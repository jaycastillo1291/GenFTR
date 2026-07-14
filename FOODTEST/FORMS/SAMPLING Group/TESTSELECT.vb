Public Class TESTSELECT
    Private Sub TESTSELECT_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        With lvTestList
            .Columns(0).Width = .Width * 0.0
            .Columns(1).Width = .Width * 0.3
            .Columns(2).Width = .Width * 0.6
            .Columns(3).Width = .Width * 0.0
        End With

        Dim strQry = "select AccessName Code, AccessName Description " &
                     "from vwGroupAuth T1 " &
                     "    inner Join(select distinct left(TESTLIST.TestCode, 1) SeqCode, GroupName SeqGroupName from TESTLIST) T2 " &
                     "        On T1.AccessName = T2.SeqGroupName " &
                     "WHERE GroupName = '" & GroupName & "' and Module = 'SAMPGROUP' and cRead = 1 " &
                     "ORDER BY T2.SeqCode"

        Auto1(cmbGroupName, strQry, "vwGroupAuth")
        cmbGroupName.SelectedIndex = 0
        LoadTestList()
    End Sub


    Private Sub LoadTestList()
        'Connect()
        Dim dal As New DataAccessLayer

        Dim strInList = ""
        Dim iCount = 0
        Dim iCanSelect = "Y"
        Dim strQry = "SELECT RowStamp, TestCode, TestName, GroupName, SamplingScheme, TestGuide, Methodology, Remarks, isInactive, " &
                        "(SELECt Count(TESTMETHOD.testCode) FROM TESTMETHOD WHERE TESTMETHOD.TestCode = TESTLIST.TestCode) MethodCount FROM TESTLIST WHERE isInactive = 0" &
                        " and GroupName = @GroupName"

        strQry = strQry & " order by left(TestCode, 1), cast(RIGHT(TestCode, LEN(TestCode) - 1) as numeric)"
        'rs = Nothing
        'rs = cn.Execute(strQry)

        dal.StrParams.Add("GroupName", cmbGroupName.Text)
        Dim dt = dal.ExecuteQuery(strQry)


        'Tags "N"(Non selective) rows that already exist in the list.
        lvTestList.Items.Clear()

        For Each row As DataRow In dt.Rows
            iCount = 0
            iCanSelect = "Y"
            With lvTestList.Items.Add(row("RowStamp"))
                .subitems.add(row("TestCode"))
                .subitems.add(row("TestName"))
                For Each i As ListViewItem In SAMPLING.lvTestList.Items
                    If i.SubItems(2).Text = row("TestCode") Then iCount += 1
                Next
                .subitems.add(IIf(iCount < CDbl(row("methodcount")), "Y", "N"))
            End With
        Next

        'While Not rs.EOF
        '    iCount = 0
        '    iCanSelect = "Y"
        '    With lvTestList.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("TestCode").Value)
        '        .subitems.add(rs.Fields("TestName").Value)
        '        For Each i As ListViewItem In SAMPLING.lvTestList.Items
        '            If i.SubItems(2).Text = rs.Fields("TestCode").Value Then iCount += 1
        '        Next
        '        .subitems.add(iIf(iCount < CDbl(rs.Fields("methodcount").Value), "Y", "N"))
        '    End With
        '    rs.MoveNext()
        'End While

        For Each i As ListViewItem In lvTestList.Items
            If i.SubItems(3).Text = "N" Then
                i.ForeColor = Color.Gray
            End If
        Next
        'DisconnectCN()
    End Sub


    Private Sub lvTestList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTestList.SelectedIndexChanged
        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub
        For Each item As ListViewItem In lvTestList.SelectedItems
            If item.SubItems(3).Text = "N" Then
                item.Selected = False
            End If
        Next
    End Sub


    Private Sub cmbGroupName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroupName.SelectedIndexChanged
        LoadTestList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, lvTestList.MouseDoubleClick
        LoadToSampling()
    End Sub


    Private Sub LoadToSampling()
        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub
        'Connect()
        Dim strTestNumber As String = "", strTestCode As String = ""


        Dim strRowStamp = lvTestList.SelectedItems(0).Text
        Dim strQry = "SELECT TestCode, TestName, GroupName, SamplingScheme, " &
                     "          isnull((SELECT top 1 TestGuide from TESTSAMPLING_D T1 WHERE T1.TestCode = TESTLIST.TestCode and T1.Method = TESTLIST.Methodology Order By cast(HeadRS as int) Desc), '') TestGuide, " &
                     "       Methodology, Remarks, isInactive " &
                     "FROM TESTLIST WHERE RowStamp = @RowStamp"


        Dim dal As New DataAccessLayer
        dal.StrParams.Add("RowStamp", strRowStamp)
        Dim dt As New DataTable
        dt = dal.ExecuteQuery(strQry)


        'rs = Nothing
        'rs = cn.Execute(strQry)
        'If rs.EOF Then Exit Sub

        If dt.Rows.Count <= 0 Then Exit Sub

        For Each row As DataRow In dt.Rows
            With SAMPLING
                .strTestGroup = cmbGroupName.Text
                .strTestCode = row("TestCode")
                .strTestName = row("TestName")
                .strSamplingScheme = ""
                .strTestResult = ""
                .strGuide = row("TestGuide")
            End With
        Next

        'With SAMPLING
        '    .strTestGroup = cmbGroupName.Text
        '    .strTestCode = rs.Fields("TestCode").Value
        '    .strTestName = rs.Fields("TestName").Value
        '    .strSamplingScheme = ""
        '    .strTestResult = ""
        '    .strGuide = rs.Fields("TestGuide").Value
        'End With

        strTestNumber = SAMPLING.lblTestNumber.Text
        strTestCode = SAMPLING.strTestCode


        strQry = "select RowStamp, TestCode, MethodName, " &
                                  "     isnull((SELECT top 1 DefGuide FROM MethodGuideSetup  T1  " &
                                  "WHERE T1.TestCode = TESTMETHOD.TestCode  " &
                                  "    and T1.Method = TESTMETHOD.MethodName " &
                                  "    and T1.ItemCode = (SELECT ItemName FROM TESTORDER WHERE DocNum = @DocNum) " &
                                  "ORDER BY RowStamp DESC), '') MethodGuide " &
                                  "FROM TESTMETHOD WHERE TestCode = @TestCode"
        dal.StrParams.Add("DocNum", strTestNumber)
        dal.StrParams.Add("TestCode", strTestCode)
        dt = dal.ExecuteQuery(strQry)

        If dt.Rows.Count < 1 Then
            MsgBox("No Method to show in this Test. Please update masterlist.")
            Exit Sub
        ElseIf dt.Rows.Count = 1 Then
            SAMPLING.strSamplingScheme = dt(0)("MethodName")
            SAMPLING.strGuide = dt(0)("MethodGuide")
        Else
            METHODSELECT.ShowDialog()
        End If

        'strQry = "SELECT *,  isnull((SELECT top 1 TestGuide FROM TESTSAMPLING_D T1 " &
        '         "WHERE T1.TestCode = TESTMETHOD.TestCode and T1.Method = TESTMETHOD.MethodName " &
        '         "order by cast(HeadRS as int) desc), '') MethodGuide FROM TESTMETHOD WHERE HeadRS = '" & lvTestList.SelectedItems(0).Text & "'"

        'rs = Nothing
        'rs = cn.Execute(strQry)

        'If rs.RecordCount < 1 Then
        '    MsgBox("No Method to show in this Test. Please update masterlist.")
        '    Exit Sub
        'ElseIf rs.RecordCount = 1 Then
        '    SAMPLING.strSamplingScheme = rs.Fields("MethodName").Value
        '    SAMPLING.strGuide = rs.Fields("MethodGuide").Value
        'Else
        '    METHODSELECT.ShowDialog()
        'End If
        'DisconnectCN()
        Me.Dispose()
    End Sub
End Class