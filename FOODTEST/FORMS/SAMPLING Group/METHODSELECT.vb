Public Class METHODSELECT
    Private Sub SCHEMESELECT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvSchemeList.Columns(0).Width = lvSchemeList.Width - 5
        lvSchemeList.Columns(1).Width = 0
        LoadSchemeList()
    End Sub

    Private Sub LoadToSampling()
        If lvSchemeList.SelectedItems.Count <= 0 Then Exit Sub
        SAMPLING.strSamplingScheme = lvSchemeList.SelectedItems(0).Text
        SAMPLING.strGuide = lvSchemeList.SelectedItems(0).SubItems(1).Text
        Me.Dispose()
    End Sub

    Private Sub LoadSchemeList()
        Dim strCanSelect = "N", strpTestCode = SAMPLING.strTestCode, strpDocNum = SAMPLING.lblTestNumber.Text

        Dim dal As DataAccessLayer
        dal = New DataAccessLayer
        dal.StrParams.Add("TestCode", strpTestCode)
        dal.StrParams.Add("DocNum", strpDocNum)
        Dim dt = dal.ExecuteQuery("select RowStamp, TestCode, MethodName, " &
                                  "     isnull((SELECT top 1 DefGuide FROM MethodGuideSetup  T1  " &
                                  "WHERE T1.TestCode = TESTMETHOD.TestCode  " &
                                  "    and T1.Method = TESTMETHOD.MethodName " &
                                  "    and T1.ItemCode = (SELECT ItemName FROM TESTORDER WHERE DocNum = @DocNum) " &
                                  "ORDER BY RowStamp DESC), '') MethodGuide " &
                                  "FROM TESTMETHOD WHERE TestCode = @TestCode")
        Dim strMethodName = "", strMethodGuide = "", strTestCode = ""

        lvSchemeList.Items.Clear()

        For Each row As DataRow In dt.Rows
            With lvSchemeList.Items.Add(row("MethodName"))
                .subitems.add(row("MethodGuide"))
                strCanSelect = "Y"
                For Each li As ListViewItem In SAMPLING.lvTestList.Items
                    If Trim(li.SubItems(2).Text + li.SubItems(4).Text) = Trim(CStr(row("TestCode")) + CStr(row("MethodName"))) Then
                        strCanSelect = "N"
                    End If
                Next
                .subitems.add(strCanSelect)
                'rs.MoveNext()
            End With
        Next

        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select RowStamp, TestCode, MethodName, isnull((SELECT top 1 TestGuide FROM TESTSAMPLING_D T1 
        '      WHERE T1.TestCode = TESTMETHOD.TestCode and T1.Method = TESTMETHOD.MethodName 
        '      order by cast(HeadRS as int) desc), '') MethodGuide from TESTMETHOD WHERE TestCode = '" & SAMPLING.strTestCode & "'")

        'lvSchemeList.Items.Clear()
        'While Not rs.EOF
        '    With lvSchemeList.Items.Add(rs.Fields("MethodName").Value)
        '        .subitems.add(rs.Fields("MethodGuide").Value)
        '        strCanSelect = "Y"
        '        For Each li As ListViewItem In SAMPLING.lvTestList.Items
        '            If Trim(li.SubItems(2).Text + li.SubItems(4).Text) = Trim(rs.Fields("TestCode").Value + rs.Fields("MethodName").Value) Then strCanSelect = "N"
        '        Next
        '        .subitems.add(strCanSelect)
        '        rs.MoveNext()
        '    End With
        'End While


        For Each i As ListViewItem In lvSchemeList.Items
            If i.SubItems(2).Text = "N" Then
                i.ForeColor = Color.Gray
            End If
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, lvSchemeList.MouseDoubleClick
        LoadToSampling()
    End Sub

    Private Sub lvSchemeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvSchemeList.SelectedIndexChanged
        If lvSchemeList.SelectedItems.Count <= 0 Then Exit Sub
        For Each item As ListViewItem In lvSchemeList.SelectedItems
            If item.SubItems(2).Text = "N" Then
                item.Selected = False
            End If
        Next
    End Sub
End Class