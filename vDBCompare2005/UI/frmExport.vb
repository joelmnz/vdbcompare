Public Class frmExport
    Private Const STR_Export As String = "Export"
    Private Const STR_More As String = "<< More"
    Private Const STR_Less As String = "Less >>"
    Private Const EXPANDED_HEIGHT As Integer = 376

    Dim _loadedDatabase As String


    Public Property VistaDatabase() As String
        Get
            Return Me.txtDatabase.Text
        End Get
        Set(ByVal value As String)
            Me.txtDatabase.Text = value
        End Set
    End Property

    Public Property OutputXmlFile() As String
        Get
            Return Me.txtXmlFile.Text
        End Get
        Set(ByVal value As String)
            Me.txtXmlFile.Text = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function RunExport() As Boolean '(ByVal dbFile As String, ByVal exportTarget As String) As Boolean
        'validate first!
        '==============================================

        Dim dbFile As String = Me.txtDatabase.Text
        Dim exportTarget As String = Me.txtXmlFile.Text
        Dim schemaOnly As Boolean = (Me.rgExportType.SelectedIndex = 0) 'Me.chkSchemaOnly.Checked

        If dbFile = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Please enter a Database", STR_Export, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If exportTarget = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Please enter an output file", STR_Export, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If


        If Not IO.File.Exists(dbFile) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("The Database """ & IO.Path.GetFileName(dbFile) & """ does not exist!", "Invalid Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If IO.File.Exists(exportTarget) Then
            'overwrite it
            Try
                IO.File.Delete(exportTarget)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to overwrite the export target file:" & Environment.NewLine & ex.Message, STR_Export, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End Try
        End If


        'ToDo: redo export features to come from db engine of version x

        'Validation Passed
        '==============================================

        Dim blnResult As Boolean = False

        'Dim db As VistaDB.VistaDBDatabase = Nothing

        Dim arTables As ArrayList = Nothing

        If Me.lstTables.Visible Then
            For Each s As String In Me.lstTables.CheckedItems
                arTables.Add(s)
            Next
        End If

        If G.IsVdb2File(dbFile) Then
            blnResult = vdb2.vdbScriptEngine.ExportData(dbFile, exportTarget, schemaOnly, arTables)
        ElseIf G.IsVdb3File(dbFile) Then
            blnResult = vdb3.vdbScriptEngine.ExportData(dbFile, exportTarget, schemaOnly, arTables)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to determine db version, please check file extension", "Check file extension", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            blnResult = False
        End If

        Return blnResult

    End Function


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Me.RunExport Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Export Completed Successfully", STR_Export, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.ExportSchemaOnly = (Me.rgExportType.SelectedIndex = 0)
        My.Settings.Save()
    End Sub

    Private Sub frmExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Size = Me.MinimumSize    'auto load as compact mode

        'Me.chkSchemaOnly.Checked = My.Settings.ExportSchemaOnly
        If My.Settings.ExportSchemaOnly Then
            Me.rgExportType.SelectedIndex = 0
        Else
            Me.rgExportType.SelectedIndex = 1
        End If
    End Sub

    Private Sub ToggleMoreState()

        If btnToggle.Text = STR_More Then
            'expand
            btnToggle.Text = STR_Less
            Me.Height = EXPANDED_HEIGHT
            Me.lstTables.Visible = True

            'unable to process in one step, suspect Krypton needs time to redraw stuff.
            'this seems to be the only way
            Me.Hide()
            Me.Show()

            Me.PrepTableList()

        Else
            'collapse
            btnToggle.Text = STR_More
            Me.lstTables.Visible = False
            Me.Height = Me.MinimumSize.Height
        End If

    End Sub

    Private Sub PrepTableList()
        If Me.lstTables.Visible = False Then Return

        If _loadedDatabase = Me.txtDatabase.Text Then Return 'don't load a 2nd time, may overwrite the selected items
        _loadedDatabase = Me.txtDatabase.Text

        Me.lstTables.Items.Clear()

        If Me.txtDatabase.Text.Trim = "" Then Return
        If Not IO.File.Exists(Me.txtDatabase.Text) Then
            'DevExpress.XtraEditors.XtraMessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'bad database
            Return
        End If


        Dim arTables As ArrayList = Nothing

        If G.IsVdb2File(Me.txtDatabase.Text) Then
            arTables = vdb2.vdbScriptEngine.ListTables(Me.txtDatabase.Text)
        ElseIf G.IsVdb3File(Me.txtDatabase.Text) Then
            arTables = vdb3.vdbScriptEngine.ListTables(Me.txtDatabase.Text)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to find db version ,please check file extension", "Check File extension", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Return
        End If

        Me.lstTables.SuspendLayout()
        For Each table As String In arTables
            Me.lstTables.Items.Add(table, True)
        Next
        Me.lstTables.ResumeLayout()

    End Sub

    Private Sub txtDatabase_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDatabase.Validated
        Me.PrepTableList()
    End Sub


    Private Sub SetAllCheckState(ByVal checkState As Boolean)
        For i As Integer = 0 To Me.lstTables.Items.Count - 1
            Me.lstTables.SetItemChecked(i, checkState)
        Next
    End Sub


    Private Sub txtDatabase_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDatabase.ButtonClick
        If Me.dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtDatabase.Text = Me.dlgOpen.FileName
            Me.PrepTableList()
        End If
    End Sub

    Private Sub txtXmlFile_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtXmlFile.ButtonClick
        If txtDatabase.Text <> "" Then
            Me.dlgSave.FileName = IO.Path.GetFileNameWithoutExtension(txtDatabase.Text) & "_Schema.xml"
        End If
        If Me.dlgSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtXmlFile.Text = Me.dlgSave.FileName
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Me.SetAllCheckState(True)
    End Sub

    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
        Me.SetAllCheckState(False)
    End Sub

    Private Sub btnToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggle.Click
        Me.ToggleMoreState()
    End Sub

End Class