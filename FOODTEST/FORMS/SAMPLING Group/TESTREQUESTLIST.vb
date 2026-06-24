Public Class TESTREQUESTLIST
    Private Sub TESTREQUESTLIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbGroup.SelectedIndex = 0

        With lvRequests
            .Columns(0).Width = 0
            .Columns(1).Width = .Width * 0.2
            .Columns(2).Width = .Width * 0.15
            .Columns(3).Width = .Width * 0.1
            .Columns(4).Width = 0 '.Width * 0.15
            .Columns(5).Width = .Width * 0.1
            .Columns(6).Width = .Width * 0.1
        End With

        DisplayPending()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        LoadToSampling()
    End Sub

    Private Sub LoadToSampling()
        If lvRequests.SelectedItems.Count <= 0 Then Exit Sub
        If cmbGroup.Text = "Pending" Then MsgBox("Cannot add Pending Request.") : Exit Sub
        SAMPLING.strRequestNumber = lvRequests.SelectedItems(0).SubItems(1).Text
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub DisplayPending()

        Dim dal As New DataAccessLayer
        dal.StrParams.Add("strDocStatus", cmbGroup.Text)
        Dim dt = dal.ExecuteQuery("SELECT RowStamp, DocNum, DocDate, RequestedBy, DocStatus, isUrgent 
                        FROM TESTORDER WHERE DocStatus = @strDocStatus and DocNum not in (SELECT DocNum FROM TESTSAMPLING) order by isUrgent desc, DocDate")

        lvRequests.Items.Clear()

        For Each row As DataRow In dt.Rows
            With lvRequests.Items.Add(row("RowStamp"))
                .subitems.add(row("DocNum"))
                .subitems.add(CDate(row("DocDate")).ToString("MM/dd/yyyy"))
                .subitems.add(row("RequestedBy"))
                '.subitems.add(CDate(rs.Fields("DateNeeded").Value).ToString("MM/dd/yyyy"))
                .subitems.add("")
                .subitems.add(row("DocStatus"))
                .subitems.add(IIf(row("isUrgent"), "Urgent", ""))
            End With
        Next


        'Connect()

        'rs = Nothing
        'rs = cn.Execute("SELECT RowStamp, DocNum, DocDate, RequestedBy, DocStatus, isUrgent 
        '                FROM TESTORDER WHERE DocStatus = '" & cmbGroup.Text & "' and DocNum not in (SELECT DocNum FROM TESTSAMPLING) order by isUrgent desc, DocDate")

        'While Not rs.EOF
        '    With lvRequests.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("DocNum").Value)
        '        .subitems.add(CDate(rs.Fields("DocDate").Value).ToString("MM/dd/yyyy"))
        '        .subitems.add(rs.Fields("RequestedBy").Value)
        '        '.subitems.add(CDate(rs.Fields("DateNeeded").Value).ToString("MM/dd/yyyy"))
        '        .subitems.add("")
        '        .subitems.add(rs.Fields("DocStatus").Value)
        '        .subitems.add(IIf(rs.Fields("isUrgent").Value, "Urgent", ""))
        '    End With
        '    rs.MoveNext()
        'End While
    End Sub

    Private Sub cmbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroup.SelectedIndexChanged
        DisplayPending()
    End Sub
End Class