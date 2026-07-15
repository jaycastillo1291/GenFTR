Public Class SAMPLING

    Public strTestGroup, strTestCode, strTestName, strSamplingScheme, strTestResult, strGuide, strUpdateStamp As String
    Public strRequestNumber As String

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TransLevel <> 1 Or lblTestNumber.Text <> "0" Then Exit Sub
        GetApprovedRequest()
        'TESTREQUESTLIST.ShowDialog()
        'If strRequestNumber = "" Then Exit Sub
        'lblTestNumber.Text = strRequestNumber
        'SampleReceivedStat.ShowDialog()
        'strRequestNumber = ""
    End Sub


    Public Sub GetApprovedRequest()
        'If TransLevel <> 1 Or lblTestNumber.Text <> "0" Then Exit Sub
        TESTREQUESTLIST.ShowDialog()
        If strRequestNumber = "" Then Exit Sub
        lblTestNumber.Text = strRequestNumber
        SampleReceivedStat.ShowDialog()
        strRequestNumber = ""
    End Sub

    Private Sub lblTestNumber_TextChanged(sender As Object, e As EventArgs) Handles lblTestNumber.TextChanged

        lblRequestor.Text = ""
        lblDept.Text = ""
        cmbClient.Text = ""
        txtBatchNo.Text = ""
        txtContNo.Text = ""
        txtCompo.Text = ""
        dtpSampleStamp.Value = ServerDate()
        dtpProdDate.Value = dtpSampleStamp.Value
        dtpUTD.Value = dtpSampleStamp.Value
        dtpRecDate.Value = dtpSampleStamp.Value
        txtPlaceOfSampling.Text = ""
        txtAreaTemp.Text = "0"
        txtQty.Text = "0"
        dtpDateRequested.Value = dtpSampleStamp.Value
        'dtpDateNeeded.Value = dtpSampleStamp.Value
        txtItemName.Text = ""
        txtTestPurpose.Text = ""
        lblSplUnit.Text = ""


        If lblTestNumber.Text = "0" Then Exit Sub


        'Dim strQry = "select Top 1 DocNum, DocDate, RequestedBy, ReqDept, Customer, BatchNo, ContainerNo, Composition, ProdDate, UTD, RecDate, 
        '                        SamplingTimeStamp, PlaceOfSampling, AreaTemp, SampleQty, StoreReqCmb, DateNeeded, ItemName, TestPurpose, Remarks,
        '                        isServNorm, isUrgent, isDisposal, isReturnPickup, isReportSigned, isReportDigital, isAWithUncert, isANoUncert, 
        '                        isBNoConfo, isBConfo, isDecision1, isDecision2
        '                FROM TESTORDER WHERE DocNum = @DocNum"

        Dim strQry = "select Top 1 DocNum, DocDate, RequestedBy, ReqDept, isnull((SELECT i2.ClientName FROM SETUP_ClientMasterfile i2 WHERE i2.ClientCode = Customer),'') Customer, BatchNo, ContainerNo, Composition, ProdDate, UTD, RecDate, 
                                SamplingTimeStamp, PlaceOfSampling, AreaTemp, SampleQty, SplUnit, StoreReqCmb, StoreReqOth, isnull((SELECT top 1  Description FROM ItemMasterData i1 WHERE i1.Itemcode = ItemName),'') ItemName, TestPurpose, Remarks, isServNorm, isUrgent, isDisposal, isReturnPickup, isReportSigned, isReportDigital, isAWithUncert, isANoUncert, isBNoConfo, isBConfo, isDecision1, isDecision2, isUrgentA, isUrgentB, isUrgentC, isFDACirc, isSuppSpec, isInternalSpec, isPNS, isBOther, txtBOther 
                        FROM TESTORDER WHERE DocNum = @DocNum"
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("DocNum", Trim(lblTestNumber.Text))
        Dim dt As DataTable = dal.ExecuteQuery(strQry)


        For Each row As DataRow In dt.Rows
            lblTestNumber.Text = row("DocNum")
            lblRequestor.Text = row("RequestedBy")
            lblDept.Text = row("ReqDept")
            cmbClient.Text = row("Customer")
            txtBatchNo.Text = row("BatchNo")
            txtContNo.Text = row("ContainerNo")
            txtCompo.Text = row("Composition")
            dtpProdDate.Value = row("ProdDate")
            dtpUTD.Value = row("UTD")
            dtpRecDate.Value = row("RecDate")
            dtpSampleStamp.Value = row("SamplingTimeStamp")
            txtPlaceOfSampling.Text = row("PlaceOfSampling")
            txtAreaTemp.Text = row("AreaTemp")
            txtQty.Text = Decimal.Parse(row("SampleQty")).ToString("#,##0.00")
            lblSplUnit.Text = row("SplUnit").ToString()
            txtPlaceOfSampling.Text = row("StoreReqCmb")
            dtpDateRequested.Value = row("DocDate")
            'dtpDateNeeded.Value = row("DateNeeded")
            txtStoreReq.Text = row("StoreReqCmb")
            txtStoreReqOth.Text = row("StoreReqOth")
            txtItemName.Text = row("ItemName")
            txtTestPurpose.Text = row("TestPurpose")
            txtRemarks.Text = row("Remarks")
            rbNormal.Checked = row("isServNorm")
            rbUrgent.Checked = row("isUrgent")
            rbDisposal.Checked = row("isDisposal")
            rbReturnPick.Checked = row("isReturnPickup")
            cbSigned.Checked = row("isReportSigned")
            cbDigital.Checked = row("isReportDigital")
            cbCOAMU.Checked = row("isAWithUncert")
            cbCOAnoMU.Checked = row("isANoUncert")
            cbwoConform.Checked = row("isBNoConfo")
            cbwConform.Checked = row("isBConfo")
            cbDec1.Checked = row("isDecision1")
            cbDec2.Checked = row("isDecision2")
            chkUrgentA.Checked = row("isUrgentA")
            chkUrgentB.Checked = row("isUrgentB")
            chkUrgentC.Checked = row("isUrgentC")
            rbisFDACirc.Checked = row("isFDACirc")
            rbisSuppSpec.Checked = row("isSuppSpec")
            rbisInternalSpec.Checked = row("isInternalSpec")
            rbisPNS.Checked = row("isPNS")
            rbisBOther.Checked = row("isBOther")
            txtBOther.Text = row("txtBOther")
        Next

        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select DocNum, DocDate, RequestedBy, ReqDept, Customer, BatchNo, ContainerNo, Composition, ProdDate, UTD, RecDate, 
        '                        SamplingTimeStamp, PlaceOfSampling, AreaTemp, SampleQty, StoreReqCmb, DateNeeded, ItemName, TestPurpose, Remarks,
        '                        isServNorm, isUrgent, isDisposal, isReturnPickup,
        '                        isReportSigned, isReportDigital, isAWithUncert, isANoUncert, isBNoConfo, isBConfo, isDecision1, isDecision2
        '                FROM TESTORDER WHERE DocNum = '" & Trim(lblTestNumber.Text) & "'")

        'If Not rs.EOF Then
        '    lblTestNumber.Text = rs.Fields("DocNum").Value
        '    lblRequestor.Text = rs.Fields("RequestedBy").Value
        '    lblDept.Text = rs.Fields("ReqDept").Value
        '    cmbClient.Text = rs.Fields("Customer").Value
        '    txtBatchNo.Text = rs.Fields("BatchNo").Value
        '    txtContNo.Text = rs.Fields("ContainerNo").Value
        '    txtCompo.Text = rs.Fields("Composition").Value
        '    dtpProdDate.Value = rs.Fields("ProdDate").Value
        '    dtpUTD.Value = rs.Fields("UTD").Value
        '    dtpRecDate.Value = rs.Fields("RecDate").Value
        '    dtpSampleStamp.Value = rs.Fields("SamplingTimeStamp").Value
        '    txtPlaceOfSampling.Text = rs.Fields("PlaceOfSampling").Value
        '    txtAreaTemp.Text = rs.Fields("AreaTemp").Value
        '    txtQty.Text = Decimal.Parse(rs.Fields("SampleQty").Value).ToString("#,##0.00")
        '    txtPlaceOfSampling.Text = rs.Fields("StoreReqCmb").Value
        '    dtpDateRequested.Value = rs.Fields("DocDate").Value
        '    dtpDateNeeded.Value = rs.Fields("DateNeeded").Value
        '    txtItemName.Text = rs.Fields("ItemName").Value
        '    txtTestPurpose.Text = rs.Fields("TestPurpose").Value
        '    txtRemarks.Text = rs.Fields("Remarks").Value
        '    rbNormal.Checked = rs.Fields("isServNorm").Value
        '    rbUrgent.Checked = rs.Fields("isUrgent").Value
        '    rbDisposal.Checked = rs.Fields("isDisposal").Value
        '    rbReturnPick.Checked = rs.Fields("isReturnPickup").Value
        '    cbSigned.Checked = rs.Fields("isReportSigned").Value
        '    cbDigital.Checked = rs.Fields("isReportDigital").Value
        '    cbCOAMU.Checked = rs.Fields("isAWithUncert").Value
        '    cbCOAnoMU.Checked = rs.Fields("isANoUncert").Value
        '    cbwoConform.Checked = rs.Fields("isBNoConfo").Value
        '    cbwConform.Checked = rs.Fields("isBConfo").Value
        '    cbDec1.Checked = rs.Fields("isDecision1").Value
        '    cbDec2.Checked = rs.Fields("isDecision2").Value
        '    rs.MoveNext()
        'End If
    End Sub

    Private Sub SAMPLING_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpSampleStamp.CustomFormat = "MM/dd/yyyy HH:mm tt"
        strRequestNumber = ""

        DisableControl(TabPage1)
        DisableControl(GBREJECT)
    End Sub

    Private Sub lvInItem_MouseClick(sender As Object, e As MouseEventArgs) Handles lvTestList.MouseUp
        If e.Button = MouseButtons.Right Then
            If lblStatus.Text <> "PENDING" And lblStatus.Text <> "Open" Then Exit Sub
            If lblTestNumber.Text = "0" Then MsgBox("You should first link a Request. " & vbCrLf & "Click on the 'Test Report Number' to Link a request") : Exit Sub
            cmsInit()
            InitiateTestVariables()
            cmsListViewOptions.Show(Cursor.Position)
        End If
    End Sub

    Private Sub InitiateTestVariables()
        strTestGroup = ""
        strTestCode = ""
        strTestName = ""
        strSamplingScheme = ""
        strTestResult = ""
        strGuide = ""
        strUpdateStamp = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button3.Click
        'If Not CheckAuth("PRODUCTRUN", "VIEWFORM", "Read") Then Exit Sub
        'REPORTVIEWING.ShowReportDialog("SAMPLINGSHOWFORM")


        Select Case DirectCast(sender, Button).Name
            Case Button1.Name
                If lblTestNumber.Text = "0" Or lblTestNumber.Text = "" Then Exit Sub
                If TransLevel <> 0 Then Exit Sub
                REPORTVIEWING.ShowSampling(CStr(BackRS.Fields("RowStamp").Value), 1)
            Case Button3.Name
                ' MsgBox("This is where the result will be shown")
                'If TransLevel <> 0 Then Exit Sub
                If lblTestNumber.Text.Length <= 5 Then Exit Sub
                Dim dal As New DataAccessLayer
                Dim strQry = "SELECT RowStamp FROM TESTORDER WHERE DocNum = @DocNum"
                dal.StrParams.Add("DocNum", Me.lblTestNumber.Text)
                Dim iRS = dal.ExecuteScalar(strQry)
                If Not IsNothing(iRS) Then
                    REPORTVIEWING.ShowRequest(CStr(iRS))
                Else
                    MsgBox("No test result to show.", vbCritical)
                End If


        End Select

    End Sub


    Private Sub cmsInit()
        Dim cms = New ContextMenuStrip


        Dim item1 As ToolStripMenuItem = cms.Items.Add("Add Item")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf AddItem

        If lvTestList.SelectedItems.Count > 0 Then
            If CheckGroupEdit(lvTestList.SelectedItems(0).SubItems(1).Text) Then
                Dim item2 As ToolStripMenuItem = cms.Items.Add("Delete row")
                item2.Tag = 2
                AddHandler item2.Click, AddressOf DeleteItem
            End If
        End If

        If lvTestList.SelectedItems.Count = 1 Then
            If CheckGroupEdit(lvTestList.SelectedItems(0).SubItems(1).Text) Then
                Dim item3 = cms.Items.Add("Edit")
                item3.Tag = 3
                'AddHandler item3.Click, AddressOf EditItem
                Dim item3StripItem = DirectCast(item3, ToolStripMenuItem)
                Dim item31 As New ToolStripMenuItem
                Dim item32 As New ToolStripMenuItem
                Dim item33 As New ToolStripMenuItem
                Dim item34 As New ToolStripMenuItem
                Dim item35 As New ToolStripMenuItem

                item31.Name = "TestResult" : item31.Text = "Test Result"
                item32.Name = "Guide" : item32.Text = "Guide"
                item33.Name = "Comp" : item33.Text = "Tag/Untag Compliant"
                item34.Name = "CheckDate" : item34.Text = "Edit Check Date"
                item35.Name = "TestDate" : item35.Text = "Edit Test Date"


                AddHandler item31.Click, AddressOf EditItemResult
                AddHandler item32.Click, AddressOf EditItemGuide
                AddHandler item33.Click, AddressOf SwitchComp
                AddHandler item34.Click, Sub(sender, e) UpdateEditStamp(12)
                AddHandler item35.Click, Sub(sender, e) UpdateEditStamp(10)

                item3StripItem.DropDownItems.Add(item31)
                item3StripItem.DropDownItems.Add(item32)
                item3StripItem.DropDownItems.Add(item33)
                item3StripItem.DropDownItems.Add(item34)
                item3StripItem.DropDownItems.Add(item35)
            End If
        End If



        cmsListViewOptions = cms
    End Sub

    Private Function CheckGroupEdit(ByVal strSampGroupName) As Boolean
        CheckGroupEdit = False

        Dim strQry = "select cRead from vwGroupAuth where Module = 'SAMPGROUP' and GroupName = @GroupName and AccessName = @AccessName"
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("GroupName", GroupName)
        dal.StrParams.Add("AccessName", strSampGroupName)
        Dim dt = dal.ExecuteScalar(strQry)
        'If dt <= 0 Then Exit Function
        If Not (dt = 1) Then Exit Function


        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select cRead from vwGroupAuth where Module = 'SAMPGROUP' and GroupName = '" & GroupName & "' and AccessName = '" & strSampGroupName & "'")
        'If rs.RecordCount <= 0 Then Exit Function
        'If Not rs.Fields("cRead").Value Then Exit Function

        CheckGroupEdit = True

        Return CheckGroupEdit
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RejectEntry()
    End Sub

    Private Sub RejectEntry()
        If lblStatus.Text <> "Open" Or
           lblTestNumber.Text = "0" Or
           lblTestNumber.Text = "" Then MsgBox("This function is available on for 'OPEN' documents.", vbInformation) : Exit Sub


        'Dim reason = InputBox("Reason:", "Reject request")
        'If reason = "" Then
        '    MsgBox("Reason is required for reject a request.")
        '    Exit Sub
        'End If

        If MsgBox("This action will remove all the test items on the list. Continue?", vbYesNo) = vbNo Then Exit Sub
        REJECTSAMPLING.ShowDialog()

        If chkRR1.Checked = 0 And chkRR2.Checked = 0 And chkRR3.Checked = 0 And chkRR4.Checked = 0 And chkRR5.Checked = 0 And
            (chkRROther.Checked = 0 Or (chkRROther.Checked = 1 And txtRROthText.Text = "")) Then
            Exit Sub
        End If

        lvTestList.Items.Clear()
        'rbCompliant.Checked = False
        If SAVES.TransLevel = 0 Then SAVES.TransLevel = 2

    End Sub

    Private Sub btnLoadPrev_Click(sender As Object, e As EventArgs) Handles btnLoadPrev.Click
        If lblStatus.Text <> "Open" Then Exit Sub

        Dim strQry = "EXEC GetLatestTest @TestNo, @UserName"
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("TestNo", lblTestNumber.Text)
        dal.StrParams.Add("UserName", UserName)
        Dim dt = dal.ExecuteQuery(strQry)

        For Each row As DataRow In dt.Rows
            For Each i As ListViewItem In lvTestList.Items
                If row("TestCode") = i.SubItems(2).Text Then
                    rs.MoveNext()
                    GoTo skipLine
                End If
            Next
            With lvTestList.Items.Add("")
                .SubItems.Add(row("TestGroup"))
                .SubItems.Add(row("TestCode"))
                .SubItems.Add(row("TestName"))
                .SubItems.Add(row("Method"))
                .SubItems.Add("")
                .SubItems.Add(row("TestGuide"))
                .SubItems.Add(IIf(cbwConform.Checked, "C", "NC"))
                .SubItems.Add("1")
                .SubItems.Add("") 'TestedBy
                .SubItems.Add("") 'TestedDate
                .SubItems.Add("") 'CheckBy
                .SubItems.Add("") 'CheckDate
            End With
skipLine:
        Next


        'Connect()
        'rs = Nothing
        'rs = cn.Execute("EXEC GetLatestTest '" & lblTestNumber.Text & "', '" & UserName & "'")

        'While Not rs.EOF
        '    For Each i As ListViewItem In lvTestList.Items
        '        If rs.Fields("TestCode").Value = i.SubItems(2).Text Then
        '            rs.MoveNext()
        '            Continue While
        '        End If
        '    Next

        '    With lvTestList.Items.Add("")
        '        .SubItems.Add(rs.Fields("TestGroup").Value)
        '        .SubItems.Add(rs.Fields("TestCode").Value)
        '        .SubItems.Add(rs.Fields("TestName").Value)
        '        .SubItems.Add(rs.Fields("Method").Value)
        '        .SubItems.Add("")
        '        .SubItems.Add(rs.Fields("TestGuide").Value)
        '        .SubItems.Add("NC")
        '        .SubItems.Add("1")
        '        .SubItems.Add("") 'TestedBy
        '        .SubItems.Add("") 'TestedDate
        '    End With
        '    rs.MoveNext()
        'End While

    End Sub

    Private Sub rbSR1No_Validated(sender As Object, e As EventArgs) Handles rbSR1No.Validated, rbSR2No.Validated, rbSR3No.Validated, rbSR4No.Validated
        Select Case sender.name
            Case rbSR1No.Name
                ForceValidated(rbSR1Yes)
            Case rbSR2No.Name
                ForceValidated(rbSR2Yes)
            Case rbSR3No.Name
                ForceValidated(rbSR3Yes)
            Case rbSR4No.Name
                ForceValidated(rbSR4Yes)
        End Select
    End Sub


    Private Sub ForceValidated(ByVal target As Control)
        ' Access the protected OnValidated method
        Dim method = GetType(Control).GetMethod("OnValidated",
        Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)

        If method IsNot Nothing Then
            ' This triggers the anonymous Sub() you attached in InitControl
            method.Invoke(target, New Object() {EventArgs.Empty})
        End If
    End Sub

    'Private Sub lvTestList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTestList.SelectedIndexChanged

    'End Sub

    Private Sub AddItem()
        InitiateTestVariables()
        TESTSELECT.ShowDialog()

        If strTestCode = "" Or strSamplingScheme = "" Then InitiateTestVariables() : Exit Sub

        strTestResult = Trim(InputBox("Enter Test Result", "TEST RESULT"))

        If strTestResult = "" Then
            If MsgBox("You entered blank Result. Continue?", vbYesNo) = vbNo Then
                InitiateTestVariables()
                Exit Sub
            End If
        End If


        With lvTestList.Items.Add("")
            .SubItems.Add(Me.strTestGroup)
            .SubItems.Add(Me.strTestCode)
            .SubItems.Add(Me.strTestName)
            .SubItems.Add(Me.strSamplingScheme)
            .SubItems.Add(Me.strTestResult)
            .SubItems.Add(Me.strGuide)
            .SubItems.Add("NC")
            .SubItems.Add("1")

            If strTestResult <> "" Then
                .SubItems.Add(UserName) 'TestedBy
                .SubItems.Add(ServerDate().ToString("MM/dd/yyyy HH:mm")) 'TestedDate
            Else
                .SubItems.Add("") 'TestedBy
                .SubItems.Add("") 'TestedDate
            End If


            If Me.strGuide <> "" Then
                .SubItems.Add(UserName) 'CheckBy
                .SubItems.Add(ServerDate().ToString("MM/dd/yyyy HH:mm")) 'CheckDate
            Else
                .SubItems.Add("") 'CheckBy
                .SubItems.Add("") 'CheckDate
            End If
        End With
        If SAVES.TransLevel = 0 Then SAVES.TransLevel = 2
    End Sub


    Private Sub DeleteItem()
        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub
        lvTestList.SelectedItems(0).Remove()
        If SAVES.TransLevel = 0 Then SAVES.TransLevel = 2
    End Sub

    Private Sub EditItemResult()

        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub

        InitiateTestVariables()


        strTestGroup = lvTestList.SelectedItems(0).SubItems(1).Text
        strTestCode = lvTestList.SelectedItems(0).SubItems(2).Text
        strTestName = lvTestList.SelectedItems(0).SubItems(3).Text
        strSamplingScheme = lvTestList.SelectedItems(0).SubItems(4).Text
        strTestResult = Trim(InputBox("Enter Test Result", "TEST RESULT", lvTestList.SelectedItems(0).SubItems(5).Text))
        strGuide = lvTestList.SelectedItems(0).SubItems(6).Text
        strUpdateStamp = lvTestList.SelectedItems(0).SubItems(9).Text

        If strTestResult = lvTestList.SelectedItems(0).SubItems(5).Text Then Exit Sub

        lvTestList.SelectedItems(0).SubItems(5).Text = strTestResult
        lvTestList.SelectedItems(0).SubItems(8).Text = "1"
        lvTestList.SelectedItems(0).SubItems(11).Text = UserName
        lvTestList.SelectedItems(0).SubItems(12).Text = ServerDate().ToString("MM/dd/yyyy HH:mm")

        If TransLevel = 0 Then TransLevel = 2
    End Sub

    Private Sub UpdateEditStamp(editCol As Integer) 'Edit Check Date
        Dim DefDateValue = ServerDate()
        Dim strEditingDate = ""
        If lvTestList.SelectedItems.Count > 0 Then
            strEditingDate = lvTestList.SelectedItems(0).SubItems(editCol).Text
            If strEditingDate = "" Then strEditingDate = DefDateValue
            DefDateValue = Date.Parse(strEditingDate).ToString("MM/dd/yyyy HH:mm")
        End If

        Dim CheckDateLimit = True

        Dim strQry = "select cRead from vwGroupAuth " &
                        "where GroupName = @GroupName " &
                        "    and Module = 'TESTSAMPLING' " &
                        "   and AccessName = 'LimitTestDate' " &
                        "   and cRead = 1"
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("GroupName", GroupName)
        Dim dt = dal.ExecuteScalar(strQry)
        CheckDateLimit = IIf(dt <= 0, False, True)

        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select cRead from vwGroupAuth " &
        '                "where GroupName = '" & GroupName & "' " &
        '                "    and Module = 'TESTSAMPLING' " &
        '                "   and AccessName = 'LimitTestDate' " &
        '                "   and cRead = 1")
        'CheckDateLimit = IIf(rs.RecordCount <= 0, False, True)

        Dim dialog As New dtpDialog() With {
        .DateFormat = "MM/dd/yyyy HH:mm",
        .MousePosition1 = cmsListViewOptions.Location,
        .DefaultValue = Date.Parse(DefDateValue).ToString("MM/dd/yyyy HH:mm"),
        .MaxDate = ServerDate(),
        .MinDate = IIf(CheckDateLimit, "1/1/2010", DateAdd(DateInterval.Day, -7, ServerDate))
        }

        If dialog.ShowDialog() = DialogResult.OK Then
            Dim selectedDateTime As DateTime = dialog.SelectedDateTime
            ' Use the selectedDateTime as needed
            lvTestList.SelectedItems(0).SubItems(editCol).Text = selectedDateTime.ToString("MM/dd/yyyy HH:mm")
            lvTestList.SelectedItems(0).SubItems(editCol - 1).Text = UserName

            'MsgBox(selectedDateTime)
        End If
        If TransLevel = 0 Then TransLevel = 2
    End Sub



    Private Sub EditItemGuide()

        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub

        InitiateTestVariables()

        strTestGroup = lvTestList.SelectedItems(0).SubItems(1).Text
        strTestCode = lvTestList.SelectedItems(0).SubItems(2).Text
        strTestName = lvTestList.SelectedItems(0).SubItems(3).Text
        strSamplingScheme = lvTestList.SelectedItems(0).SubItems(4).Text
        strTestResult = lvTestList.SelectedItems(0).SubItems(5).Text
        strGuide = Trim(InputBox("Enter Test Guide", "TEST GUIDE", lvTestList.SelectedItems(0).SubItems(6).Text))
        strUpdateStamp = lvTestList.SelectedItems(0).SubItems(9).Text

        If strGuide = lvTestList.SelectedItems(0).SubItems(6).Text Then Exit Sub

        lvTestList.SelectedItems(0).SubItems(6).Text = strGuide
        lvTestList.SelectedItems(0).SubItems(8).Text = "1"

        lvTestList.SelectedItems(0).SubItems(11).Text = UserName
        lvTestList.SelectedItems(0).SubItems(12).Text = ServerDate().ToString("MM/dd/yyyy HH:mm")
        If TransLevel = 0 Then TransLevel = 2
    End Sub

    Private Sub SwitchComp() 'Change compliance status
        If lvTestList.SelectedItems.Count <= 0 Then Exit Sub
        With lvTestList.SelectedItems(0)
            .SubItems(7).Text = IIf(.SubItems(7).Text = "NC", "C", "NC")
            .SubItems(8).Text = "1"
            .SubItems(11).Text = UserName
            .SubItems(12).Text = ServerDate().ToString("MM/dd/yyyy HH:mm")
        End With
        If TransLevel = 0 Then TransLevel = 2
    End Sub
End Class