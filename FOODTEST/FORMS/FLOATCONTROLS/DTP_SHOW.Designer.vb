<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dtpDialog
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.btnCancelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(153, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(84, 31)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'btnCancelButton
        '
        Me.btnCancelButton.Location = New System.Drawing.Point(3, 31)
        Me.btnCancelButton.Name = "btnCancelButton"
        Me.btnCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelButton.TabIndex = 1
        Me.btnCancelButton.Text = "Cancel"
        Me.btnCancelButton.UseVisualStyleBackColor = True
        '
        'dtpDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(179, 62)
        Me.Controls.Add(Me.btnCancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dtpDialog"
        Me.Text = "DTP_SHOW"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents OKButton As Button
    Friend WithEvents btnCancelButton As Button
End Class
