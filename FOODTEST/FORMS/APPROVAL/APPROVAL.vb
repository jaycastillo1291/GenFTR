Public Class APPROVAL
    Public strApprovalRefNo = ""
    Private Sub APPROVAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPending()


        lvErrorList.Items.Clear()
        lvErrorList.Columns(0).Width = lvErrorList.Width * 0.95

    End Sub


    Private Sub LoadPending()
        Dim strQry As String

        'strQry = "EXEC GetForApprovals '" & UserName & "', '" & GroupName & "'"
        strQry = "EXEC GetForApprovals @UserName, @GroupName, @DateFrom, @DateTo"

        Dim dal = New DataAccessLayer

        dal.StrParams.Add("UserName", UserName)
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("DateFrom", dtpDateFrom.Value)
        dal.StrParams.Add("DateTo", dtpDateTo.Value)
        Dim dt = dal.ExecuteQuery(strQry)

        lvApprovalList.Items.Clear()


        For Each row As DataRow In dt.Rows
            With lvApprovalList.Items.Add(row("RowStamp"))
                .subitems.add(row("Origin"))
                .subitems.add(row("DocNum"))
                .subitems.add(DateTime.Parse(row("DocDate")).ToString("MM/dd/yyyy"))
                .subitems.add(row("DocStatus"))
                .subitems.add(row("Remarks"))
                .subitems.add("")
            End With
        Next

        'Connect()
        'rs = Nothing
        'rs = cn.Execute(strQry)

        'lvApprovalList.Items.Clear()

        'While Not rs.EOF
        '    With lvApprovalList.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("Origin").Value)
        '        .subitems.add(rs.Fields("DocNum").Value)
        '        .subitems.add(DateTime.Parse(rs.Fields("DocDate").Value).ToString("MM/dd/yyyy"))
        '        .subitems.add(rs.Fields("DocStatus").Value)
        '        .subitems.add(rs.Fields("Remarks").Value)
        '        .subitems.add("")
        '        rs.MoveNext()
        '    End With
        'End While

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadPending()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want commit Approvals?", vbYesNo) = MsgBoxResult.No Then Exit Sub
        Dim dal As DataAccessLayer

        Try
            Dim strApprove = ""
            'Connect()
            'cn.BeginTrans()
            For Each i As ListViewItem In lvApprovalList.Items
                If UCase(i.SubItems(4).Text) = UCase("Approved") Then
                    dal = New DataAccessLayer
                    dal.StrParams.Add("RowStamp", i.SubItems(0).Text)
                    dal.StrParams.Add("DocName", i.SubItems(1).Text)
                    dal.StrParams.Add("UserName", UserName)
                    dal.StrParams.Add("StatusChange", IIf(i.SubItems(6).Text <> "", i.SubItems(6).Text, ""))
                    Dim dt = dal.ExecuteQuery("EXEC ApproveDocument @RowStamp, @DocName, @UserName, @StatusChange")

                    'strApprove = "EXEC ApproveDocument " & i.SubItems(0).Text & ", '" & i.SubItems(1).Text & "', '" & UserName & "'" & IIf(i.SubItems(6).Text <> "", ",'" & i.SubItems(6).Text & "'", "")

                    'Select Case i.SubItems(1).Text
                    '    Case "TEST REQUEST"
                    '        strApprove &= "TESTORDER Set DocStatus = 'Approved'"
                    '    Case "SAMPLING"
                    '        strApprove &= "TESTSAMPLING Set DocStatus = 'Approved'"
                    'End Select
                    'strApprove &= " WHERE RowStamp = '" & i.SubItems(0).Text & "'"

                    'rs = Nothing
                    'rs = cn.Execute(strApprove)

                    'If rs.Fields(0).Value = 1 Then
                    '    lvErrorList.Items.Add(i.SubItems(0).Text & ", " & i.SubItems(2).Text & ": Already approved")
                    'End If

                    For Each row As DataRow In dt.Rows
                        If row("Result") = 1 Then
                            lvErrorList.Items.Add(i.SubItems(0).Text & ", " & i.SubItems(2).Text & ": Already approved")
                        End If
                    Next

                End If
            Next

            'cn.CommitTrans()
            LoadPending()
            MsgBox("Saved!")
        Catch ex As Exception
            'cn.RollbackTrans()
            MsgBox("Failed to approved selected items" & vbCrLf & "Error Code: " & ex.Message)
        End Try
        'DisconnectCN()
    End Sub

    Private Sub ChangeTag(sender As Object, e As MouseEventArgs) Handles lvApprovalList.MouseUp
        If e.Button = MouseButtons.Right Then
            If lvApprovalList.SelectedItems.Count <= 0 Then Exit Sub

            cmsInit()
            'InitiateTestVariables()
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub


    Private Sub cmsInit()
        Dim cms = New ContextMenuStrip


        Dim item1 As ToolStripMenuItem = cms.Items.Add("Tag Approved")
        item1.Tag = 1
        AddHandler item1.Click, Sub()
                                    lvApprovalList.SelectedItems(0).SubItems(4).Text = "APPROVED"
                                End Sub

        Dim item2 As ToolStripMenuItem = cms.Items.Add("Tag Pending")
        item2.Tag = 2
        AddHandler item2.Click, Sub()
                                    lvApprovalList.SelectedItems(0).SubItems(4).Text = "Pending"
                                End Sub

        Dim item3 As ToolStripMenuItem = cms.Items.Add("Show form")
        item3.Tag = 3
        AddHandler item3.Click, AddressOf ShowSelectedReport
        'AddHandler item3.Click, Sub()
        '                            Me.strApprovalRefNo = lvApprovalList.SelectedItems(0).SubItems(2).Text
        '                            Select Case lvApprovalList.SelectedItems(0).SubItems(1).Text
        '                                Case "SAMPLING"
        '                                    'REPORTVIEWING.ShowReportDialog("APPROVALSHOWFORM")
        '                                    REPORTVIEWING.ShowSampling(lvApprovalList.SelectedItems(0).Text)
        '                                Case "TEST REQUEST"
        '                                    REPORTVIEWING.ShowRequest(lvApprovalList.SelectedItems(0).Text)
        '                            End Select
        '                        End Sub



        Dim item4 = cms.Items.Add("Add Parameter")
        item4.Tag = 4
        'AddHandler item3.Click, AddressOf EditItem
        Dim item4StripItem = DirectCast(item4, ToolStripMenuItem)
        Dim item41 As New ToolStripMenuItem
        Dim item42 As New ToolStripMenuItem
        'Dim item43 As New ToolStripMenuItem

        item41.Name = "TestResult" : item41.Text = "Compliant"
        item42.Name = "Guide" : item42.Text = "Not Compliant"
        'item43.Name = "Comp" : item43.Text = "Tag/Untag Compliant"


        AddHandler item41.Click, AddressOf TagCompliant
        AddHandler item42.Click, AddressOf TagNotCompliant
        'AddHandler item43.Click, AddressOf SwitchComp

        If lvApprovalList.SelectedItems(0).SubItems(1).Text = "SAMPLING" Then
            item4StripItem.DropDownItems.Add(item41)
            item4StripItem.DropDownItems.Add(item42)
            'item4StripItem.DropDownItems.Add(item43)
        End If

        ContextMenuStrip1 = cms


    End Sub

    Private Sub TagCompliant()
        lvApprovalList.SelectedItems(0).SubItems(6).Text = "COMPLIANT"
    End Sub
    Private Sub TagNotCompliant()
        lvApprovalList.SelectedItems(0).SubItems(6).Text = "NOT COMPLIANT"
    End Sub

    Private Sub ShowSelectedReport()
        If lvApprovalList.SelectedItems.Count <> 1 Then Exit Sub
        Me.strApprovalRefNo = lvApprovalList.SelectedItems(0).SubItems(2).Text
        Select Case lvApprovalList.SelectedItems(0).SubItems(1).Text
            Case "SAMPLING"
                'REPORTVIEWING.ShowReportDialog("APPROVALSHOWFORM")
                REPORTVIEWING.ShowSampling(lvApprovalList.SelectedItems(0).Text, 1)
            Case "TEST REQUEST"
                REPORTVIEWING.ShowRequest(lvApprovalList.SelectedItems(0).Text)
        End Select
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If lvErrorList.Items.Count <= 0 Then If MsgBox("This action will clear the error log. Continue?", vbYesNo) = vbNo Then Exit Sub
        lvErrorList.Items.Clear()
    End Sub

    Private Sub dtpDateFrom_Enter(sender As Object, e As EventArgs) Handles dtpDateFrom.Enter, dtpDateTo.Enter
        Me.AcceptButton = Button2
    End Sub

    Private Sub dtpDateFrom_Leave(sender As Object, e As EventArgs) Handles dtpDateFrom.Leave, dtpDateTo.Leave
        Me.AcceptButton = Button1
    End Sub

    Private Sub lvApprovalList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvApprovalList.MouseDoubleClick
        If (cb2ClickRep.Checked) Then ShowSelectedReport()
    End Sub
End Class