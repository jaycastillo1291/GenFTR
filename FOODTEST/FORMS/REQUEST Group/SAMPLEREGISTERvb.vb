Public Class SAMPLEREGISTERvb
    Private Sub SAMPLEREGISTERvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lvRegList
            .Columns(0).Width = 0
            .Columns(1).Width = .Width * 0.2
            .Columns(2).Width = .Width * 0.3
            .Columns(3).Width = .Width * 0.2
            .Columns(4).Width = .Width * 0.15
        End With
    End Sub

    Private Sub btnCreateReg_Click(sender As Object, e As EventArgs) Handles btnCreateReg.Click

        lvRegList.Items.Clear()

        With lvRegList.Items.Add("ADD")
            .SubItems.Add("") 'Reg No
            .SubItems.Add(UserName) 'Prepared By
            .SubItems.Add(ServerDate) 'Date Prepared
            .SubItems.Add("") 'Is Printed
        End With

        lvRegDetails.Items.Clear()
        Dim dal As New DataAccessLayer
        Dim strQry As String


        dal.StrParams.Add("@UserName", UserName)
        dal.StrParams.Add("@GroupName", GroupName)
        dal.StrParams.Add("@DateFrom", dtpDateFrom.Value)
        dal.StrParams.Add("@DateTo", dtpDateTo.Value)

        strQry = ""
        strQry = "exec GetRegisterList @UserName, @GroupName, @DateFrom, @DateTo"

        Dim dt = dal.ExecuteQuery(strQry)

        For Each row As DataRow In dt.Rows
            With lvRegDetails.Items.Add(row("TRN"))
                .SubItems.Add(row("RowStamp"))
                .SubItems.Add(row("RequestedBy"))
                .SubItems.Add(row("SamplingTimeStamp"))
                .SubItems.Add(row("ItemName"))
                .SubItems.Add(row("ProdDate").ToString("MM/dd/yyyy"))
                .SubItems.Add(row("UTD").ToString("MM/dd/yyyy"))
                .SubItems.Add(row("BatchNo"))
                .SubItems.Add(row("TestRequested"))
            End With
        Next



    End Sub
End Class