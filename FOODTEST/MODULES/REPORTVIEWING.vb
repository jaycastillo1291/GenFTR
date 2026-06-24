Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data.OleDb

Module REPORTVIEWING

    Public cryRpt As New ReportDocument

    Private strRequestRowStamp As String

    Public Sub ShowRequest(strRowStamp As String)
        strRequestRowStamp = strRowStamp
        ShowReportDialog("REQUESTSHOWREPORT")
    End Sub
    Public Sub ShowSampling(strRowStamp As String, Optional ByVal isPreview As Boolean = 0)
        strRequestRowStamp = strRowStamp
        ShowReportDialog(IIf(isPreview, "SAMPLINGREPORTPREV", "SAMPLINGREPORT"))
    End Sub


    Public Sub ShowReportDialog(ByVal strReportName)
        'Dim frm As New LoadingForm()
        'frm.ShowDialog()
        Dim paramCnt As Integer
        Dim strParams(,) As String ' Element 1 is data field, element 2 is the actual parameter
        Dim strPrevStatus As String

        strPrevStatus = ""

        Dim CrTables As Tables
        Dim CrTable As Table
        Dim strNewReportPath As String

        cryRpt = Nothing
        cryRpt = New ReportDocument

        paramCnt = 0
        strNewReportPath = Application.StartupPath & "\REPORTS\"



        ReDim strParams(2, paramCnt)
        Dim x = 0
        Select Case strReportName

            'Case "SAMPLINGSHOWFORM", "ORDERSHOWFORM", "APPROVALSHOWFORM"
            '    paramCnt = 0
            '    ReDim strParams(2, paramCnt)
            '    Dim fRowStamp As String
            '    Dim strDocNum As String
            '    fRowStamp = ""
            '    strDocNum = ""

            '    Select Case MAINFORM.fSelectedForm.Name
            '        Case SAMPLING.Name
            '            strDocNum = SAMPLING.lblTestNumber.Text
            '        Case TESTREQ.Name
            '            strDocNum = TESTREQ.lblTestNumber.Text
            '    End Select

            '    If strReportName = "POSTINGSHOWFORM" Then
            '        strDocNum = BATCHPOSTING.strBatchPostingDocNum
            '    End If

            '    If strReportName = "APPROVALSHOWFORM" Then
            '        strDocNum = APPROVAL.strApprovalRefNo
            '    End If



            '    strParams(0, 0) = "pDocNum" : strParams(1, 0) = strDocNum
            '    cryRpt.Load(strNewReportPath & "FoodTestSampling.rpt")

            Case "REQUESTSHOWREPORT"
                paramCnt = 0
                ReDim strParams(2, paramCnt)

                strParams(0, 0) = "DocumentRS" : strParams(1, 0) = strRequestRowStamp

                cryRpt.Load(strNewReportPath & "FoodTestRequest.rpt")

            Case "SAMPLINGREPORT", "SAMPLINGREPORTPREV"
                paramCnt = 1
                ReDim strParams(2, paramCnt)

                strParams(0, 0) = "DocumentRS" : strParams(1, 0) = strRequestRowStamp
                strParams(0, 1) = "isPreview" : strParams(1, 1) = IIf(strReportName = "SAMPLINGREPORTPREV", 1, 0)
                'strParams(0, 0) = "pDocNum" : strParams(1, 0) = BATCHPOSTING.strBatchPostingDocNum

                cryRpt.Load(strNewReportPath & "FoodTestSampling.rpt")


            Case Else
                MsgBox("No selected report!", vbCritical)
                Exit Sub
        End Select


        Call CrystalLogin()
        cryRpt.Refresh()

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'Assigning Parameter 1
        Dim crParameterFieldDefinitions1(paramCnt) As ParameterFieldDefinitions
        Dim crParameterFieldDefinition1(paramCnt) As ParameterFieldDefinition
        Dim crParameterValues1(paramCnt) As ParameterValues
        Dim crParameterDiscreteValue1(paramCnt) As ParameterDiscreteValue



        For x = 0 To crParameterFieldDefinition1.Length - 1
            'crParameterFieldDefinitions1(x) = New ParameterFieldDefinitions
            'crParameterFieldDefinition1(x) = New ParameterFieldDefinition
            crParameterValues1(x) = New ParameterValues
            crParameterDiscreteValue1(x) = New ParameterDiscreteValue
        Next


        For x = 0 To crParameterFieldDefinition1.Length - 1
            crParameterDiscreteValue1(x).Value = strParams(1, x).ToString
            crParameterFieldDefinitions1(x) = cryRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition1(x) = crParameterFieldDefinitions1(x).Item(strParams(0, x).ToString)
            crParameterValues1(x) = crParameterFieldDefinition1(x).CurrentValues


            crParameterValues1(x).Clear()
            crParameterValues1(x).Add(crParameterDiscreteValue1(x))
            crParameterFieldDefinition1(x).ApplyCurrentValues(crParameterValues1(x))
        Next


        'CRYSTALVIEWER2.CrystalReportViewer2.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
        'cryRpt.Refresh()
        CRYSTALVIEWER2.ShowDialog()
    End Sub

    Public Sub ShowReportForm(ByVal strReportName)

        Dim paramCnt As Integer
        Dim strParams(,) As String ' Element 1 is data field, element 2 is the actual parameter
        Dim strPrevStatus As String
        Dim x = 0

        strPrevStatus = ""

        Dim CrTables As Tables
        Dim CrTable As Table
        Dim strNewReportPath As String

        paramCnt = 0
        CrTables = Nothing
        CrTable = Nothing

        cryRpt = Nothing
        cryRpt = New ReportDocument

        paramCnt = 0
        strNewReportPath = Application.StartupPath & "\REPORTS\"

        Connect()

        Select Case strReportName

            Case "MBOR Summary"
                paramCnt = 0
                ReDim strParams(2, paramCnt)

                'connect()
                strParams(0, 0) = "pProdDate" : strParams(1, 0) = Year(CRYSTALVIEWER.dtpParam1.Value)
                cryRpt.Load(strNewReportPath & "MBOR_Summary.rpt")

            Case "MBOR Detail"
                paramCnt = 0
                ReDim strParams(2, paramCnt)

                'connect()
                strParams(0, 0) = "pDate" : strParams(1, 0) = CDate(CRYSTALVIEWER.dtpParam1.Value)
                cryRpt.Load(strNewReportPath & "MBOR_Detailed.rpt")

            Case "CM Traceability"
                paramCnt = 1
                ReDim strParams(1, paramCnt)
                Dim strItemName = CRYSTALVIEWER.txtParam4.Text

                'connect()
                strParams(0, 0) = "PD" : strParams(1, 0) = CDate(CRYSTALVIEWER.dtpParam1.Value)
                strParams(0, 1) = "ItemName" : strParams(1, 1) = RQ(strItemName)
                cryRpt.Load(strNewReportPath & "CM-Traceability.rpt")

            Case Else
                MsgBox("No selected report!", vbCritical)
                Exit Sub
        End Select

        Call CrystalLogin()
        cryRpt.Refresh()

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'Assigning Parameter 1
        Dim crParameterFieldDefinitions1(paramCnt) As ParameterFieldDefinitions
        Dim crParameterFieldDefinition1(paramCnt) As ParameterFieldDefinition
        Dim crParameterValues1(paramCnt) As ParameterValues
        Dim crParameterDiscreteValue1(paramCnt) As ParameterDiscreteValue


        For x = 0 To crParameterFieldDefinition1.Length - 1
            'crParameterFieldDefinitions1(x) = New ParameterFieldDefinitions
            'crParameterFieldDefinition1(x) = New ParameterFieldDefinition
            crParameterValues1(x) = New ParameterValues
            crParameterDiscreteValue1(x) = New ParameterDiscreteValue
        Next


        For x = 0 To crParameterFieldDefinition1.Length - 1


            crParameterDiscreteValue1(x).Value = strParams(1, x).ToString
            crParameterFieldDefinitions1(x) = cryRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition1(x) = crParameterFieldDefinitions1(x).Item(strParams(0, x).ToString)
            crParameterValues1(x) = crParameterFieldDefinition1(x).CurrentValues


            crParameterValues1(x).Clear()
            crParameterValues1(x).Add(crParameterDiscreteValue1(x))
            crParameterFieldDefinition1(x).ApplyCurrentValues(crParameterValues1(x))
        Next


        'CRYSTALVIEWER2.CrystalReportViewer2.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
        'cryRpt.Refresh()
        'CRYSTALVIEWER2.ShowDialog()

        DisconnectCN()
    End Sub

End Module
