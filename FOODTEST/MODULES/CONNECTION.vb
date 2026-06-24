
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices ' Necessary for the Marshal command

Module CONNECTION
    Public rs As New ADODB.Recordset
    Public cn As New ADODB.Connection
    Public FrontRS As New ADODB.Recordset
    Public BackRS As New ADODB.Recordset
    Public cnLastAttempt As New DateTime

    Public crtableLogoninfo As New TableLogOnInfo
    Public crConnectionInfo As New ConnectionInfo


    Public UserName As String
    Public GroupName As String
    Public GroupDescription As String


    Public strConPwd As String
    Public strDBName As String


    Public isConnected As Boolean



    Public oledbc As New SqlCommand
    Public oledbdr As SqlDataReader
    Public dconn As New SqlConnection
    Public da As New SqlDataAdapter


    Public Sub Connect()

        Dim strConUID As String

        Dim strSvrName As String
        Dim strServerAdd As String
        Dim strNewSvrName As String
        Dim strNewSvrAdd As String


        strNewSvrName = "192.168.11.5,51909"
        strNewSvrAdd = "192.168.11.5"


        strNewSvrName = "192.168.11.5\sql2k14"
        strNewSvrAdd = "192.168.11.5"

        'Dim fileReader As System.IO.StreamReader
        'fileReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\ServerName.txt")

        'for better understanding, here's the code block

        If (Not IsNothing(cn)) AndAlso cn.State > 0 Then Exit Sub
        'If SAVES.TransLevel > 0 Then Exit Sub

        'Removed due to ESET blocking. tagged as bruteforce
        'Using fileReader As New System.IO.StreamReader(Application.StartupPath & "\ServerName.txt")
        '    Dim stringReader As String
        '    stringReader = fileReader.ReadLine()
        '    strNewSvrName = stringReader
        '    stringReader = fileReader.ReadLine()
        '    strNewSvrAdd = stringReader

        '    fileReader.Close()
        'End Using

        'fileReader.Dispose()

        'Connection for SQL Commands
        strConUID = "sa"
        strConPwd = "GenOSI2017"
        strDBName = "FOODSAMPLING"

        isConnected = False

        'strSvrName = "192.168.11.5\sql2k14"
        'strServerAdd = "192.168.11.17"
        strSvrName = "192.168.11.5,51909"
        strServerAdd = "192.168.11.5"

        If strNewSvrName <> "" Then strSvrName = strNewSvrName
        If strNewSvrAdd <> "" Then strServerAdd = strNewSvrAdd


        'removed reading of textfile due to eset blocking. to prevent tagged as bruteforce
        'Hindi pala ito ung main reason ng ESET blocking. 
        strSvrName = "192.168.11.5\sql2k14"
        strServerAdd = "192.168.11.5"



        ' 1. Clening variables from StreamReader to prevent hidden character hangs
        Dim cleanSvr As String = strNewSvrName.Trim().Replace(vbCr, "").Replace(vbLf, "")
        Dim cleanDB As String = strDBName.Trim().Replace(vbCr, "").Replace(vbLf, "")

        ' 2. Construct the OLE DB Connection String (No ODBC/DSN involved)
        ' We use Provider=SQLOLEDB for a direct path to the SQL engine.
        'Dim directConnString As String = "Provider=SQLOLEDB;" &
        '                         "Data Source=" & cleanSvr & ";" &
        '                         "Initial Catalog=" & cleanDB & ";" &
        '                         "User ID=sa;" &
        '                         "Password=GenOSI2017;" &
        '                         "Network Library=DBMSSOCN;" &
        '                         "Workstation ID=" & Environment.MachineName & ";"

        Dim directConnString As String = "Provider=SQLOLEDB;" &
                           "Data Source=" & cleanSvr.Trim() & ";" &
                           "Initial Catalog=" & cleanDB.Trim() & ";" &
                           "User ID=sa;" &
                           "Password=GenOSI2017;" &
                           "Network Library=DBMSSOCN;" &
                           "Workstation ID=" & Environment.MachineName & ";"

        ' 3. Initialize the connection object
        cn = New ADODB.Connection With {
        .CursorLocation = ADODB.CursorLocationEnum.adUseClient,
        .IsolationLevel = ADODB.IsolationLevelEnum.adXactBrowse,
        .CommandTimeout = 60,
        .ConnectionTimeout = 20,
        .ConnectionString = directConnString
}

        'If SAVES.TransLevel > 0 Then Exit Sub
        'para sa immediate query
        'If cn.State <> 0 Then
        '    cn = New ADODB.Connection
        'End If
        'cn = New ADODB.Connection With {
        '    .CursorLocation = ADODB.CursorLocationEnum.adUseClient,
        '    .IsolationLevel = ADODB.IsolationLevelEnum.adXactBrowse,
        '    .CommandTimeout = 2000,
        '    .ConnectionTimeout = 20,
        '    .ConnectionString = "DSN=" & strDBName & ";app=Microsoft® Visual Studio® 2008;wsid=" & strServerAdd & ";database=" & strDBName & ";Uid=sa;Pwd=GenOSI2017;"
        '    }

        'Dim directConnString As String = "Provider=SQLOLEDB;" &
        '                         "Data Source=" & cleanSvr & ";" &
        '                         "Initial Catalog=" & cleanDB & ";" &
        '                         "User ID=sa;" &
        '                         "Password=GenOSI2017;" &
        '                         "Network Library=DBMSSOCN;" &
        '                         "Workstation ID=" & Environment.MachineName & ";"

        'cn = New ADODB.Connection With {
        '    .CursorLocation = ADODB.CursorLocationEnum.adUseClient,
        '    .IsolationLevel = ADODB.IsolationLevelEnum.adXactBrowse,
        '    .CommandTimeout = 2000,
        '    .ConnectionTimeout = 20,
        '    .ConnectionString = directConnString
        '    }




        'dconn = New SqlConnection("Data Source=" & strNewSvrName & ";Initial Catalog=FOODSAMPLING;User ID=sa;Password=GenOSI2017;WSID=" & Environment.MachineName)

        dconn = New SqlConnection("Data Source=" & strNewSvrName.Trim() & ";" &
                           "Initial Catalog=" & strDBName.Trim() & ";" &
                           "User ID=sa;" &
                           "Password=GenOSI2017;" &
                           "Network Library=DBMSSOCN;" &
                           "Workstation ID=" & Environment.MachineName & ";")
        Try
            If Not (cn IsNot Nothing AndAlso (cn.State And ADODB.ObjectStateEnum.adStateOpen) = ADODB.ObjectStateEnum.adStateOpen) Then
                If (DateTime.Now - cnLastAttempt).TotalMilliseconds <= 2000 Then
                    Dim slFor = 2000 - (DateTime.Now - cnLastAttempt).TotalMilliseconds
                    System.Threading.Thread.Sleep(slFor)
                    'MsgBox("Slept for " & slFor)
                End If

                cn.Open()
                dconn.Open()
            End If
            isConnected = True
        Catch ex As Exception
            MsgBox("Cannot connect QUERY command to the server. Please report to IT Administrator" & vbCrLf & "Error Code:  " & ex.Message, vbCritical)
            isConnected = False

            GlobalCleanup()
            'Exit Sub
            'Application.Exit()
        End Try




        Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US", False)

        Try
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "MM/dd/yyyy")
        Catch ex As Exception
            MsgBox("Error with setting Short Date. Please report to IT Administrator.")
        End Try
    End Sub


    Public Sub DisconnectCN()
        Exit Sub
        Try
            If cn IsNot Nothing Then
                ' 1. Check if it's open (State 1 = adStateOpen)
                If (cn.State And 1) = 1 Then
                    cn.Close()
                End If

                ' 2. FORCE the COM object to release its hold on the network socket
                ' Without this, the "Ghost" connection often lingers.
                Marshal.ReleaseComObject(cn)

                ' 3. Clear the reference
                cn = Nothing
            End If

            ' 4. Prompt the Garbage Collector to tidy up
            GC.Collect()
            GC.WaitForPendingFinalizers()

            isConnected = False
        Catch ex As Exception
            ' Silent fail during disconnect to prevent crash loops
        End Try
    End Sub


    Public Function SelectQry(strQry As String, strParams(,) As String) As SqlDataAdapter
        SelectQry = Nothing

        Connect()

        With oledbc
            .Connection = dconn
            .CommandText = strQry
            .CommandType = CommandType.Text
            Dim x = 0
            For x = 1 To strParams.Length
                .Parameters.Add(New SqlParameter(strParams(0, x), strParams(1, x)))
            Next

            oledbdr = oledbc.ExecuteReader
            .Parameters.Clear()
        End With

        While oledbdr.Read()
            MsgBox(oledbdr("ColumnName"))
        End While

        dconn.Close()


        Return SelectQry
    End Function



    Private Sub testInsert()
        With oledbc
            .Connection = dconn
            .CommandText = "INSERT INTO Leave_Entry VALUES(@LeaveNo,@EmpNo,@FromLeaveDate,@ToLeaveDate,@TypeofLeave," &
                " @Remarks,@iscompGrant,'Open',@DateAdded,@DateUpdated,@EnteredBy,'')"
            .CommandType = CommandType.Text

            oledbc.Parameters.Add(New SqlParameter("@LeaveNo", ""))
            oledbc.Parameters.Add(New SqlParameter("@EmpNo", ""))
            oledbc.Parameters.Add(New SqlParameter("@FromLeaveDate", ""))
            oledbc.Parameters.Add(New SqlParameter("@ToLeaveDate", ""))
            oledbc.Parameters.Add(New SqlParameter("@TypeofLeave", ""))
            oledbc.Parameters.Add(New SqlParameter("@Remarks", ""))
            oledbc.Parameters.Add(New SqlParameter("@isCompGrant", ""))
            oledbc.Parameters.Add(New SqlParameter("@DateAdded", ""))
            oledbc.Parameters.Add(New SqlParameter("@DateUpdated", ""))
            oledbc.Parameters.Add(New SqlParameter("@EnteredBy", ""))


            .ExecuteNonQuery()
            .Parameters.Clear()
        End With
        dconn.Close()
    End Sub


    Private Sub testSelect()
        With oledbc
            .Connection = dconn
            .CommandText = "SELECT * FROM (SELECT * FROM Leave_Entry" _
                         & " UNION" _
                         & " SELECT * FROM Leave_Entry_Deleted) a_1 WHERE LeaveNo = @LeaveNo"
            .CommandType = CommandType.Text
            .Parameters.Add(New SqlParameter("@LeaveNo", "TESTDATA"))
            oledbdr = oledbc.ExecuteReader
            .Parameters.Clear()
        End With

        While oledbdr.Read()
            MsgBox(oledbdr("ColumnName"))
        End While

        dconn.Close()
    End Sub


    Private Sub testWithNavigation()
        Dim dtData As New DataTable()
        Dim bsData As New BindingSource()


        Using connection As New SqlConnection("SELECT * FROM USERNAMES")
            Call Connect()

            Using adapter As New SqlDataAdapter("SELECT Column1, Column2 FROM YourTable", dconn)
                dtData.Clear() ' Clear previous data
                adapter.Fill(dtData)
                bsData.DataSource = dtData
                ' Bind controls to BindingSource
                Dim TextBox1, TextBox2 As New TextBox

                TextBox1.DataBindings.Add("Text", bsData, "Column1")
                TextBox2.DataBindings.Add("Text", bsData, "Column2")
            End Using
        End Using

        bsData.MoveNext()
        bsData.MovePrevious()
        bsData.MoveFirst()
        bsData.MoveLast()

    End Sub


    Public Sub CrystalLogin()
        With crConnectionInfo
            .ServerName = strdbname
            .DatabaseName = "FOODSAMPLING"
            '.IntegratedSecurity = True
            .UserID = "sa"
            .Password = "GenOSI2017"
        End With
    End Sub

End Module
