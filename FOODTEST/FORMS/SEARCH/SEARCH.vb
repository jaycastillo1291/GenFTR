Public Class SEARCH

    Private rsSearch As ADODB.Recordset
    Public strSearchForm = ""
    Private Sub SEARCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombos()

        LoadFields()
    End Sub

    Private Sub LoadCombos()
        Dim strCmbList1 = "", strCmbList2 = "", strCmbList3 = ""
        cmbCrit1.Items.Clear()
        cmbCrit2.Items.Clear()
        cmbCrit3.Items.Clear()


        txtCrit1.Enabled = False
        cmbCrit1.Enabled = False
        txtCrit2.Enabled = False
        cmbCrit2.Enabled = False
        dtpDateFrom.Enabled = False
        dtpDateTo.Enabled = False
        cmbCrit3.Enabled = False

        Select Case strSearchForm
            Case "TestRequest"
                strCmbList1 = "SELECT 'DocNum' Code, 'Document No' Description union all " &
                              "SELECT 'RequestedBy' Code, 'Requested By' Description union all " &
                              "SELECT 'Customer' Code, 'Customer' Description union all " &
                              "SELECT 'ItemName' Code, 'Item Name' Description"
                strCmbList2 = "SELECT 'DocNum' Code, 'Document No' Description union all " &
                              "SELECT 'RequestedBy' Code, 'Requested By' Description union all " &
                              "SELECT 'Customer' Code, 'Customer' Description union all " &
                              "SELECT 'ItemName' Code, 'Item Name' Description"
                strCmbList3 = "SELECT 'DocDate' Code, 'Document Date' Description"
            Case "TestRun"
                strCmbList1 = "SELECT 'DocNum' Code, 'Document No.' Description union all " &
                              "SELECT 'RequestedBy' Code, 'Requestor' Description union all " &
                              "SELECT 'ItemName' Code, 'Item Name' Description "
                strCmbList2 = "SELECT 'DocNum' Code, 'Document No.' Description union all " &
                              "SELECT 'RequestedBy' Code, 'Requestor' Description union all " &
                              "SELECT 'ItemName' Code, 'Item Name' Description "
                strCmbList3 = "SELECT 'DocDate' Code, 'Document Date' Description union all " &
                              "SELECT 'SamplingTimeStamp' Code, 'Sampling Date/Time' Description"
        End Select
        Auto1(cmbCrit1, strCmbList1, "none")
        Auto1(cmbCrit2, strCmbList2, "none")
        Auto1(cmbCrit3, strCmbList3, "none")
        cmbCrit1.SelectedIndex = 0
        cmbCrit2.SelectedIndex = 1
        cmbCrit3.SelectedIndex = 0
        txtCrit1.Focus()

        txtCrit1.Enabled = False : txtCrit1.Text = ""
        txtCrit2.Enabled = False : txtCrit2.Text = ""
        dtpDateFrom.Enabled = False : dtpDateFrom.Value = ServerDate()
        dtpDateTo.Enabled = False : dtpDateTo.Value = ServerDate()
        chkCrit1.Checked = False
        chkCrit2.Checked = False
        chkCrit3.Checked = False
    End Sub

    Private Sub LoadFields()
        Dim strQry = ""

        lvSearchList.Items.Clear()


        Dim dal As New DataAccessLayer
        dal.StrParams.Add("ModuleName", MAINFORM.fSelectedForm.AccessibleName)
        Dim dt = dal.ExecuteQuery("EXEC SEARCHTABLE @ModuleName")

        For Each x As DataColumn In dt.Columns
            With lvSearchList.Columns.Add(x.ColumnName)
                .Name = x.ColumnName
                .Text = dt.Rows(0)(x).ToString()
                If x.ColumnName = "RowStamp" Then
                    .Width = 0
                Else
                    .Width = lvSearchList.Width / (dt.Columns.Count - 1) 'minus 1 para s RowStamp
                End If
            End With
        Next


        'Select Case strSearchForm
        '    Case "TestRequest"
        '        strQry = "select 'Row Stamp' RowStamp, 'Document No.' DocNum, 'Date Submitted' DocDate, 'Requested by' RequestedBy, 'Customer' Customer, 'Document Status' DocStatus, 'Item Name' ItemName"
        '    Case "TestRun"
        '        strQry = "select 'Row Stamp' RowStamp, 'Document No.' DocNum, 'Document Date' DocDate, 'Sampling Date/Time' SamplingTimeStamp, 'Requestor' RequestedBy "
        'End Select



        'lvSearchList.Columns.Clear()
        'Connect()
        'Try
        '    rs = Nothing
        '    rs = cn.Execute(strQry)
        'Catch ex As Exception
        '    MsgBox("An Error occured while loading table definition. Please report to IT Administrator.")

        '    Exit Sub
        'End Try

        'For Each x As ADODB.Field In rs.Fields
        '    With lvSearchList.Columns.Add(x.Value)
        '        .Name = x.Name
        '        .Text = x.Value
        '        If x.Name = "RowStamp" Then
        '            .Width = 0
        '        Else
        '            .Width = lvSearchList.Width / (rs.Fields.Count - 1) 'minus 1 para s RowStamp
        '        End If
        '    End With
        'Next

        'DisconnectCN()
    End Sub


    Private Sub LoadList()
        Dim x = 0
        Dim dal As New DataAccessLayer
        If Not (chkCrit1.Checked Or chkCrit2.Checked Or chkCrit3.Checked) Then
            lvSearchList.Items.Clear()
            Exit Sub
        End If

        Dim strQry = ""


        Select Case strSearchForm
            Case "TestRequest"
                strQry = "SELECT RowStamp, DocNum, DocDate, RequestedBy, Customer, DocStatus, ItemName FROM vw_Search_TestOrder WHERE ('" & GroupName & "' = 'ADMINISTRATOR' " &
             " OR ApprovalCode IN ( " &
             "  SELECT ApprovalCode FROM ApproverTemplate_D WHERE USERNAME = '" & UserName & "' " &
                "	UNION ALL " &
             " SELECT ApprovalCode FROM ApproverTemplate_D2 WHERE USERNAME = '" & UserName & "' " &
             "))"
                strQry = strQry & IIf(chkCrit1.Checked, " and " & cmbCrit1.SelectedValue & " like '%" & Trim(RQ(txtCrit1.Text)) & "%'", "")
                strQry = strQry & IIf(chkCrit2.Checked, " and " & cmbCrit2.SelectedValue & " like '%" & Trim(RQ(txtCrit2.Text)) & "%'", "")
                strQry = strQry & IIf(chkCrit3.Checked, " and cast(" & cmbCrit3.SelectedValue & " as Date) between '" & dtpDateFrom.Value.ToShortDateString & "' and '" & dtpDateTo.Value.ToShortDateString & "'", "")

            Case "TestRun"
                strQry = "SELECT RowStamp, DocNum, DocDate, RequestedBy, SamplingTimeStamp, ApprovalCode, ItemName " &
                 "FROM vw_Search_TestSampling asd " &
                 "WHERE ('" & GroupName & "' = 'ADMINISTRATOR' " &
                 " OR asd.ApprovalCode IN ( " &
                 "  SELECT ApprovalCode FROM ApproverTemplate_D WHERE USERNAME = '" & UserName & "' " &
                    "	UNION ALL " &
                 " SELECT ApprovalCode FROM ApproverTemplate_D2 WHERE USERNAME = '" & UserName & "' " &
                 "))"
                strQry = strQry & IIf(chkCrit1.Checked, " and " & cmbCrit1.SelectedValue & " like '%" & Trim(RQ(txtCrit1.Text)) & "%'", "")
                strQry = strQry & IIf(chkCrit2.Checked, " and " & cmbCrit2.SelectedValue & " like '%" & Trim(RQ(txtCrit2.Text)) & "%'", "")
                strQry = strQry & IIf(chkCrit3.Checked, " and cast(" & cmbCrit3.SelectedValue & " as Date) between '" & dtpDateFrom.Value.ToShortDateString & "' and '" & dtpDateTo.Value.ToShortDateString & "'", "")

                'Case "TestRun"
                '    strQry = "SELECT RowStamp, DocNum, convert(varchar, DocDate, 101) DocDate, RequestedBy, SamplingTimeStamp " &
                '            "FROM (select T1.RowStamp, T1.DocNum, T2.DocDate, T2.RequestedBy, T2.SamplingTimeStamp, T1.ApprovalCode " &
                '            "from TESTSAMPLING T1 INNER JOIN TESTORDER T2 on T1.DocNum = T2.DocNum WHERE T1.DocStatus <> 'Deleted') asd " &
                '            "WHERE ('" & GroupName & "' = 'ADMINISTRATOR' " &
                '     " OR asd.ApprovalCode IN ( " &
                '     "  SELECT ApprovalCode FROM ApproverTemplate_D WHERE USERNAME = '" & UserName & "' " &
                '        "	UNION ALL " &
                '     " SELECT ApprovalCode FROM ApproverTemplate_D2 WHERE USERNAME = '" & UserName & "' " &
                '     "))"
                '    strQry = strQry & IIf(chkCrit1.Checked, " and " & cmbCrit1.SelectedValue & " like '%" & Trim(RQ(txtCrit1.Text)) & "%'", "")
                '    strQry = strQry & IIf(chkCrit2.Checked, " and " & cmbCrit2.SelectedValue & " like '%" & Trim(RQ(txtCrit2.Text)) & "%'", "")
                '    strQry = strQry & IIf(chkCrit3.Checked, " and cast(" & cmbCrit3.SelectedValue & " as Date) between '" & dtpDateFrom.Value.ToShortDateString & "' and '" & dtpDateTo.Value.ToShortDateString & "'", "")

        End Select
        Dim dt As New DataTable
        Try
            Connect()
            rs = Nothing
            rs = cn.Execute(strQry)

            'dt = dal.ExecuteQuery(strQry)

        Catch ex As Exception
            MsgBox("Error connecting to search database. Please contact IT Administrator")
            Exit Sub
        End Try

        If rs.RecordCount > 0 Then rs.MoveFirst()
        lvSearchList.Items.Clear()

        While Not rs.EOF
            With lvSearchList.Items.Add(rs.Fields(0).Value)
                For x = 0 To lvSearchList.Columns.Count - 1
                    If lvSearchList.Columns(x).Name <> "RowStamp" Then .subitems.add(rs.Fields(lvSearchList.Columns(x).Name).Value)
                Next
            End With

            rs.MoveNext()
        End While
        DisconnectCN()
    End Sub

    Private Sub SEARCH_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub chkCrit1_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrit1.CheckedChanged, chkCrit2.CheckStateChanged, chkCrit3.CheckStateChanged
        Select Case sender.name
            Case chkCrit1.Name
                txtCrit1.Enabled = chkCrit1.Checked
                cmbCrit1.Enabled = chkCrit1.Checked
            Case chkCrit2.Name
                txtCrit2.Enabled = chkCrit2.Checked
                cmbCrit2.Enabled = chkCrit2.Checked
            Case chkCrit3.Name
                dtpDateFrom.Enabled = chkCrit3.Checked
                dtpDateTo.Enabled = chkCrit3.Checked
                cmbCrit3.Enabled = chkCrit3.Checked
        End Select
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadList()
    End Sub


    Private Sub AppendSearch()
        If lvSearchList.SelectedItems.Count <= 0 Then Exit Sub
        MODULECONTROLS.SearchRecord(lvSearchList.SelectedItems(0).Text)
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        AppendSearch()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        Me.AcceptButton = btnSearch
    End Sub

    Private Sub lvSearchList_Enter(sender As Object, e As EventArgs) Handles lvSearchList.Enter, GroupBox1.Leave
        Me.AcceptButton = btnOK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lvSearchList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvSearchList.MouseDoubleClick
        AppendSearch()
    End Sub
End Class