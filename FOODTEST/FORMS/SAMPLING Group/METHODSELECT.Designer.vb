<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class METHODSELECT
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
        Me.lvSchemeList = New System.Windows.Forms.ListView()
        Me.colSchemeName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGuide = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvSchemeList
        '
        Me.lvSchemeList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSchemeName, Me.colGuide, Me.ColumnHeader1})
        Me.lvSchemeList.HideSelection = False
        Me.lvSchemeList.Location = New System.Drawing.Point(12, 12)
        Me.lvSchemeList.MultiSelect = False
        Me.lvSchemeList.Name = "lvSchemeList"
        Me.lvSchemeList.Size = New System.Drawing.Size(160, 228)
        Me.lvSchemeList.TabIndex = 0
        Me.lvSchemeList.UseCompatibleStateImageBehavior = False
        Me.lvSchemeList.View = System.Windows.Forms.View.Details
        '
        'colSchemeName
        '
        Me.colSchemeName.Text = "Scheme Name"
        '
        'colGuide
        '
        Me.colGuide.Text = "Guide"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 247)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 276)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(159, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "exist"
        '
        'METHODSELECT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(187, 307)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvSchemeList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "METHODSELECT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "METHOD LIST"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvSchemeList As ListView
    Friend WithEvents colSchemeName As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents colGuide As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
