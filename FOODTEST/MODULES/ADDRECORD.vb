Module ADDRECORD
    Public Sub AddRecord()
        If BackRS Is Nothing Then Exit Sub
        MODULECONTROLS.clearControls()
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    .lblTestNumber.Text = "0"
                    .dtpSampleStamp.Value = Date.Now
                    .cmbReqBy.Text = UCase(UserName)
                    .cmbReqDept.Text = ""
                    .txtCompo.Text = "1"
                    .txtPlcSamp.Text = ""
                    .txtAreaTemp.Text = "0.00"
                    .txtSampleQty.Text = "0.00"
                    .lblStatus.Text = "PENDING"
                    .CheckBox4.Checked = False
                    .CheckBox5.Checked = True
                    .RadioButton6.Checked = False
                    .RadioButton7.Checked = True
                End With
            Case SAMPLING.Name
                With SAMPLING
                    .lblStatus.Text = "Open"
                    '.rbInit.Checked = True
                    .lblRowStamp.Text = "0"
                    .GetApprovedRequest()
                End With
            Case Else
        End Select
        MAINFORM.txtCurPos.Text = "0"
        MODULECONTROLS.clearMisc()

        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    .cmbReqBy.Text = UserName
                End With
            Case Else
        End Select


        SAVES.TransLevel = 1
    End Sub

End Module
