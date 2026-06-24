Public Class REQTESTLIST
    Private Sub REQTESTLIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        With lvTestListSelect
            .Columns(0).Width = .Width * 0.04
            .Columns(1).Width = .Width * 0.2
            .Columns(2).Width = .Width * 0.3
            .Columns(3).Width = .Width * 0.2
        End With
        LoadTestList()
    End Sub



    Private Sub LoadTestList()
        Dim strQry = "select RowStamp, TestCode, TestName, GroupName from TESTLIST where isInactive = 0 order by LEFT(TestCode, 1),  cast(SUBSTRING(TestCode, 2, 10) as numeric)"


        Dim dal As New DataAccessLayer

        Dim dt = dal.ExecuteQuery(strQry)


        lvTestListSelect.Items.Clear()
        For Each i As DataRow In dt.Rows
            With lvTestListSelect.Items.Add(i("RowStamp"))
                .subitems.add(i("testCode"))
                .subitems.add(i("TestName"))
                .subitems.add(i("GroupName"))
                .checked = False
                For Each selectedItem As ListViewItem In TESTREQ.lvTestList.Items

                    If i("testCode") = selectedItem.SubItems(2).Text Then
                        .checked = True
                    End If
                Next selectedItem

            End With
        Next


        'rs = Nothing

        'rs = cn.Execute(strQry)

        'lvTestListSelect.Items.Clear()

        'While Not rs.EOF
        '    With lvTestListSelect.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("testCode").Value)
        '        .subitems.add(rs.Fields("TestName").Value)
        '        .subitems.add(rs.Fields("GroupName").Value)
        '        .checked = False
        '        For Each selectedItem As ListViewItem In TESTREQ.lvTestList.Items

        '            If rs.Fields("testCode").Value = selectedItem.SubItems(2).Text Then
        '                .checked = True
        '            End If
        '        Next selectedItem

        '        rs.MoveNext()
        '    End With

        'End While

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If MsgBox("Are you sure you want to Add selected Items?" &
                  IIf(TESTREQ.lvTestList.Items.Count > 0, vbCrLf & "This will overwrite previously selected items.", ""), vbYesNo, "CONFIRM TEST REQUEST LIST") = vbNo Then
            Exit Sub
        End If
        TESTREQ.lvTestList.Items.Clear()
        LoadToTest()
        If TransLevel = 0 Then TransLevel = 2
        Me.Close()
    End Sub


    Private Sub LoadToTest()

        For Each selectedItem As ListViewItem In lvTestListSelect.CheckedItems
            With TESTREQ.lvTestList.Items.Add("0")
                .SubItems.Add(selectedItem.SubItems(3).Text)
                .SubItems.Add(selectedItem.SubItems(1).Text)
                .SubItems.Add(selectedItem.SubItems(2).Text)
            End With
        Next selectedItem
    End Sub
End Class