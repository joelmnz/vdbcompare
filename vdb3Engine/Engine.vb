Module Engine

    Dim _DDA As VistaDB.DDA.IVistaDBDDA
    'Public ReadOnly DDA As VistaDB.DDA.IVistaDBDDA = VistaDB.DDA.VistaDBEngine.Connections.OpenDDA

    Public Property DDA() As VistaDB.DDA.IVistaDBDDA
        Get
            If _DDA Is Nothing Then
                _DDA = VistaDB.DDA.VistaDBEngine.Connections.OpenDDA
            End If
            Return _DDA
        End Get
        Set(ByVal value As VistaDB.DDA.IVistaDBDDA)
            If value Is Nothing Then
                If _DDA IsNot Nothing Then
                    _DDA.Dispose()
                    _DDA = Nothing
                End If
            Else
                _DDA = value
            End If
        End Set
    End Property


    Public Function PackDatabase(ByVal dataFile As String) As Boolean

        If dataFile = "" Then
            'DevExpress.XtraEditors.XtraMessageBox.Show("Please enter a Database First", "Pack Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If IO.File.Exists(dataFile) Then

            Try

                Engine.DDA.PackDatabase(dataFile, Nothing, True, Nothing)
                'Engine.DDA = Nothing
                Return True
            Catch ex As Exception
                Engine.DDA = Nothing
                Return False
            End Try

        End If
    End Function


    Public Function ColumnExists(ByVal t As VistaDB.DDA.IVistaDBTableSchema, ByVal columnName As String) As Boolean
        'created this function as t.Contains, t.Columns.Contains, t.ColumnIndex, t.columns(colname) is nothing
        'all return errors if col doesn't exist.

        If t Is Nothing Then Return False

        Dim col As VistaDB.DDA.IVistaDBColumnAttributes = t.Item(columnName)

        Return col IsNot Nothing

    End Function



End Module
