Public Class SAMPLEREGISTER
    Private Sub SAMPLEREGISTERvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lvRegList
            .Columns(0).Width = 0
            .Columns(1).Width = .Width * 0.2
            .Columns(2).Width = .Width * 0.3
            .Columns(3).Width = .Width * 0.2
            .Columns(4).Width = .Width * 0.15
        End With
        With lvRegDetails
            .Columns(0).Width = .Width * 0.2
            .Columns(1).Width = 0
            .Columns(2).Width = .Width * 0.15
            .Columns(3).Width = .Width * 0.15
            .Columns(4).Width = .Width * 0.15
            .Columns(5).Width = .Width * 0.15
            .Columns(6).Width = .Width * 0.15
            .Columns(7).Width = .Width * 0.15
            .Columns(8).Width = .Width * 0.15
        End With
    End Sub

    Private Sub btnCreateReg_Click(sender As Object, e As EventArgs) Handles btnCreateReg.Click

        lvRegList.Items.Clear()

        With lvRegList.Items.Add("ADD")
            .SubItems.Add("") 'Reg No
            .SubItems.Add(UserName) 'Prepared By
            .SubItems.Add(ServerDate) 'Date Prepared
            .SubItems.Add("") 'Is Printed
            .Selected = True
            .Focused = True
        End With

        lvRegDetails.Items.Clear()
        Dim dal As New DataAccessLayer
        Dim strQry As String


        dal.StrParams.Add("UserName", UserName)
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("DateFrom", dtpDateFrom.Value)
        dal.StrParams.Add("DateTo", dtpDateTo.Value)

        strQry = ""
        strQry = "exec SAMPLEREGISTER_GetToRegisterList @UserName, @GroupName"

        Dim dt = dal.ExecuteQuery(strQry)

        For Each row As DataRow In dt.Rows
            With lvRegDetails.Items.Add(row("TRN"))
                .SubItems.Add(row("RowStamp"))
                .SubItems.Add(row("RequestedBy"))
                .SubItems.Add(row("SamplingTimeStamp"))
                .SubItems.Add(row("ItemName"))
                .SubItems.Add(Convert.ToDateTime(row("ProdDate")).ToString("MM/dd/yyyy"))
                .SubItems.Add(Convert.ToDateTime(row("UTD")).ToString("MM/dd/yyyy"))
                .SubItems.Add(row("BatchNo"))
                .SubItems.Add(row("TestRequested"))
            End With
        Next

        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strAction As String
        If lvRegList.SelectedItems.Count > 1 Then Exit Sub


        strAction = IIf(lvRegList.SelectedItems(0).Text = "ADD", "ADD", "UPDATE")

        If MsgBox("Are you sure you want to Save " & strAction & " register?", vbYesNo) = vbNo Then Exit Sub

        If lvRegDetails.CheckedItems.Count <= 0 Then MsgBox("No selected items") : Exit Sub

        Dim dal As New DataAccessLayer
        Dim strInsertedRS As String, strRegNo As String
        dal.BeginTransaction()
        strInsertedRS = ""
        Try
            If strAction = "UPDATE" Then
                dal.StrParams.Add("SRN", lvRegList.SelectedItems(0).SubItems(1).Text)

                'Delete all TESTORDER having the registerno
                dal.ExecuteNonQuery("UPDATE TESTORDER SET RegisterNo = '' WHERE RegisterNo = @SRN")
                strInsertedRS = lvRegList.SelectedItems(0).Text
            ElseIf strAction = "ADD" Then
                dal.StrParams.Add("UserName", UserName)

                'Insert/create new sample register, get the inserted rowstamp
                strInsertedRS = dal.ExecuteScalar("INSERT INTO [dbo].[SAMPLEREGISTER] " &
                                    "       ([PrepBy] " &
                                    "       ,[PrepDate] " &
                                    "       ,[isPrinted]) " &
                                    " VALUES " &
                                    "       (@UserName " &
                                    "       ,GETDATE() " &
                                    "       ,'N'); select SCOPE_IDENTITY()")
            End If



            For Each li As ListViewItem In lvRegDetails.CheckedItems
                dal.StrParams.Add("RowStamp", strInsertedRS)
                dal.StrParams.Add("UpdateRS", li.SubItems(1).Text)
                dal.ExecuteNonQuery("UPDATE TESTORDER " &
                                    "SET RegisterNo = (SELECT RegNo FROM SAMPLEREGISTER T1 WHERE T1.RowStamp = @RowStamp) " &
                                    "WHERE RowStamp = @UpdateRS")
            Next


            dal.StrParams.Add("RowStamp", strInsertedRS)
            strRegNo = dal.ExecuteScalar("SELECT top 1 RegNo FROM SAMPLEREGISTER WHERE RowStamp = @RowStamp")
            dal.Commit()
            MsgBox("Successfully saved Sample Register No. " & strRegNo & ".")
            LoadRegisterList()
        Catch ex As Exception
            dal.Rollback()
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub AddNewRegister()
        If MsgBox("Are you sure you want to Save Sample register?") = vbNo Then Exit Sub

        If lvRegDetails.CheckedItems.Count <= 0 Then MsgBox("No selected items") : Exit Sub

        Dim dal As New DataAccessLayer
        Dim strInsertedRS As String, strRegNo As String
        dal.BeginTransaction()

        Try
            dal.StrParams.Add("UserName", UserName)
            strInsertedRS = dal.ExecuteScalar("INSERT INTO [dbo].[SAMPLEREGISTER] " &
                                "       ([PrepBy] " &
                                "       ,[PrepDate] " &
                                "       ,[isPrinted]) " &
                                " VALUES " &
                                "       (@UserName " &
                                "       ,GETDATE() " &
                                "       ,'N'); select SCOPE_IDENTITY()")

            For Each li As ListViewItem In lvRegDetails.CheckedItems
                dal.StrParams.Add("RowStamp", strInsertedRS)
                dal.StrParams.Add("UpdateRS", li.SubItems(1).Text)
                dal.ExecuteNonQuery("UPDATE TESTORDER " &
                                    "SET RegisterNo = (SELECT RegNo FROM SAMPLEREGISTER T1 WHERE T1.RowStamp = @RowStamp) " &
                                    "WHERE RowStamp = @UpdateRS")
            Next


            dal.StrParams.Add("RowStamp", strInsertedRS)
            strRegNo = dal.ExecuteScalar("SELECT top 1 RegNo FROM SAMPLEREGISTER WHERE RowStamp = @RowStamp")
            dal.Commit()
            MsgBox("Successfully created Sample Register No. " & strRegNo & ".")
            LoadRegisterList()
        Catch ex As Exception
            dal.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub LoadRegisterList()
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("UserName", UserName)
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("DateFrom", CDate(dtpDateFrom.Value))
        dal.StrParams.Add("DateTo", CDate(dtpDateTo.Value))
        Dim dt As DataTable = dal.ExecuteQuery("exec SAMPLEREGISTER_GetRegisteredList @UserName, @GroupName, @DateFrom, @DateTo")

        lvRegDetails.Items.Clear()
        lvRegList.Items.Clear()
        For Each i As DataRow In dt.Rows
            With lvRegList.Items.Add(i("RowStamp"))
                .subitems.add(i("RegNo"))
                .subitems.add(i("PrepBy"))
                .subitems.add(Convert.ToDateTime(i("Prepdate")).ToString("MM/dd/yyyy HH:mm"))
                .subitems.add(IIf(i("IsPrinted") = "N", "", "Y"))
            End With
        Next

    End Sub

    Private Sub LoadRegisterDetails(strRegNoRS As String)
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("ApproverID", UserName)
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("RegNoRS", strRegNoRS)
        Dim dt As DataTable = dal.ExecuteQuery("EXEC SAMPLEREGISTER_GetRegisterDetails @ApproverID, @GroupName, @RegNoRS, 'G'")

        lvRegDetails.Items.Clear()

        For Each i As DataRow In dt.Rows
            With lvRegDetails.Items.Add(i("TRN"))
                .checked = (i("RegisterNo") <> "")
                .subitems.add(i("RowStamp"))
                .subitems.add(i("RequestedBy"))
                .subitems.add(Convert.ToDateTime(i("SamplingTimeStamp")).ToString("MM/dd/yyyy HH:mm"))
                .subitems.add(i("ItemName"))
                .subitems.add(Convert.ToDateTime(i("ProdDate")).ToString("MM/dd/yyyy HH:mm"))
                .subitems.add(Convert.ToDateTime(i("UTD")).ToString("MM/dd/yyyy HH:mm"))
                .subitems.add(i("BatchNo"))
                .subitems.add(i("TestRequested"))
            End With
        Next

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        LoadRegisterList()
    End Sub

    Private Sub lvRegList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles btnLoadtoList.Click, lvRegList.MouseDoubleClick
        If lvRegList.SelectedItems.Count <> 1 Then Exit Sub
        LoadRegisterDetails(lvRegList.SelectedItems(0).SubItems(0).Text)
        btnSave.Enabled = lvRegList.SelectedItems(0).SubItems(4).Text <> "Y"
    End Sub

    Private Sub dtpDateFrom_Enter(sender As Object, e As EventArgs) Handles dtpDateTo.Enter, dtpDateFrom.Enter
        Me.AcceptButton = btnView
    End Sub

    Private Sub lvRegList_Enter(sender As Object, e As EventArgs) Handles lvRegList.Enter
        Me.AcceptButton = btnLoadtoList
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dal As New DataAccessLayer
        If lvRegList.SelectedItems.Count <= 0 Then Exit Sub
        If lvRegList.SelectedItems(0).Text = "ADD" Then Exit Sub

        If lvRegList.SelectedItems(0).SubItems(4).Text <> "Y" Then
            If MsgBox("Do you want to Print to Post this document?", vbYesNo) = vbYes Then
                dal.StrParams.Add("RowStamp", lvRegList.SelectedItems(0).Text)
                dal.ExecuteNonQuery("UPDATE SAMPLEREGISTER Set isPrinted = 'Y' WHERE RowStamp = @RowStamp")
                lvRegList.SelectedItems(0).SubItems(4).Text = "Y"
            End If

        End If

        ShowSampleRegister(lvRegList.SelectedItems(0).Text)
    End Sub
End Class