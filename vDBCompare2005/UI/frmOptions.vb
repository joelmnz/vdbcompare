Public Class frmOptions

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.SaveOptions Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Function ValidateOptions() As Boolean

        'script lang type
        Select Case Me.cboScriptLang.SelectedIndex
            Case 3 'VSql
                DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, Support for V-Sql scripting is not yet supported.", "Language Type", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                Return False
            Case 4 'Delphi ?
                DevExpress.XtraEditors.XtraMessageBox.Show("Sorry, Support for Delphi scripting is not yet supported.", "Language Type", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                Return False
        End Select

        Return True

    End Function

    Private Function SaveOptions() As Boolean
        If Me.ValidateOptions = False Then Return False

        'save
        My.Settings.ScriptLang = Me.cboScriptLang.SelectedIndex
        My.Settings.CodeGen_ProcessIndexes = Me.chkProcessIndexes.Checked

        My.Settings.Save()

        Return True

    End Function

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadOptions()
    End Sub

    Private Sub LoadOptions()

        Me.cboScriptLang.SelectedIndex = My.Settings.ScriptLang
        Me.chkProcessIndexes.Checked = My.Settings.CodeGen_ProcessIndexes

    End Sub

End Class