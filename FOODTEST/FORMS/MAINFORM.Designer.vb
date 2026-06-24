<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAINFORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAINFORM))
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Test Masterlist")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Admin Controls", New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Food Test Request")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sampling Test")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data Encoding", New System.Windows.Forms.TreeNode() {TreeNode31, TreeNode32})
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Test Approval")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Approval", New System.Windows.Forms.TreeNode() {TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports")
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestPostingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.btnAddNew = New System.Windows.Forms.ToolStripButton()
        Me.lblTotalRec = New System.Windows.Forms.ToolStripLabel()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveFirst = New System.Windows.Forms.ToolStripButton()
        Me.btnMovePrev = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.txtCurPos = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMoveNext = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveLast = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.tvModuleList = New System.Windows.Forms.TreeView()
        Me.FORMPANEL = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sep1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGroupName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sep2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblModuleActivity = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.MainNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainNavigator.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1055, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestPostingToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'TestPostingToolStripMenuItem
        '
        Me.TestPostingToolStripMenuItem.Name = "TestPostingToolStripMenuItem"
        Me.TestPostingToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.TestPostingToolStripMenuItem.Text = "Test Posting"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'MainNavigator
        '
        Me.MainNavigator.AddNewItem = Me.btnAddNew
        Me.MainNavigator.CountItem = Me.lblTotalRec
        Me.MainNavigator.DeleteItem = Me.btnDelete
        Me.MainNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.MainNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMoveFirst, Me.btnMovePrev, Me.BindingNavigatorSeparator, Me.txtCurPos, Me.lblTotalRec, Me.BindingNavigatorSeparator1, Me.btnMoveNext, Me.btnMoveLast, Me.BindingNavigatorSeparator2, Me.btnAddNew, Me.btnDelete, Me.btnSave, Me.btnSearch})
        Me.MainNavigator.Location = New System.Drawing.Point(209, 0)
        Me.MainNavigator.MoveFirstItem = Me.btnMoveFirst
        Me.MainNavigator.MoveLastItem = Me.btnMoveLast
        Me.MainNavigator.MoveNextItem = Me.btnMoveNext
        Me.MainNavigator.MovePreviousItem = Me.btnMovePrev
        Me.MainNavigator.Name = "MainNavigator"
        Me.MainNavigator.PositionItem = Me.txtCurPos
        Me.MainNavigator.Size = New System.Drawing.Size(301, 25)
        Me.MainNavigator.TabIndex = 4
        Me.MainNavigator.Text = "BindingNavigator1"
        '
        'btnAddNew
        '
        Me.btnAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAddNew.Image = CType(resources.GetObject("btnAddNew.Image"), System.Drawing.Image)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.RightToLeftAutoMirrorImage = True
        Me.btnAddNew.Size = New System.Drawing.Size(23, 22)
        Me.btnAddNew.Text = "Add new"
        '
        'lblTotalRec
        '
        Me.lblTotalRec.Name = "lblTotalRec"
        Me.lblTotalRec.Size = New System.Drawing.Size(35, 22)
        Me.lblTotalRec.Text = "of {0}"
        Me.lblTotalRec.ToolTipText = "Total number of items"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeftAutoMirrorImage = True
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMoveFirst.Image = CType(resources.GetObject("btnMoveFirst.Image"), System.Drawing.Image)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.RightToLeftAutoMirrorImage = True
        Me.btnMoveFirst.Size = New System.Drawing.Size(23, 22)
        Me.btnMoveFirst.Text = "Move first"
        '
        'btnMovePrev
        '
        Me.btnMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMovePrev.Image = CType(resources.GetObject("btnMovePrev.Image"), System.Drawing.Image)
        Me.btnMovePrev.Name = "btnMovePrev"
        Me.btnMovePrev.RightToLeftAutoMirrorImage = True
        Me.btnMovePrev.Size = New System.Drawing.Size(23, 22)
        Me.btnMovePrev.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'txtCurPos
        '
        Me.txtCurPos.AccessibleName = "Position"
        Me.txtCurPos.AutoSize = False
        Me.txtCurPos.Name = "txtCurPos"
        Me.txtCurPos.Size = New System.Drawing.Size(50, 23)
        Me.txtCurPos.Text = "0"
        Me.txtCurPos.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnMoveNext
        '
        Me.btnMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMoveNext.Image = CType(resources.GetObject("btnMoveNext.Image"), System.Drawing.Image)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.RightToLeftAutoMirrorImage = True
        Me.btnMoveNext.Size = New System.Drawing.Size(23, 22)
        Me.btnMoveNext.Text = "Move next"
        '
        'btnMoveLast
        '
        Me.btnMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMoveLast.Image = CType(resources.GetObject("btnMoveLast.Image"), System.Drawing.Image)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.RightToLeftAutoMirrorImage = True
        Me.btnMoveLast.Size = New System.Drawing.Size(23, 22)
        Me.btnMoveLast.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save"
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSearch.Text = "Search"
        '
        'tvModuleList
        '
        Me.tvModuleList.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvModuleList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvModuleList.Location = New System.Drawing.Point(0, 24)
        Me.tvModuleList.Name = "tvModuleList"
        TreeNode28.Name = "nUsers"
        TreeNode28.Text = "Users"
        TreeNode29.Name = "nTestMasterList"
        TreeNode29.Text = "Test Masterlist"
        TreeNode30.Name = "nAdmin"
        TreeNode30.Text = "Admin Controls"
        TreeNode30.ToolTipText = "Admin control and setup"
        TreeNode31.Name = "nTestRequest"
        TreeNode31.Text = "Food Test Request"
        TreeNode32.Name = "nFoodTest"
        TreeNode32.Text = "Sampling Test"
        TreeNode33.Name = "nEncode"
        TreeNode33.Text = "Data Encoding"
        TreeNode34.Name = "nTestApprove"
        TreeNode34.Text = "Test Approval"
        TreeNode35.Name = "nApprove"
        TreeNode35.Text = "Approval"
        TreeNode36.Name = "nReport"
        TreeNode36.Text = "Reports"
        Me.tvModuleList.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode30, TreeNode33, TreeNode35, TreeNode36})
        Me.tvModuleList.Size = New System.Drawing.Size(198, 630)
        Me.tvModuleList.TabIndex = 5
        '
        'FORMPANEL
        '
        Me.FORMPANEL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FORMPANEL.Location = New System.Drawing.Point(198, 24)
        Me.FORMPANEL.Name = "FORMPANEL"
        Me.FORMPANEL.Size = New System.Drawing.Size(857, 630)
        Me.FORMPANEL.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUserName, Me.sep1, Me.lblGroupName, Me.sep2, Me.lblModuleActivity})
        Me.StatusStrip1.Location = New System.Drawing.Point(697, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(324, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUserName
        '
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(68, 17)
        Me.lblUserName.Text = "USERNAME"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        Me.sep1.Size = New System.Drawing.Size(10, 17)
        Me.sep1.Text = "|"
        '
        'lblGroupName
        '
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.Size = New System.Drawing.Size(80, 17)
        Me.lblGroupName.Text = "GROUPNAME"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        Me.sep2.Size = New System.Drawing.Size(10, 17)
        Me.sep2.Text = "|"
        '
        'lblModuleActivity
        '
        Me.lblModuleActivity.Name = "lblModuleActivity"
        Me.lblModuleActivity.Size = New System.Drawing.Size(108, 17)
        Me.lblModuleActivity.Text = "MODULE_ACTIVITY"
        '
        'MAINFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 654)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.FORMPANEL)
        Me.Controls.Add(Me.tvModuleList)
        Me.Controls.Add(Me.MainNavigator)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MAINFORM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FOOD TEST"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.MainNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainNavigator.ResumeLayout(False)
        Me.MainNavigator.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainNavigator As BindingNavigator
    Friend WithEvents btnAddNew As ToolStripButton
    Friend WithEvents lblTotalRec As ToolStripLabel
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnMoveFirst As ToolStripButton
    Friend WithEvents btnMovePrev As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents txtCurPos As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents btnMoveNext As ToolStripButton
    Friend WithEvents btnMoveLast As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents tvModuleList As TreeView
    Friend WithEvents FORMPANEL As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblUserName As ToolStripStatusLabel
    Friend WithEvents sep1 As ToolStripStatusLabel
    Friend WithEvents lblGroupName As ToolStripStatusLabel
    Friend WithEvents sep2 As ToolStripStatusLabel
    Friend WithEvents lblModuleActivity As ToolStripStatusLabel
    Friend WithEvents TestPostingToolStripMenuItem As ToolStripMenuItem
End Class
