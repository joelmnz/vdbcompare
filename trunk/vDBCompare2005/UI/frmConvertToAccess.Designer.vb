<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvertToAccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConvertToAccess))
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.StyleController1 = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.txtAccessDatabase = New DevExpress.XtraEditors.ButtonEdit
        Me.txtVistaDatabase = New DevExpress.XtraEditors.ButtonEdit
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.rgExportOptions = New DevExpress.XtraEditors.RadioGroup
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.txtTablePrefix = New DevExpress.XtraEditors.TextEdit
        Me.lblProgressTitle = New DevExpress.XtraEditors.LabelControl
        Me.pbProgress = New DevExpress.XtraEditors.ProgressBarControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.btnConvertToAccess = New DevExpress.XtraEditors.SimpleButton
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccessDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVistaDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.rgExportOptions.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTablePrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.vDBCompare.My.Resources.Resources.Grid_Footers
        Me.PictureBox1.Location = New System.Drawing.Point(5, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 14)
        Me.LabelControl2.StyleController = Me.StyleController1
        Me.LabelControl2.TabIndex = 28
        Me.LabelControl2.Text = "Access DB:"
        '
        'StyleController1
        '
        Me.StyleController1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StyleController1.Appearance.Options.UseFont = True
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 14)
        Me.LabelControl1.StyleController = Me.StyleController1
        Me.LabelControl1.TabIndex = 27
        Me.LabelControl1.Text = "Vista DB:"
        '
        'txtAccessDatabase
        '
        Me.txtAccessDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccessDatabase.Location = New System.Drawing.Point(78, 40)
        Me.txtAccessDatabase.Name = "txtAccessDatabase"
        Me.txtAccessDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.Utils.HorzAlignment.Center, Global.vDBCompare.My.Resources.Resources.Search)})
        Me.txtAccessDatabase.Size = New System.Drawing.Size(412, 22)
        Me.txtAccessDatabase.TabIndex = 26
        '
        'txtVistaDatabase
        '
        Me.txtVistaDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVistaDatabase.Location = New System.Drawing.Point(78, 12)
        Me.txtVistaDatabase.Name = "txtVistaDatabase"
        Me.txtVistaDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.Utils.HorzAlignment.Center, Global.vDBCompare.My.Resources.Resources.Search)})
        Me.txtVistaDatabase.Size = New System.Drawing.Size(412, 22)
        Me.txtVistaDatabase.TabIndex = 25
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.rgExportOptions)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.txtTablePrefix)
        Me.GroupControl1.Controls.Add(Me.PictureBox1)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 82)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(478, 78)
        Me.GroupControl1.TabIndex = 29
        Me.GroupControl1.Text = "Options"
        '
        'rgExportOptions
        '
        Me.rgExportOptions.Location = New System.Drawing.Point(195, 34)
        Me.rgExportOptions.Name = "rgExportOptions"
        Me.rgExportOptions.Properties.Columns = 2
        Me.rgExportOptions.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Schema Only"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Schema && Data")})
        Me.rgExportOptions.Size = New System.Drawing.Size(225, 26)
        Me.rgExportOptions.TabIndex = 31
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(27, 36)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(72, 14)
        Me.LabelControl3.StyleController = Me.StyleController1
        Me.LabelControl3.TabIndex = 30
        Me.LabelControl3.Text = "Table Prefix :"
        '
        'txtTablePrefix
        '
        Me.txtTablePrefix.Location = New System.Drawing.Point(105, 34)
        Me.txtTablePrefix.Name = "txtTablePrefix"
        Me.txtTablePrefix.Size = New System.Drawing.Size(63, 20)
        Me.txtTablePrefix.TabIndex = 0
        '
        'lblProgressTitle
        '
        Me.lblProgressTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgressTitle.Appearance.Options.UseTextOptions = True
        Me.lblProgressTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblProgressTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblProgressTitle.Location = New System.Drawing.Point(12, 205)
        Me.lblProgressTitle.Name = "lblProgressTitle"
        Me.lblProgressTitle.Size = New System.Drawing.Size(478, 22)
        Me.lblProgressTitle.StyleController = Me.StyleController1
        Me.lblProgressTitle.TabIndex = 31
        Me.lblProgressTitle.Text = "Ready..."
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(12, 166)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(478, 33)
        Me.pbProgress.TabIndex = 32
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelControl4.Location = New System.Drawing.Point(81, 269)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(341, 14)
        Me.LabelControl4.StyleController = Me.StyleController1
        Me.LabelControl4.TabIndex = 33
        Me.LabelControl4.Text = "WARNING: If the access database exists it will be overwritten."
        '
        'btnConvertToAccess
        '
        Me.btnConvertToAccess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConvertToAccess.Image = Global.vDBCompare.My.Resources.Resources.play_24
        Me.btnConvertToAccess.Location = New System.Drawing.Point(6, 230)
        Me.btnConvertToAccess.Name = "btnConvertToAccess"
        Me.btnConvertToAccess.Size = New System.Drawing.Size(141, 33)
        Me.btnConvertToAccess.TabIndex = 34
        Me.btnConvertToAccess.Text = "Convert to Access"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Image = Global.vDBCompare.My.Resources.Resources.exit_24
        Me.btnClose.Location = New System.Drawing.Point(349, 232)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(141, 31)
        Me.btnClose.TabIndex = 35
        Me.btnClose.Text = "Close"
        '
        'frmConvertToAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 295)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnConvertToAccess)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.lblProgressTitle)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtAccessDatabase)
        Me.Controls.Add(Me.txtVistaDatabase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConvertToAccess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert To Access"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccessDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVistaDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.rgExportOptions.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTablePrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAccessDatabase As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtVistaDatabase As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rgExportOptions As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTablePrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblProgressTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pbProgress As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnConvertToAccess As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton

End Class
