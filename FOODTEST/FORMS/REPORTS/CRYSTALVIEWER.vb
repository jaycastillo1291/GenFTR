'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.ReportSource
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.Windows.Forms

Public Class CRYSTALVIEWER
    'Public crViewer2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ShowReportForm(cbReportName.Text)

        If cbReportName.Text = "" Then Exit Sub

        CrystalReportViewer2.ReportSource = REPORTVIEWING.cryRpt
        CrystalReportViewer2.Refresh()
    End Sub

    Private Sub CRYSTALVIEWER_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dal As New DataAccessLayer
        dal.StrParams.Add("GroupName", GroupName)
        Dim dt = dal.ExecuteQuery("select AccessName from LOGIN_GroupAuthority WHERE cRead = 1 and GroupName = @GroupName and MODULE = 'REPORT'")

        cbReportName.Items.Clear()

        For Each row as DataRow In dt.Rows

            cbReportName.Items.Add(row("AccessName"))
            'rs.MoveNext()
        Next

        'Connect()
        'rs = Nothing
        'rs = cn.Execute("select AccessName from LOGIN_GroupAuthority WHERE cRead = 1 and GroupName = '" & GroupName & "' and MODULE = 'REPORT'")

        'cbReportName.Items.Clear()

        'While Not rs.EOF
        '    cbReportName.Items.Add(rs.Fields(0).Value)
        '    rs.MoveNext()
        'End While

        'DisconnectCN()
    End Sub

    Private Sub cbReportName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReportName.SelectedIndexChanged

        Dim strParamDesc = ""
        Select Case cbReportName.Text
            Case "MBOR Summary"
                strParamDesc = "Date1 - Report Year"
                dtpParam1.Enabled = True
                dtpParam2.Enabled = False
                dtpParam3.Enabled = False
                txtParam4.Enabled = False
                txtParam5.Enabled = False
                txtParam6.Enabled = False
            Case "MBOR Detail"
                strParamDesc = "Date1 - Report Month and Year"
                dtpParam1.Enabled = True
                dtpParam2.Enabled = False
                dtpParam3.Enabled = False
                txtParam4.Enabled = False
                txtParam5.Enabled = False
                txtParam6.Enabled = False
            Case "CM Traceability"
                strParamDesc = "Date1 - Production Date(RM), String 1 - Item Name"
                dtpParam1.Enabled = True
                dtpParam2.Enabled = False
                dtpParam3.Enabled = False
                txtParam4.Enabled = True
                txtParam5.Enabled = False
                txtParam6.Enabled = False
            Case Else
                strParamDesc = "-"
                dtpParam1.Enabled = False
                dtpParam2.Enabled = False
                dtpParam3.Enabled = False
                txtParam4.Enabled = False
                txtParam5.Enabled = False
                txtParam6.Enabled = False
        End Select

        lblDescription.Text = strParamDesc

    End Sub
End Class