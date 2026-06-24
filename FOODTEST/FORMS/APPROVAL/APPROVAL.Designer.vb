<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APPROVAL
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
        Me.lvApprovalList = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOrigin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDocNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRemarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWParam = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lvErrorList = New System.Windows.Forms.ListView()
        Me.colError = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb2ClickRep = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lvApprovalList
        '
        Me.lvApprovalList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colOrigin, Me.colDocNum, Me.colDate, Me.colStat, Me.colRemarks, Me.colWParam})
        Me.lvApprovalList.FullRowSelect = True
        Me.lvApprovalList.HideSelection = False
        Me.lvApprovalList.Location = New System.Drawing.Point(12, 64)
        Me.lvApprovalList.MultiSelect = False
        Me.lvApprovalList.Name = "lvApprovalList"
        Me.lvApprovalList.Size = New System.Drawing.Size(671, 254)
        Me.lvApprovalList.TabIndex = 0
        Me.lvApprovalList.UseCompatibleStateImageBehavior = False
        Me.lvApprovalList.View = System.Windows.Forms.View.Details
        '
        'colRowStamp
        '
        Me.colRowStamp.Text = "RowStamp"
        '
        'colOrigin
        '
        Me.colOrigin.Text = "Origin"
        Me.colOrigin.Width = 85
        '
        'colDocNum
        '
        Me.colDocNum.Text = "Ref No."
        Me.colDocNum.Width = 87
        '
        'colDate
        '
        Me.colDate.Text = "Doc Date"
        Me.colDate.Width = 91
        '
        'colStat
        '
        Me.colStat.Text = "Status"
        Me.colStat.Width = 95
        '
        'colRemarks
        '
        Me.colRemarks.Text = "Remarks"
        Me.colRemarks.Width = 151
        '
        'colWParam
        '
        Me.colWParam.Text = "Parameter"
        Me.colWParam.Width = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Print", 18.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 43)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Document Approval"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(557, 324)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(425, 324)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'lvErrorList
        '
        Me.lvErrorList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colError})
        Me.lvErrorList.HideSelection = False
        Me.lvErrorList.Location = New System.Drawing.Point(12, 324)
        Me.lvErrorList.Name = "lvErrorList"
        Me.lvErrorList.Size = New System.Drawing.Size(211, 99)
        Me.lvErrorList.TabIndex = 4
        Me.lvErrorList.UseCompatibleStateImageBehavior = False
        Me.lvErrorList.View = System.Windows.Forms.View.Details
        '
        'colError
        '
        Me.colError.Text = "Error List"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(229, 400)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(124, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Clear Error List"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(451, 37)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(102, 20)
        Me.dtpDateFrom.TabIndex = 98
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Document Date:"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(581, 38)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(102, 20)
        Me.dtpDateTo.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(559, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "to"
        '
        'cb2ClickRep
        '
        Me.cb2ClickRep.AutoSize = True
        Me.cb2ClickRep.Location = New System.Drawing.Point(239, 328)
        Me.cb2ClickRep.Name = "cb2ClickRep"
        Me.cb2ClickRep.Size = New System.Drawing.Size(148, 17)
        Me.cb2ClickRep.TabIndex = 100
        Me.cb2ClickRep.Text = "Double click to show form"
        Me.cb2ClickRep.UseVisualStyleBackColor = True
        '
        'APPROVAL
        '
        Me.AccessibleName = "APPROVAL"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 435)
        Me.Controls.Add(Me.cb2ClickRep)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDateTo)
        Me.Controls.Add(Me.dtpDateFrom)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lvErrorList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvApprovalList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "APPROVAL"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "GENERIC"
        Me.Text = "APPROVAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvApprovalList As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents colOrigin As ColumnHeader
    Friend WithEvents colDocNum As ColumnHeader
    Friend WithEvents colDate As ColumnHeader
    Friend WithEvents colStat As ColumnHeader
    Friend WithEvents colRemarks As ColumnHeader
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents lvErrorList As ListView
    Friend WithEvents colError As ColumnHeader
    Friend WithEvents Button3 As Button
    Friend WithEvents colWParam As ColumnHeader
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cb2ClickRep As CheckBox
End Class
