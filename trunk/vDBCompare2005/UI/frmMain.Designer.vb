<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
    Me.tvDB1 = New System.Windows.Forms.TreeView
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.tvDB2 = New System.Windows.Forms.TreeView
    Me.tvDiff2 = New System.Windows.Forms.TreeView
    Me.tvDiff1 = New System.Windows.Forms.TreeView
    Me.ilsTab = New System.Windows.Forms.ImageList(Me.components)
    Me.dlgSave = New System.Windows.Forms.SaveFileDialog
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
    Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.PackDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
    Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.LoadSchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.CompareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SkinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin1 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin2 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin3 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin4 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin5 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin6 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin7 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin8 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin9 = New System.Windows.Forms.ToolStripMenuItem
    Me.miSkin10 = New System.Windows.Forms.ToolStripMenuItem
    Me.DB1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToAccessmdbToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToSqlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ScriptVBNETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.PackDatabase1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DB2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ExportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.ToAccessmdbToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.ToSQLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.ScriptVBNETToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.PackDatabase2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ORMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.XPOObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.Opf3ObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.VistaDBDataBuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DataBuilder3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
    Me.ConvertToAccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.CloneDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
    Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.OnlineManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ReportFaultIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
    Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.StyleController1 = New DevExpress.XtraEditors.StyleController(Me.components)
    Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
    Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
    Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
    Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl
    Me.lnkDB1ShortName = New System.Windows.Forms.LinkLabel
    Me.lnkDB2ShortName = New System.Windows.Forms.LinkLabel
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
    Me.txtMasterDB = New DevExpress.XtraEditors.ButtonEdit
    Me.txtCompareDB = New DevExpress.XtraEditors.ButtonEdit
    Me.txtScript = New DevExpress.XtraEditors.MemoEdit
    Me.xTabMain = New DevExpress.XtraTab.XtraTabControl
    Me.xtpSchema = New DevExpress.XtraTab.XtraTabPage
    Me.xtpDifferences = New DevExpress.XtraTab.XtraTabPage
    Me.xtpScript = New DevExpress.XtraTab.XtraTabPage
    Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
    Me.btnLoadSchema = New DevExpress.XtraEditors.SimpleButton
    Me.btnCompare = New DevExpress.XtraEditors.SimpleButton
    Me.btnSwapDBs = New DevExpress.XtraEditors.SimpleButton
    Me.chkGenScript = New DevExpress.XtraEditors.CheckEdit
    Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
    Me.VisitProjectHomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.MenuStrip1.SuspendLayout()
    CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerControl1.SuspendLayout()
    CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerControl2.SuspendLayout()
    CType(Me.txtMasterDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtCompareDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtScript.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.xTabMain, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.xTabMain.SuspendLayout()
    Me.xtpSchema.SuspendLayout()
    Me.xtpDifferences.SuspendLayout()
    Me.xtpScript.SuspendLayout()
    CType(Me.chkGenScript.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dlgOpen
    '
    Me.dlgOpen.DefaultExt = "vdb"
    Me.dlgOpen.Filter = "VistaDB  (*.vdb)|*.vdb;*.vdb3|All Files (*.*)|*.*"
    Me.dlgOpen.Title = "Open Database"
    '
    'tvDB1
    '
    Me.tvDB1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.tvDB1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tvDB1.ImageIndex = 0
    Me.tvDB1.ImageList = Me.ImageList1
    Me.tvDB1.Location = New System.Drawing.Point(0, 0)
    Me.tvDB1.Name = "tvDB1"
    Me.tvDB1.SelectedImageIndex = 3
    Me.tvDB1.Size = New System.Drawing.Size(291, 386)
    Me.ToolTipController1.SetSuperTip(Me.tvDB1, Nothing)
    Me.tvDB1.TabIndex = 7
    Me.ToolTipController1.SetTitle(Me.tvDB1, "Master Database Schema")
    Me.ToolTipController1.SetToolTip(Me.tvDB1, "Drag a VistaDB file here to view")
    Me.ToolTipController1.SetToolTipIconType(Me.tvDB1, DevExpress.Utils.ToolTipIconType.Information)
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Empty
    Me.ImageList1.Images.SetKeyName(0, "folder_16.ico")
    Me.ImageList1.Images.SetKeyName(1, "folderadd_16.ico")
    Me.ImageList1.Images.SetKeyName(2, "folderdel_16.ico")
    Me.ImageList1.Images.SetKeyName(3, "")
    Me.ImageList1.Images.SetKeyName(4, "doc_16.ico")
    Me.ImageList1.Images.SetKeyName(5, "adddoc_16.ico")
    Me.ImageList1.Images.SetKeyName(6, "docdel_16.ico")
    Me.ImageList1.Images.SetKeyName(7, "docnext_16.ico")
    Me.ImageList1.Images.SetKeyName(8, "")
    Me.ImageList1.Images.SetKeyName(9, "")
    '
    'tvDB2
    '
    Me.tvDB2.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.tvDB2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tvDB2.ImageIndex = 0
    Me.tvDB2.ImageList = Me.ImageList1
    Me.tvDB2.Location = New System.Drawing.Point(0, 0)
    Me.tvDB2.Name = "tvDB2"
    Me.tvDB2.SelectedImageIndex = 3
    Me.tvDB2.Size = New System.Drawing.Size(314, 386)
    Me.ToolTipController1.SetSuperTip(Me.tvDB2, Nothing)
    Me.tvDB2.TabIndex = 8
    Me.ToolTipController1.SetTitle(Me.tvDB2, "Compare DB Schema")
    Me.ToolTipController1.SetToolTip(Me.tvDB2, "Drag a VistaDB file here to view")
    Me.ToolTipController1.SetToolTipIconType(Me.tvDB2, DevExpress.Utils.ToolTipIconType.Information)
    '
    'tvDiff2
    '
    Me.tvDiff2.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.tvDiff2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tvDiff2.ImageIndex = 0
    Me.tvDiff2.ImageList = Me.ImageList1
    Me.tvDiff2.Location = New System.Drawing.Point(0, 0)
    Me.tvDiff2.Name = "tvDiff2"
    Me.tvDiff2.SelectedImageIndex = 3
    Me.tvDiff2.Size = New System.Drawing.Size(291, 386)
    Me.ToolTipController1.SetSuperTip(Me.tvDiff2, Nothing)
    Me.tvDiff2.TabIndex = 9
    Me.ToolTipController1.SetTitle(Me.tvDiff2, "Master Schema")
    Me.ToolTipController1.SetToolTip(Me.tvDiff2, "Changes to make Master DB same as Compare DB")
    Me.ToolTipController1.SetToolTipIconType(Me.tvDiff2, DevExpress.Utils.ToolTipIconType.Information)
    '
    'tvDiff1
    '
    Me.tvDiff1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.tvDiff1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tvDiff1.ImageIndex = 0
    Me.tvDiff1.ImageList = Me.ImageList1
    Me.tvDiff1.Location = New System.Drawing.Point(0, 0)
    Me.tvDiff1.Name = "tvDiff1"
    Me.tvDiff1.SelectedImageIndex = 3
    Me.tvDiff1.Size = New System.Drawing.Size(314, 386)
    Me.ToolTipController1.SetSuperTip(Me.tvDiff1, Nothing)
    Me.tvDiff1.TabIndex = 8
    Me.ToolTipController1.SetTitle(Me.tvDiff1, "Compare Schema")
    Me.ToolTipController1.SetToolTip(Me.tvDiff1, "Changes to make Compare DB same as Master DB")
    Me.ToolTipController1.SetToolTipIconType(Me.tvDiff1, DevExpress.Utils.ToolTipIconType.Information)
    '
    'ilsTab
    '
    Me.ilsTab.ImageStream = CType(resources.GetObject("ilsTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ilsTab.TransparentColor = System.Drawing.Color.Magenta
    Me.ilsTab.Images.SetKeyName(0, "Compare Image.bmp")
    Me.ilsTab.Images.SetKeyName(1, "Copy.bmp")
    Me.ilsTab.Images.SetKeyName(2, "Highlight.bmp")
    '
    'MenuStrip1
    '
    Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
    Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ActionToolStripMenuItem, Me.DB1ToolStripMenuItem, Me.DB2ToolStripMenuItem, Me.ORMToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.MenuStrip1.Size = New System.Drawing.Size(662, 24)
    Me.ToolTipController1.SetSuperTip(Me.MenuStrip1, Nothing)
    Me.MenuStrip1.TabIndex = 19
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'FileToolStripMenuItem
    '
    Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PackDatabaseToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
    Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
    Me.FileToolStripMenuItem.Text = "&File"
    '
    'PackDatabaseToolStripMenuItem
    '
    Me.PackDatabaseToolStripMenuItem.Name = "PackDatabaseToolStripMenuItem"
    Me.PackDatabaseToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.PackDatabaseToolStripMenuItem.Text = "Pack Database..."
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(157, 6)
    '
    'ExitToolStripMenuItem
    '
    Me.ExitToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.exit_16
    Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.ExitToolStripMenuItem.Text = "E&xit"
    '
    'ActionToolStripMenuItem
    '
    Me.ActionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadSchemaToolStripMenuItem, Me.CompareToolStripMenuItem, Me.SkinToolStripMenuItem})
    Me.ActionToolStripMenuItem.Name = "ActionToolStripMenuItem"
    Me.ActionToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
    Me.ActionToolStripMenuItem.Text = "&View"
    '
    'LoadSchemaToolStripMenuItem
    '
    Me.LoadSchemaToolStripMenuItem.Name = "LoadSchemaToolStripMenuItem"
    Me.LoadSchemaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
    Me.LoadSchemaToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
    Me.LoadSchemaToolStripMenuItem.Text = "Schema"
    '
    'CompareToolStripMenuItem
    '
    Me.CompareToolStripMenuItem.Name = "CompareToolStripMenuItem"
    Me.CompareToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
    Me.CompareToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
    Me.CompareToolStripMenuItem.Text = "Compare"
    '
    'SkinToolStripMenuItem
    '
    Me.SkinToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSkin1, Me.miSkin2, Me.miSkin3, Me.miSkin4, Me.miSkin5, Me.miSkin6, Me.miSkin7, Me.miSkin8, Me.miSkin9, Me.miSkin10})
    Me.SkinToolStripMenuItem.Name = "SkinToolStripMenuItem"
    Me.SkinToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
    Me.SkinToolStripMenuItem.Text = "Skin"
    '
    'miSkin1
    '
    Me.miSkin1.Checked = True
    Me.miSkin1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.miSkin1.Name = "miSkin1"
    Me.miSkin1.Size = New System.Drawing.Size(165, 22)
    Me.miSkin1.Text = "Caramel"
    '
    'miSkin2
    '
    Me.miSkin2.Name = "miSkin2"
    Me.miSkin2.Size = New System.Drawing.Size(165, 22)
    Me.miSkin2.Text = "Money Twins"
    '
    'miSkin3
    '
    Me.miSkin3.Name = "miSkin3"
    Me.miSkin3.Size = New System.Drawing.Size(165, 22)
    Me.miSkin3.Text = "Lilian"
    '
    'miSkin4
    '
    Me.miSkin4.Name = "miSkin4"
    Me.miSkin4.Size = New System.Drawing.Size(165, 22)
    Me.miSkin4.Text = "The Asphalt World"
    '
    'miSkin5
    '
    Me.miSkin5.Name = "miSkin5"
    Me.miSkin5.Size = New System.Drawing.Size(165, 22)
    Me.miSkin5.Text = "iMaginary"
    '
    'miSkin6
    '
    Me.miSkin6.Name = "miSkin6"
    Me.miSkin6.Size = New System.Drawing.Size(165, 22)
    Me.miSkin6.Text = "Black"
    '
    'miSkin7
    '
    Me.miSkin7.Name = "miSkin7"
    Me.miSkin7.Size = New System.Drawing.Size(165, 22)
    Me.miSkin7.Text = "Blue"
    '
    'miSkin8
    '
    Me.miSkin8.Name = "miSkin8"
    Me.miSkin8.Size = New System.Drawing.Size(165, 22)
    Me.miSkin8.Text = "Office 2007 Blue"
    '
    'miSkin9
    '
    Me.miSkin9.Name = "miSkin9"
    Me.miSkin9.Size = New System.Drawing.Size(165, 22)
    Me.miSkin9.Text = "Office 2007 Black"
    '
    'miSkin10
    '
    Me.miSkin10.Name = "miSkin10"
    Me.miSkin10.Size = New System.Drawing.Size(165, 22)
    Me.miSkin10.Text = "Office 2007 Silver"
    '
    'DB1ToolStripMenuItem
    '
    Me.DB1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToolStripMenuItem, Me.ToAccessmdbToolStripMenuItem, Me.ToSqlToolStripMenuItem, Me.ScriptVBNETToolStripMenuItem, Me.PackDatabase1ToolStripMenuItem})
    Me.DB1ToolStripMenuItem.Name = "DB1ToolStripMenuItem"
    Me.DB1ToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
    Me.DB1ToolStripMenuItem.Text = "DB1"
    '
    'ExportToolStripMenuItem
    '
    Me.ExportToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.Save
    Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
    Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.ExportToolStripMenuItem.Text = "Export..."
    '
    'ToAccessmdbToolStripMenuItem
    '
    Me.ToAccessmdbToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.Grid_Footers
    Me.ToAccessmdbToolStripMenuItem.Name = "ToAccessmdbToolStripMenuItem"
    Me.ToAccessmdbToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.ToAccessmdbToolStripMenuItem.Text = "To Access (mdb)"
    '
    'ToSqlToolStripMenuItem
    '
    Me.ToSqlToolStripMenuItem.Enabled = False
    Me.ToSqlToolStripMenuItem.Name = "ToSqlToolStripMenuItem"
    Me.ToSqlToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.ToSqlToolStripMenuItem.Text = "To SQL"
    '
    'ScriptVBNETToolStripMenuItem
    '
    Me.ScriptVBNETToolStripMenuItem.Name = "ScriptVBNETToolStripMenuItem"
    Me.ScriptVBNETToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.ScriptVBNETToolStripMenuItem.Text = "Script VB.NET"
    '
    'PackDatabase1ToolStripMenuItem
    '
    Me.PackDatabase1ToolStripMenuItem.Name = "PackDatabase1ToolStripMenuItem"
    Me.PackDatabase1ToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.PackDatabase1ToolStripMenuItem.Text = "Pack Database"
    '
    'DB2ToolStripMenuItem
    '
    Me.DB2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToolStripMenuItem1, Me.ToAccessmdbToolStripMenuItem1, Me.ToSQLToolStripMenuItem1, Me.ScriptVBNETToolStripMenuItem1, Me.PackDatabase2ToolStripMenuItem})
    Me.DB2ToolStripMenuItem.Name = "DB2ToolStripMenuItem"
    Me.DB2ToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
    Me.DB2ToolStripMenuItem.Text = "DB2"
    '
    'ExportToolStripMenuItem1
    '
    Me.ExportToolStripMenuItem1.Image = Global.vDBCompare.My.Resources.Resources.Save
    Me.ExportToolStripMenuItem1.Name = "ExportToolStripMenuItem1"
    Me.ExportToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
    Me.ExportToolStripMenuItem1.Text = "Export..."
    '
    'ToAccessmdbToolStripMenuItem1
    '
    Me.ToAccessmdbToolStripMenuItem1.Image = Global.vDBCompare.My.Resources.Resources.Grid_Footers
    Me.ToAccessmdbToolStripMenuItem1.Name = "ToAccessmdbToolStripMenuItem1"
    Me.ToAccessmdbToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
    Me.ToAccessmdbToolStripMenuItem1.Text = "To Access (mdb)"
    '
    'ToSQLToolStripMenuItem1
    '
    Me.ToSQLToolStripMenuItem1.Enabled = False
    Me.ToSQLToolStripMenuItem1.Name = "ToSQLToolStripMenuItem1"
    Me.ToSQLToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
    Me.ToSQLToolStripMenuItem1.Text = "To SQL"
    '
    'ScriptVBNETToolStripMenuItem1
    '
    Me.ScriptVBNETToolStripMenuItem1.Name = "ScriptVBNETToolStripMenuItem1"
    Me.ScriptVBNETToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
    Me.ScriptVBNETToolStripMenuItem1.Text = "Script VB.NET"
    '
    'PackDatabase2ToolStripMenuItem
    '
    Me.PackDatabase2ToolStripMenuItem.Name = "PackDatabase2ToolStripMenuItem"
    Me.PackDatabase2ToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
    Me.PackDatabase2ToolStripMenuItem.Text = "Pack Database"
    '
    'ORMToolStripMenuItem
    '
    Me.ORMToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XPOObjectsToolStripMenuItem, Me.Opf3ObjectsToolStripMenuItem})
    Me.ORMToolStripMenuItem.Name = "ORMToolStripMenuItem"
    Me.ORMToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
    Me.ORMToolStripMenuItem.Text = "ORM"
    '
    'XPOObjectsToolStripMenuItem
    '
    Me.XPOObjectsToolStripMenuItem.Name = "XPOObjectsToolStripMenuItem"
    Me.XPOObjectsToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
    Me.XPOObjectsToolStripMenuItem.Text = "XPO Objects... (web link)"
    '
    'Opf3ObjectsToolStripMenuItem
    '
    Me.Opf3ObjectsToolStripMenuItem.Name = "Opf3ObjectsToolStripMenuItem"
    Me.Opf3ObjectsToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
    Me.Opf3ObjectsToolStripMenuItem.Text = "Opf3 Objects... (web link)"
    '
    'ToolsToolStripMenuItem
    '
    Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VistaDBDataBuilderToolStripMenuItem, Me.DataBuilder3ToolStripMenuItem, Me.ToolStripSeparator3, Me.ConvertToAccessToolStripMenuItem, Me.CloneDatabaseToolStripMenuItem, Me.ToolStripSeparator1, Me.OptionsToolStripMenuItem})
    Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
    Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
    Me.ToolsToolStripMenuItem.Text = "&Tools"
    '
    'VistaDBDataBuilderToolStripMenuItem
    '
    Me.VistaDBDataBuilderToolStripMenuItem.Name = "VistaDBDataBuilderToolStripMenuItem"
    Me.VistaDBDataBuilderToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
    Me.VistaDBDataBuilderToolStripMenuItem.Text = "Data Builder v2"
    '
    'DataBuilder3ToolStripMenuItem
    '
    Me.DataBuilder3ToolStripMenuItem.Name = "DataBuilder3ToolStripMenuItem"
    Me.DataBuilder3ToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
    Me.DataBuilder3ToolStripMenuItem.Text = "Data Builder v3"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(174, 6)
    '
    'ConvertToAccessToolStripMenuItem
    '
    Me.ConvertToAccessToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.Grid_Footers
    Me.ConvertToAccessToolStripMenuItem.Name = "ConvertToAccessToolStripMenuItem"
    Me.ConvertToAccessToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
    Me.ConvertToAccessToolStripMenuItem.Text = "Convert To Access..."
    '
    'CloneDatabaseToolStripMenuItem
    '
    Me.CloneDatabaseToolStripMenuItem.Enabled = False
    Me.CloneDatabaseToolStripMenuItem.Name = "CloneDatabaseToolStripMenuItem"
    Me.CloneDatabaseToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
    Me.CloneDatabaseToolStripMenuItem.Text = "Clone Database..."
    Me.CloneDatabaseToolStripMenuItem.Visible = False
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
    '
    'OptionsToolStripMenuItem
    '
    Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
    Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
    Me.OptionsToolStripMenuItem.Text = "&Options"
    '
    'HelpToolStripMenuItem
    '
    Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisitProjectHomeToolStripMenuItem, Me.OnlineManualToolStripMenuItem, Me.ReportFaultIssueToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
    Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
    Me.HelpToolStripMenuItem.Text = "&Help"
    '
    'OnlineManualToolStripMenuItem
    '
    Me.OnlineManualToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.help_16
    Me.OnlineManualToolStripMenuItem.Name = "OnlineManualToolStripMenuItem"
    Me.OnlineManualToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.OnlineManualToolStripMenuItem.Text = "Online Manual"
    '
    'ReportFaultIssueToolStripMenuItem
    '
    Me.ReportFaultIssueToolStripMenuItem.Name = "ReportFaultIssueToolStripMenuItem"
    Me.ReportFaultIssueToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.ReportFaultIssueToolStripMenuItem.Text = "Report Fault/Issue"
    '
    'CheckForUpdatesToolStripMenuItem
    '
    Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
    Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.CheckForUpdatesToolStripMenuItem.Text = "Check For Updates"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
    '
    'AboutToolStripMenuItem
    '
    Me.AboutToolStripMenuItem.Image = Global.vDBCompare.My.Resources.Resources.info_16
    Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.AboutToolStripMenuItem.Text = "About"
    '
    'StyleController1
    '
    Me.StyleController1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.StyleController1.Appearance.Options.UseFont = True
    '
    'LabelControl1
    '
    Me.LabelControl1.Location = New System.Drawing.Point(12, 38)
    Me.LabelControl1.Name = "LabelControl1"
    Me.LabelControl1.Size = New System.Drawing.Size(90, 14)
    Me.LabelControl1.StyleController = Me.StyleController1
    Me.LabelControl1.TabIndex = 31
    Me.LabelControl1.Text = "Master Database"
    '
    'ToolTipController1
    '
    Me.ToolTipController1.Rounded = True
    Me.ToolTipController1.ShowBeak = True
    '
    'SplitContainerControl1
    '
    Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerControl1.Location = New System.Drawing.Point(5, 5)
    Me.SplitContainerControl1.Name = "SplitContainerControl1"
    Me.SplitContainerControl1.Panel1.Controls.Add(Me.tvDiff2)
    Me.SplitContainerControl1.Panel1.Text = "Panel1"
    Me.SplitContainerControl1.Panel2.Controls.Add(Me.tvDiff1)
    Me.SplitContainerControl1.Panel2.Text = "Panel2"
    Me.SplitContainerControl1.Size = New System.Drawing.Size(619, 390)
    Me.SplitContainerControl1.SplitterPosition = 295
    Me.ToolTipController1.SetSuperTip(Me.SplitContainerControl1, Nothing)
    Me.SplitContainerControl1.TabIndex = 0
    Me.SplitContainerControl1.Text = "SplitContainerControl1"
    '
    'SplitContainerControl2
    '
    Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerControl2.Location = New System.Drawing.Point(5, 5)
    Me.SplitContainerControl2.Name = "SplitContainerControl2"
    Me.SplitContainerControl2.Panel1.Controls.Add(Me.tvDB1)
    Me.SplitContainerControl2.Panel1.Text = "Panel1"
    Me.SplitContainerControl2.Panel2.Controls.Add(Me.tvDB2)
    Me.SplitContainerControl2.Panel2.Text = "Panel2"
    Me.SplitContainerControl2.Size = New System.Drawing.Size(619, 390)
    Me.SplitContainerControl2.SplitterPosition = 295
    Me.ToolTipController1.SetSuperTip(Me.SplitContainerControl2, Nothing)
    Me.SplitContainerControl2.TabIndex = 0
    Me.SplitContainerControl2.Text = "SplitContainerControl2"
    '
    'lnkDB1ShortName
    '
    Me.lnkDB1ShortName.Location = New System.Drawing.Point(121, 39)
    Me.lnkDB1ShortName.Name = "lnkDB1ShortName"
    Me.lnkDB1ShortName.Size = New System.Drawing.Size(199, 13)
    Me.ToolTipController1.SetSuperTip(Me.lnkDB1ShortName, Nothing)
    Me.lnkDB1ShortName.TabIndex = 37
    '
    'lnkDB2ShortName
    '
    Me.lnkDB2ShortName.Location = New System.Drawing.Point(451, 39)
    Me.lnkDB2ShortName.Name = "lnkDB2ShortName"
    Me.lnkDB2ShortName.Size = New System.Drawing.Size(199, 13)
    Me.ToolTipController1.SetSuperTip(Me.lnkDB2ShortName, Nothing)
    Me.lnkDB2ShortName.TabIndex = 38
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LinkLabel1.Location = New System.Drawing.Point(305, 8)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(147, 16)
    Me.ToolTipController1.SetSuperTip(Me.LinkLabel1, Nothing)
    Me.LinkLabel1.TabIndex = 37
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "Click here to Buy Now"
    '
    'LabelControl2
    '
    Me.LabelControl2.Location = New System.Drawing.Point(336, 38)
    Me.LabelControl2.Name = "LabelControl2"
    Me.LabelControl2.Size = New System.Drawing.Size(102, 14)
    Me.LabelControl2.StyleController = Me.StyleController1
    Me.LabelControl2.TabIndex = 32
    Me.LabelControl2.Text = "Compare Database"
    '
    'txtMasterDB
    '
    Me.txtMasterDB.Location = New System.Drawing.Point(12, 60)
    Me.txtMasterDB.Name = "txtMasterDB"
    Me.txtMasterDB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, Global.vDBCompare.My.Resources.Resources.Search, Nothing)})
    Me.txtMasterDB.Size = New System.Drawing.Size(308, 22)
    Me.txtMasterDB.TabIndex = 33
    '
    'txtCompareDB
    '
    Me.txtCompareDB.Location = New System.Drawing.Point(336, 60)
    Me.txtCompareDB.Name = "txtCompareDB"
    Me.txtCompareDB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, Global.vDBCompare.My.Resources.Resources.Search, Nothing)})
    Me.txtCompareDB.Size = New System.Drawing.Size(314, 22)
    Me.txtCompareDB.TabIndex = 34
    '
    'txtScript
    '
    Me.txtScript.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtScript.Location = New System.Drawing.Point(5, 5)
    Me.txtScript.Name = "txtScript"
    Me.txtScript.Size = New System.Drawing.Size(619, 390)
    Me.txtScript.TabIndex = 35
    '
    'xTabMain
    '
    Me.xTabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.xTabMain.AppearancePage.Header.Options.UseTextOptions = True
    Me.xTabMain.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    Me.xTabMain.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
    Me.xTabMain.Images = Me.ilsTab
    Me.xTabMain.Location = New System.Drawing.Point(12, 129)
    Me.xTabMain.Name = "xTabMain"
    Me.xTabMain.SelectedTabPage = Me.xtpSchema
    Me.xTabMain.Size = New System.Drawing.Size(638, 432)
    Me.xTabMain.TabIndex = 36
    Me.xTabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpSchema, Me.xtpDifferences, Me.xtpScript})
    Me.xTabMain.Text = "XtraTabControl1"
    Me.xTabMain.ToolTipController = Me.ToolTipController1
    '
    'xtpSchema
    '
    Me.xtpSchema.Controls.Add(Me.SplitContainerControl2)
    Me.xtpSchema.ImageIndex = 0
    Me.xtpSchema.Name = "xtpSchema"
    Me.xtpSchema.Padding = New System.Windows.Forms.Padding(5)
    Me.xtpSchema.Size = New System.Drawing.Size(629, 400)
    Me.xtpSchema.Text = "Schema View"
    '
    'xtpDifferences
    '
    Me.xtpDifferences.Controls.Add(Me.SplitContainerControl1)
    Me.xtpDifferences.ImageIndex = 1
    Me.xtpDifferences.Name = "xtpDifferences"
    Me.xtpDifferences.Padding = New System.Windows.Forms.Padding(5)
    Me.xtpDifferences.Size = New System.Drawing.Size(629, 400)
    Me.xtpDifferences.Text = "Differences"
    '
    'xtpScript
    '
    Me.xtpScript.Controls.Add(Me.txtScript)
    Me.xtpScript.Controls.Add(Me.LinkLabel1)
    Me.xtpScript.Controls.Add(Me.LabelControl3)
    Me.xtpScript.ImageIndex = 2
    Me.xtpScript.Name = "xtpScript"
    Me.xtpScript.Padding = New System.Windows.Forms.Padding(5)
    Me.xtpScript.Size = New System.Drawing.Size(629, 400)
    Me.xtpScript.Text = "Script"
    '
    'LabelControl3
    '
    Me.LabelControl3.Location = New System.Drawing.Point(8, 8)
    Me.LabelControl3.Name = "LabelControl3"
    Me.LabelControl3.Size = New System.Drawing.Size(291, 14)
    Me.LabelControl3.StyleController = Me.StyleController1
    Me.LabelControl3.TabIndex = 36
    Me.LabelControl3.Text = "Script Generation is only avaliable on the Pro Version."
    '
    'btnLoadSchema
    '
    Me.btnLoadSchema.Image = Global.vDBCompare.My.Resources.Resources.configprev_24
    Me.btnLoadSchema.Location = New System.Drawing.Point(12, 86)
    Me.btnLoadSchema.Name = "btnLoadSchema"
    Me.btnLoadSchema.Size = New System.Drawing.Size(122, 37)
    Me.btnLoadSchema.TabIndex = 39
    Me.btnLoadSchema.Text = "Load Schema"
    '
    'btnCompare
    '
    Me.btnCompare.Image = Global.vDBCompare.My.Resources.Resources.play_24
    Me.btnCompare.Location = New System.Drawing.Point(140, 86)
    Me.btnCompare.Name = "btnCompare"
    Me.btnCompare.Size = New System.Drawing.Size(116, 37)
    Me.btnCompare.TabIndex = 40
    Me.btnCompare.Text = "Compare"
    '
    'btnSwapDBs
    '
    Me.btnSwapDBs.Location = New System.Drawing.Point(552, 94)
    Me.btnSwapDBs.Name = "btnSwapDBs"
    Me.btnSwapDBs.Size = New System.Drawing.Size(98, 25)
    Me.btnSwapDBs.TabIndex = 41
    Me.btnSwapDBs.Text = "Swap Databases"
    '
    'chkGenScript
    '
    Me.chkGenScript.Location = New System.Drawing.Point(336, 94)
    Me.chkGenScript.Name = "chkGenScript"
    Me.chkGenScript.Properties.Caption = "Generate Script On Compare"
    Me.chkGenScript.Size = New System.Drawing.Size(191, 19)
    Me.chkGenScript.StyleController = Me.StyleController1
    Me.chkGenScript.TabIndex = 42
    Me.chkGenScript.ToolTipController = Me.ToolTipController1
    '
    'DefaultLookAndFeel1
    '
    Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Black"
    '
    'VisitProjectHomeToolStripMenuItem
    '
    Me.VisitProjectHomeToolStripMenuItem.Name = "VisitProjectHomeToolStripMenuItem"
    Me.VisitProjectHomeToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.VisitProjectHomeToolStripMenuItem.Text = "Visit Project Home"
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(662, 573)
    Me.Controls.Add(Me.chkGenScript)
    Me.Controls.Add(Me.btnSwapDBs)
    Me.Controls.Add(Me.btnCompare)
    Me.Controls.Add(Me.btnLoadSchema)
    Me.Controls.Add(Me.lnkDB2ShortName)
    Me.Controls.Add(Me.lnkDB1ShortName)
    Me.Controls.Add(Me.xTabMain)
    Me.Controls.Add(Me.txtCompareDB)
    Me.Controls.Add(Me.txtMasterDB)
    Me.Controls.Add(Me.LabelControl2)
    Me.Controls.Add(Me.LabelControl1)
    Me.Controls.Add(Me.MenuStrip1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.MinimumSize = New System.Drawing.Size(670, 400)
    Me.Name = "frmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.ToolTipController1.SetSuperTip(Me, Nothing)
    Me.Text = "VistaDB Compare"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerControl1.ResumeLayout(False)
    CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerControl2.ResumeLayout(False)
    CType(Me.txtMasterDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtCompareDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtScript.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.xTabMain, System.ComponentModel.ISupportInitialize).EndInit()
    Me.xTabMain.ResumeLayout(False)
    Me.xtpSchema.ResumeLayout(False)
    Me.xtpDifferences.ResumeLayout(False)
    Me.xtpScript.ResumeLayout(False)
    Me.xtpScript.PerformLayout()
    CType(Me.chkGenScript.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tvDB1 As System.Windows.Forms.TreeView
    Friend WithEvents tvDB2 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tvDiff1 As System.Windows.Forms.TreeView
    Friend WithEvents tvDiff2 As System.Windows.Forms.TreeView
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadSchemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DB1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToAccessmdbToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToSqlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptVBNETToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DB2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToAccessmdbToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToSQLToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptVBNETToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertToAccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ilsTab As System.Windows.Forms.ImageList
    Friend WithEvents VistaDBDataBuilderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloneDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents OnlineManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ORMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XPOObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Opf3ObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents PackDatabase1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PackDatabase2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PackDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMasterDB As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtCompareDB As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtScript As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents xTabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpSchema As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpDifferences As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents xtpScript As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lnkDB1ShortName As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDB2ShortName As System.Windows.Forms.LinkLabel
    Friend WithEvents btnLoadSchema As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCompare As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSwapDBs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkGenScript As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SkinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents miSkin2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataBuilder3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSkin9 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents miSkin10 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ReportFaultIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents VisitProjectHomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


End Class
