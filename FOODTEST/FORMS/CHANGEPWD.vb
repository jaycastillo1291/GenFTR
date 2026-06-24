Public Class CHANGEPWD
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.Compare(TextBox1.Text, TextBox2.Text, False) <> 0 Then MsgBox("Password not match.") : Exit Sub
        'cn.Execute("UPDATE LoginNames Set PWD = ENCRYPTBYPASSPHRASE('ctltphUs3r', '" & RQ(TextBox1.Text).GetHashCode & "'), ModifiedBy = '" & LoginForm1.txtUID.Text & "', ModifiedDate = '" & ServerDate() & "' WHERE  UserName = '" & LoginForm1.txtUID.Text & "'")

        'Dim strQry = "UPDATE LoginNames Set PWD = ENCRYPTBYPASSPHRASE('ctltphUs3r', HASHBYTES('SHA1','" & RQ(TextBox1.Text) & "')), ModifiedBy = '" & LOGIN.txtUserName.Text & "', ModifiedDate = '" & ServerDate() & "' WHERE  UserName = '" & LOGIN.txtUserName.Text & "'"

        Dim strQry = "UPDATE LoginNames Set PWD = ENCRYPTBYPASSPHRASE('ctltphUs3r', HASHBYTES('SHA1',cast(@NewPass as varchar(200)))), ModifiedBy = @username, ModifiedDate = getdate() WHERE  UserName = @Username"

        'cn.Execute(strQry)
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("NewPass", RQ(TextBox1.Text))
        dal.StrParams.Add("UserName", RQ(LOGIN.txtUserName.Text))
        Dim i = dal.ExecuteNonQuery(strQry)

        MsgBox(CStr(i) & " records update.", MsgBoxStyle.Information)
        LOGIN.cbChangePass.Checked = False
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CHANGEPWD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class