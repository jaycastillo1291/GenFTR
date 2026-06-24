<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TESTREQUESTLIST
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbGroup = New System.Windows.Forms.ComboBox()
        Me.lvRequests = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTestNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRequestDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRequestBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateNeeded = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.colUrgent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(222, 43)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Test Request List"
        '
        'cmbGroup
        '
        Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroup.FormattingEnabled = True
        Me.cmbGroup.Items.AddRange(New Object() {"Approved", "Pending"})
        Me.cmbGroup.Location = New System.Drawing.Point(369, 31)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(214, 21)
        Me.cmbGroup.TabIndex = 3
        '
        'lvRequests
        '
        Me.lvRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colTestNumber, Me.colRequestDate, Me.colRequestBy, Me.colDateNeeded, Me.colStatus, Me.colUrgent})
        Me.lvRequests.FullRowSelect = True
        Me.lvRequests.HideSelection = False
        Me.lvRequests.Location = New System.Drawing.Point(12, 71)
        Me.lvRequests.MultiSelect = False
        Me.lvRequests.Name = "lvRequests"
        Me.lvRequests.Size = New System.Drawing.Size(571, 306)
        Me.lvRequests.TabIndex = 4
        Me.lvRequests.UseCompatibleStateImageBehavior = False
        Me.lvRequests.View = System.Windows.Forms.View.Details
        '
        'colTestNumber
        '
        Me.colTestNumber.Text = "Request Number"
        Me.colTestNumber.Width = 100
        '
        'colRequestDate
        '
        Me.colRequestDate.Text = "Request Date"
        Me.colRequestDate.Width = 99
        '
        'colRequestBy
        '
        Me.colRequestBy.Text = "Request By"
        Me.colRequestBy.Width = 108
        '
        'colDateNeeded
        '
        Me.colDateNeeded.Text = "Date Needed"
        Me.colDateNeeded.Width = 84
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(466, 383)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(342, 383)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'colUrgent
        '
        Me.colUrgent.Text = "-"
        '
        'TESTREQUESTLIST
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(596, 412)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lvRequests)
        Me.Controls.Add(Me.cmbGroup)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "TESTREQUESTLIST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "REQUEST LIST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbGroup As ComboBox
    Friend WithEvents lvRequests As ListView
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents colTestNumber As ColumnHeader
    Friend WithEvents colRequestDate As ColumnHeader
    Friend WithEvents colRequestBy As ColumnHeader
    Friend WithEvents colDateNeeded As ColumnHeader
    Friend WithEvents colStatus As ColumnHeader
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents colUrgent As ColumnHeader
End Class
