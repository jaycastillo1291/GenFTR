<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TESTLIST
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvTestList = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbGroupName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTestCode = New System.Windows.Forms.TextBox()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMethod = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGuide = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkInactive = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvMethodList = New System.Windows.Forms.ListView()
        Me.colMethodRS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTestMethod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMethodRef1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMethodRef2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsMethodList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Print", 18.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 43)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Test Masterlist"
        '
        'lvTestList
        '
        Me.lvTestList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colCode, Me.colDescription})
        Me.lvTestList.FullRowSelect = True
        Me.lvTestList.HideSelection = False
        Me.lvTestList.Location = New System.Drawing.Point(20, 97)
        Me.lvTestList.MultiSelect = False
        Me.lvTestList.Name = "lvTestList"
        Me.lvTestList.Size = New System.Drawing.Size(370, 461)
        Me.lvTestList.TabIndex = 2
        Me.lvTestList.UseCompatibleStateImageBehavior = False
        Me.lvTestList.View = System.Windows.Forms.View.Details
        '
        'colRowStamp
        '
        Me.colRowStamp.Text = "Row Stamp"
        Me.colRowStamp.Width = 41
        '
        'colCode
        '
        Me.colCode.Text = "Code"
        Me.colCode.Width = 80
        '
        'colDescription
        '
        Me.colDescription.Text = "Description"
        Me.colDescription.Width = 241
        '
        'cmbGroupName
        '
        Me.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupName.FormattingEnabled = True
        Me.cmbGroupName.Items.AddRange(New Object() {"Microbiological", "Biological", "Physico-Chemical"})
        Me.cmbGroupName.Location = New System.Drawing.Point(213, 68)
        Me.cmbGroupName.Name = "cmbGroupName"
        Me.cmbGroupName.Size = New System.Drawing.Size(177, 21)
        Me.cmbGroupName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Group"
        '
        'txtTestCode
        '
        Me.txtTestCode.Location = New System.Drawing.Point(496, 97)
        Me.txtTestCode.Name = "txtTestCode"
        Me.txtTestCode.Size = New System.Drawing.Size(159, 20)
        Me.txtTestCode.TabIndex = 6
        '
        'txtTestName
        '
        Me.txtTestName.Location = New System.Drawing.Point(496, 123)
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.Size = New System.Drawing.Size(327, 20)
        Me.txtTestName.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(427, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Test Name:"
        '
        'txtMethod
        '
        Me.txtMethod.Location = New System.Drawing.Point(496, 149)
        Me.txtMethod.Multiline = True
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.Size = New System.Drawing.Size(329, 56)
        Me.txtMethod.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(418, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Methodology:"
        '
        'txtGuide
        '
        Me.txtGuide.AccessibleName = "TestGuide"
        Me.txtGuide.Location = New System.Drawing.Point(496, 211)
        Me.txtGuide.Multiline = True
        Me.txtGuide.Name = "txtGuide"
        Me.txtGuide.Size = New System.Drawing.Size(329, 42)
        Me.txtGuide.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(428, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Test Guide:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Sampling Scheme:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(496, 453)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(329, 79)
        Me.txtRemarks.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(437, 456)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Remarks:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(719, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkInactive
        '
        Me.chkInactive.AccessibleName = "isInactive"
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Location = New System.Drawing.Point(661, 100)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(64, 17)
        Me.chkInactive.TabIndex = 8
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(607, 538)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "RELOAD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(495, 538)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "CLEAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(431, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Test Code:"
        '
        'lvMethodList
        '
        Me.lvMethodList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMethodRS, Me.colTestMethod, Me.colMethodRef1, Me.colMethodRef2})
        Me.lvMethodList.FullRowSelect = True
        Me.lvMethodList.HideSelection = False
        Me.lvMethodList.Location = New System.Drawing.Point(496, 259)
        Me.lvMethodList.MultiSelect = False
        Me.lvMethodList.Name = "lvMethodList"
        Me.lvMethodList.Size = New System.Drawing.Size(327, 188)
        Me.lvMethodList.TabIndex = 9
        Me.lvMethodList.UseCompatibleStateImageBehavior = False
        Me.lvMethodList.View = System.Windows.Forms.View.Details
        '
        'colMethodRS
        '
        Me.colMethodRS.Text = "RowStamp"
        '
        'colTestMethod
        '
        Me.colTestMethod.Text = "Test Method"
        '
        'colMethodRef1
        '
        Me.colMethodRef1.Text = "Reference1"
        '
        'colMethodRef2
        '
        Me.colMethodRef2.Text = "Reference2"
        '
        'cmsMethodList
        '
        Me.cmsMethodList.Name = "cmsMethodList"
        Me.cmsMethodList.Size = New System.Drawing.Size(61, 4)
        '
        'TESTLIST
        '
        Me.AccessibleName = "TESTLIST"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 570)
        Me.Controls.Add(Me.lvMethodList)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtGuide)
        Me.Controls.Add(Me.txtMethod)
        Me.Controls.Add(Me.txtTestName)
        Me.Controls.Add(Me.txtTestCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbGroupName)
        Me.Controls.Add(Me.lvTestList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TESTLIST"
        Me.Tag = "GENERIC"
        Me.Text = "TESTLIST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lvTestList As ListView
    Friend WithEvents cmbGroupName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents colCode As ColumnHeader
    Friend WithEvents colDescription As ColumnHeader
    Friend WithEvents txtTestCode As TextBox
    Friend WithEvents txtTestName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMethod As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtGuide As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents chkInactive As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lvMethodList As ListView
    Friend WithEvents cmsMethodList As ContextMenuStrip
    Friend WithEvents colMethodRS As ColumnHeader
    Friend WithEvents colTestMethod As ColumnHeader
    Friend WithEvents colMethodRef1 As ColumnHeader
    Friend WithEvents colMethodRef2 As ColumnHeader
End Class
