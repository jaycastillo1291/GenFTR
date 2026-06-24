Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class CRYSTALVIEWER2
    Public crViewer
    Private Sub CRYSTALVIEWER2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CrystalReportViewer2.ReportSource = REPORTVIEWING.cryRpt
        'crViewer = CrystalReportViewer2
        CrystalReportViewer2.Refresh()

    End Sub
End Class