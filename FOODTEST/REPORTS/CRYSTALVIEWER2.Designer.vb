<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRYSTALVIEWER2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CrystalReportViewer2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 450)
        Me.Panel1.TabIndex = 34
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer2.DisplayStatusBar = False
        Me.CrystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer2.ShowCopyButton = False
        Me.CrystalReportViewer2.ShowGroupTreeButton = False
        Me.CrystalReportViewer2.ShowLogo = False
        Me.CrystalReportViewer2.ShowParameterPanelButton = False
        Me.CrystalReportViewer2.ShowRefreshButton = False
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(798, 448)
        Me.CrystalReportViewer2.TabIndex = 0
        Me.CrystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'CRYSTALVIEWER2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CRYSTALVIEWER2"
        Me.Text = "CRYSTALVIEWER2"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
