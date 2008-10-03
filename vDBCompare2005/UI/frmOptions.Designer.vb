<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.cboScriptLang = New DevExpress.XtraEditors.ComboBoxEdit
    Me.btnOK = New DevExpress.XtraEditors.SimpleButton
    Me.btnCancel = New DevExpress.XtraEditors.SimpleButton
    Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
    Me.chkProcessIndexes = New DevExpress.XtraEditors.CheckEdit
    CType(Me.cboScriptLang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.chkProcessIndexes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(23, 34)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(102, 15)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Output Language"
    '
    'cboScriptLang
    '
    Me.cboScriptLang.Location = New System.Drawing.Point(131, 34)
    Me.cboScriptLang.Name = "cboScriptLang"
    Me.cboScriptLang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
    Me.cboScriptLang.Properties.Items.AddRange(New Object() {"VB.NET", "Text", "C#", "VSql", "Delphi"})
    Me.cboScriptLang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    Me.cboScriptLang.Size = New System.Drawing.Size(115, 20)
    Me.cboScriptLang.TabIndex = 5
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.Location = New System.Drawing.Point(131, 107)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 6
    Me.btnOK.Text = "OK"
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.Location = New System.Drawing.Point(212, 107)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 7
    Me.btnCancel.Text = "Cancel"
    '
    'LabelControl1
    '
    Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelControl1.Appearance.Options.UseFont = True
    Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
    Me.LabelControl1.LineVisible = True
    Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
    Me.LabelControl1.Name = "LabelControl1"
    Me.LabelControl1.Size = New System.Drawing.Size(270, 19)
    Me.LabelControl1.TabIndex = 8
    Me.LabelControl1.Text = "Code Generation"
    '
    'chkProcessIndexes
    '
    Me.chkProcessIndexes.Location = New System.Drawing.Point(26, 71)
    Me.chkProcessIndexes.Name = "chkProcessIndexes"
    Me.chkProcessIndexes.Properties.Caption = "Process Indexes"
    Me.chkProcessIndexes.Size = New System.Drawing.Size(123, 18)
    Me.chkProcessIndexes.TabIndex = 9
    '
    'frmOptions
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(299, 142)
    Me.Controls.Add(Me.chkProcessIndexes)
    Me.Controls.Add(Me.LabelControl1)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.cboScriptLang)
    Me.Controls.Add(Me.Label1)
    Me.Name = "frmOptions"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Options"
    CType(Me.cboScriptLang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.chkProcessIndexes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboScriptLang As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkProcessIndexes As DevExpress.XtraEditors.CheckEdit
End Class
