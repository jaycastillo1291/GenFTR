Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Threading
Imports System.Text
Imports System.Diagnostics

Module COMMONFUNCTION
    Public Sub ClosePreviousInstances()
        ' Get the name of the current process
        Dim currentProcess As Process = Process.GetCurrentProcess()

        ' Get all running processes with the same name
        Dim runningProcesses As Process() = Process.GetProcessesByName(currentProcess.ProcessName)

        For Each p As Process In runningProcesses
            ' Only kill it if it's NOT the current running instance
            If p.Id <> currentProcess.Id Then
                Try
                    ' Attempt a graceful close first
                    p.CloseMainWindow()

                    ' Wait up to 2 seconds for it to exit
                    If Not p.WaitForExit(2000) Then
                        ' If it's still hanging (deadlocked), force it to stop
                        p.Kill()
                    End If
                Catch ex As Exception
                    ' Likely an access denied error if another user is running it 
                    ' (usually not an issue on the client side)
                End Try
            End If
        Next
    End Sub
    Public Sub HandleOldInstances()
        Dim current As Process = Process.GetCurrentProcess()

        For Each proc As Process In Process.GetProcessesByName(current.ProcessName)
            If proc.Id <> current.Id Then
                Try
                    If Not proc.Responding Then
                        proc.Kill()
                    End If
                Catch ex As Exception
                    ' Ignore errors
                End Try
            End If
        Next
    End Sub

    Public Enum AccessTypes
        cAdd = 1
        cEdit = 2
        cDelete = 3
        cRead = 4
    End Enum


    Public dblGlobalFormat As String = "#,##0.00"
    Public intGlobalFormat As String = "#,##0"
    Public dtGlobalFormat As String = "MM/dd/yyyy HH:mm"

    Public Function RQ(ByVal strRQ)
        strRQ = Replace(strRQ, "'", "`")
        Return strRQ
    End Function

    Public Sub Auto1(ByVal cmb As ComboBox, ByVal strQry As String, ByVal stTbl As String)
        Dim dal As New DataAccessLayer
        dal.ExecuteQuery(strQry)
        With cmb
            .DataSource = dal.ExecuteQuery(strQry)
            .ValueMember = "Code"
            .DisplayMember = "Description"
            .SelectedIndex = 0
            .MaxDropDownItems = 8
        End With

        'Dim locDaOle As New OleDbDataAdapter
        'Dim locDa As New DataSet
        'rs = cn.Execute(strQry)
        'If rs.EOF Then Exit Sub

        'locDaOle.Fill(locDa, rs, stTbl)
        'cmb.DisplayMember = "Description"
        'cmb.ValueMember = "Code"
        'cmb.DataSource = locDa.Tables(stTbl)

        ''If Not rs.EOF Then cmb.SelectedIndex = 1
        'cmb.SelectedIndex = 0
    End Sub


    Public Function ServerDate() As DateTime
        'Connect()
        Try
            ServerDate = DateTime.Now

            Dim dal As New DataAccessLayer
            Dim dt = dal.ExecuteQuery("SELECT FORMAT(GETDATE(), '" & dtGlobalFormat & "') ServerDate")
            For Each row As DataRow In dt.Rows
                ServerDate = row("ServerDate")
            Next
            Return ServerDate
            'Return (cn.Execute("SELECT GetDate()")).Fields(0).Value
        Catch ex As Exception
            Return Date.Now
        End Try
    End Function

    Public Function GetAuthorization(ByVal ModuleName As String, ByVal AccessName As String, AccessType As AccessTypes) As Boolean
        'AccessType should be "Read", "Add", "Edit" and "Delete"
        GetAuthorization = False
        Dim dal As New DataAccessLayer
        Dim strQry = ""
        Select Case AccessType
            Case 4 '"Read"
                strQry = "SELECT top 1 cRead FROM vwGroupAuth WHERE Module = @Module and AccessName = @AccessName and GroupName = @Groupname"
            Case 1 '"Add"
                strQry = "SELECT top 1 cAdd FROM vwGroupAuth WHERE Module = @Module and AccessName = @AccessName and GroupName = @Groupname"
            Case 2 '"Edit"
                strQry = "SELECT top 1 cEdit FROM vwGroupAuth WHERE Module = @Module and AccessName = @AccessName and GroupName = @Groupname"
            Case 3 '"Delete"
                strQry = "SELECT top 1 cDelete FROM vwGroupAuth WHERE Module = @Module and AccessName = @AccessName and GroupName = @Groupname"
        End Select

        dal.StrParams.Add("Module", ModuleName)
        dal.StrParams.Add("AccessName", AccessName)
        dal.StrParams.Add("GroupName", GroupName)

        GetAuthorization = dal.ExecuteScalar(strQry)


        Return GetAuthorization
    End Function


    Public Function RandomString() As String
        Dim r As Random = Nothing
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        r = New Random
        Dim cnt As Integer = r.Next(10, 15)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Public Sub GlobalCleanup()
        ' 1. Close and Dispose SQL Connection
        ' Check if your connection variable (e.g., 'cn') exists and is open
        'Try
        '    If cn IsNot Nothing Then
        '        ' Best practice: check state before closing
        '        If cn.State <> ConnectionState.Closed Then
        '            cn.Close()
        '        End If
        '        cn.Dispose()
        '        cn = Nothing
        '    End If
        'Catch
        '    ' Silently fail so the program shutdown continues
        '    cn = Nothing
        'End Try

        '' 2. Dispose of all other forms except the one currently running this code
        '' This handles any hidden forms hanging out in memory
        'For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
        '    Dim f As Form = Application.OpenForms(i)
        '    ' Don't close the current form yet, or the loop might break
        '    If f IsNot Form.ActiveForm Then
        '        f.Dispose()
        '    End If
        'Next

        Try
            ' 1. DISPOSE HIDDEN FORMS
            ' Loop backwards through open forms to avoid index errors
            For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                Dim f As Form = Application.OpenForms(i)
                If f IsNot Form.ActiveForm Then
                    f.Dispose()
                End If
            Next

            ' 2. CLOSE GLOBAL CONNECTION
            ' Using OrElse prevents the "NullReference" crash you saw earlier
            If cn IsNot Nothing Then
                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                End If
                cn.Dispose()
                cn = Nothing
            End If

            '' 3. TERMINATE DATA ACCESS LAYER
            '' Call your DAL's specific cleanup method
            'YourDALClass.DisposeDAL()

        Catch ex As Exception
            ' If something goes wrong, force the process to end anyway
        Finally
            ' Final command to ensure the Windows Message Loop stops
            'MsgBox("Exiting the application." & vbCrLf & "Please contact IT Administrator for inquiries and further assistance.", vbInformation)
            System.Environment.Exit(0)
        End Try

    End Sub


End Module
