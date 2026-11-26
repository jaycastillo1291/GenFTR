<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAMPLEREGISTER
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
        Me.lvRegList = New System.Windows.Forms.ListView()
        Me.colRowStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRegNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPreparedBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPrepDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPrinted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvRegDetails = New System.Windows.Forms.ListView()
        Me.colTRN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colReqRS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSubBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSamplingStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSampleSub = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUTD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBatch = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTestReq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateReg = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnLoadtoList = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvRegList
        '
        Me.lvRegList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRowStamp, Me.colRegNo, Me.colPreparedBy, Me.colPrepDate, Me.colPrinted})
        Me.lvRegList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRegList.FullRowSelect = True
        Me.lvRegList.HideSelection = False
        Me.lvRegList.Location = New System.Drawing.Point(3, 16)
        Me.lvRegList.MultiSelect = False
        Me.lvRegList.Name = "lvRegList"
        Me.lvRegList.Size = New System.Drawing.Size(357, 333)
        Me.lvRegList.TabIndex = 0
        Me.lvRegList.UseCompatibleStateImageBehavior = False
        Me.lvRegList.View = System.Windows.Forms.View.Details
        '
        'colRowStamp
        '
        Me.colRowStamp.Text = "RowStamp"
        Me.colRowStamp.Width = 35
        '
        'colRegNo
        '
        Me.colRegNo.Text = "Reg. No."
        Me.colRegNo.Width = 79
        '
        'colPreparedBy
        '
        Me.colPreparedBy.Text = "Prepared By"
        Me.colPreparedBy.Width = 79
        '
        'colPrepDate
        '
        Me.colPrepDate.Text = "Date Prepared"
        Me.colPrepDate.Width = 81
        '
        'colPrinted
        '
        Me.colPrinted.Text = "Printed"
        Me.colPrinted.Width = 50
        '
        'lvRegDetails
        '
        Me.lvRegDetails.CheckBoxes = True
        Me.lvRegDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTRN, Me.colReqRS, Me.colSubBy, Me.colSamplingStamp, Me.colSampleSub, Me.colPD, Me.colUTD, Me.colBatch, Me.colTestReq})
        Me.lvRegDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRegDetails.FullRowSelect = True
        Me.lvRegDetails.HideSelection = False
        Me.lvRegDetails.Location = New System.Drawing.Point(3, 16)
        Me.lvRegDetails.MultiSelect = False
        Me.lvRegDetails.Name = "lvRegDetails"
        Me.lvRegDetails.Size = New System.Drawing.Size(660, 333)
        Me.lvRegDetails.TabIndex = 1
        Me.lvRegDetails.UseCompatibleStateImageBehavior = False
        Me.lvRegDetails.View = System.Windows.Forms.View.Details
        '
        'colTRN
        '
        Me.colTRN.Text = "Test Req. No."
        Me.colTRN.Width = 83
        '
        'colReqRS
        '
        Me.colReqRS.Text = "RowStamp"
        Me.colReqRS.Width = 72
        '
        'colSubBy
        '
        Me.colSubBy.Text = "Submitted By"
        Me.colSubBy.Width = 83
        '
        'colSamplingStamp
        '
        Me.colSamplingStamp.Text = "Sampling Date/Time"
        Me.colSamplingStamp.Width = 77
        '
        'colSampleSub
        '
        Me.colSampleSub.Text = "Sample Submitted"
        '
        'colPD
        '
        Me.colPD.Text = "Production/Kill/Pack Date"
        '
        'colUTD
        '
        Me.colUTD.Text = "UTD/ Rec Date"
        '
        'colBatch
        '
        Me.colBatch.Text = "Batch No."
        '
        'colTestReq
        '
        Me.colTestReq.Text = "Test Requested"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lvRegDetails)
        Me.GroupBox1.Location = New System.Drawing.Point(378, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 352)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test List"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvRegList)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 352)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Register List"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(89, 21)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(97, 20)
        Me.dtpDateFrom.TabIndex = 4
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(89, 47)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(97, 20)
        Me.dtpDateTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Date From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "to:"
        '
        'btnCreateReg
        '
        Me.btnCreateReg.Location = New System.Drawing.Point(466, 30)
        Me.btnCreateReg.Name = "btnCreateReg"
        Me.btnCreateReg.Size = New System.Drawing.Size(153, 25)
        Me.btnCreateReg.TabIndex = 6
        Me.btnCreateReg.Text = "Create Register"
        Me.btnCreateReg.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(466, 61)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(153, 25)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(218, 18)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(129, 23)
        Me.btnView.TabIndex = 6
        Me.btnView.Text = "View Register List"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnLoadtoList
        '
        Me.btnLoadtoList.Location = New System.Drawing.Point(218, 47)
        Me.btnLoadtoList.Name = "btnLoadtoList"
        Me.btnLoadtoList.Size = New System.Drawing.Size(129, 23)
        Me.btnLoadtoList.TabIndex = 6
        Me.btnLoadtoList.Text = "Load to Details"
        Me.btnLoadtoList.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(625, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 56)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SAMPLEREGISTER
        '
        Me.AcceptButton = Me.btnView
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 439)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnLoadtoList)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCreateReg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDateTo)
        Me.Controls.Add(Me.dtpDateFrom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SAMPLEREGISTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAMPLE REGISTER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvRegList As ListView
    Friend WithEvents colRowStamp As ColumnHeader
    Friend WithEvents colRegNo As ColumnHeader
    Friend WithEvents colPreparedBy As ColumnHeader
    Friend WithEvents colPrepDate As ColumnHeader
    Friend WithEvents colPrinted As ColumnHeader
    Friend WithEvents lvRegDetails As ListView
    Friend WithEvents colTRN As ColumnHeader
    Friend WithEvents colReqRS As ColumnHeader
    Friend WithEvents colSubBy As ColumnHeader
    Friend WithEvents colSamplingStamp As ColumnHeader
    Friend WithEvents colSampleSub As ColumnHeader
    Friend WithEvents colPD As ColumnHeader
    Friend WithEvents colUTD As ColumnHeader
    Friend WithEvents colBatch As ColumnHeader
    Friend WithEvents colTestReq As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCreateReg As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnLoadtoList As Button
    Friend WithEvents Button1 As Button
End Class
