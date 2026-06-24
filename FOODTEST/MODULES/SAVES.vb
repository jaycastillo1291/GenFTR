Module SAVES
    Public TransLevel As Long ' 0-Wala, 1-Add, 2-Edit, 3-Delete    (Sana masunod ko pa to)
    Dim TempID = ""
    Private strColumns As String
    Private strValues As String


    Public Sub BeginSave()
        '------------------ PRE SAVING ------------------
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name

            Case SAMPLING.Name
                With SAMPLING
                    If .lblTestNumber.Text = "0" Then
                        MsgBox("Test Number is a required field.")
                        Exit Sub
                    End If
                End With
            Case Else
                MsgBox("Module not found. Please report to IT Administrator.")
                Exit Sub
        End Select

        Select Case TransLevel
            Case 0 'No Transaction

            Case 1 'Adding
                SaveAddEntry()
                LoadAutoCmb()
                LoadBackRS()
                If BackRS.RecordCount > 0 Then BackRS.MoveLast()
            Case 2 'Editing
                SaveUpdateEntry()
                Dim strCurRecord = BackRS.Fields("RowStamp").Value.ToString
                LoadAutoCmb()
                LoadBackRS()
                MODULECONTROLS.SearchRecord(strCurRecord)
            Case 3 'Deleting
            Case Else
        End Select



        '------------------ POST SAVING ------------------
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
            Case SAMPLING.Name

            Case Else
                MsgBox("Module not found. Please report to IT Administrator.")
                Exit Sub
        End Select



        SAVES.TransLevel = 0
        isEditing = 0
    End Sub


    Public Sub SaveAddEntry()

        strColumns = ""
        strValues = ""
        For Each ctrl As Control In MAINFORM.fSelectedForm.Controls
            LoopSaveAddEntry(ctrl)
        Next

        If strColumns = "" Or strValues = "" Then
            MsgBox("Error loading the Database tables. Please Report to IT Administrator.")
            GlobalCleanup()
            'Application.Exit()
        End If


        'Connect()
        Dim dalInsert As New DataAccessLayer

        Try
            'Dim strQry = "DECLARE @tempRSTable TABLE (TempRS int); " &
            '     "INSERT INTO " & MAINFORM.fSelectedForm.AccessibleName & " (" & strColumns & ",CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) output INSERTED.RowStamp into @tempRSTable values(" &
            '                                                                        strValues & ", '" & UserName & "','" & ServerDate() & "','','1/1/1900') " &
            '    "SELECT TempRS from @tempRSTable"
            dalInsert.BeginTransaction()
            dalInsert.StrParams.Add("CreatedBy", UserName)
            Dim strQry = "INSERT INTO " & MAINFORM.fSelectedForm.AccessibleName & " (" & strColumns & ",CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)  values(" & strValues & ", @CreatedBy,getdate(),'','1/1/1900') "


            'Dim strQry = "INSERT INTO " & MAINFORM.fSelectedForm.AccessibleName & " (" & strColumns & ",CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)  values(" & strValues & ", '" & UserName & "','" & ServerDate() & "','','1/1/1900') "
            'cn.BeginTrans()
            If Not AddPostGoSave() Then
                'cn.RollbackTrans()
                dalInsert.Rollback()

                MsgBox("Problem encountered when saving. May result in Duplicate Entry." & vbCrLf & "Please report to IT Administrator")
                Exit Sub
            End If
            Dim strInsertedRS As String
            'Dim RSInserted As New ADODB.Recordset
            'cn.Execute(strQry)
            strInsertedRS = dalInsert.ExecuteScalar(strQry & "; select SCOPE_IDENTITY()")

            'RSInserted = cn.Execute("select SCOPE_IDENTITY()")
            'strInsertedRS = RSInserted.Fields(0).Value

            'strInsertedRS = dalInsert.ExecuteScalar("select SCOPE_IDENTITY()")


            InsertMisc(strInsertedRS, dalInsert, 1)
            'cn.CommitTrans()


            '------------------ POST SAVING (INSERT) ------------------

            Select Case MAINFORM.fSelectedForm.Name
                Case TESTREQ.Name
                    'cn.Execute("UpdateInsertedLeaveApp '" & TempID & "'")

                Case SAMPLING.Name
                    'Dim strQry1 = "UPDATE TESTSAMPLING set ApprovedBy = '', " &
                    '              "                         ApprovedDate = '1/1/1900', " &
                    '              "                         PostedBy = '', " &
                    '              "                         PostedDate = '1/1/1900' " &
                    '              " WHERE DocNum = '" & SAMPLING.lblTestNumber.Text & "' and DocStatus <> 'Deleted'"
                    'cn.Execute(strQry1)
                    dalInsert.StrParams.Add("RowStamp", strInsertedRS)
                    Dim strQry1 = "UPDATE TESTSAMPLING set ApprovedBy = '', " &
                                  "                         ApprovedDate = '1/1/1900', " &
                                  "                         PostedBy = '', " &
                                  "                         PostedDate = '1/1/1900' " &
                                  " WHERE RowStamp = @rowStamp and DocStatus <> 'Deleted'"
                    dalInsert.ExecuteNonQuery(strQry1)

            End Select
            dalInsert.Commit()
            MsgBox("Record Added!", vbInformation)
        Catch ex As Exception
            'If cn.State > 0 Then cn.RollbackTrans()
            If dalInsert.TransactionLevel = 1 Then dalInsert.Rollback()

            MsgBox("There was an error Adding the record. Please Report to IT Administrator." & vbCrLf & "Rolling back the changes." & vbCrLf & ex.Message, vbCritical)
        End Try
        'DisconnectCN()

    End Sub

    Private Sub LoopSaveAddEntry(ctrl As Control)
        If ctrl.HasChildren Then
            For Each c As Control In ctrl.Controls
                LoopSaveAddEntry(c)
            Next
        Else
            'For Each ctrl In MAINFORM.fSelectedForm.Controls
            If ctrl.AccessibleName = "" Then Exit Sub ' Continue For
            If InStr(ctrl.Tag, "ID") Then Exit Sub ' Continue For

            strColumns = IIf(strColumns = "", ctrl.AccessibleName, strColumns & "," & ctrl.AccessibleName)
            strValues = IIf(strValues = "", "", strValues & ",")

            If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                strValues = strValues & "'" & CStr(ctrl.Text) & "'"
            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                'strValues = strValues & "'" & CStr(IIf(IsNothing(DirectCast(ctrl, ComboBox).SelectedValue), DirectCast(ctrl, ComboBox).Text, DirectCast(ctrl, ComboBox).SelectedValue)) & "'"
                If DirectCast(ctrl, ComboBox).SelectedValue = "" Then
                    strValues = strValues & "'" & CStr(DirectCast(ctrl, ComboBox).Text) & "'"
                Else
                    strValues = strValues & "'" & CStr(DirectCast(ctrl, ComboBox).SelectedValue) & "'"
                End If
            ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                    strValues = strValues & "'" & (DirectCast(ctrl, DateTimePicker).Value).ToString("MM/dd/yyyy HH:mm") & "'"
                ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                    strValues = strValues & "'" & IIf(DirectCast(ctrl, CheckBox).Checked, "1", "0") & "'"
                ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                    strValues = strValues & "'" & IIf(DirectCast(ctrl, RadioButton).Checked, "1", "0") & "'"
            End If
            'Next
        End If
    End Sub


    Private Function AddPostGoSave() As Boolean
        AddPostGoSave = True
        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name

            Case SAMPLING.Name
                Dim strQry = "SELECT RowStamp FROM TESTSAMPLING WHERE DocNum = '" & SAMPLING.lblTestNumber.Text & "'"
                rs = Nothing
                rs = cn.Execute(strQry)
                If rs.RecordCount > 0 Then
                    AddPostGoSave = False
                End If
        End Select
        Return AddPostGoSave
    End Function

    Public Sub SaveUpdateEntry()
        'Dim strColumns = "", strValues = ""

        Dim dal As New DataAccessLayer

        strColumns = ""
        strValues = ""


        If GetAuthorization("MAINFORM", MAINFORM.fSelectedForm.AccessibleName, AccessTypes.cEdit) = 0 Then
            MsgBox("You are not allowed to Edit a record in this module. Please ask Administrator assistance.", vbInformation)
            Exit Sub
        End If

        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                'Connect()
                'rs = Nothing
                'rs = cn.Execute("SELECT * FROM TESTSAMPLING WHERE DocNum = '" & FrontRS.Fields("DocNum").Value & "' and DocStatus not in ('Cancelled','Deleted')")
                'rs = cn.Execute("SELECT * FROM TESTSAMPLING WHERE DocNum = '" & FrontRS.Fields("DocNum").Value & "'")


                'Check if it has an active SAMPLING entry
                dal.StrParams.Add("DocNum", FrontRS.Fields("DocNum").Value)
                If dal.ExecuteScalar("SELECT COUNT(RowStamp) FROM TESTSAMPLING WHERE DocNum = @DocNum and DocStatus <> 'Deleted'") > 0 Then
                    MsgBox("You cannot edit document with existing SAMPLE.")
                    Exit Sub
                End If

                'If rs.RecordCount > 0 Then
                '    MsgBox("You cannot edit document with existing SAMPLE.")
                '    Exit Sub
                'End If

                'Making sure that the entry we're updating exist
                dal.StrParams.Add("DocNum", FrontRS.Fields("DocNum").Value)
                If dal.ExecuteScalar("Select count(DocStatus) FROM TESTORDER WHERE DocNum = @DocNum") <= 0 Then
                    MsgBox("An error occured while checking the Document status.", vbCritical)
                    Exit Sub
                End If

                'rs = Nothing
                'rs = cn.Execute("Select DocStatus FROM TESTORDER WHERE DocNum = '" & FrontRS.Fields("DocNum").Value & "'")
                'If rs.RecordCount <= 0 Then
                '    MsgBox("An error occured while checking the Document status.", vbCritical)
                '    Exit Sub
                'End If

                dal.StrParams.Add("DocNum", FrontRS.Fields("DocNum").Value)
                Dim strDocStatus = (dal.ExecuteQuery("Select top 1 DocStatus FROM TESTORDER WHERE DocNum = @DocNum"))(0)("DocStatus")
                If strDocStatus <> "PENDING" Then
                    MsgBox("The document you're trying to edit has an active transaction.", vbCritical)
                    Exit Sub
                End If

                'If rs.Fields("DocStatus").Value <> "PENDING" Then
                '    MsgBox("The document you're trying to edit has an active transaction.", vbCritical)
                '    Exit Sub
                'End If

            Case SAMPLING.Name
                'Connect()
                'rs = Nothing
                'rs = cn.Execute("SELECT DocStatus FROM TESTSAMPLING WHERE RowStamp =" & BackRS.Fields("RowStamp").Value)

                dal.StrParams.Add("RowStamp", BackRS.Fields("RowStamp").Value)
                Dim strDocStatus = UCase((dal.ExecuteQuery("SELECT DocStatus FROM TESTSAMPLING WHERE RowStamp = @RowStamp"))(0)("DocStatus"))
                'If UCase(rs.Fields("DocStatus").Value) = "POSTED" Or UCase(rs.Fields("DocStatus").Value) = "APPROVED" Then
                If strDocStatus <> "OPEN" Then
                    MsgBox(strDocStatus & " entries cannot be modified." & vbCrLf & "Please report to Administrator.", vbInformation)
                    Exit Sub
                End If

                'If UCase(rs.Fields("DocStatus").Value) <> "OPEN" Then
                '    MsgBox(UCase(rs.Fields("DocStatus").Value) & " entries cannot be modified." & vbCrLf & "Please report to Administrator.", vbInformation)
                '    Exit Sub
                'End If

        End Select


        For Each ctrl As Control In MAINFORM.fSelectedForm.Controls
            LoopSaveUpdateEntry(ctrl)
        Next


        If strValues = "" Then
            MsgBox("Error loading the Database tables. Please Report to IT Administrator.")
            GlobalCleanup()
            'Application.Exit()
        End If

        'Connect()
        Dim dalInsert As New DataAccessLayer

        Try
            'Dim strQRY = "UPDATE " & MAINFORM.fSelectedForm.AccessibleName & " set " & strValues & ", ModifiedBy = '" & UserName & "', ModifiedDate = '" & ServerDate() & "' WHERE RowStamp = " & BackRS.Fields("RowStamp").Value
            Dim strQRY = "UPDATE " & MAINFORM.fSelectedForm.AccessibleName & " set " & strValues & ", ModifiedBy = @Username, ModifiedDate = GETDATE() WHERE RowStamp = @RowStamp"

            'cn.BeginTrans()
            dalInsert.BeginTransaction()
            dalInsert.StrParams.Add("Username", UserName)
            dalInsert.StrParams.Add("RowStamp", BackRS.Fields("RowStamp").Value)
            dalInsert.ExecuteQuery(strQRY)

            InsertMisc(BackRS.Fields("RowStamp").Value, dalInsert, 2)
            'cn.Execute(strQRY)
            'dalInsert.ExecuteNonQuery(strQRY)

            MsgBox("Record Updated!", vbInformation)
            'cn.CommitTrans()
            dalInsert.Commit()
        Catch ex As Exception
            'cn.RollbackTrans()
            dalInsert.Rollback()
            MsgBox("There was an error updating the record. Please Report to IT Administrator." & vbCrLf & "Rolling back the changes." & vbCrLf & ex.Message, vbCritical)
        End Try
        'DisconnectCN()
    End Sub

    Private Sub LoopSaveUpdateEntry(ctrl As Control)
        If ctrl.HasChildren Then
            For Each c As Control In ctrl.Controls
                LoopSaveUpdateEntry(c)
            Next
        Else
            'For Each ctrl In MAINFORM.fSelectedForm.Controls
            If ctrl.AccessibleName = "" Then Exit Sub
            If InStr(ctrl.Tag, "ID") Then Exit Sub

            strValues = IIf(strValues = "", ctrl.AccessibleName, strValues & " ," & vbCrLf & ctrl.AccessibleName) & " = "
            'strValues = strValues & ctrl.AccessibleName & "="

            If (ctrl.GetType() Is GetType(TextBox)) Or (ctrl.GetType() Is GetType(Label)) Then
                strValues = strValues & "'" & CStr(ctrl.Text) & "'"
            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                Dim cmbCtrl = DirectCast(ctrl, ComboBox)
                'strValues = strValues & "'" & CStr(CStr(DirectCast(ctrl, ComboBox).Text)) & "'"
                strValues = strValues & "'" & CStr(IIf(cmbCtrl.SelectedValue = "", cmbCtrl.Text, cmbCtrl.SelectedValue)) & "'"
            ElseIf (ctrl.GetType() Is GetType(DateTimePicker)) Then
                strValues = strValues & "'" & (DirectCast(ctrl, DateTimePicker).Value).ToString("MM/dd/yyyy HH:mm") & "'"
            ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                strValues = strValues & "'" & IIf(DirectCast(ctrl, CheckBox).Checked, "1", "0") & "'"
            ElseIf (ctrl.GetType() Is GetType(RadioButton)) Then
                strValues = strValues & "'" & IIf(DirectCast(ctrl, RadioButton).Checked, "1", "0") & "'"
            End If
            'Next
        End If
    End Sub


    Private Sub InsertMisc(strRowStamp As String, dal As DataAccessLayer, tranFlag As Integer) ' tranFlag (1=Adding, 2=Editing, 3=Delete)

        Select Case MAINFORM.fSelectedForm.Name
            Case TESTREQ.Name
                Dim strQryIn = ""
                With TESTREQ
                    'If TransLevel <> 1 Then cn.Execute("DELETE FROM TESTORDER_D WHERE HeadRS = '" & BackRS.Fields("RowStamp").Value & "'")

                    'If tranFlag <> 1 Then cn.Execute("DELETE FROM TESTORDER_D WHERE HeadRS = '" & strRowStamp & "'")
                    If tranFlag <> 1 Then
                        dal.StrParams.Add("RowStamp", strRowStamp)
                        dal.ExecuteNonQuery("DELETE FROM TESTORDER_D WHERE HeadRS = @RowStamp")
                    End If

                    For Each lv As ListViewItem In .lvTestList.Items
                        dal.StrParams.Add("RowStamp", strRowStamp)
                        dal.StrParams.Add("TestGroup", lv.SubItems(1).Text)
                        dal.StrParams.Add("Code", lv.SubItems(2).Text)
                        dal.StrParams.Add("TestName", lv.SubItems(3).Text)

                        strQryIn = "INSERT INTO [dbo].[TESTORDER_D] " &
                                   "        ([HeadRS] " &
                                   "        ,[TestGroup] " &
                                   "        ,[Code] " &
                                   "        ,[TestName]) " &
                                   "  VALUES " &
                                   "        (@RowStamp " &
                                   "        ,@TestGroup " &
                                   "        ,@Code " &
                                   "        ,@TestName)"

                        dal.ExecuteNonQuery(strQryIn)

                        'strQryIn = "INSERT INTO [dbo].[TESTORDER_D] " &
                        '           "        ([HeadRS] " &
                        '           "        ,[TestGroup] " &
                        '           "        ,[Code] " &
                        '           "        ,[TestName]) " &
                        '           "  VALUES " &
                        '           "        ('" & strRowStamp & "' " &
                        '           "        ,'" & lv.SubItems(1).Text & "' " &
                        '           "        ,'" & lv.SubItems(2).Text & "' " &
                        '           "        ,'" & lv.SubItems(3).Text & "')"
                        'cn.Execute(strQryIn)
                    Next
                End With

            Case SAMPLING.Name
                Dim strHeadRS, strTestGroup, strTestCode, strTestName, strMethod, strResult, strGuide, strCompliance, strTestedBy, strTestedDate, strCheckBy, strCheckDate As String
                Dim strQryIn = ""
                strHeadRS = ""
                strTestGroup = ""
                strTestCode = ""
                strTestName = ""
                strMethod = ""
                strResult = ""
                strGuide = ""
                strCompliance = ""
                strTestedBy = ""
                strTestedDate = ""
                strCheckBy = ""
                strCheckDate = ""



                With SAMPLING
                    dal.StrParams.Add("HeadRS", strRowStamp)
                    'dal.ExecuteNonQuery("DELETE FROM TESTSAMPLING_D WHERE HeadRS = (SELECT RowStamp FROM TESTSAMPLING WHERE Docnum = @DocNum)")
                    dal.ExecuteNonQuery("DELETE FROM TESTSAMPLING_D WHERE HeadRS = @HeadRS")

                    'cn.Execute("DELETE FROM TESTSAMPLING_D WHERE HeadRS = (SELECT RowStamp FROM TESTSAMPLING WHERE Docnum = '" & .lblTestNumber.Text & "')")
                    For Each i As ListViewItem In .lvTestList.Items
                        'strHeadRS = Left(RQ(.lblTestNumber.Text), 20)
                        strHeadRS = Left(RQ(i.SubItems(0).Text), 20)
                        strTestGroup = Left(RQ(i.SubItems(1).Text), 20)
                        strTestCode = Left(RQ(i.SubItems(2).Text), 20)
                        strTestName = Left(RQ(i.SubItems(3).Text), 50)
                        strMethod = Left(RQ(i.SubItems(4).Text), 30)
                        strResult = Left(RQ(i.SubItems(5).Text), 100)
                        strGuide = Left(RQ(i.SubItems(6).Text), 100)
                        strCompliance = Left(RQ(i.SubItems(7).Text), 2)
                        strTestedBy = Left(RQ(i.SubItems(9).Text), 10)
                        strTestedDate = Left(RQ(i.SubItems(10).Text), 20)
                        strCheckBy = Left(RQ(i.SubItems(11).Text), 10)
                        strCheckDate = Left(RQ(i.SubItems(12).Text), 20)

                        'If .lblRowStamp.Text = 0 Then
                        '    strHeadRS = Left(RQ(.lblTestNumber.Text), 20)
                        'Else
                        '    strHeadRS = Left(RQ(.lblRowStamp.Text), 20)
                        'End If


                        strHeadRS = strRowStamp

                        If strTestedBy = "" Then strTestedBy = UserName

                        dal.StrParams.Add("strHeadRS", strHeadRS)
                        dal.StrParams.Add("strTestGroup", strTestGroup)
                        dal.StrParams.Add("strTestCode", strTestCode)
                        dal.StrParams.Add("strTestName", strTestName)
                        dal.StrParams.Add("strMethod", strMethod)
                        dal.StrParams.Add("strResult", strResult)
                        dal.StrParams.Add("strGuide", strGuide)
                        dal.StrParams.Add("strCompliance", strCompliance)
                        dal.StrParams.Add("strTestedBy", strTestedBy)
                        dal.StrParams.Add("strTestedDate", strTestedDate)
                        dal.StrParams.Add("strCheckBy", strCheckBy)
                        dal.StrParams.Add("strCheckDate", strCheckDate)


                        strQryIn = "INSERT INTO [dbo].[TESTSAMPLING_D] " &
                                   "        ([HeadRS] " &
                                   "        ,[TestGroup] " &
                                   "        ,[TestCode] " &
                                   "        ,[TestName] " &
                                   "        ,[Method] " &
                                   "        ,[TestResult] " &
                                   "        ,[TestGuide] " &
                                   "        ,[Compliance] " &
                                   "        ,[TestBy] " &
                                   "        ,[TestDate] " &
                                   "        ,[CheckBy] " &
                                   "        ,[CheckDate] " &
                                   "        ,[isEditing]) " &
                                   "  VALUES " &
                                   "        (@strHeadRS " &
                                   "        ,@strTestGroup " &
                                   "        ,@strTestCode " &
                                   "        ,@strTestName " &
                                   "        ,@strMethod " &
                                   "        ,@strResult " &
                                   "        ,@strGuide " &
                                   "        ,@strCompliance " &
                                   "        ,@strTestedBy " &
                                   "        ," & IIf(strTestedDate = "", "getdate()", "@strTestedDate") &
                                   "        ,@strCheckBy" &
                                   "        ," & IIf(strCheckDate = "", "getdate()", "@strCheckDate") &
                                   "        , 1)"

                        dal.ExecuteNonQuery(strQryIn)

                        'strQryIn = "INSERT INTO [dbo].[TESTSAMPLING_D] " &
                        '           "        ([HeadRS] " &
                        '           "        ,[TestGroup] " &
                        '           "        ,[TestCode] " &
                        '           "        ,[TestName] " &
                        '           "        ,[Method] " &
                        '           "        ,[TestResult] " &
                        '           "        ,[TestGuide] " &
                        '           "        ,[Compliance] " &
                        '           "        ,[TestBy] " &
                        '           "        ,[TestDate] " &
                        '           "        ,[CheckBy] " &
                        '           "        ,[CheckDate] " &
                        '           "        ,[isEditing]) " &
                        '           "  VALUES " &
                        '           "        ('" & strHeadRS & "' " &
                        '           "        ,'" & strTestGroup & "' " &
                        '           "        ,'" & strTestCode & "' " &
                        '           "        ,'" & strTestName & "' " &
                        '           "        ,'" & strMethod & "' " &
                        '           "        ,'" & strResult & "' " &
                        '           "        ,'" & strGuide & "' " &
                        '           "        ,'" & strCompliance & "'" &
                        '           "        ,'" & strTestedBy & "'" &
                        '           "        ," & IIf(i.SubItems(10).Text = "", "getdate()", "'" & strTestedDate & "'") &
                        '           "        ,'" & strCheckBy & "'" &
                        '           "        ," & IIf(i.SubItems(12).Text = "", "getdate()", "'" & strCheckDate & "'") & ", 1)"
                        'cn.Execute(strQryIn)
                    Next
                    'If .lblRowStamp.Text = 0 Then
                    '    strHeadRS = Left(RQ(.lblTestNumber.Text), 20)
                    'Else
                    '    strHeadRS = Left(RQ(.lblRowStamp.Text), 20)
                    'End If
                    'strQryIn = "DELETE FROM [dbo].[TESTSAMPLING_D] WHERE [HeadRS] = '" & strHeadRS & "' and [isEditing] = 0 " &
                    '           "UPDATE [dbo].[TESTSAMPLING_D] set isEditing = 0 WHERE HeadRS = '" & strHeadRS & "'"
                    'strQryIn = "UPDATE [dbo].[TESTSAMPLING_D] set isEditing = 0 WHERE HeadRS = '" & strHeadRS & "'"

                    strQryIn = "UPDATE [dbo].[TESTSAMPLING_D] set isEditing = 0 WHERE HeadRS = @strHeadRS"
                    dal.StrParams.Add("strHeadRS", strHeadRS)
                    dal.ExecuteNonQuery(strQryIn)

                    'cn.Execute(strQryIn)
                End With
        End Select

    End Sub

End Module
