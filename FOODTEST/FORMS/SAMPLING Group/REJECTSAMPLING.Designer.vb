<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REJECTSAMPLING
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
        Me.GBREJECT = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtRROthText = New System.Windows.Forms.TextBox()
        Me.chkRROther = New System.Windows.Forms.CheckBox()
        Me.chkRR5 = New System.Windows.Forms.CheckBox()
        Me.chkRR4 = New System.Windows.Forms.CheckBox()
        Me.chkRR3 = New System.Windows.Forms.CheckBox()
        Me.chkRR2 = New System.Windows.Forms.CheckBox()
        Me.chkRR1 = New System.Windows.Forms.CheckBox()
        Me.GBREJECT.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBREJECT
        '
        Me.GBREJECT.Controls.Add(Me.Button1)
        Me.GBREJECT.Controls.Add(Me.txtRROthText)
        Me.GBREJECT.Controls.Add(Me.chkRROther)
        Me.GBREJECT.Controls.Add(Me.chkRR5)
        Me.GBREJECT.Controls.Add(Me.chkRR4)
        Me.GBREJECT.Controls.Add(Me.chkRR3)
        Me.GBREJECT.Controls.Add(Me.chkRR2)
        Me.GBREJECT.Controls.Add(Me.chkRR1)
        Me.GBREJECT.Location = New System.Drawing.Point(12, 12)
        Me.GBREJECT.Name = "GBREJECT"
        Me.GBREJECT.Size = New System.Drawing.Size(488, 235)
        Me.GBREJECT.TabIndex = 2
        Me.GBREJECT.TabStop = False
        Me.GBREJECT.Text = "TEST REQUEST REJECTED"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 195)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(476, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Continue"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtRROthText
        '
        Me.txtRROthText.AccessibleName = "RROthText"
        Me.txtRROthText.Location = New System.Drawing.Point(175, 158)
        Me.txtRROthText.Name = "txtRROthText"
        Me.txtRROthText.Size = New System.Drawing.Size(292, 20)
        Me.txtRROthText.TabIndex = 1
        '
        'chkRROther
        '
        Me.chkRROther.AccessibleName = "RROther"
        Me.chkRROther.AutoSize = True
        Me.chkRROther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRROther.Location = New System.Drawing.Point(28, 158)
        Me.chkRROther.Name = "chkRROther"
        Me.chkRROther.Size = New System.Drawing.Size(149, 19)
        Me.chkRROther.TabIndex = 0
        Me.chkRROther.Text = "Others: Please specify:"
        Me.chkRROther.UseVisualStyleBackColor = True
        '
        'chkRR5
        '
        Me.chkRR5.AccessibleName = "RR5"
        Me.chkRR5.AutoSize = True
        Me.chkRR5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRR5.Location = New System.Drawing.Point(28, 133)
        Me.chkRR5.Name = "chkRR5"
        Me.chkRR5.Size = New System.Drawing.Size(88, 19)
        Me.chkRR5.TabIndex = 0
        Me.chkRR5.Text = "No Sample"
        Me.chkRR5.UseVisualStyleBackColor = True
        '
        'chkRR4
        '
        Me.chkRR4.AccessibleName = "RR4"
        Me.chkRR4.AutoSize = True
        Me.chkRR4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRR4.Location = New System.Drawing.Point(28, 108)
        Me.chkRR4.Name = "chkRR4"
        Me.chkRR4.Size = New System.Drawing.Size(435, 19)
        Me.chkRR4.TabIndex = 0
        Me.chkRR4.Text = "Sample details did not match details in the Food Testing Request (Internal)."
        Me.chkRR4.UseVisualStyleBackColor = True
        '
        'chkRR3
        '
        Me.chkRR3.AccessibleName = "RR3"
        Me.chkRR3.AutoSize = True
        Me.chkRR3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRR3.Location = New System.Drawing.Point(28, 83)
        Me.chkRR3.Name = "chkRR3"
        Me.chkRR3.Size = New System.Drawing.Size(276, 19)
        Me.chkRR3.TabIndex = 0
        Me.chkRR3.Text = "Sample material was not suffecient for testing."
        Me.chkRR3.UseVisualStyleBackColor = True
        '
        'chkRR2
        '
        Me.chkRR2.AccessibleName = "RR2"
        Me.chkRR2.AutoSize = True
        Me.chkRR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRR2.Location = New System.Drawing.Point(28, 58)
        Me.chkRR2.Name = "chkRR2"
        Me.chkRR2.Size = New System.Drawing.Size(331, 19)
        Me.chkRR2.TabIndex = 0
        Me.chkRR2.Text = "Sample material was inappropiate for the test requested"
        Me.chkRR2.UseVisualStyleBackColor = True
        '
        'chkRR1
        '
        Me.chkRR1.AccessibleName = "RR1"
        Me.chkRR1.AutoSize = True
        Me.chkRR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRR1.Location = New System.Drawing.Point(29, 33)
        Me.chkRR1.Name = "chkRR1"
        Me.chkRR1.Size = New System.Drawing.Size(209, 19)
        Me.chkRR1.TabIndex = 0
        Me.chkRR1.Text = "Refer above IV.A. Sample Integrity"
        Me.chkRR1.UseVisualStyleBackColor = True
        '
        'REJECTSAMPLING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 252)
        Me.Controls.Add(Me.GBREJECT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "REJECTSAMPLING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "REJECT SAMPLE REQUEST"
        Me.GBREJECT.ResumeLayout(False)
        Me.GBREJECT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBREJECT As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtRROthText As TextBox
    Friend WithEvents chkRROther As CheckBox
    Friend WithEvents chkRR5 As CheckBox
    Friend WithEvents chkRR4 As CheckBox
    Friend WithEvents chkRR3 As CheckBox
    Friend WithEvents chkRR2 As CheckBox
    Friend WithEvents chkRR1 As CheckBox
End Class
