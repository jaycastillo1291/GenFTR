<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TESTSELECT
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGroupName = New System.Windows.Forms.ComboBox()
        Me.lvTestList = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTagSelect = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Group"
        '
        'cmbGroupName
        '
        Me.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupName.FormattingEnabled = True
        Me.cmbGroupName.Items.AddRange(New Object() {"Microbiological", "Biological", "Physico-Chemical"})
        Me.cmbGroupName.Location = New System.Drawing.Point(205, 12)
        Me.cmbGroupName.Name = "cmbGroupName"
        Me.cmbGroupName.Size = New System.Drawing.Size(177, 21)
        Me.cmbGroupName.TabIndex = 5
        '
        'lvTestList
        '
        Me.lvTestList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colCode, Me.colDescription, Me.colTagSelect})
        Me.lvTestList.FullRowSelect = True
        Me.lvTestList.HideSelection = False
        Me.lvTestList.Location = New System.Drawing.Point(12, 39)
        Me.lvTestList.MultiSelect = False
        Me.lvTestList.Name = "lvTestList"
        Me.lvTestList.Size = New System.Drawing.Size(370, 355)
        Me.lvTestList.TabIndex = 7
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
        Me.colDescription.Width = 96
        '
        'colTagSelect
        '
        Me.colTagSelect.Width = 94
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(307, 400)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(226, 400)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TESTSELECT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 433)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvTestList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbGroupName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "TESTSELECT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TEST SELECTION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents cmbGroupName As ComboBox
    Friend WithEvents lvTestList As ListView
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents colCode As ColumnHeader
    Friend WithEvents colDescription As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents colTagSelect As ColumnHeader
End Class
