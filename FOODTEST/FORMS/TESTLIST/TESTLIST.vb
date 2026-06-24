Public Class TESTLIST
    Private Sub TESTLIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvMethodList.Items.Clear()
        ClearDetails()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroupName.SelectedIndexChanged
        LoadTestList()
    End Sub


    Private Sub LoadTestList()

        'Connect()
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("isInactive", IIf(chkInactive.Checked, 1, 0))
        dal.StrParams.Add("GroupName", cmbGroupName.Text)
        Dim strQry = "SELECT RowStamp, TestCode, TestName, GroupName, Methodology, TestGuide, SamplingScheme, Remarks, isInactive FROM TESTLIST WHERE isInactive = @isInactive and GroupName like @GroupName ORDER BY TestCode"

        'Dim strQry = "SELECT RowStamp, TestCode, TestName, GroupName, Methodology, TestGuide, SamplingScheme, Remarks, isInactive FROM TESTLIST " & IIf(chkInactive.Checked, "WHERE isInactive = 1", "WHERE isInactive = 0") &
        '                " and GroupName like '" & cmbGroupName.Text & "' ORDER BY TestCode"
        'rs = Nothing
        'rs = cn.Execute(strQry)

        Dim dt = dal.ExecuteQuery(strQry)
        lvTestList.Items.Clear()

        For Each row as DataRow In dt.rows
            With lvTestList.Items.Add(row("RowStamp"))
                .subitems.add(row("TestCode"))
                .subitems.add(row("TestName"))
            End With
        Next

        'While Not rs.EOF
        '    With lvTestList.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("TestCode").Value)
        '        .subitems.add(rs.Fields("TestName").Value)
        '    End With
        '    rs.MoveNext()
        'End While

        'DisconnectCN()

    End Sub

    Private Sub lvTestList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTestList.MouseDoubleClick
        LoadToDetails()
    End Sub

    Private Sub LoadToDetails()
        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub

        Dim dal As New DataAccessLayer


        'Connect()

        Dim strRowStamp = lvTestList.SelectedItems(0).Text
        Dim strQry = "SELECT TestCode, TestName, GroupName, Methodology, " &
                     "          TestGuide, SamplingScheme, Remarks, isInactive " &
                     "FROM TESTLIST WHERE RowStamp = @RowStamp"
        'Dim strQry = "SELECT TestCode, TestName, GroupName, Methodology, " &
        '             "          TestGuide, SamplingScheme, Remarks, isInactive " &
        '             "FROM TESTLIST WHERE RowStamp = " & strRowStamp

        dal.StrParams.Add("RowStamp", strRowStamp)
        Dim dt = dal.ExecuteQuery(strQry)


        txtTestCode.Text = ""
        txtTestName.Text = ""
        txtMethod.Text = ""
        txtGuide.Text = ""
        txtRemarks.Text = ""
        lvMethodList.Items.Clear()

        'rs = Nothing
        'rs = cn.Execute(strQry)
        'If rs.EOF Then Exit Sub
        If dt.Rows.Count <= 0 Then Exit Sub

        Dim row = dt.Rows(0)
        txtTestCode.Text = row("TestCode")
        txtTestName.Text = row("TestName")
        txtMethod.Text = row("Methodology")
        txtGuide.Text = row("TestGuide")
        txtRemarks.Text = row("Remarks")

        'txtTestCode.Text = rs.Fields("TestCode").Value
        'txtTestName.Text = rs.Fields("TestName").Value
        'txtMethod.Text = rs.Fields("Methodology").Value
        'txtGuide.Text = rs.Fields("TestGuide").Value
        'txtRemarks.Text = rs.Fields("Remarks").Value

        'strQry = "SELECT RowStamp, HeadRS, TestCode, MethodName, Reference1, Reference2 FROM TESTMETHOD WHERE HeadRS = '" & lvTestList.SelectedItems(0).Text & "'"
        strQry = "SELECT RowStamp, HeadRS, TestCode, MethodName, Reference1, Reference2 FROM TESTMETHOD WHERE HeadRS = @HeadRS"
        'rs = Nothing
        'rs = cn.Execute(strQry)
        lvMethodList.Items.Clear()

        dal.StrParams.Add("HeadRS", lvTestList.SelectedItems(0).Text)
        dt = dal.ExecuteQuery(strQry)

        For Each row In dt.Rows
            With lvMethodList.Items.Add(row("RowStamp"))
                .subitems.add(row("MethodName"))
                .subitems.add(row("Reference1"))
                .subitems.add(row("Reference2"))
            End With
        Next

        ''lvMethodList.TopItem.Bounds.Top

        'While Not rs.EOF
        '    With lvMethodList.Items.Add(rs.Fields("RowStamp").Value)
        '        .subitems.add(rs.Fields("MethodName").Value)
        '        .subitems.add(rs.Fields("Reference1").Value)
        '        .subitems.add(rs.Fields("Reference2").Value)
        '    End With
        '    rs.MoveNext()
        'End While

        'DisconnectCN()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearDetails()
    End Sub

    Private Sub ClearDetails()
        chkInactive.Checked = False
        txtTestCode.Text = ""
        txtTestName.Text = ""
        txtMethod.Text = ""
        txtGuide.Text = ""
        lvMethodList.Items.Clear()
        txtRemarks.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadToDetails()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strQry = "SELECT count(RowStamp) RSCount FROM TESTLIST WHERE TestCode = @Testcode"
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("TestCode", Trim(txtTestCode.Text))
        Dim RecCount = dal.ExecuteScalar(strQry)
        'Connect()
        'Dim strQry = "SELECT RowStamp FROM TESTLIST WHERE TestCode = '" & Trim(txtTestCode.Text) & "'"
        'rs = Nothing
        'rs = cn.Execute(strQry)

        If RecCount > 0 Then
            If MsgBox("Are you sure you want to UPDATE the record?", vbYesNo) = vbNo Then
                Exit Sub
            Else
                dal.StrParams.Add("TestName", RQ(txtTestName.Text))
                dal.StrParams.Add("GroupName", RQ(cmbGroupName.Text))
                dal.StrParams.Add("Methodology", RQ(txtMethod.Text))
                dal.StrParams.Add("TestGuide", RQ(txtGuide.Text))
                dal.StrParams.Add("Remarks", RQ(txtRemarks.Text))
                dal.StrParams.Add("isInactive", IIf(chkInactive.Checked, "1", "0"))
                dal.StrParams.Add("TestCode", RQ(Trim(txtTestCode.Text)))
                strQry = "UPDATE TESTLIST
                               SET TestName = @TestName
                                  ,GroupName = @GroupName
                                  ,Methodology = @Methodology
                                  ,TestGuide = @TestGuide
                                  ,Remarks = @Remarks
                                  ,isInactive = @isInactive
                             WHERE TestCode = @TestCode'; SELECT RowStamp FROM TESTLIST WHERE TestCode = @TestCode"
            End If
        Else
            If MsgBox("Are you sure you want to CREATE the record?", vbYesNo) = vbNo Then
                Exit Sub
            Else
                dal.StrParams.Add("TestCode", RQ(Trim(txtTestCode.Text)))
                dal.StrParams.Add("TestName", RQ(txtTestName.Text))
                dal.StrParams.Add("GroupName", RQ(cmbGroupName.Text))
                dal.StrParams.Add("Methodology", RQ(txtMethod.Text))
                dal.StrParams.Add("TestGuide", RQ(txtGuide.Text))
                dal.StrParams.Add("Remarks", RQ(txtRemarks.Text))
                dal.StrParams.Add("isInactive", RQ(txtRemarks.Text))

                strQry = "INSERT INTO dbo.TESTLIST
                               (TestCode
                               ,TestName
                               ,GroupName
                               ,Methodology
                               ,TestGuide
                               ,Remarks
                               ,isInactive)
                         VALUES
                               (@TestCode
                               ,@TestName
                               ,@GroupName
                               ,@Methodology
                               ,@TestGuide
                               ,@Remarks
                               ,@isInactive; select SCOPE_IDENTITY()"
            End If
        End If

        'If rs.RecordCount > 0 Then
        '    If MsgBox("Are you sure you want to UPDATE the record?", vbYesNo) = vbNo Then
        '        Exit Sub
        '    Else
        '        strQry = "UPDATE TESTLIST
        '                       SET TestName = '" & RQ(txtTestName.Text) & "'
        '                          ,GroupName = '" & RQ(cmbGroupName.Text) & "'
        '                          ,Methodology = '" & RQ(txtMethod.Text) & "'
        '                          ,TestGuide = '" & RQ(txtGuide.Text) & "'
        '                          ,Remarks = '" & RQ(txtRemarks.Text) & "'
        '                          ,isInactive = " & IIf(chkInactive.Checked, "1", "0") & "
        '                     WHERE TestCode = '" & RQ(Trim(txtTestCode.Text)) & "'"
        '    End If
        'Else
        '    If MsgBox("Are you sure you want to CREATE the record?", vbYesNo) = vbNo Then
        '        Exit Sub
        '    Else
        '        strQry = "INSERT INTO dbo.TESTLIST
        '                       (TestCode
        '                       ,TestName
        '                       ,GroupName
        '                       ,Methodology
        '                       ,TestGuide
        '                       ,SamplingScheme
        '                       ,Remarks
        '                       ,isInactive)
        '                 VALUES
        '                       ('" & RQ(Trim(txtTestCode.Text)) & "'
        '                       ,'" & RQ(txtTestName.Text) & "'
        '                       ,'" & RQ(cmbGroupName.Text) & "'
        '                       ,'" & RQ(txtMethod.Text) & "'
        '                       ,'" & RQ(txtGuide.Text) & "'
        '                       ,'" & RQ(txtRemarks.Text) & "'
        '                       ," & IIf(chkInactive.Checked, "1", "0")
        '    End If
        'End If
        Try
            dal.BeginTransaction()
            Dim strRS = dal.ExecuteNonQuery(strQry)
            InsertTestScheme(RQ(Trim(txtTestCode.Text)), dal, strRS)
            MsgBox("Record SAVED.")
            dal.Commit()
            LoadTestList()
        Catch ex As Exception
            MsgBox("Error SAVING the entry. Please report to IT Administrator.")
            dal.Rollback()
        End Try


        'Try
        '    cn.BeginTrans()
        '    cn.Execute(strQry)
        '    InsertTestScheme(RQ(Trim(txtTestCode.Text)))
        '    MsgBox("Record SAVED.")
        '    cn.CommitTrans()
        '    LoadTestList()
        'Catch ex As Exception
        '    MsgBox("Error SAVING the entry. Please report to IT Administrator.")
        '    cn.RollbackTrans()
        'End Try
        'DisconnectCN()
    End Sub

    'Private Sub InsertTestScheme(ByVal strTestCode As String, ByVal dal As DataAccessLayer)
    '    Try
    '        Dim strHeadRS, strMethodName, strReference1, strReference2 As String
    '        strHeadRS = ""
    '        strMethodName = ""
    '        strReference1 = ""
    '        strReference2 = ""
    '        rs = Nothing
    '        rs = cn.Execute("SELECT top 1 * from TESTLIST")
    '        If rs.RecordCount <= 0 Then MsgBox("Error loading Method list table definition. Pleas report to IT.", vbCritical) : cn.RollbackTrans() : Exit Sub
    '        cn.Execute("DELETE FROM TESTMETHOD WHERE HeadRS = (SELECT top 1 RowStamp FROM TESTLIST WHERE TestCode = '" & strTestCode & "')")
    '        For Each i As ListViewItem In lvMethodList.Items
    '            strTestCode = ""
    '            strMethodName = Strings.Left(RQ(i.SubItems(1).Text), rs.Fields("MethodName").DefinedSize)
    '            strReference1 = Strings.Left(RQ(i.SubItems(2).Text), rs.Fields("Reference1").DefinedSize)
    '            strReference2 = Strings.Left(RQ(i.SubItems(3).Text), rs.Fields("Reference2").DefinedSize)
    '            cn.Execute("INSERT INTO TESTMETHOD (HeadRS, TestCode, MethodName, Reference1, Reference2) Values 
    '                        ((SELECT top 1 RowStamp FROM TESTLIST WHERE TestCode = '" & strTestCode & "'), '" & strTestCode & "', '" & strMethodName & "', '" & strReference1 & "', '" & strReference2 & "')")
    '        Next
    '    Catch ex As Exception
    '        MsgBox("Error inserting the Method. Please report to IT Administrator.")
    '        cn.RollbackTrans()
    '    End Try
    'End Sub

    Private Sub InsertTestScheme(strTestCode As String, dal As DataAccessLayer, strRowStamp As String)
        Try
            Dim strHeadRS, strMethodName, strReference1, strReference2 As String
            strHeadRS = strRowStamp
            strMethodName = ""
            strReference1 = ""
            strReference2 = ""
            Dim RecCount = dal.ExecuteScalar("SELECT top 1 COUNT(*) RecCount FROM TESTLIST")

            'rs = Nothing
            'rs = cn.Execute("SELECT top 1 * from TESTLIST")
            If RecCount <= 0 Then MsgBox("Error loading Method list table definition. Pleas report to IT.", vbCritical) : dal.Rollback() : Exit Sub
            'dal.StrParams.Add("TestCode", strTestCode)
            'dal.ExecuteNonQuery("DELETE FROM TESTMETHOD WHERE HeadRS = (SELECT top 1 RowStamp FROM TESTLIST WHERE TestCode = @TestCode)")
            dal.StrParams.Add("HeadRS", strRowStamp)
            dal.ExecuteNonQuery("DELETE FROM TESTMETHOD WHERE HeadRS = @HeadRS")
            'cn.Execute("DELETE FROM TESTMETHOD WHERE HeadRS = (SELECT top 1 RowStamp FROM TESTLIST WHERE TestCode = '" & strTestCode & "')")

            For Each i As ListViewItem In lvMethodList.Items
                'strTestCode = ""
                strMethodName = Strings.Left(RQ(i.SubItems(1).Text), rs.Fields("MethodName").DefinedSize)
                strReference1 = Strings.Left(RQ(i.SubItems(2).Text), rs.Fields("Reference1").DefinedSize)
                strReference2 = Strings.Left(RQ(i.SubItems(3).Text), rs.Fields("Reference2").DefinedSize)

                dal.StrParams.Add("HeadRS", strHeadRS)
                dal.StrParams.Add("TestCode", strTestCode)
                dal.StrParams.Add("MethodName", strMethodName)
                dal.StrParams.Add("Reference1", strReference1)
                dal.StrParams.Add("Reference2", strReference2)
                dal.ExecuteNonQuery("INSERT INTO TESTMETHOD (HeadRS, TestCode, MethodName, Reference1, Reference2) Values 
                            (@strRowStamp, @TestCode, @MethodName, @Reference1, @Reference2)")
            Next
        Catch ex As Exception
            MsgBox("Error inserting the Method. Please report to IT Administrator.")
            dal.Rollback()
        End Try
    End Sub


    Private Sub LoadCMS()
        Dim cms = New ContextMenuStrip


        Dim item1 As ToolStripMenuItem = cms.Items.Add("Add Item")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf AddItem


        Dim item2 As ToolStripMenuItem = cms.Items.Add("Edit Item")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf AddItem


        Dim item3 As ToolStripMenuItem = cms.Items.Add("Delete Item")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf AddItem
    End Sub


    Private Sub AddItem()

    End Sub

End Class