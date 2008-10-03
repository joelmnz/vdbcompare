<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.StyleController1 = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.txtXmlFile = New DevExpress.XtraEditors.ButtonEdit
        Me.txtDatabase = New DevExpress.XtraEditors.ButtonEdit
        Me.rgExportType = New DevExpress.XtraEditors.RadioGroup
        Me.lstTables = New DevExpress.XtraEditors.CheckedListBoxControl
        Me.btnSelectAll = New DevExpress.XtraEditors.SimpleButton
        Me.btnSelectNone = New DevExpress.XtraEditors.SimpleButton
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton
        Me.btnToggle = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtXmlFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgExportType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstTables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dlgOpen
        '
        Me.dlgOpen.DefaultExt = "vdb"
        Me.dlgOpen.Filter = "Vista Database (*.vdb)|*.vdb"
        Me.dlgOpen.Title = "Select database"
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "xml"
        Me.dlgSave.Filter = "XML Schema (*.xml)|*.xml|All Files|*.*"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 14)
        Me.LabelControl2.StyleController = Me.StyleController1
        Me.LabelControl2.TabIndex = 32
        Me.LabelControl2.Text = "Export To:"
        '
        'StyleController1
        '
        Me.StyleController1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StyleController1.Appearance.Options.UseFont = True
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 14)
        Me.LabelControl1.StyleController = Me.StyleController1
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "Database:"
        '
        'txtXmlFile
        '
        Me.txtXmlFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtXmlFile.Location = New System.Drawing.Point(77, 40)
        Me.txtXmlFile.Name = "txtXmlFile"
        Me.txtXmlFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.Utils.HorzAlignment.Center, Global.vDBCompare.My.Resources.Resources.Search)})
        Me.txtXmlFile.Size = New System.Drawing.Size(483, 22)
        Me.txtXmlFile.TabIndex = 30
        '
        'txtDatabase
        '
        Me.txtDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabase.Location = New System.Drawing.Point(77, 12)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.Utils.HorzAlignment.Center, Global.vDBCompare.My.Resources.Resources.Search)})
        Me.txtDatabase.Size = New System.Drawing.Size(483, 22)
        Me.txtDatabase.TabIndex = 29
        '
        'rgExportType
        '
        Me.rgExportType.Location = New System.Drawing.Point(85, 78)
        Me.rgExportType.Name = "rgExportType"
        Me.rgExportType.Properties.Columns = 2
        Me.rgExportType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Schema Only"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Schema && Data")})
        Me.rgExportType.Size = New System.Drawing.Size(232, 25)
        Me.rgExportType.TabIndex = 33
        '
        'lstTables
        '
        Me.lstTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTables.CheckOnClick = True
        Me.lstTables.HotTrackItems = True
        Me.lstTables.Location = New System.Drawing.Point(12, 116)
        Me.lstTables.Name = "lstTables"
        Me.lstTables.Size = New System.Drawing.Size(308, 221)
        Me.lstTables.TabIndex = 34
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(326, 149)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(67, 25)
        Me.btnSelectAll.TabIndex = 35
        Me.btnSelectAll.Text = "Select All"
        '
        'btnSelectNone
        '
        Me.btnSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectNone.Location = New System.Drawing.Point(399, 149)
        Me.btnSelectNone.Name = "btnSelectNone"
        Me.btnSelectNone.Size = New System.Drawing.Size(75, 25)
        Me.btnSelectNone.TabIndex = 36
        Me.btnSelectNone.Text = "Select None"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Image = Global.vDBCompare.My.Resources.Resources.exit_24
        Me.btnClose.Location = New System.Drawing.Point(449, 306)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 31)
        Me.btnClose.TabIndex = 37
        Me.btnClose.Text = "Close"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Image = Global.vDBCompare.My.Resources.Resources.play_24
        Me.btnExport.Location = New System.Drawing.Point(326, 306)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(105, 31)
        Me.btnExport.TabIndex = 38
        Me.btnExport.Text = "Export"
        '
        'btnToggle
        '
        Me.btnToggle.Location = New System.Drawing.Point(12, 78)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(67, 25)
        Me.btnToggle.TabIndex = 39
        Me.btnToggle.Text = "<< More"
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Location = New System.Drawing.Point(326, 129)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(184, 14)
        Me.LabelControl3.StyleController = Me.StyleController1
        Me.LabelControl3.TabIndex = 40
        Me.LabelControl3.Text = "Select 1 or more tables to export"
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 349)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btnToggle)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSelectNone)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.lstTables)
        Me.Controls.Add(Me.rgExportType)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtXmlFile)
        Me.Controls.Add(Me.txtDatabase)
        Me.MinimumSize = New System.Drawing.Size(580, 145)
        Me.Name = "frmExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export"
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtXmlFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgExportType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstTables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtXmlFile As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtDatabase As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents rgExportType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lstTables As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents btnSelectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSelectNone As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnToggle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
End Class
