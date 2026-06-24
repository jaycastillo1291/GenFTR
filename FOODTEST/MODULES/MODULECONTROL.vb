Module MODULECONTROLS

    Public prevTxtValue = "", nextTxtValue = ""
    Public isEditing As Boolean = False

    Public Sub LOADFORM(fFormload As Form)
        Dim rs As New Resizer
        fFormload.TopLevel = False
        'MAINFORM.FORMPANEL = New Panel
        MAINFORM.FORMPANEL.Controls.Clear()
        MAINFORM.FORMPANEL.Controls.Add(fFormload)

        InitializeForm()
        LoadAutoCmb()

        If fFormload.AccessibleName = "" Then
            MsgBox("No Table specified for this module.")
        Else
            If fFormload.Tag <> "GENERIC" Then LoadBackRS()
        End If
        EnableNavigation()

        'For Each ctrl In MAINFORM.fSelectedForm.Controls
        '    'InitControl(ctrl)
        '    'If ctrl.name = "Label1" Then MsgBox(ctrl.name)
        '    'LoopInitControl(ctrl)
        '    'ControlValidation(ctrl)
        '    'System.Diagnostics.EventLog.CreateEventSource("MyApplicationSource", "Application").writeentry(ctrl.name)
        'Next

        LoopInitControl(fFormload)

        SAVES.TransLevel = 0
        fFormload.Dock = DockStyle.Fill
        fFormload.Show()


        'rs.FindAllControls(fFormload)
        'AddHandler fFormload.Resize,
        '    Sub()
        '        rs.ResizeAllControls(fFormload)
        '    End Sub
        fFormload.Focus()

        'GotFocus(fFormload)

    End Sub

    Private Sub LoopInitControl(ctrl As Control)
        If ctrl.HasChildren Then
            For Each c As Control In ctrl.Controls
                LoopInitControl(c)
            Next
        Else
            If ctrl.AccessibleName <> "" Or Not (IsNothing(ctrl.AccessibleName)) Then
                InitControl(ctrl)
                ControlValidation(ctrl)
            End If
        End If
    End Sub

    Public Sub InitializeForm()
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    'Auto1(.cmbItemName, "SELECT distinct ItemName Code, ItemName Description FROM TESTORDER WHERE DocStatus <> 'Deleted'", "TESTORDER")
                    'DisableControl(.cmbClient)

                    With .lvTestList
                        .Columns(0).Width = 0


                        .Columns(1).Width = .Width * 0.15 '  Group
                        .Columns(2).Width = .Width * 0.15 '  Code
                        .Columns(3).Width = .Width * 0.3 ' Name
                        .Columns(4).Width = 0 ' Editing
                    End With
                    .gbUrgent.Enabled = False
                    .txtStrOthr.Enabled = False
                End With

            Case SAMPLING.Name
                With SAMPLING
                    With .lvTestList
                        .Columns(0).Width = 0
                        .Columns(1).Width = .Width * 0.08 '  Group
                        .Columns(2).Width = .Width * 0.06 '  Code
                        .Columns(3).Width = .Width * 0.13 ' Name
                        .Columns(4).Width = .Width * 0.13 ' Method
                        .Columns(5).Width = .Width * 0.1 ' Result
                        .Columns(6).Width = .Width * 0.1 ' Guide
                        .Columns(7).Width = .Width * 0.05 '  Compliance
                        .Columns(8).Width = 0 '  Editing
                        .Columns(9).Width = .Width * 0.06 '  TestedBy
                        .Columns(10).Width = .Width * 0.11 '  TestDate
                        .Columns(11).Width = .Width * 0.06 '  CheckBy
                        .Columns(12).Width = .Width * 0.11 '  CheckDate
                    End With



                End With

            Case TESTLIST.Name
                With TESTLIST
                    With .lvTestList
                        .Columns(0).Width = 0
                        .Columns(1).Width = .Width * 0.35
                        .Columns(2).Width = .Width * 0.6
                    End With

                    With .lvMethodList
                        .Columns(0).Width = 0
                        .Columns(1).Width = .Width * 0.97
                        .Columns(2).Width = 0
                        .Columns(3).Width = 0
                    End With
                End With
                    Case APPROVAL.Name
                With APPROVAL
                    With .lvApprovalList
                        .Columns(0).Width = 0
                        .Columns(1).Width = .Width * 0.13
                        .Columns(2).Width = .Width * 0.15
                        .Columns(3).Width = .Width * 0.15
                        .Columns(4).Width = .Width * 0.14
                        .Columns(5).Width = .Width * 0.3
                        .Columns(6).Width = .Width * 0.12
                    End With
                End With
        End Select
    End Sub


    Private Sub InitControl(ctrl As Control)

        If ctrl.AccessibleName <> "" Then
            'AddHandler IIf((ctrl.GetType() Is GetType(RadioButton)), ctrl.Parent.Validated, ctrl.Validated),
            'If (ctrl.GetType() Is GetType(RadioButton)) Then
            '    ctrl = ctrl.Parent
            'End If
            AddHandler ctrl.Validated,
            Sub()
                '--------------- Checking Previous value ------------------>>>
                Dim strTextVal = ctrl.Text

                If BackRS Is Nothing Or FrontRS Is Nothing Then Exit Sub
                If BackRS.State = 0 Or FrontRS.State = 0 Then Exit Sub
                If BackRS.RecordCount <= 0 Or FrontRS.RecordCount <= 0 Then Exit Sub
                If TransLevel = 1 Then Exit Sub
                If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                    If InStr(ctrl.Tag, "NUMERIC") Then
                        prevTxtValue = Decimal.Parse(IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)).ToString(dblGlobalFormat)
                    ElseIf InStr(ctrl.Tag, "INTEGER") Then
                        prevTxtValue = Decimal.Parse(IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)).ToString(intGlobalFormat)
                    Else
                        prevTxtValue = FrontRS.Fields(ctrl.AccessibleName).Value
                    End If

                ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                    prevTxtValue = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), "", FrontRS.Fields(ctrl.AccessibleName).Value)
                ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                    prevTxtValue = DateTime.Parse(FrontRS.Fields(ctrl.AccessibleName).Value).ToString("MM/dd/yyyy HH:mm")
                ElseIf (ctrl.GetType() Is GetType(CheckBox)) Or (ctrl.GetType() Is GetType(RadioButton)) Then
                    prevTxtValue = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), "false", IIf(FrontRS.Fields(ctrl.AccessibleName).Value, "true", "false"))
                End If

                '-----------------Checking current value for comparison ----------------->>>>

                If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                    If InStr(ctrl.Tag, "NUMERIC") Then
                        If Not IsNumeric(strTextVal) Then strTextVal = "0"
                        nextTxtValue = Decimal.Parse(strTextVal).ToString(COMMONFUNCTION.dblGlobalFormat)
                    ElseIf InStr(ctrl.Tag, "INTEGER") Then
                        If Not IsNumeric(strTextVal) Then strTextVal = "0"
                        nextTxtValue = Decimal.Parse(strTextVal).ToString(intGlobalFormat)
                    Else
                        nextTxtValue = ctrl.Text
                    End If

                ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                    'If DirectCast(ctrl, ComboBox).SelectedValue = "" And DirectCast(ctrl, ComboBox).Text <> "" Then DirectCast(ctrl, ComboBox).SelectedValue = DirectCast(ctrl, ComboBox).Text
                    'DirectCast(ctrl, ComboBox).Text = DirectCast(ctrl, ComboBox).SelectedValue

                    nextTxtValue = IIf(DirectCast(ctrl, ComboBox).SelectedValue = "" And DirectCast(ctrl, ComboBox).Text <> "", DirectCast(ctrl, ComboBox).Text, DirectCast(ctrl, ComboBox).SelectedValue)
                ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                    nextTxtValue = DateTime.Parse(DirectCast(ctrl, DateTimePicker).Value).ToString("MM/dd/yyyy HH:mm")
                ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                    nextTxtValue = IIf(DirectCast(ctrl, CheckBox).Checked, "true", "false")
                ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                    nextTxtValue = IIf(DirectCast(ctrl, RadioButton).Checked, "true", "false")
                End If



                If nextTxtValue <> prevTxtValue And SAVES.TransLevel = 0 Then
                    isEditing = True
                    SAVES.TransLevel = 2
                End If

                nextTxtValue = ""
                prevTxtValue = ""
            End Sub

            If (ctrl.GetType() Is GetType(RadioButton)) Then
                AddHandler DirectCast(ctrl, RadioButton).Parent.Validated,
                    Sub()
                        If BackRS Is Nothing Or FrontRS Is Nothing Then Exit Sub
                        If TransLevel = 1 Or TransLevel = 0 Then Exit Sub
                        prevTxtValue = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), "false", IIf(FrontRS.Fields(ctrl.AccessibleName).Value, "true", "false"))
                        nextTxtValue = IIf(DirectCast(ctrl, RadioButton).Checked, "true", "false")

                        If nextTxtValue <> prevTxtValue And SAVES.TransLevel < 2 Then
                            isEditing = True
                            'SAVES.TransLevel = 2
                        End If

                        nextTxtValue = ""
                        prevTxtValue = ""
                    End Sub
            End If
        End If
    End Sub


    Public Sub DisableControl(sender As Object)
        For Each c As Control In sender.controls
            If c.HasChildren Then
                DisableControl(c)
            Else
                Select Case c.GetType
                    Case GetType(TextBox)
                        Dim previousValue = DirectCast(c, TextBox).Text
                        AddHandler c.Enter, Sub(send As Object, ee As EventArgs)
                                                previousValue = DirectCast(send, TextBox).Text
                                            End Sub
                        AddHandler DirectCast(c, TextBox).Validated, Sub(send As Object, ee As EventArgs)
                                                                         DirectCast(send, TextBox).Text = previousValue
                                                                     End Sub
                        AddHandler c.KeyPress, Sub(send As Object, ee As KeyPressEventArgs)
                                                   ee.Handled = True
                                               End Sub


                    Case GetType(ComboBox)
                        Dim previousValue = DirectCast(c, ComboBox).Text
                        AddHandler c.Enter, Sub(send As Object, ee As EventArgs)
                                                previousValue = DirectCast(send, ComboBox).Text
                                            End Sub
                        AddHandler DirectCast(c, ComboBox).Validated, Sub(send As Object, ee As EventArgs)
                                                                          DirectCast(send, ComboBox).Text = previousValue
                                                                      End Sub
                        AddHandler c.TabIndexChanged, Sub(send As Object, ee As KeyPressEventArgs)
                                                          ee.Handled = True
                                                      End Sub


                    Case GetType(CheckBox)
                        AddHandler DirectCast(c, CheckBox).MouseClick, Sub(send As Object, ee As EventArgs)
                                                                           Dim cCheck = DirectCast(c, CheckBox)
                                                                           If cCheck.Checked Then
                                                                               cCheck.Checked = 0
                                                                           Else
                                                                               cCheck.Checked = 1
                                                                           End If
                                                                       End Sub


                    Case GetType(RadioButton)
                        AddHandler DirectCast(c, RadioButton).MouseClick, Sub(send As Object, ee As EventArgs)
                                                                              Dim cCheck = DirectCast(c, RadioButton)
                                                                              If cCheck.Checked Then
                                                                                  cCheck.Checked = 0
                                                                              Else
                                                                                  cCheck.Checked = 1
                                                                              End If
                                                                          End Sub


                    Case GetType(DateTimePicker)
                        Dim previousValue = DirectCast(c, DateTimePicker).Value
                        AddHandler c.KeyPress, Sub(send As Object, ee As KeyPressEventArgs)
                                                   ee.Handled = True
                                               End Sub
                        AddHandler DirectCast(c, DateTimePicker).Validated, Sub(send As Object, ee As EventArgs)
                                                                                DirectCast(send, DateTimePicker).Value = previousValue
                                                                            End Sub
                        AddHandler DirectCast(c, DateTimePicker).Enter, Sub(send As Object, ee As EventArgs)
                                                                            previousValue = DirectCast(send, DateTimePicker).Value
                                                                        End Sub
                End Select
            End If
        Next

    End Sub


    Public Sub LoadBackRS()
        Dim strWhereClause = "", strQuery = ""


        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    strWhereClause = ""
                End With
        End Select

        Connect()

        'strQuery = "SELECT RowStamp, " & MAINFORM.fSelectedForm.AccessibleDescription & " RecID FROM " & MAINFORM.fSelectedForm.AccessibleName & " ORDER BY RowStamp"
        strQuery = "EXEC LoadBackRS '" & UserName & "', '" & MAINFORM.fSelectedForm.AccessibleName & "'"

        BackRS = Nothing
        BackRS = cn.Execute(strQuery)

        AddHandler BackRS.MoveComplete,
            Sub()
                'MAINFORM.strCurrentRec = IIf(BackRS.RecordCount > 0, BackRS.Fields("RecID").Value, "")
                MAINFORM.txtCurPos.Text = BackRS.AbsolutePosition
                MAINFORM.lblTotalRec.Text = "of {" & BackRS.RecordCount & "}"
                MAINFORM.fSelectedForm.ActiveControl = Nothing
                If BackRS.RecordCount > 0 Then LoadFrontRS()
            End Sub
        DisconnectCN()
    End Sub

    Public Sub LoadFrontRS()

        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ

                End With
        End Select

        Connect()
        FrontRS = Nothing
        FrontRS = cn.Execute("SELECT * FROM " & MAINFORM.fSelectedForm.AccessibleName & " WHERE RowStamp = " & BackRS.Fields("RowStamp").Value)
        If FrontRS.RecordCount <> 1 Then
            MsgBox("Error in loading the record. Please contact IT Administrator.", vbCritical)
            Exit Sub
        End If

        'LEAVEAPPLICATION.txtLeaveNo.Text = FrontRS.Fields("LeaveNo").Value

        For Each ctrl As Control In MAINFORM.fSelectedForm.Controls
            LoopLoadControl(ctrl)
        Next

        LoadMisc()
        DisconnectCN()
    End Sub

    Private Sub LoopLoadControl(ctrl As Control)
        If ctrl.Parent.GetType.Name <> "DataGridView" Then
            If ctrl.HasChildren Then
                For Each c As Control In ctrl.Controls
                    LoopLoadControl(c)
                Next
            Else
                LoadControlData(ctrl)
            End If
        End If
    End Sub


    Private Sub LoadControlData(ctrl As Control)
        If ctrl.AccessibleName <> "" Then
            If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                If InStr(ctrl.Tag, "NUMERIC") Then
                    ctrl.Text = Decimal.Parse(IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)).ToString(dblGlobalFormat)
                ElseIf InStr(ctrl.Tag, "INTEGER") Then
                    ctrl.Text = Decimal.Parse(IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)).ToString(intGlobalFormat)
                Else
                    ctrl.Text = FrontRS.Fields(ctrl.AccessibleName).Value
                End If

            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                DirectCast(ctrl, ComboBox).SelectedValue = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), "", FrontRS.Fields(ctrl.AccessibleName).Value)
            ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                DirectCast(ctrl, DateTimePicker).Value = FrontRS.Fields(ctrl.AccessibleName).Value
            ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                DirectCast(ctrl, CheckBox).Checked = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)
            ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                DirectCast(ctrl, RadioButton).Checked = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)
            End If

            SetMaxValue(ctrl)
        End If
    End Sub


    Private Sub SetMaxValue(ctrl As Control)
        'If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
        Select Case ctrl.GetType()
            Case GetType(TextBox)
                DirectCast(ctrl, TextBox).MaxLength = FrontRS.Fields(ctrl.AccessibleName).DefinedSize
            'Case GetType(Label)
            '    DirectCast(ctrl, Label).MaxLength = FrontRS.Fields(ctrl.AccessibleName).DefinedSize
            Case GetType(ComboBox)
                DirectCast(ctrl, ComboBox).MaxLength = FrontRS.Fields(ctrl.AccessibleName).DefinedSize

            Case Else
                'DirectCast(ctrl, TextBox).MaxLength = FrontRS.Fields(ctrl.AccessibleName).DefinedSize

        End Select


        'ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
        '    DirectCast(ctrl, ComboBox).MaxLength = FrontRS.Fields(ctrl.AccessibleName).DefinedSize
        'ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
        '    DirectCast(ctrl, DateTimePicker).Value = FrontRS.Fields(ctrl.AccessibleName).Value
        'ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
        '    DirectCast(ctrl, CheckBox).Checked = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)
        'ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
        '    DirectCast(ctrl, RadioButton).Checked = IIf(IsDBNull(FrontRS.Fields(ctrl.AccessibleName).Value), 0, FrontRS.Fields(ctrl.AccessibleName).Value)
        'End If
    End Sub


    Public Sub clearControls()
        For Each ctrl As Control In MAINFORM.fSelectedForm.Controls
            LoopClearControls(ctrl)
        Next
        Dim strFormName = MAINFORM.fSelectedForm.Name
        Select Case strFormName
            Case "SAMPLING"
                With SAMPLING
                    .lblTestNumber.Text = "0"
                    .lvTestList.Items.Clear()
                    '.rbInit.Checked = False
                    '.rbResamp.Checked = False
                    '.rbShelf.Checked = False
                    '.CheckBox1.Enabled = False : .CheckBox1.Checked = False
                End With

            Case "TESTREQ"
                With TESTREQ
                    .TestReqDisableControlsbyStatus(True)
                    .cmbReqBy.SelectedIndex = 0
                    .cmbReqDept.SelectedIndex = 0
                    .cmbClient.SelectedIndex = 0
                    .cmbStrReq.SelectedIndex = 0
                    .cmbTstPur.SelectedIndex = 0
                    .dtpDocDate.Value = ServerDate()
                    .dtpPD.Value = .dtpDocDate.Value
                    .dtpRecDate.Value = .dtpDocDate.Value
                    .dtpSampleStamp.Value = .dtpDocDate.Value
                    .txtContNo.Text = ""
                    .txtBatchNo.Text = ""
                    .txtCompo.Text = "0"
                    .txtAreaTemp.Text = "0"
                    .txtStrOthr.Text = ""
                    .txtRemarks.Text = ""
                    .RadioButton4.Checked = True
                    .rbIsUrgent.Checked = False
                    .RadioButton6.Checked = True
                    .RadioButton7.Checked = False
                    .RadioButton8.Checked = True
                    .RadioButton9.Checked = False
                    .RadioButton10.Checked = True
                    .RadioButton11.Checked = False
                    .RadioButton12.Checked = False
                    .RadioButton13.Checked = False
                    .RadioButton14.Checked = False
                    .RadioButton15.Checked = True
                    .RadioButton16.Checked = False

                    .lvTestList.Items.Clear()
                End With
            Case Else
                MsgBox("No selected form.")
        End Select
    End Sub

    Private Sub LoopClearControls(ctrl As Control)
        If ctrl.HasChildren Then
            For Each c As Control In ctrl.Controls
                LoopClearControls(c)
            Next
        Else
            If ctrl.AccessibleName <> "" Then
                If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                    If InStr(ctrl.Tag, "NUMERIC") Then
                        ctrl.Text = Decimal.Parse("0").ToString(dblGlobalFormat)
                    ElseIf InStr(ctrl.Tag, "INTEGER") Then
                        ctrl.Text = Decimal.Parse("0").ToString(intGlobalFormat)
                    Else
                        ctrl.Text = ""
                    End If

                ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                    DirectCast(ctrl, ComboBox).SelectedIndex = 0
                ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                    DirectCast(ctrl, DateTimePicker).Value = Now
                ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                    DirectCast(ctrl, CheckBox).Checked = 0
                ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                    DirectCast(ctrl, RadioButton).Checked = 0
                End If
            End If
        End If
    End Sub


    Private Sub ControlValidation(ctrl As Control)
        If ctrl.AccessibleName <> "" Or Not (IsNothing(ctrl.AccessibleName)) Then
            If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                'Select Case ctrl.GetType()
                '    Case GetType(TextBox)
                '        DirectCast(ctrl, TextBox).MaxLength =
                '    Case GetType(Label)

                'End Select
                ctrl.Text = IIf(InStr(ctrl.Tag, "NUMERIC") Or InStr(ctrl.Tag, "INTEGER"), "0", "") : ctrl.Enabled = True
                If ctrl.Name = TESTREQ.Label1.Name Then MsgBox("")
                AddHandler ctrl.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)

                                              Dim strCtlText As String = DirectCast(sender, TextBox).Text

                                              '' Check if the key pressed is a digit, a control key (like Backspace), or a negative sign
                                              'If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "-" Then
                                              '    ' If the key is not a digit, a control key, or a negative sign, then ignore it by setting Handled to True
                                              '    e.Handled = True
                                              'ElseIf e.KeyChar = "-" Then
                                              '    ' If the key pressed is a negative sign, make sure it's at the start and there is no existing negative sign
                                              '    If TextBox1.SelectionStart <> 0 OrElse textBoxText.Contains("-") Then
                                              '        e.Handled = True
                                              '    End If
                                              'End If

                                              If InStr(ctrl.Tag, "NUMERIC") Then
                                                  'If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "." OrElse (e.KeyChar = "-" OrElse CDbl(Val(strCtlText)) = 0)) Then
                                                  If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = vbBack OrElse e.KeyChar = "." OrElse e.KeyChar = "-" OrElse IsNumeric(e.KeyChar)) Then
                                                      e.Handled = True
                                                  End If
                                              ElseIf InStr(ctrl.Tag, "INTEGER") Then
                                                  'If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or (e.KeyChar = "-")) Then
                                                  If Not (Char.IsDigit(e.KeyChar) OrElse (e.KeyChar = "-")) Then
                                                      e.Handled = True
                                                  End If
                                              End If
                                              If InStr(ctrl.Tag, "LOCKED") Then
                                                  e.Handled = True
                                              End If
                                          End Sub

                AddHandler ctrl.Validated, Sub(sender As Object, e As EventArgs)
                                               'If DirectCast(sender, TextBox).Text = "" Then DirectCast(sender, TextBox).Text = "0.00" : Exit Sub
                                               Dim strTextValue = DirectCast(sender, TextBox).Text
                                               If InStr(ctrl.Tag, "NUMERIC") Then
                                                   If Not IsNumeric(strTextValue) Then DirectCast(sender, TextBox).Text = "0.000" : strTextValue = DirectCast(sender, TextBox).Text
                                                   Select Case sender.GetType
                                                       Case GetType(TextBox)
                                                           DirectCast(sender, TextBox).Text = Decimal.Parse(strTextValue).ToString(dblGlobalFormat)
                                                       Case GetType(ComboBox)
                                                   End Select
                                               End If
                                               If InStr(ctrl.Tag, "INTEGER") Then
                                                   If Not IsNumeric(strTextValue) Then DirectCast(sender, TextBox).Text = "0"
                                                   Select Case sender.GetType
                                                       Case GetType(TextBox)
                                                           DirectCast(sender, TextBox).Text = Decimal.Parse(DirectCast(sender, TextBox).Text).ToString(intGlobalFormat)
                                                       Case GetType(ComboBox)
                                                   End Select
                                               End If
                                           End Sub
            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                With DirectCast(ctrl, ComboBox)
                    If .Items.Count > 0 Then .SelectedIndex = 0 : .Enabled = True
                End With
            ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                DirectCast(ctrl, DateTimePicker).Value = ServerDate().ToString("MM/dd/yyyy") & " 00:00" : ctrl.Enabled = True
            ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                DirectCast(ctrl, CheckBox).Checked = False : ctrl.Enabled = True
            ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                DirectCast(ctrl, RadioButton).Checked = False : ctrl.Enabled = True
            End If
        End If
    End Sub




    Public Sub MoveRecord(ByVal strMoveTo)
        If BackRS.RecordCount <= 0 Then Exit Sub

        Select Case strMoveTo
            Case "First"
                If BackRS.AbsolutePosition > 1 Then
                    'MsgBox("Currently at FIRST Record.")
                    BackRS.MoveFirst()
                End If
            Case "Prev"
                If BackRS.AbsolutePosition > 1 Then
                    BackRS.MovePrevious()
                End If
            Case "Next"
                If BackRS.AbsolutePosition < BackRS.RecordCount Then
                    BackRS.MoveNext()
                End If
            Case "Last"
                If BackRS.AbsolutePosition < BackRS.RecordCount Then
                    BackRS.MoveLast()
                End If
            Case Else
                MsgBox("Error reading the action. Please report to IT Administrator.")
        End Select
    End Sub

    Public Sub DisableNavigation()
        With MAINFORM
            .btnMoveFirst.Enabled = False
            .btnMovePrev.Enabled = False
            .btnMoveNext.Enabled = False
            .btnMoveLast.Enabled = False
            .txtCurPos.Enabled = False : .txtCurPos.Text = ""
            .lblTotalRec.Text = "of {0}"
            .btnAddNew.Enabled = False
            .btnDelete.Enabled = False
            .btnSave.Enabled = False
            .btnSearch.Enabled = False
        End With
    End Sub

    Public Sub EnableNavigation()
        DisableNavigation()

        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name, SAMPLING.Name
                With MAINFORM
                    .btnMoveFirst.Enabled = True
                    .btnMovePrev.Enabled = True
                    .btnMoveNext.Enabled = True
                    .btnMoveLast.Enabled = True
                    .txtCurPos.Enabled = False : .txtCurPos.Text = "0"
                    .lblTotalRec.Text = "of {0}"
                    .btnAddNew.Enabled = True
                    .btnDelete.Enabled = True
                    .btnSave.Enabled = True
                    .btnSearch.Enabled = True
                End With
        End Select

    End Sub


    Public Sub LoadMisc()
        Dim rsMisc As New ADODB.Recordset
        Dim dal As New DataAccessLayer
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    .lvTestList.Items.Clear()

                    dal.StrParams.Add("RowStamp", BackRS.Fields("RowStamp").Value)
                    Dim dt = dal.ExecuteQuery("select RowStamp, HeadRS, TestGroup, Code, TestName  " &
                                    "from TESTORDER_D " &
                                    "where HeadRS = @RowStamp " &
                                    "order by left(Code,1), cast(SUBSTRING(Code, 2, 10)as numeric)")

                    For Each row As DataRow In dt.Rows
                        With .lvTestList.Items.Add(row("RowStamp"))
                            .subitems.add(row("TestGroup"))
                            .subitems.add(row("Code"))
                            .subitems.add(row("TestName"))
                        End With
                    Next

                    'rs = Nothing
                    'rs = cn.Execute("select RowStamp, HeadRS, TestGroup, Code, TestName  " &
                    '                "from TESTORDER_D " &
                    '                "where HeadRS = '" & BackRS.Fields("RowStamp").Value & "' " &
                    '                "order by left(Code,1), cast(SUBSTRING(Code, 2, 10)as numeric)")
                    'While Not rs.EOF
                    '    With .lvTestList.Items.Add(rs.Fields("RowStamp").Value)
                    '        .subitems.add(rs.Fields("TestGroup").Value)
                    '        .subitems.add(rs.Fields("Code").Value)
                    '        .subitems.add(rs.Fields("TestName").Value)
                    '    End With
                    '    rs.MoveNext()
                    'End While

                    .TestReqDisableControlsbyStatus(Not (FrontRS.Fields("DocStatus").Value <> "PENDING"))


                End With

            Case SAMPLING.Name
                With SAMPLING
                    .lvTestList.Items.Clear()

                    Dim strQry = "SELECT HeadRS, TestGroup, TestCode, TestName, Method, TestResult, TestGuide, Compliance, " &
                                        "isnull(isEditing, 0) isEditing, TestBy, TestDate, CheckBy, CheckDate " &
                                 "FROM TESTSAMPLING_D " &
                                 "WHERE HeadRS = @RowStamp"
                    'Dim dal As New DataAccessLayer
                    dal.StrParams.Add("RowStamp", FrontRS.Fields("RowStamp").Value)
                    Dim dt = dal.ExecuteQuery(strQry)

                    For Each row As DataRow In dt.Rows
                        With .lvTestList.Items.Add(row("HeadRS"))
                            .SubItems.Add(row("TestGroup"))
                            .SubItems.Add(row("TestCode"))
                            .SubItems.Add(row("TestName"))
                            .SubItems.Add(row("Method"))
                            .SubItems.Add(row("TestResult"))
                            .SubItems.Add(row("TestGuide"))
                            .SubItems.Add(row("Compliance"))
                            .SubItems.Add(row("isEditing"))
                            .SubItems.Add(row("TestBy"))
                            .SubItems.Add(CDate(row("TestDate")).ToString("MM/dd/yyyy hhh:mm"))
                            .SubItems.Add(row("CheckBy"))
                            .SubItems.Add(CDate(row("CheckDate")).ToString("MM/dd/yyyy hhh:mm"))
                        End With
                    Next





                    'rs = Nothing
                    'rs = cn.Execute("SELECT HeadRS, TestGroup, TestCode, TestName, Method, TestResult, TestGuide, Compliance, isnull(isEditing, 0) isEditing, TestBy, TestDate " &
                    '                "FROM TESTSAMPLING_D " &
                    '                "WHERE HeadRS = '" & FrontRS.Fields("RowStamp").Value & "'")
                    'While Not rs.EOF
                    '    With .lvTestList.Items.Add(rs.Fields("HeadRS").Value)
                    '        .SubItems.Add(rs.Fields("TestGroup").Value)
                    '        .SubItems.Add(rs.Fields("TestCode").Value)
                    '        .SubItems.Add(rs.Fields("TestName").Value)
                    '        .SubItems.Add(rs.Fields("Method").Value)
                    '        .SubItems.Add(rs.Fields("TestResult").Value)
                    '        .SubItems.Add(rs.Fields("TestGuide").Value)
                    '        .SubItems.Add(rs.Fields("Compliance").Value)
                    '        .SubItems.Add(rs.Fields("isEditing").Value)
                    '        .SubItems.Add(rs.Fields("TestBy").Value)
                    '        .SubItems.Add(CDate(rs.Fields("TestDate").Value).ToString("MM/dd/yyyy hhh:mm"))
                    '        rs.MoveNext()
                    '    End With
                    'End While

                End With
            Case Else

        End Select
    End Sub

    Public Sub clearMisc()
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ

                End With
            Case Else

        End Select
    End Sub

    Public Sub SearchRecord(ByVal strRowStamp)
        If BackRS.State = 0 Then Exit Sub
        BackRS.MoveFirst()
        BackRS.Find("RowStamp=" & strRowStamp)
    End Sub


    Public Sub LoadAutoCmb()
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                With TESTREQ
                    Auto1(.cmbReqDept, "select '' Code, '' Description union all Select Distinct ReqDept Code, ReqDept Description FROM TESTORDER WHERE DocStatus <> 'Canceled'", "TESTORDER")
                    Auto1(.cmbReqBy, "select '' Code, '' Description union all Select Distinct RequestedBy Code, RequestedBy Description FROM TESTORDER WHERE DocStatus <> 'Canceled'", "TESTORDER")
                    'Auto1(.cmbClient, "Select Distinct Customer Code, Customer Description FROM TESTORDER WHERE DocStatus <> 'Canceled'", "TESTORDER")
                    Auto1(.cmbClient, "select '' Code, '' Description union all select Distinct ClientCode Code, ClientName Description from SETUP_ClientMasterfile WHERE Status = 'Active'", "SETUP_ClientMasterfile")
                    'Auto1(.cmbContNo, "select '' Code, '' Description union all Select Distinct ContainerNo Code, ContainerNo Description FROM TESTORDER WHERE DocStatus <> 'Canceled'", "TESTORDER")
                    'Auto1(.cmbItemName, "select '' Code, '' Description, '12/31/3000' CreatedDate union all SELECT distinct TOP 20 ItemName Code, ItemName Description, max(CreatedDate) CreatedDate FROM TESTORDER WHERE DocStatus <> 'Deleted' group by ItemName order by 3 desc", "TESTORDER")
                    Auto1(.cmbItemName, "select ItemCode Code, Description from ItemMasterdata  WHERE Active = 1  order by ItemType, Description", "ItemMasterdata")
                    Auto1(.cmbSplUnit, "SELECT 'g' Code, 'g' Description Union all  SELECT 'mL' Code, 'mL' Description ", "")
                    Auto1(.cmbTstPur, "SELECT 'Initial Test' Code, 'Initial Test' Description " &
                                       "union all " &
                                       "Select 'Re-Sample' Code, 'Re-Sample' Description " &
                                        "union all " &
                                        "SELECT 'Shelf-Life' Code, 'Shelf-Life' Description", "")

                End With
            Case SAMPLING.Name
                With SAMPLING
                    Auto1(.cmbClient, "select '' Code, '' Description union all select Distinct ClientCode Code, ClientName Description from SETUP_ClientMasterfile WHERE Status = 'Active'", "SETUP_ClientMasterfile")
                End With
        End Select
    End Sub

End Module
