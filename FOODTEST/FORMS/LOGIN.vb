Imports System.ComponentModel

Public Class LOGIN


    Private Property MoveForm As Boolean
    Private Property Moveform_Position As Point

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim struserName = Trim(txtUserName.Text), strPass = Trim(txtPass.Text)

        'for testing only
        'UserName = "TEST"
        'GroupName = "TEST Group"
        'MAINFORM.Logged = True
        'Me.Close()
        'Exit Sub
        '----------------


        If struserName = "" Then
            MsgBox("Username is a required field.")
            txtUserName.Focus()
            txtUserName.SelectAll()
            Exit Sub
        End If


        If strPass = "" Then
            MsgBox("Password is a required field.")
            txtPass.Focus()
            txtPass.SelectAll()
            Exit Sub
        End If


        'Connect()
        Dim strQryLogin = "select T1.Username, T1.GroupName, T2.GroupDescription, T1.isActive, T2.Hold, T2.AllowToChangePwd
                         from LOGINNAMES T1 
	                         INNER JOIN LOGIN_GroupNames T2 on t1.GroupName = T2.GroupName
                         WHERE Username = '" & struserName & "' and 
	                        cast(DECRYPTBYPASSPHRASE('ctltphUs3r', T1.PWD) as varchar) = HASHBYTES('SHA1','" & strPass & "')"

        Dim dal As New DataAccessLayer
        dal.StrParams.Add("UserName", struserName)
        dal.StrParams.Add("Pass", strPass)

        strQryLogin = "select T1.Username, T1.GroupName, T2.GroupDescription, T1.isActive, T2.Hold, T2.AllowToChangePwd
                         from LOGINNAMES T1 
	                         INNER JOIN LOGIN_GroupNames T2 on t1.GroupName = T2.GroupName
                         WHERE Username = @Username and 
	                        cast(DECRYPTBYPASSPHRASE('ctltphUs3r', T1.PWD) as varchar) = HASHBYTES('SHA1',cast(@Pass as varchar(50)))"

        Dim dt = dal.ExecuteQuery(strQryLogin)

        If dt.Rows.Count <= 0 Then
            MsgBox("Username and Password do not match. Please check the log in info.", vbCritical)
            txtUserName.Focus()
            txtUserName.SelectAll()
            Exit Sub
        End If

        'User is not Active
        If Not dt.Rows(0)("isActive") Then
            MsgBox("You are trying to log in an INACTIVE account.", vbInformation)
            Exit Sub
        End If

        'User is OnHold
        If dt.Rows(0)("Hold") Then
            MsgBox("Account you tried to log in is currently ON-HOLD.", vbInformation)
            Exit Sub
        End If

        If cbChangePass.Checked Then

            'User is not allowed to change password
            If Not dt.Rows(0)("AllowToChangePwd") Then
                MsgBox("This account is not allowed for changing password.", vbInformation)
                Exit Sub
            End If
            CHANGEPWD.ShowDialog()
            MsgBox("Please enter your username and password again.")
            'txtUserName.Text = ""
            txtPass.Text = ""
            txtPass.Focus()
            Exit Sub
        End If

        UserName = dt.Rows(0)("UserName").ToString.ToUpper
        GroupName = dt.Rows(0)("GroupName").ToString.ToUpper
        GroupDescription = dt.Rows(0)("GroupDescription").ToString.ToUpper
        MAINFORM.Logged = True

        If UserName = "" Then
            MsgBox("No Logged user detected. Please Report to Administrator.")
        Else
            MAINFORM.lblUserName.Text = UserName
            MAINFORM.lblGroupName.Text = GroupDescription
        End If


        MAINFORM.Show()
        Me.Close()




        'rs = Nothing
        'rs = cn.Execute(strQryLogin)

        'If rs.EOF Then
        '    MsgBox("Username and Password do not match. Please check the log in info.", vbCritical)
        '    txtUserName.Focus()
        '    txtUserName.SelectAll()
        '    Exit Sub
        'Else
        '    'User is not Active
        '    If Not rs.Fields("isActive").Value Then
        '        MsgBox("You are trying to log in an INACTIVE account.", vbInformation)
        '        Exit Sub
        '    End If

        '    'User is OnHold
        '    If rs.Fields("Hold").Value Then
        '        MsgBox("Account you tried to log in is currently ON-HOLD.", vbInformation)
        '        Exit Sub
        '    End If

        '    If cbChangePass.Checked Then

        '        'User is not allowed to change password
        '        If Not rs.Fields("AllowToChangePwd").Value Then
        '            MsgBox("This account is not allowed for changing password.", vbInformation)
        '            Exit Sub
        '        End If
        '        CHANGEPWD.ShowDialog()
        '        MsgBox("Please enter your username and password again.")
        '        'txtUserName.Text = ""
        '        txtPass.Text = ""
        '        txtPass.Focus()
        '        Exit Sub
        '    End If

        '    UserName = rs.Fields("UserName").Value.ToString.ToUpper
        '    GroupName = rs.Fields("GroupName").Value.ToString.ToUpper
        '    GroupDescription = rs.Fields("GroupDescription").Value.ToString.ToUpper
        '    MAINFORM.Logged = True
        '    MAINFORM.Show()
        '    Me.Close()
        'End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click, Button1.Click
        'Application.Exit()
        If MsgBox("Are you sure you want to exit the system?", vbYesNo) = vbNo Then Exit Sub
        Environment.Exit(0)
        Me.Close()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    'Application.Exit()
    '    Environment.Exit(0)
    '    Me.Close()
    'End Sub

    Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserName.Text = ""
        txtPass.Text = ""
        'Connect()
        'Exit Sub

        Dim dal As New DataAccessLayer
        Dim dt = dal.ExecuteQuery("select VarName, VarValue from GlobalVariable WHERE VarName = 'SystemMaintenenace'")
        If dt.Rows.Count <= 0 Then
            MsgBox("Error in reading System Variables. Please report to IT Administrator.")
            GlobalCleanup()
            'Application.Exit()
            Me.Close()
        End If


        If dt.Rows(0)("VarValue") = "1" And Environment.MachineName <> "GEN-IT-LP2" Then
            MsgBox("System is under maintenance and not available at the moment. " & vbCrLf & "Please call IT Administrator for more details.")
            GlobalCleanup()
            'Application.Exit()
            Me.Close()
        End If

        'rs = Nothing
        'rs = cn.Execute("select VarName, VarValue from GlobalVariable WHERE VarName = 'SystemMaintenenace'")
        'If rs.RecordCount <= 0 Then
        '    MsgBox("Error in reading System Variables. Please report to IT Administrator.")
        '    Application.Exit()
        '    Me.Close()
        'End If


        'If rs.Fields("VarValue").Value = "1" And Environment.MachineName <> "GEN-IT-LP2" Then
        '    MsgBox("System is under maintenance and not available at the moment. " & vbCrLf & "Please call IT Administrator for more details.")
        '    Application.Exit()
        '    Me.Close()
        'End If

        'DisconnectCN()
        txtUserName.Focus()

    End Sub

    Private Sub LOGIN_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pb2.MouseDown, pbPass.MouseDown, pbUser.MouseDown, lblTitle.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            Moveform_Position = e.Location
        End If
    End Sub

    Private Sub LOGIN_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, pb2.MouseUp, pbPass.MouseUp, pbUser.MouseUp, lblTitle.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
            Moveform_Position = e.Location
        End If
    End Sub

    Private Sub LOGIN_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, pb2.MouseMove, pbPass.MouseMove, pbUser.MouseMove, lblTitle.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - Moveform_Position)
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dal As New DataAccessLayer
        Dim strQry = "select * from TESTORDER_D WHERE HeadRS = @HeadRS"
        Dim strContent = ""
        dal.StrParams.Add("HeadRS", "30")
        dal.SetConnectionString()
        Dim dt As DataTable = dal.ExecuteQuery(strQry)
        For Each row As DataRow In dt.Rows
            strContent += row("HeadRS") & " " & row("Code") & vbCrLf
        Next
        MsgBox(strContent)

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles pbPeek1.MouseDown
        pbPeek1.Image = My.Resources.pwnvis
        txtPass.PasswordChar = Nothing
    End Sub

    Private Sub pbPeek1_MouseUp(sender As Object, e As MouseEventArgs) Handles pbPeek1.MouseUp
        pbPeek1.Image = My.Resources.pwvis
        txtPass.PasswordChar = "*"
    End Sub

    'Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
    '    Dim openfiledialog As New OpenFileDialog
    '    openfiledialog.Filter = "Image File (*.png, *jpg, *.jpeg) | *.png; *jpg; *.jpeg"
    '    openfiledialog.Multiselect = False

    '    If openfiledialog.ShowDialog = DialogResult.OK Then
    '        MsgBox("ayos naman")
    '    End If
    'End Sub

    'Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    'Private Sub LOGIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    If MsgBox("Are you sure you want to exit the application?", vbYesNo) = vbNo Then Exit Sub
    'End Sub
End Class
