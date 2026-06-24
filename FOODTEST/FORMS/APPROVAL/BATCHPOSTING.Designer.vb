<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BATCHPOSTING
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
        Me.components = New System.ComponentModel.Container()
        Me.lvForPosting = New System.Windows.Forms.ListView()
        Me.colDocNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCompliant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDocDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCreatedBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colApproved = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cmsRClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dtpList = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvForPosting
        '
        Me.lvForPosting.CheckBoxes = True
        Me.lvForPosting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDocNum, Me.colCompliant, Me.colDocDate, Me.colCreatedBy, Me.colApproved, Me.colRowStamp})
        Me.lvForPosting.FullRowSelect = True
        Me.lvForPosting.HideSelection = False
        Me.lvForPosting.Location = New System.Drawing.Point(12, 93)
        Me.lvForPosting.MultiSelect = False
        Me.lvForPosting.Name = "lvForPosting"
        Me.lvForPosting.Size = New System.Drawing.Size(542, 277)
        Me.lvForPosting.TabIndex = 0
        Me.lvForPosting.UseCompatibleStateImageBehavior = False
        Me.lvForPosting.View = System.Windows.Forms.View.Details
        '
        'colDocNum
        '
        Me.colDocNum.Text = "TRN"
        '
        'colCompliant
        '
        Me.colCompliant.Text = "Compliance"
        '
        'colDocDate
        '
        Me.colDocDate.Text = "Doc Date"
        '
        'colCreatedBy
        '
        Me.colCreatedBy.Text = "Tested By"
        '
        'colApproved
        '
        Me.colApproved.Text = "Approver"
        '
        'colRowStamp
        '
        Me.colRowStamp.Text = "RowStamp"
        Me.colRowStamp.Width = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TEST POSTING"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"PENDING", "POSTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(437, 12)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(117, 21)
        Me.cmbStatus.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(379, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(175, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "POST"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(198, 376)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(175, 23)
        Me.btnReload.TabIndex = 3
        Me.btnReload.Text = "Refresh"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(17, 69)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(120, 17)
        Me.chkAll.TabIndex = 4
        Me.chkAll.Text = "Check/Uncheck All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cmsRClick
        '
        Me.cmsRClick.Name = "cmsRClick"
        Me.cmsRClick.Size = New System.Drawing.Size(61, 4)
        '
        'dtpList
        '
        Me.dtpList.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpList.Location = New System.Drawing.Point(437, 38)
        Me.dtpList.Name = "dtpList"
        Me.dtpList.Size = New System.Drawing.Size(117, 20)
        Me.dtpList.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(364, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Month/Year:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(437, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(42, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(402, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Day:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(483, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "0 = whole month"
        '
        'BATCHPOSTING
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 407)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpList)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvForPosting)
        Me.Name = "BATCHPOSTING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "POSTING RECORDS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvForPosting As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents colDocNum As ColumnHeader
    Friend WithEvents colCompliant As ColumnHeader
    Friend WithEvents colDocDate As ColumnHeader
    Friend WithEvents colCreatedBy As ColumnHeader
    Friend WithEvents colApproved As ColumnHeader
    Friend WithEvents btnSave As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents cmsRClick As ContextMenuStrip
    Friend WithEvents dtpList As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
