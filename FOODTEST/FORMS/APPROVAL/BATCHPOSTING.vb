Public Class BATCHPOSTING
    Public strBatchPostingDocNum = ""
    Private Sub BATCHPOSTING_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpList.CustomFormat = "MMM/yyyy"

        cmbStatus.SelectedIndex = 0


        With lvForPosting
            .Columns(0).Width = .Width * 0.2
            .Columns(1).Width = .Width * 0.2
            .Columns(2).Width = .Width * 0.2
            .Columns(3).Width = .Width * 0.2
            .Columns(4).Width = .Width * 0.2
            .Columns(5).Width = 0
        End With
        ValidateDaysInput()
        'LoadList()
    End Sub

    Private Sub LoadList()


        Dim dal As New DataAccessLayer
        Dim dblDay = Val(TextBox1.Text), dblMonth = Month(dtpList.Value), dblYEar = Year(dtpList.Value)
        dal.StrParams.Add("DocStatus", IIf(cmbStatus.Text = "PENDING", "Approved", "Posted"))
        dal.StrParams.Add("AppMonth", dblMonth)
        dal.StrParams.Add("AppYear", dblYEar)
        dal.StrParams.Add("AppDay", dblDay)
        Dim dt = dal.ExecuteQuery("select T1.DocNum, Case when isCompliant = 1 then 'Compliant' else 'Non-Compliant' end Compliant, " &
                     "      T1.DocDate, T1.CreatedBy, isnull(T1.ApprovedBy, '') ApprovedBy, T1.RowStamp " &
                     "from TESTSAMPLING T1 " &
                     "      INNER JOIN TESTORDER T2 on T1.DocNum = T2.DocNum and T2.DocStatus <> 'DELETED' " &
                     "WHERE T1.DocStatus = @DocStatus and month(t1.DocDate) = @AppMonth and year(t1.DocDate) = @AppYear " &
                     IIf(dblDay = 0, "", "      and Day(t1.DocDate) = @AppDay ") &
                     "ORDER by T2.DocDate Desc")


        'Dim strQry = "select T1.DocNum, Case when isCompliant = 1 then 'Compliant' else 'Non-Compliant' end Compliant, " &
        '             "      T2.DocDate, T1.CreatedBy, isnull(T1.ApprovedBy, '') ApprovedBy, T1.RowStamp " &
        '             "from TESTSAMPLING T1 " &
        '             "      INNER JOIN TESTORDER T2 on T1.DocNum = T2.DocNum and T2.DocStatus <> 'DELETED' " &
        '             "WHERE T1.DocStatus = '" & IIf(cmbStatus.Text = "PENDING", "Approved", "Posted") & "' and month(t1.CreatedDate) = " & Month(DateTimePicker1.Value) & " and year(t1.CreatedDate) = " & Year(DateTimePicker1.Value) & " ORDER by T2.DocDate Desc"
        'Connect()
        'rs = Nothing
        'rs = cn.Execute(strQry)



        lvForPosting.Items.Clear()

        For Each row As DataRow In dt.Rows
            With lvForPosting.Items.Add(row("DocNum"))
                .SubItems.Add(row("Compliant"))
                .SubItems.Add(CDate(row("DocDate")).ToShortDateString)
                .SubItems.Add(row("CreatedBy"))
                .SubItems.Add(row("ApprovedBy"))
                .SubItems.Add(row("RowStamp"))
            End With
        Next


        ''If rs.RecordCount <= 0 Then Exit Sub

        'While Not rs.EOF
        '    With lvForPosting.Items.Add(rs.Fields("DocNum").Value)
        '        .SubItems.Add(rs.Fields("Compliant").Value)
        '        .SubItems.Add(CDate(rs.Fields("DocDate").Value).ToShortDateString)
        '        .SubItems.Add(rs.Fields("CreatedBy").Value)
        '        .SubItems.Add(rs.Fields("ApprovedBy").Value)
        '        .SubItems.Add(rs.Fields("RowStamp").Value)
        '    End With
        '    rs.MoveNext()
        'End While
        'DisconnectCN()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        'LoadList()
        ValidateDaysInput()
    End Sub

    'Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged, dtpList.ValueChanged
    '    'Me.TextBox1.Text = dtpList.Value.Day
    '    ValidateDaysInput()
    '    'MsgBox(dtpList.Value.Day)
    '    'LoadList()
    'End Sub



    Private Sub dtpList_ValueChanged(sender As Object, e As EventArgs) Handles dtpList.ValueChanged
        Me.TextBox1.Text = dtpList.Value.Day
        ValidateDaysInput()
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        ValidateDaysInput()
    End Sub
    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each x As ListViewItem In lvForPosting.Items
            x.Checked = chkAll.Checked
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not GetAuthorization("POSTING", "POSTING", AccessTypes.cEdit) Then
            MsgBox("You are not allowed to Post entries.", vbCritical)
            Exit Sub
        End If

        Dim dal As New DataAccessLayer


        If cmbStatus.Text <> "PENDING" Then Exit Sub
        If MsgBox("Are you sure you want to POST selected entries?", vbYesNo) = vbNo Then Exit Sub
        'Connect()
        Try
            dal.BeginTransaction()
            'cn.BeginTrans()

            'For Each x As ListViewItem In lvForPosting.Items
            '    If x.Checked Then
            '        cn.Execute("EXEC ApproveDocument '" & x.SubItems(5).Text & "', 'APPROVESAMPLING', '" & UserName & "'")
            '    End If
            'Next

            'For Each x As ListViewItem In lvForPosting.Items
            '    If x.Checked Then
            '        cn.Execute("EXEC ApproveDocument '" & x.SubItems(5).Text & "', 'APPROVESAMPLING', '" & UserName & "'")
            '    End If
            'Next

            For Each x As ListViewItem In lvForPosting.Items
                If x.Checked Then
                    dal.StrParams.Add("RowStamp", x.SubItems(5).Text)
                    dal.StrParams.Add("UserName", UserName)
                    dal.ExecuteQuery("EXEC ApproveDocument @RowStamp, 'POSTSAMPLING', @UserName")
                End If
            Next

            MsgBox("Record saved!")
            'cn.CommitTrans()
            dal.Commit()
        Catch ex As Exception
            MsgBox("An error occured while posting the records. Please report to IT Administrator.", vbCritical)
            'cn.RollbackTrans()
            dal.Rollback()
        End Try
        'DisconnectCN()
        'LoadList() 'inilagay ko na sa ValidateDaysInout yung loading ng list
        ValidateDaysInput()
    End Sub


    Private Sub cmsInit()
        Dim cms = New ContextMenuStrip


        Dim item1 As ToolStripMenuItem = cms.Items.Add("Show Form")
        item1.Tag = 1
        AddHandler item1.Click, Sub()
                                    'strBatchPostingDocNum = lvForPosting.SelectedItems(0).Text
                                    'REPORTVIEWING.ShowReportDialog("POSTINGSHOWFORM")
                                    REPORTVIEWING.ShowSampling(lvForPosting.SelectedItems(0).SubItems(5).Text)
                                End Sub

        Dim item2 As ToolStripMenuItem = cms.Items.Add("Edit Note")
        item2.Tag = 2
        AddHandler item2.Click, Sub()

                                    strBatchPostingDocNum = lvForPosting.SelectedItems(0).Text
                                    Dim strNote = ""
                                    Dim dal As New DataAccessLayer

                                    'Connect()
                                    'rs = Nothing
                                    'rs = cn.Execute("SELECT PostingNote FROM TESTSAMPLING WHERE DocNum = '" & strBatchPostingDocNum & "'")

                                    dal.StrParams.Add("DocNum", strBatchPostingDocNum)
                                    strNote = (dal.ExecuteQuery("SELECT isnull(PostingNote, '') PostingNote FROM TESTSAMPLING WHERE DocNum = @DocNum"))(0)("PostingNote")

                                    'If rs.RecordCount > 0 Then
                                    'If strNote = "" Then
                                    strNote = RQ(InputBox("Enter Note:", "POSTING NOTE", strNote))
                                    strNote = IIf(IsNothing(strNote), "", strNote)
                                    If strNote = "" AndAlso MsgBox("Proceed editing note with blank?", vbYesNo) = vbNo Then Exit Sub
                                    '    If MsgBox("Proceed editing note with blank?", vbYesNo) = vbNo Then Exit Sub
                                    'End If

                                    dal = New DataAccessLayer
                                    dal.StrParams.Add("StrNote", strNote)
                                    dal.StrParams.Add("DocNum", strBatchPostingDocNum)

                                    'cn.Execute("UPDATE TESTSAMPLING SET PostingNote = '" & strNote & "', PostedDate = getdate() WHERE DocNum = '" & strBatchPostingDocNum & "'")
                                    dal.ExecuteNonQuery("UPDATE TESTSAMPLING SET PostingNote = @StrNote, PostedDate = getdate() WHERE DocNum = @DocNum")
                                    'dal.ExecuteNonQuery("UPDATE TESTSAMPLING SET PostingNote = @StrNote WHERE DocNum = @DocNum")

                                    MsgBox("Note edited!")
                                    'Else
                                    '    MsgBox("Error adding notes. Please report to IT Administrator.")
                                    '    Exit Sub
                                    'End If
                                    'DisconnectCN()
                                End Sub



        cmsRClick = cms
    End Sub

    Private Sub lvForPosting_MouseUp(sender As Object, e As MouseEventArgs) Handles lvForPosting.MouseUp
        If e.Button = MouseButtons.Right Then
            cmsInit()
            cmsRClick.Show(Cursor.Position)
        End If
    End Sub

    Private Sub DateTimePicker1_Enter(sender As Object, e As EventArgs) Handles dtpList.Enter
        Me.AcceptButton = btnReload
    End Sub

    Private Sub lvForPosting_Enter(sender As Object, e As EventArgs) Handles lvForPosting.Enter
        Me.AcceptButton = btnSave
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Reject the input
        End If
    End Sub

    'Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
    '    ValidateDaysInput()
    'End Sub

    Private Sub ValidateDaysInput()
        ' 1. Define your target year and month (e.g., from NumericUpDowns, ComboBoxes, or Current Date)
        'Dim dtpDateValue As Date

        Dim targetYear As Integer = dtpList.Value.Year
        Dim targetMonth As Integer = dtpList.Value.Month ' e.g., 2 for February

        ' 2. Get the absolute maximum days allowed for that specific month/year
        Dim maxAllowedDays As Integer = DateTime.DaysInMonth(targetYear, targetMonth)

        ' 3. Parse the TextBox value safely
        Dim enteredDays As Integer
        If Integer.TryParse(TextBox1.Text, enteredDays) Then

            '' 4. Validate the range
            'If enteredDays >= 0 AndAlso enteredDays <= maxAllowedDays Then
            '    ' --- VALID INPUT ---
            '    'MessageBox.Show("Valid day entered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    ' Proceed with your logic here
            '    LoadList()
            'Else
            '    ' --- INVALID NUMBER OF DAYS ---
            '    MessageBox.Show($"Invalid day. For this month, please enter a value between 1 and {maxAllowedDays}.",
            '                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    TextBox1.Focus()
            '    TextBox1.SelectAll()
            'End If

            If enteredDays < 0 Then enteredDays = 0
            If enteredDays > maxAllowedDays Then enteredDays = maxAllowedDays

            TextBox1.Text = enteredDays

            'If enteredDays >= 0 AndAlso enteredDays <= maxAllowedDays Then
            '    enteredDays = maxAllowedDays
            '    TextBox1.Text = enteredDays
            'End If


            LoadList()


        Else
            ' --- EMPTY OR MALFORMED INPUT ---
            MessageBox.Show("Please enter a valid numeric day.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Text = "0"
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ValidateDaysInput()
    End Sub

    Private Sub lvForPosting_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvForPosting.MouseDoubleClick
        If lvForPosting.SelectedItems.Count <= 0 Then Exit Sub
        REPORTVIEWING.ShowSampling(lvForPosting.SelectedItems(0).SubItems(5).Text)
    End Sub

    'Private Sub dtpList_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtpList.Validating
    '    'Me.TextBox1.Text = dtpList.Value.Day
    '    ValidateDaysInput()
    '    'MsgBox(dtpList.Value.Day)
    '    'LoadList()
    'End Sub


    'Private Sub dtpList_Validated(sender As Object, e As EventArgs) Handles dtpList.Validated
    '    Me.TextBox1.Text = dtpList.Value.Day
    '    LoadList()
    'End Sub
End Class