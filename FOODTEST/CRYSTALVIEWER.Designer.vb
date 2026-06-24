<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRYSTALVIEWER
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbReportName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.txtParam6 = New System.Windows.Forms.TextBox()
        Me.lblParam6 = New System.Windows.Forms.Label()
        Me.txtParam5 = New System.Windows.Forms.TextBox()
        Me.lblParam5 = New System.Windows.Forms.Label()
        Me.txtParam4 = New System.Windows.Forms.TextBox()
        Me.lblParam4 = New System.Windows.Forms.Label()
        Me.lblParam3 = New System.Windows.Forms.Label()
        Me.lblParam2 = New System.Windows.Forms.Label()
        Me.lblParam1 = New System.Windows.Forms.Label()
        Me.dtpParam3 = New System.Windows.Forms.DateTimePicker()
        Me.dtpParam2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpParam1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 108)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 339)
        Me.Panel2.TabIndex = 34
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CrystalReportViewer2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(792, 337)
        Me.Panel3.TabIndex = 35
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
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(790, 335)
        Me.CrystalReportViewer2.TabIndex = 0
        Me.CrystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cbReportName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.lblCondition)
        Me.Panel1.Controls.Add(Me.txtParam6)
        Me.Panel1.Controls.Add(Me.lblParam6)
        Me.Panel1.Controls.Add(Me.txtParam5)
        Me.Panel1.Controls.Add(Me.lblParam5)
        Me.Panel1.Controls.Add(Me.txtParam4)
        Me.Panel1.Controls.Add(Me.lblParam4)
        Me.Panel1.Controls.Add(Me.lblParam3)
        Me.Panel1.Controls.Add(Me.lblParam2)
        Me.Panel1.Controls.Add(Me.lblParam1)
        Me.Panel1.Controls.Add(Me.dtpParam3)
        Me.Panel1.Controls.Add(Me.dtpParam2)
        Me.Panel1.Controls.Add(Me.dtpParam1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 99)
        Me.Panel1.TabIndex = 1
        '
        'cbReportName
        '
        Me.cbReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportName.FormattingEnabled = True
        Me.cbReportName.Location = New System.Drawing.Point(88, 16)
        Me.cbReportName.Name = "cbReportName"
        Me.cbReportName.Size = New System.Drawing.Size(175, 21)
        Me.cbReportName.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Report Name:"
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(27, 61)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(263, 33)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "-"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(9, 45)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(114, 13)
        Me.lblCondition.TabIndex = 5
        Me.lblCondition.Text = "Parameter Description:"
        '
        'txtParam6
        '
        Me.txtParam6.Location = New System.Drawing.Point(507, 66)
        Me.txtParam6.Name = "txtParam6"
        Me.txtParam6.Size = New System.Drawing.Size(127, 20)
        Me.txtParam6.TabIndex = 6
        '
        'lblParam6
        '
        Me.lblParam6.AutoSize = True
        Me.lblParam6.Location = New System.Drawing.Point(458, 71)
        Me.lblParam6.Name = "lblParam6"
        Me.lblParam6.Size = New System.Drawing.Size(43, 13)
        Me.lblParam6.TabIndex = 3
        Me.lblParam6.Text = "String 3"
        '
        'txtParam5
        '
        Me.txtParam5.Location = New System.Drawing.Point(507, 40)
        Me.txtParam5.Name = "txtParam5"
        Me.txtParam5.Size = New System.Drawing.Size(127, 20)
        Me.txtParam5.TabIndex = 5
        '
        'lblParam5
        '
        Me.lblParam5.AutoSize = True
        Me.lblParam5.Location = New System.Drawing.Point(458, 45)
        Me.lblParam5.Name = "lblParam5"
        Me.lblParam5.Size = New System.Drawing.Size(43, 13)
        Me.lblParam5.TabIndex = 3
        Me.lblParam5.Text = "String 2"
        '
        'txtParam4
        '
        Me.txtParam4.Location = New System.Drawing.Point(507, 14)
        Me.txtParam4.Name = "txtParam4"
        Me.txtParam4.Size = New System.Drawing.Size(127, 20)
        Me.txtParam4.TabIndex = 4
        '
        'lblParam4
        '
        Me.lblParam4.AutoSize = True
        Me.lblParam4.Location = New System.Drawing.Point(458, 19)
        Me.lblParam4.Name = "lblParam4"
        Me.lblParam4.Size = New System.Drawing.Size(43, 13)
        Me.lblParam4.TabIndex = 3
        Me.lblParam4.Text = "String 1"
        '
        'lblParam3
        '
        Me.lblParam3.AutoSize = True
        Me.lblParam3.Location = New System.Drawing.Point(296, 72)
        Me.lblParam3.Name = "lblParam3"
        Me.lblParam3.Size = New System.Drawing.Size(39, 13)
        Me.lblParam3.TabIndex = 2
        Me.lblParam3.Text = "Date 3"
        '
        'lblParam2
        '
        Me.lblParam2.AutoSize = True
        Me.lblParam2.Location = New System.Drawing.Point(296, 46)
        Me.lblParam2.Name = "lblParam2"
        Me.lblParam2.Size = New System.Drawing.Size(39, 13)
        Me.lblParam2.TabIndex = 2
        Me.lblParam2.Text = "Date 2"
        '
        'lblParam1
        '
        Me.lblParam1.AutoSize = True
        Me.lblParam1.Location = New System.Drawing.Point(296, 20)
        Me.lblParam1.Name = "lblParam1"
        Me.lblParam1.Size = New System.Drawing.Size(39, 13)
        Me.lblParam1.TabIndex = 2
        Me.lblParam1.Text = "Date 1"
        '
        'dtpParam3
        '
        Me.dtpParam3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpParam3.Location = New System.Drawing.Point(341, 66)
        Me.dtpParam3.Name = "dtpParam3"
        Me.dtpParam3.Size = New System.Drawing.Size(97, 20)
        Me.dtpParam3.TabIndex = 3
        '
        'dtpParam2
        '
        Me.dtpParam2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpParam2.Location = New System.Drawing.Point(341, 40)
        Me.dtpParam2.Name = "dtpParam2"
        Me.dtpParam2.Size = New System.Drawing.Size(97, 20)
        Me.dtpParam2.TabIndex = 2
        '
        'dtpParam1
        '
        Me.dtpParam1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpParam1.Location = New System.Drawing.Point(341, 14)
        Me.dtpParam1.Name = "dtpParam1"
        Me.dtpParam1.Size = New System.Drawing.Size(97, 20)
        Me.dtpParam1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(662, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 88)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Show Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CRYSTALVIEWER
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CRYSTALVIEWER"
        Me.Text = "CRYSTALVIEWER"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lblParam3 As Label
    Friend WithEvents lblParam2 As Label
    Friend WithEvents lblParam1 As Label
    Friend WithEvents dtpParam3 As DateTimePicker
    Friend WithEvents dtpParam2 As DateTimePicker
    Friend WithEvents dtpParam1 As DateTimePicker
    Friend WithEvents txtParam6 As TextBox
    Friend WithEvents lblParam6 As Label
    Friend WithEvents txtParam5 As TextBox
    Friend WithEvents lblParam5 As Label
    Friend WithEvents txtParam4 As TextBox
    Friend WithEvents lblParam4 As Label
    Friend WithEvents cbReportName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblCondition As Label
    Friend WithEvents Panel3 As Panel
    Private WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
