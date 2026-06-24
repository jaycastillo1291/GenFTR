Public Class SampleReceivedStat
    Private Sub SampleReceivedStat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbSR1Yes.Checked = 1 : rbSR1No.Checked = 0
        rbSR2Yes.Checked = 1 : rbSR2No.Checked = 0
        rbSR3Yes.Checked = 1 : rbSR3No.Checked = 0
        rbSR4Yes.Checked = 1 : rbSR4No.Checked = 0
        rbSR5Yes.Checked = 1 : rbSR5No.Checked = 0
        rbSR6Yes.Checked = 1 : rbSR6No.Checked = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With SAMPLING
            .rbSR1Yes.Checked = Me.rbSR1Yes.Checked : .rbSR1No.Checked = Me.rbSR1No.Checked
            .rbSR2Yes.Checked = Me.rbSR2Yes.Checked : .rbSR2No.Checked = Me.rbSR2No.Checked
            .rbSR3Yes.Checked = Me.rbSR3Yes.Checked : .rbSR3No.Checked = Me.rbSR3No.Checked
            .rbSR4Yes.Checked = Me.rbSR4Yes.Checked : .rbSR4No.Checked = Me.rbSR4No.Checked
            .rbSR5Yes.Checked = Me.rbSR5Yes.Checked : .rbSR5No.Checked = Me.rbSR5No.Checked
            .rbSR6Yes.Checked = Me.rbSR6Yes.Checked : .rbSR6No.Checked = Me.rbSR6No.Checked
        End With
        Me.Dispose()
        Me.Close()
    End Sub
End Class