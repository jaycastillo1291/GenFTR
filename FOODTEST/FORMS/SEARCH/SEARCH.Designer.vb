<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SEARCH
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
        Me.chkCrit1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCrit3 = New System.Windows.Forms.ComboBox()
        Me.cmbCrit2 = New System.Windows.Forms.ComboBox()
        Me.cmbCrit1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtCrit2 = New System.Windows.Forms.TextBox()
        Me.txtCrit1 = New System.Windows.Forms.TextBox()
        Me.chkCrit3 = New System.Windows.Forms.CheckBox()
        Me.chkCrit2 = New System.Windows.Forms.CheckBox()
        Me.lvSearchList = New System.Windows.Forms.ListView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkCrit1
        '
        Me.chkCrit1.AutoSize = True
        Me.chkCrit1.Location = New System.Drawing.Point(10, 19)
        Me.chkCrit1.Name = "chkCrit1"
        Me.chkCrit1.Size = New System.Drawing.Size(15, 14)
        Me.chkCrit1.TabIndex = 1
        Me.chkCrit1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCrit3)
        Me.GroupBox1.Controls.Add(Me.cmbCrit2)
        Me.GroupBox1.Controls.Add(Me.cmbCrit1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpDateTo)
        Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtCrit2)
        Me.GroupBox1.Controls.Add(Me.txtCrit1)
        Me.GroupBox1.Controls.Add(Me.chkCrit3)
        Me.GroupBox1.Controls.Add(Me.chkCrit2)
        Me.GroupBox1.Controls.Add(Me.chkCrit1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(531, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Criteria"
        '
        'cmbCrit3
        '
        Me.cmbCrit3.FormattingEnabled = True
        Me.cmbCrit3.Location = New System.Drawing.Point(296, 67)
        Me.cmbCrit3.Name = "cmbCrit3"
        Me.cmbCrit3.Size = New System.Drawing.Size(107, 21)
        Me.cmbCrit3.TabIndex = 8
        '
        'cmbCrit2
        '
        Me.cmbCrit2.FormattingEnabled = True
        Me.cmbCrit2.Location = New System.Drawing.Point(296, 42)
        Me.cmbCrit2.Name = "cmbCrit2"
        Me.cmbCrit2.Size = New System.Drawing.Size(107, 21)
        Me.cmbCrit2.TabIndex = 5
        '
        'cmbCrit1
        '
        Me.cmbCrit1.FormattingEnabled = True
        Me.cmbCrit1.Location = New System.Drawing.Point(296, 15)
        Me.cmbCrit1.Name = "cmbCrit1"
        Me.cmbCrit1.Size = New System.Drawing.Size(107, 21)
        Me.cmbCrit1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "to"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(195, 68)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(95, 20)
        Me.dtpDateTo.TabIndex = 7
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(72, 67)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(95, 20)
        Me.dtpDateFrom.TabIndex = 6
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(411, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(114, 69)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtCrit2
        '
        Me.txtCrit2.Location = New System.Drawing.Point(31, 42)
        Me.txtCrit2.Name = "txtCrit2"
        Me.txtCrit2.Size = New System.Drawing.Size(259, 20)
        Me.txtCrit2.TabIndex = 4
        '
        'txtCrit1
        '
        Me.txtCrit1.Location = New System.Drawing.Point(31, 16)
        Me.txtCrit1.Name = "txtCrit1"
        Me.txtCrit1.Size = New System.Drawing.Size(259, 20)
        Me.txtCrit1.TabIndex = 2
        '
        'chkCrit3
        '
        Me.chkCrit3.AutoSize = True
        Me.chkCrit3.Location = New System.Drawing.Point(10, 71)
        Me.chkCrit3.Name = "chkCrit3"
        Me.chkCrit3.Size = New System.Drawing.Size(15, 14)
        Me.chkCrit3.TabIndex = 1
        Me.chkCrit3.UseVisualStyleBackColor = True
        '
        'chkCrit2
        '
        Me.chkCrit2.AutoSize = True
        Me.chkCrit2.Location = New System.Drawing.Point(10, 45)
        Me.chkCrit2.Name = "chkCrit2"
        Me.chkCrit2.Size = New System.Drawing.Size(15, 14)
        Me.chkCrit2.TabIndex = 1
        Me.chkCrit2.UseVisualStyleBackColor = True
        '
        'lvSearchList
        '
        Me.lvSearchList.FullRowSelect = True
        Me.lvSearchList.HideSelection = False
        Me.lvSearchList.Location = New System.Drawing.Point(12, 118)
        Me.lvSearchList.MultiSelect = False
        Me.lvSearchList.Name = "lvSearchList"
        Me.lvSearchList.Size = New System.Drawing.Size(531, 297)
        Me.lvSearchList.TabIndex = 2
        Me.lvSearchList.UseCompatibleStateImageBehavior = False
        Me.lvSearchList.View = System.Windows.Forms.View.Details
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(424, 421)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 23)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(298, 421)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SEARCH
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(556, 450)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lvSearchList)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SEARCH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SEARCH"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chkCrit1 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtCrit2 As TextBox
    Friend WithEvents txtCrit1 As TextBox
    Friend WithEvents chkCrit3 As CheckBox
    Friend WithEvents chkCrit2 As CheckBox
    Friend WithEvents cmbCrit3 As ComboBox
    Friend WithEvents cmbCrit2 As ComboBox
    Friend WithEvents cmbCrit1 As ComboBox
    Friend WithEvents lvSearchList As ListView
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
