Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Runtime.InteropServices ' Mandatory for Marshal
Public Class MAINFORM

    Public fSelectedForm As New Form
    Public Logged = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'HandleOldInstances()
        ClosePreviousInstances()
        Dim dalCon As New DataAccessLayer
        Try
            Dim ConnectionTest = (dalCon.ExecuteQuery("SELECT COUNT(GETDATE()) VarValue"))(0)("VarValue")
            isConnected = IIf(ConnectionTest, True, False)
        Catch ex As Exception
            MsgBox("Cannot connect to the server. Please contact IT Administrator.", vbCritical)
            GlobalCleanup()
        End Try


        'Connect()
        If Not (isConnected) Then
            MsgBox("Cannot connect to the server." & vbCrLf & "Exiting the application.", vbCritical)
            GlobalCleanup()
        End If
        'Do While Not Logged
        Me.Hide()
            LOGIN.ShowDialog()
        If Not Logged Then GlobalCleanup()
        'If UserName = "" Then
        '    MsgBox("No Logged user detected. Please Report to Administrator.")
        'Else
        '    Me.lblUserName.Text = UserName
        '    Me.lblGroupName.Text = GroupDescription

        'End If
        'Loop
        'DisconnectCN()
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load(Application.StartupPath & "\REPORTS\Report_Load.rpt")
    End Sub

    Private Sub tvDisplayModule(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvModuleList.NodeMouseDoubleClick
        'fSelectedForm = Nothing
        fSelectedForm.Dispose()
        fSelectedForm = New Form
        'H_Table = ""

        Select Case e.Node.Name
            Case "nTestRequest"
                fSelectedForm = TESTREQ
            Case "nFoodTest"
                fSelectedForm = SAMPLING
            Case "nTestMasterList"
                fSelectedForm = TESTLIST
            Case "nTestApprove"
                fSelectedForm = APPROVAL
            Case Else
                MsgBox("No module to show.")
                Exit Sub
        End Select

        Dim dal As New DataAccessLayer
        Dim strqry = "SELECT count(cRead) isAllowed FROM vwGroupAuth WHERE GroupName = @Groupname and AccessName = @AccessName and Module = 'MAINFORM' and cRead = 1"
        dal.StrParams.Add("AccessName", fSelectedForm.AccessibleName)
        dal.StrParams.Add("Groupname", GroupName)

        Dim isAllowed = dal.ExecuteScalar(strqry)

        If isAllowed > 0 Then
            MODULECONTROLS.LOADFORM(fSelectedForm)
        Else
            MsgBox("You are not allowed to access this module. Please contact IT Administrator to gain access in this module.", vbCritical)
            Exit Sub
        End If

    End Sub

    Private Sub MoveRecord(sender As Object, e As EventArgs) Handles btnMoveFirst.Click, btnMovePrev.Click, btnMoveNext.Click, btnMoveLast.Click
        'Select Case DirectCast(sender, Button).Name
        Validate()
        If BackRS Is Nothing Then
            'If Me.pDashboard.Controls.Count >= 1 Then
            '    Me.pDashboard.Controls.Clear()
            '    fSelectedForm = DirectCast(Me.pDashboard.Controls(0), Form)
            'Else
            'End If

            Me.fSelectedForm = Nothing
            'EnableControls()
            DisableNavigation()
            Exit Sub
        End If
        If BackRS.RecordCount <= 0 Then MsgBox("No records found!") : Exit Sub
        'Validate()
        'If isEditing Then
        '    If MsgBox("You are currently editing an entry." & vbCrLf & "Doing this action might lose your encoded data." & vbCrLf & "Continue without saving?", vbYesNo) = vbNo Then
        '        Exit Sub
        '    End If
        'End If
        'If isEditing Or TransLevel > 0 Then
        '    If MsgBox("You are currently editing an entry." & vbCrLf & "Doing this action might lose your encoded data." & vbCrLf & "Continue without saving?", vbYesNo) = vbNo Then
        '        Exit Sub
        '    End If
        'End If

        Select Case TransLevel
            Case 0

            Case 1 'Adding
                If MsgBox("You are currently Adding an entry." & vbCrLf & "Doing this action might lose your encoded data." & vbCrLf & "Continue without saving?", vbYesNo) = vbNo Then
                    Exit Sub
                Else
                    TransLevel = 0
                End If

            Case 2 'Editing
                If MsgBox("You are currently editing an entry." & vbCrLf & "Doing this action might lose your encoded data." & vbCrLf & "Continue without saving?", vbYesNo) = vbNo Then
                    Exit Sub
                Else
                    TransLevel = 0
                End If

            Case 3

            Case Else

        End Select

        Select Case sender.Name
            Case btnMoveFirst.Name
                MODULECONTROLS.MoveRecord("First")
            Case btnMovePrev.Name
                MODULECONTROLS.MoveRecord("Prev")
            Case btnMoveNext.Name
                MODULECONTROLS.MoveRecord("Next")
            Case btnMoveLast.Name
                MODULECONTROLS.MoveRecord("Last")
        End Select
        isEditing = False
        TransLevel = 0
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Validate()

        If fSelectedForm Is Nothing Then Exit Sub

        If Not GetAuthorization("MAINFORM", fSelectedForm.AccessibleName, AccessTypes.cAdd) Then
            MsgBox("You are not allowed to addrecord in this module. Please ask Administrator assistance.", vbCritical)
            Exit Sub
        End If

        If isEditing Then
            If MsgBox("You are currently adding an entry." & vbCrLf & "Doing this action might lose your encoded data." & vbCrLf & "Continue without saving?", vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If
        MODULECONTROLS.clearControls()
        ADDRECORD.AddRecord()
        'TransLevel = 1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Validate()
        Dim strQry = ""
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("ModuleName", Me.fSelectedForm.AccessibleName)
        dal.StrParams.Add("GroupName", GroupName)
        Select Case TransLevel
            Case 0
                Exit Sub
            Case 1 'Adding
                strQry = "SELECT count(cAdd) FROM vwGroupauth WHERE cAdd = 1 and Module = 'MAINFORM' and AccessName = @ModuleName and GroupName = @GroupName"
            Case 2 'Editing
                strQry = "SELECT count(cEdit) FROM vwGroupauth WHERE cEdit = 1 and Module = 'MAINFORM' and AccessName = @ModuleName and GroupName = @GroupName"
            Case 3
        End Select

        Dim accessLevel = dal.ExecuteScalar(strQry)

        If accessLevel <= 0 Then
            MsgBox("You are not allowed to perform this action. Please report to IT Administrator.", vbCritical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to save the record?", vbYesNo) = vbNo Then Exit Sub

        SAVES.BeginSave()
    End Sub

    Private Sub TestPostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestPostingToolStripMenuItem.Click
        If GetAuthorization("POSTING", "POSTING", AccessTypes.cRead) Then
            BATCHPOSTING.ShowDialog()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Me.fSelectedForm Is Nothing Then Exit Sub
        Try
            Select Case Me.fSelectedForm.Name
                Case TESTREQ.Name
                    SEARCH.strSearchForm = "TestRequest"
                    SEARCH.Text = "Search: Test Requests"
                    SEARCH.ShowDialog()
                Case SAMPLING.Name
                    SEARCH.strSearchForm = "TestRun"
                    SEARCH.Text = "Search: Test Sampling Runs"
                    SEARCH.ShowDialog()

            End Select

        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MsgBox("Are you sure you want to log out of the system?", vbYesNo) = vbNo Then Exit Sub

        UserName = ""
        GroupName = ""

        fSelectedForm.Dispose()
        fSelectedForm = New Form
        DisableNavigation()

        Me.Hide()
        LOGIN.txtUserName.Focus()
        LOGIN.ShowDialog()

    End Sub

    Private Sub MAINFORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ClosePreviousInstances()

        GlobalCleanup()

        'Try
        '    ' 1. Check if the global connection exists
        '    If cn IsNot Nothing Then
        '        ' 2. Close it if it's still open
        '        If cn.State = 1 Then
        '            cn.Close()
        '        End If

        '        ' 3. THE CRITICAL STEP: Release the COM handle
        '        ' This tells Windows to kill the network socket NOW
        '        Marshal.ReleaseComObject(cn)
        '        cn = Nothing
        '    End If

        '    ' 4. Final Garbage Collection (Optional but helpful for Multi-user)
        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()

        'Catch ex As Exception
        '    ' We don't want to crash during shutdown
        'End Try
    End Sub
End Class
