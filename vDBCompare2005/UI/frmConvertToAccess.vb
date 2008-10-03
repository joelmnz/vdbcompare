Public Class frmConvertToAccess

    Private Sub btnConvertToAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertToAccess.Click
        ConvertToAccess()
    End Sub

    Public Sub ConvertToAccess()

        'If Not G.FullLicense Then
        '    'DevExpress.XtraEditors.XtraMessageBox.Show("This feature is not avaliable in the Free version", "Script to VB.NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        'validate
        If Me.txtVistaDatabase.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Please set the Source database", "Convert To Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtVistaDatabase.Focus()
            Return
        End If

        If Me.txtAccessDatabase.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Please set the Target Access Database", "Convert To Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAccessDatabase.Focus()
            Return
        End If

        If IO.File.Exists(Me.txtAccessDatabase.Text) Then
            'must delete it
            Try
                IO.File.Delete(Me.txtAccessDatabase.Text)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error Overwriting existing DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If G.IsVdb2File(Me.txtVistaDatabase.Text) Then
            Me.ConvertToAccessFromv2()
        ElseIf G.IsVdb3File(Me.txtVistaDatabase.Text) Then
            Me.ConvertToAccessFromv3()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to determine the database version, please check file extension", "Check File extension", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
        End If


    End Sub

    Private Function ConvertToAccessFromv2() As Boolean
        Dim dbGen As vdb2.AccessDBGen

        dbGen = New vdb2.AccessDBGen

        'events
        AddHandler dbGen.ProgressChanged, AddressOf OnProgressChanged


        btnConvertToAccess.Enabled = False

        Try
            If dbGen.ConvertToAccess(Me.txtVistaDatabase.Text, Me.txtAccessDatabase.Text, (Me.rgExportOptions.SelectedIndex = 0), Me.txtTablePrefix.Text) Then
                'finished
                Me.pbProgress.Position = Me.pbProgress.Properties.Maximum
                If DevExpress.XtraEditors.XtraMessageBox.Show("To Access Completed, Open the database now?", "To Access Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    G.StartProcess(Me.txtAccessDatabase.Text)
                End If
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show(dbGen.ErrorMessage, "To Access Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error occurred during conversion", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

        'Tidy Up

        RemoveHandler dbGen.ProgressChanged, AddressOf OnProgressChanged

        btnConvertToAccess.Enabled = True
        Me.pbProgress.Position = 0
        Me.lblProgressTitle.Text = ""

        dbGen = Nothing
    End Function

    Private Function ConvertToAccessFromv3() As Boolean
        Dim dbGen As vdb3.AccessDBGen

        dbGen = New vdb3.AccessDBGen

        'events
        AddHandler dbGen.ProgressChanged, AddressOf OnProgressChanged


        btnConvertToAccess.Enabled = False

        'Try
        If dbGen.ConvertToAccess(Me.txtVistaDatabase.Text, Me.txtAccessDatabase.Text, (Me.rgExportOptions.SelectedIndex = 0), Me.txtTablePrefix.Text) Then
            'finished
            Me.pbProgress.Position = Me.pbProgress.Properties.Maximum
            If DevExpress.XtraEditors.XtraMessageBox.Show("To Access Completed, Open the database now?", "To Access Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                G.StartProcess(Me.txtAccessDatabase.Text)
            End If
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show(dbGen.ErrorMessage, "To Access Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'Catch ex As Exception
        '    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error occurred during conversion", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        'End Try

        'Tidy Up

        RemoveHandler dbGen.ProgressChanged, AddressOf OnProgressChanged

        btnConvertToAccess.Enabled = True
        Me.pbProgress.Position = 0
        Me.lblProgressTitle.Text = ""

        dbGen = Nothing
    End Function

    'Events
    Private Sub OnProgressChanged(ByVal iPercent As Integer, ByVal sTitle As String)

        If iPercent >= 0 Then
            Me.pbProgress.Position = iPercent
        End If

        Me.lblProgressTitle.Text = sTitle

        Application.DoEvents()

    End Sub




    Private Sub btnAccessDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnAccessDB.Click
        With Me.dlgSave
            .Title = "Export To"
            .Filter = "Access (*.mdb)|*.mdb|All Files|*.*"
            .DefaultExt = "mdb"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtAccessDatabase.Text = .FileName
            End If
        End With
    End Sub

    Private Sub frmConvertToAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If G.License.Type = LicenseHelper.LicenseType.Free Then
        '    btnConvertToAccess.Enabled = False
        'Else
        '    btnConvertToAccess.Enabled = True
        'End If

    End Sub

    Private Sub txtVistaDatabase_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtVistaDatabase.ButtonClick
        With Me.dlgOpen
            .Title = "Data Source"
            .Filter = "VistaDB (*.vdb;*.vdb3)|*.vdb;*.vdb3|All Files|*.*"
            .DefaultExt = "vdb"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtVistaDatabase.Text = .FileName

                'now auto set the access database
                If txtAccessDatabase.Text = "" Then
                    txtAccessDatabase.Text = IO.Path.ChangeExtension(.FileName, ".mdb")
                End If
            End If
        End With
    End Sub


    Private Sub txtAccessDatabase_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtAccessDatabase.ButtonClick
        With Me.dlgSave
            .Title = "Export To"
            .Filter = "Access Database (*.mdb)|*.mdb|All Files|*.*"
            If Me.txtAccessDatabase.Text <> "" Then
                .FileName = Me.txtAccessDatabase.Text
            End If
            .DefaultExt = "mdb"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtAccessDatabase.Text = .FileName
            End If
        End With
    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
