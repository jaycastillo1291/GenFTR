Public Class REJECTSAMPLING
    Private Sub REJECTSAMPLING_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkRR1.Checked = 0
        chkRR2.Checked = 0
        chkRR3.Checked = 0
        chkRR4.Checked = 0
        chkRR5.Checked = 0
        chkRROther.Checked = 0
        txtRROthText.Text = "" : txtRROthText.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If chkRR1.Checked = 0 And chkRR2.Checked = 0 And chkRR3.Checked = 0 And chkRR4.Checked = 0 And chkRR5.Checked = 0 And
            (chkRROther.Checked = 0 Or (chkRROther.Checked <> 1 And txtRROthText.Text = "")) Then
            If MsgBox("At least one reason is required to reject a request." &
                      vbCrLf & "Do you wish to cancel rejecting the entry?", vbYesNo, "Reject Request") = vbYes Then
                GoTo skipAppend
            Else
                Exit Sub
            End If
        Else
            With SAMPLING
                .chkRR1.Checked = Me.chkRR1.Checked
                .chkRR2.Checked = Me.chkRR2.Checked
                .chkRR3.Checked = Me.chkRR3.Checked
                .chkRR4.Checked = Me.chkRR4.Checked
                .chkRR5.Checked = Me.chkRR5.Checked
                .chkRROther.Checked = Me.chkRROther.Checked : .txtRROthText.Text = Me.txtRROthText.Text
                .lblStatus.Text = "Rejected"
                .lblRejectedBy.Text = UserName
                .lblRejectDate.Text = ServerDate().ToString("MM/dd/yyyy HH:mm")
            End With

skipAppend:
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If


    End Sub

    Private Sub chkRROther_CheckedChanged(sender As Object, e As EventArgs) Handles chkRROther.CheckedChanged
        If Not (chkRROther.Checked) And txtRROthText.Text <> "" Then
            If MsgBox("Unchecking will remove the encoded text." & vbCrLf & "Continue?", vbYesNo) = vbYes Then
                txtRROthText.Text = ""

            End If
        End If

        txtRROthText.Enabled = chkRROther.Checked
    End Sub
End Class