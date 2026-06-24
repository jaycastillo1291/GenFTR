<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class LOGIN
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
    Friend WithEvents pbUser As System.Windows.Forms.PictureBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbChangePass = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pbPeek1 = New System.Windows.Forms.PictureBox()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.pbPass = New System.Windows.Forms.PictureBox()
        Me.pbUser = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbPeek1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(62, 124)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(213, 31)
        Me.txtUserName.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(62, 163)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(182, 31)
        Me.txtPass.TabIndex = 3
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OK.FlatAppearance.BorderSize = 0
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.Location = New System.Drawing.Point(12, 239)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(264, 37)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&LOGIN"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Cancel.FlatAppearance.BorderSize = 0
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cancel.Location = New System.Drawing.Point(12, 282)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(264, 37)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&CANCEL"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(34, 73)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(211, 17)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Laboratory Test Monitoring System"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(250, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cbChangePass
        '
        Me.cbChangePass.AutoSize = True
        Me.cbChangePass.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChangePass.Location = New System.Drawing.Point(132, 200)
        Me.cbChangePass.Name = "cbChangePass"
        Me.cbChangePass.Size = New System.Drawing.Size(100, 16)
        Me.cbChangePass.TabIndex = 9
        Me.cbChangePass.Text = "Change Password"
        Me.cbChangePass.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(19, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 22)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'pbPeek1
        '
        Me.pbPeek1.Image = Global.FOODTEST.My.Resources.Resources.pwvis
        Me.pbPeek1.Location = New System.Drawing.Point(250, 168)
        Me.pbPeek1.Name = "pbPeek1"
        Me.pbPeek1.Size = New System.Drawing.Size(25, 22)
        Me.pbPeek1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPeek1.TabIndex = 11
        Me.pbPeek1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbPeek1, "Show/Hide password")
        '
        'pb2
        '
        Me.pb2.Image = Global.FOODTEST.My.Resources.Resources.GenOSI_LOGO
        Me.pb2.Location = New System.Drawing.Point(73, 44)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(124, 26)
        Me.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb2.TabIndex = 8
        Me.pb2.TabStop = False
        '
        'pbPass
        '
        Me.pbPass.Image = Global.FOODTEST.My.Resources.Resources.PW_Sample
        Me.pbPass.Location = New System.Drawing.Point(22, 163)
        Me.pbPass.Name = "pbPass"
        Me.pbPass.Size = New System.Drawing.Size(34, 31)
        Me.pbPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPass.TabIndex = 0
        Me.pbPass.TabStop = False
        '
        'pbUser
        '
        Me.pbUser.Image = Global.FOODTEST.My.Resources.Resources.Sample_User_Icon
        Me.pbUser.Location = New System.Drawing.Point(22, 124)
        Me.pbUser.Name = "pbUser"
        Me.pbUser.Size = New System.Drawing.Size(34, 31)
        Me.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbUser.TabIndex = 0
        Me.pbUser.TabStop = False
        '
        'LOGIN
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(287, 357)
        Me.Controls.Add(Me.pbPeek1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbChangePass)
        Me.Controls.Add(Me.pb2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.pbPass)
        Me.Controls.Add(Me.pbUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LOGIN"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LOGIN"
        CType(Me.pbPeek1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbPass As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pb2 As PictureBox
    Friend WithEvents cbChangePass As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents pbPeek1 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
