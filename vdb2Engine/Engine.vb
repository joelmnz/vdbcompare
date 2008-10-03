Module Engine

    Public Function PackDatabase(ByVal dataFile As String) As Boolean

        If dataFile = "" Then
            'DevExpress.XtraEditors.XtraMessageBox.Show("Please enter a Database First", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If IO.File.Exists(dataFile) Then
            Dim db As VistaDB.VistaDBDatabase = Nothing

            Try
                db = New VistaDB.VistaDBDatabase(dataFile, True)
                db.PackDatabase(True)
                db.Dispose()
                db = Nothing
                Return True
            Catch ex As Exception
                If Not db Is Nothing Then
                    db.Dispose()
                    db = Nothing
                End If
                Return False
            End Try

        End If
    End Function


    Public Function ColumnExists(ByVal t As VistaDB.VistaDBTable, ByVal columnName As String) As Boolean
        'created this funciton as t.Contains, t.Columns.Contains, t.ColumnIndex, t.columns(colname) is nothing
        'all return errors if col doesn't exist.

        'If t Is Nothing Then Return False
        If Not t.Opened Then t.Open()

        Dim col As VistaDB.VistaDBColumn

        For Each col In t.Columns
            If col.Name = columnName Then Return True
        Next

        Return False

    End Function



End Module
