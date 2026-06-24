<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REQTESTLIST
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lvTestListSelect = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTestCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTestName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGroupName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(416, 299)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(127, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(283, 299)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(127, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lvTestListSelect
        '
        Me.lvTestListSelect.CheckBoxes = True
        Me.lvTestListSelect.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colTestCode, Me.colTestName, Me.colGroupName})
        Me.lvTestListSelect.FullRowSelect = True
        Me.lvTestListSelect.HideSelection = False
        Me.lvTestListSelect.Location = New System.Drawing.Point(12, 12)
        Me.lvTestListSelect.Name = "lvTestListSelect"
        Me.lvTestListSelect.Size = New System.Drawing.Size(531, 281)
        Me.lvTestListSelect.TabIndex = 1
        Me.lvTestListSelect.UseCompatibleStateImageBehavior = False
        Me.lvTestListSelect.View = System.Windows.Forms.View.Details
        '
        'colRowStamp
        '
        Me.colRowStamp.Text = ""
        '
        'colTestCode
        '
        Me.colTestCode.Text = "Test Code"
        '
        'colTestName
        '
        Me.colTestName.Text = "Test Name"
        '
        'colGroupName
        '
        Me.colGroupName.Text = "Type"
        '
        'REQTESTLIST
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(555, 334)
        Me.Controls.Add(Me.lvTestListSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "REQTESTLIST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TEST LIST"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lvTestListSelect As ListView
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents colTestCode As ColumnHeader
    Friend WithEvents colTestName As ColumnHeader
    Friend WithEvents colGroupName As ColumnHeader
End Class
