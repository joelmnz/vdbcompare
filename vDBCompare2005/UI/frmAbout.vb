Public Class AboutForm
    Inherits DevExpress.XtraEditors.XtraForm
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
    Private Const STR_Httpwwwcomponentfactorycom As String = "http://www.componentfactory.com/"

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblVDBProviderVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lblLicenseHolder As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lblBuildDate As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lnkMP As System.Windows.Forms.LinkLabel
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
    Me.lblVDBProviderVersion = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.btnOK = New DevExpress.XtraEditors.SimpleButton
    Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
    Me.StyleController1 = New DevExpress.XtraEditors.StyleController(Me.components)
    Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
    Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
    Me.lblLicenseHolder = New DevExpress.XtraEditors.LabelControl
    Me.lblVersion = New DevExpress.XtraEditors.LabelControl
    Me.lblBuildDate = New DevExpress.XtraEditors.LabelControl
    Me.lnkMP = New System.Windows.Forms.LinkLabel
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblVDBProviderVersion
    '
    Me.lblVDBProviderVersion.BackColor = System.Drawing.Color.Transparent
    Me.lblVDBProviderVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblVDBProviderVersion.Location = New System.Drawing.Point(195, 186)
    Me.lblVDBProviderVersion.Name = "lblVDBProviderVersion"
    Me.lblVDBProviderVersion.Size = New System.Drawing.Size(160, 43)
    Me.lblVDBProviderVersion.TabIndex = 6
    Me.lblVDBProviderVersion.Text = "=VistaDB.Provider.Version"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(489, 109)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 7
    Me.PictureBox1.TabStop = False
    '
    'PictureBox2
    '
    Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
    Me.PictureBox2.Image = Global.vDBCompare.My.Resources.Resources.VistaDB120x60w
    Me.PictureBox2.Location = New System.Drawing.Point(381, 181)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(120, 60)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox2.TabIndex = 12
    Me.PictureBox2.TabStop = False
    '
    'btnOK
    '
    Me.btnOK.Location = New System.Drawing.Point(192, 261)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(123, 23)
    Me.btnOK.TabIndex = 25
    Me.btnOK.Text = "OK"
    '
    'LabelControl1
    '
    Me.LabelControl1.Location = New System.Drawing.Point(12, 138)
    Me.LabelControl1.Name = "LabelControl1"
    Me.LabelControl1.Size = New System.Drawing.Size(109, 14)
    Me.LabelControl1.StyleController = Me.StyleController1
    Me.LabelControl1.TabIndex = 26
    Me.LabelControl1.Text = "Program Version:"
    '
    'StyleController1
    '
    Me.StyleController1.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.StyleController1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.StyleController1.Appearance.Options.UseFont = True
    Me.StyleController1.Appearance.Options.UseForeColor = True
    '
    'LabelControl2
    '
    Me.LabelControl2.Location = New System.Drawing.Point(12, 158)
    Me.LabelControl2.Name = "LabelControl2"
    Me.LabelControl2.Size = New System.Drawing.Size(69, 14)
    Me.LabelControl2.StyleController = Me.StyleController1
    Me.LabelControl2.TabIndex = 27
    Me.LabelControl2.Text = "Build Date:"
    '
    'LabelControl3
    '
    Me.LabelControl3.Location = New System.Drawing.Point(12, 186)
    Me.LabelControl3.Name = "LabelControl3"
    Me.LabelControl3.Size = New System.Drawing.Size(172, 14)
    Me.LabelControl3.StyleController = Me.StyleController1
    Me.LabelControl3.TabIndex = 28
    Me.LabelControl3.Text = "VistaDB2 Provider Version :"
    '
    'lblLicenseHolder
    '
    Me.lblLicenseHolder.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblLicenseHolder.Appearance.Options.UseFont = True
    Me.lblLicenseHolder.Location = New System.Drawing.Point(198, 222)
    Me.lblLicenseHolder.Name = "lblLicenseHolder"
    Me.lblLicenseHolder.Size = New System.Drawing.Size(102, 19)
    Me.lblLicenseHolder.StyleController = Me.StyleController1
    Me.lblLicenseHolder.TabIndex = 30
    Me.lblLicenseHolder.Text = "Open Source"
    '
    'lblVersion
    '
    Me.lblVersion.Location = New System.Drawing.Point(192, 138)
    Me.lblVersion.Name = "lblVersion"
    Me.lblVersion.Size = New System.Drawing.Size(57, 14)
    Me.lblVersion.StyleController = Me.StyleController1
    Me.lblVersion.TabIndex = 31
    Me.lblVersion.Text = "Version()"
    '
    'lblBuildDate
    '
    Me.lblBuildDate.Location = New System.Drawing.Point(192, 158)
    Me.lblBuildDate.Name = "lblBuildDate"
    Me.lblBuildDate.Size = New System.Drawing.Size(76, 14)
    Me.lblBuildDate.StyleController = Me.StyleController1
    Me.lblBuildDate.TabIndex = 32
    Me.lblBuildDate.Text = "Build Date..."
    '
    'lnkMP
    '
    Me.lnkMP.AutoSize = True
    Me.lnkMP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lnkMP.Location = New System.Drawing.Point(9, 268)
    Me.lnkMP.Name = "lnkMP"
    Me.lnkMP.Size = New System.Drawing.Size(125, 16)
    Me.lnkMP.TabIndex = 33
    Me.lnkMP.TabStop = True
    Me.lnkMP.Text = "Meikle Programming"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LinkLabel1.Location = New System.Drawing.Point(423, 268)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(78, 16)
    Me.LinkLabel1.TabIndex = 34
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "VistaDB.NET"
    '
    'AboutForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
    Me.ClientSize = New System.Drawing.Size(516, 300)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.lnkMP)
    Me.Controls.Add(Me.lblBuildDate)
    Me.Controls.Add(Me.lblVersion)
    Me.Controls.Add(Me.lblLicenseHolder)
    Me.Controls.Add(Me.LabelControl3)
    Me.Controls.Add(Me.LabelControl2)
    Me.Controls.Add(Me.LabelControl1)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.lblVDBProviderVersion)
    Me.Controls.Add(Me.PictureBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AboutForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "About vDBCompare"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

  Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.lblVersion.Text = Application.ProductVersion
    Me.lblBuildDate.Text = My.Resources.BuildDate
    Me.lblVDBProviderVersion.Text = My.Resources.VistaDBProviderVersion


    'Dim db As New VistaDB.VistaDBDatabase

    'Try
    'Note: refactoring on db.Version doesn't work, 
    'its not a static method!
    Me.lblVDBProviderVersion.Text = ".Net Provider : " & _
    My.Resources.VistaDBProviderVersion '& _
    'Environment.NewLine & VistaDB.VistaDBDatabase.Version

    '        Catch ex As Exception
    'Finally
    '    If db IsNot Nothing Then
    '        db.Dispose()
    '        db = Nothing
    '    End If
    'End Try

  End Sub




  Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
    G.StartProcess(My.Resources.VistaDBWebiste)
  End Sub



  'Private Sub KryptonLinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '    G.StartProcess(STR_Httpwwwcomponentfactorycom)
  'End Sub


  Private Sub lnkMP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMP.LinkClicked
    G.StartProcess("http://" & My.Resources.WebSite)
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    G.StartProcess(My.Resources.VistaDBWebiste)
  End Sub

End Class
