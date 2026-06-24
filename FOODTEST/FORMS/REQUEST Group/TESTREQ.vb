Public Class TESTREQ
    Private Sub TESTREQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpSampleStamp.CustomFormat = "MM/dd/yyyy HH:mm tt"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lblTestNumber.Text = "0" Or lblTestNumber.Text = "" Then Exit Sub
        'If Not CheckAuth("PRODUCTRUN", "VIEWFORM", "Read") Then Exit Sub
        If TransLevel <> 0 Then Exit Sub
        REPORTVIEWING.ShowReportDialog("ORDERSHOWFORM")
    End Sub

    Private Sub lvTestListRClick(sender As Object, e As MouseEventArgs) Handles lvTestList.MouseUp
        If e.Button = MouseButtons.Right Then
            If lblStatus.Text = "APPROVED" And lblStatus.Text <> "OPEN" Then Exit Sub
            'If lblTestNumber.Text = "0" Then MsgBox("You should first link a Request. " & vbCrLf & "Click on the 'Test Report Number' to Link a request") : Exit Sub
            cmsInit()
            'InitiateTestVariables()
            cmsListViewOptions.Show(Cursor.Position)
        End If
    End Sub


    Private Sub cmsInit()
        Dim cms = New ContextMenuStrip
        Dim item1 As ToolStripMenuItem = cms.Items.Add("Add Item")

        item1.Tag = 1
        AddHandler item1.Click, AddressOf AddItem

        If lvTestList.SelectedItems.Count > 0 Then
            If CheckGroupEdit(lvTestList.SelectedItems(0).SubItems(1).Text) Then
                Dim item2 As ToolStripMenuItem = cms.Items.Add("Delete row")
                item2.Tag = 2
                AddHandler item2.Click, AddressOf DeleteItem
            End If
        End If

        cmsListViewOptions = cms
    End Sub

    Private Sub AddItem()
        REQTESTLIST.ShowDialog()
    End Sub
    Private Sub DeleteItem()
        MsgBox("Delete Items")
    End Sub

    Private Function CheckGroupEdit(ByVal strSampGroupName) As Boolean
        CheckGroupEdit = False

        Dim dal As New DataAccessLayer
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("AccessName", strSampGroupName)
        Dim dt = dal.ExecuteQuery("select cRead from vwGroupAuth where Module = 'SAMPGROUP' and GroupName = @Groupname and AccessName = AccessName")
        If dt.Rows.Count <= 0 Then Exit Function
        If Not dt.Rows(0)("cRead") Then Exit Function

        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select cRead from vwGroupAuth where Module = 'SAMPGROUP' and GroupName = '" & GroupName & "' and AccessName = '" & strSampGroupName & "'")
        'If rs.RecordCount <= 0 Then Exit Function
        'If Not rs.Fields("cRead").Value Then Exit Function
        CheckGroupEdit = True
        'DisconnectCN()
        Return CheckGroupEdit
    End Function



    Private Sub ComboBox5_Validated(sender As Object, e As EventArgs) Handles cmbStrReq.Validating
        If cmbStrReq.Text <> "Others" Then
            txtStrOthr.Text = ""
            txtStrOthr.Enabled = False
        Else
            txtStrOthr.Enabled = True
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        PanelIVB.Enabled = RadioButton9.Checked
    End Sub

    Private Sub ReportingBRBs(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged, RadioButton9.CheckedChanged,
                                                                                    RadioButton10.CheckedChanged, RadioButton11.CheckedChanged, RadioButton12.CheckedChanged,
                                                                                    RadioButton13.CheckedChanged, RadioButton14.CheckedChanged, PanelIVB.EnabledChanged
        TextBox12.Enabled = RadioButton14.Checked And PanelIVB.Enabled

        If RadioButton8.Checked Then
            GroupBox6.Enabled = False
        Else
            GroupBox6.Enabled = True
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Button3.Click
        If lblTestNumber.Text = "0" Or lblTestNumber.Text = "" Then Exit Sub

        Select Case DirectCast(sender, Button).Name
            Case Button2.Name
                'If Not CheckAuth("PRODUCTRUN", "VIEWFORM", "Read") Then Exit Sub
                If TransLevel <> 0 Then Exit Sub
                REPORTVIEWING.ShowRequest(CStr(BackRS.Fields("RowStamp").Value))
            Case Button3.Name
                ' MsgBox("This is where the result will be shown")
                If TransLevel <> 0 Then Exit Sub

                Dim dal As New DataAccessLayer
                Dim strQry = "SELECT RowStamp FROM TESTSAMPLING WHERE DocNum = @DocNum"
                dal.StrParams.Add("DocNum", Me.lblTestNumber.Text)
                Dim iRS = dal.ExecuteScalar(strQry)
                If Not IsNothing(iRS) Then
                    REPORTVIEWING.ShowSampling(CStr(iRS))
                Else
                    MsgBox("No test result to show.", vbCritical)
                End If


        End Select
    End Sub

    Private Sub txtCompo_Validating(sender As Object, e As EventArgs) Handles txtCompo.Validating
        If CDbl(Val(txtCompo.Text)) > 5 Then
            txtCompo.Text = "5.00"
        ElseIf CDbl(Val(txtCompo.Text)) <= 0 Then
            txtCompo.Text = "1.00"
        End If
    End Sub

    Private Sub chkNoRec_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoRec.CheckedChanged
        dtpRecDate.Enabled = Not (chkNoRec.Checked)
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoUTD.CheckedChanged
        dtpUTD.Enabled = Not (chkNoUTD.Checked)
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles rbIsUrgent.CheckedChanged
        If Not rbIsUrgent.Checked Then
            gbUrgent.Enabled = False
            chkUrgentA.Checked = False
            chkUrgentB.Checked = False
            chkUrgentC.Checked = False
        Else
            gbUrgent.Enabled = 1
        End If
    End Sub


    Public Sub TestReqDisableControlsbyStatus(ByVal bDocStatus)
        LoopControls(Me, bDocStatus)
        gbUrgent.Enabled = rbIsUrgent.Checked And bDocStatus
        txtStrOthr.Enabled = (cmbStrReq.Text = "Others")
    End Sub

    Private Sub LoopControls(ByVal ctrl As Control, ByVal isLock As Boolean)
        For Each i As Control In ctrl.Controls
            If i.HasChildren Then
                LoopControls(i, isLock)
            Else
                If i.AccessibleName <> "" Then
                    i.Enabled = isLock
                End If
            End If
        Next
    End Sub

End Class