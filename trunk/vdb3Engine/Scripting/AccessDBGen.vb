Imports VistaDB
Public Class AccessDBGen
    'PURPOSE:
    '1. TO generate an access database from a vistaDB database
    '2. options of structure only or Structure & Data

    Dim mErrorMessage As String

    'access const
    Const dbLangGeneral As String = ";LANGID=0x0409;CP=1252;COUNTRY=0"

    Public Event ProgressChanged(ByVal iPercent As Integer, ByVal sTitle As String)
    'Public Event OnStartConversion()
    Public Event OnError(ByVal sErrorMessage As String)
    Public Event OnComplete(ByVal sAccessFileName As String)


    Public Sub New()

    End Sub

#Region "  "

    Public Shared Function BuildAccessConnectionString(ByVal dbFile As String) As String
        'Provider=Microsoft.Jet.OLEDB.4.0;Password=lumber1;User ID=lumberflex;Data Source=C:\Clients\Lumberflex\TradSend\SampleTradData.mdb;Persist Security Info=True;Jet OLEDB:System database=C:\Clients\Lumberflex\TradSend\STEVE.MDW
        'Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile & ";Persist Security Info=True"
        Return BuildAccessConnectionString(dbFile, "", "", "", "")
    End Function

    Public Shared Function BuildAccessConnectionString(ByVal dbFile As String, ByVal user As String, ByVal pwd As String, ByVal workGroupFile As String) As String
        'Return "Provider=Microsoft.Jet.OLEDB.4.0;Password=" & pwd & ";User ID=" & user & ";Data Source=" & dbFile & ";Persist Security Info=True;Jet OLEDB:System database=" & workGroupFile
        Return BuildAccessConnectionString(dbFile, user, pwd, workGroupFile, "")
    End Function

    Public Shared Function BuildAccessConnectionString(ByVal dbFile As String, ByVal user As String, ByVal pwd As String, ByVal workGroupFile As String, ByVal databasePassword As String) As String
        'GOING HARD & DOING THIS PROPERLY
        Dim sb As New System.Text.StringBuilder

        sb.Append("Provider=Microsoft.Jet.OLEDB.4.0")

        If pwd <> "" Then
            sb.Append(";Password=")
            sb.Append(pwd)
        End If

        If user <> "" Then
            sb.Append(";User ID=")
            sb.Append(user)
        End If

        'DATA SOURCE IS REQUIRED!!!
        sb.Append(";Data Source=")
        sb.Append(dbFile)
        sb.Append(";Persist Security Info=True")

        If workGroupFile <> "" Then
            sb.Append(";Jet OLEDB:System database=")
            sb.Append(workGroupFile)
        End If

        If databasePassword <> "" Then
            sb.Append(";Jet OLEDB:Database Password=")
            sb.Append(databasePassword)
        End If

        Return sb.ToString

    End Function




#End Region

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
    End Property

    Public Function CreateAccessDatabase(ByVal accessDatabase As String) As Boolean
        mErrorMessage = ""

        'Dim cat As ADOX.Catalog

        'cat = New ADOX.Catalog

        'Try
        '    cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & accessDatabase)
        '    'cat.Create(BuildAccessConnectionString(accessDatabase))
        '    Return True
        'Catch ex As Exception
        '    mErrorMessage = ex.Message
        '    Return False
        'Finally
        '    cat = Nothing
        'End Try

        Dim dbe As DAO.DBEngine

        dbe = New DAO.DBEngine

        ';LANGID=0x0409;CP=1252;COUNTRY=0

        Try
            dbe.CreateDatabase(accessDatabase, dbLangGeneral)

        Catch ex As Exception
            mErrorMessage = ex.Message
            Return False
        End Try

        dbe = Nothing

        Return True

    End Function

    Public Function ConvertToAccess(ByVal vistaDatabase As String, ByVal accessDatabase As String) As Boolean
        Return ConvertToAccess(vistaDatabase, accessDatabase, True, "")
    End Function


	Public Function ConvertToAccess(ByVal vistaDatabase As String, ByVal accessDatabase As String, ByVal schemaOnly As Boolean) As Boolean
		Return ConvertToAccess(vistaDatabase, accessDatabase, schemaOnly, "")
	End Function

    'Public Function ConvertToAccessADOX(ByVal vistaDatabase As String, ByVal accessDatabase As String, ByVal schemaOnly As Boolean, ByVal tablePrefix As String) As Boolean

    '    mErrorMessage = ""

    '    If tablePrefix Is Nothing Then tablePrefix = ""

    '    Dim cnnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & accessDatabase 'BuildAccessConnectionString(accessDatabase)
    '    Dim tables() As String
    '    Dim tableName, fieldName, tableSuffix As String
    '    Dim i As Integer

    '    Dim db As VistaDB.VistaDBDatabase
    '    Dim t As VistaDB.VistaDBTable

    '    Dim cat As ADOX.Catalog
    '    Dim cnn As ADODB.Connection
    '    Dim ADOXtable As ADOX.Table
    '    Dim ADOXcolumn As ADOX.Column
    '    Dim rs As ADODB.Recordset

    '    'Dim dbe As DAO.DBEngine
    '    'Dim dbA As DAO.Database


    '    cat = New ADOX.Catalog
    '    'dbe = New DAO.DBEngine

    '    'TEST ACCESS DATABASE
    '    '=======================================================
    '    If IO.File.Exists(accessDatabase) Then
    '        '
    '        ''it must already exist
    '        'If Not IO.File.Exists(accessDatabase) Then
    '        '    mErrorMessage = "Access database '" & accessDatabase & "' not found!"
    '        '    Return False
    '        'End If

    '        'do we need to check for existing tables??, if they exists will create error
    '        'dbA = dbe.OpenDatabase(accessDatabase)
    '    Else
    '        'create it
    '        Try
    '            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & accessDatabase)
    '            'cat.Create(cnnString)
    '            'dbA = dbe.CreateDatabase(accessDatabase, AccessDBGen.dbLangGeneral)

    '        Catch ex As Exception
    '            mErrorMessage = ex.Message
    '            Return False
    '        End Try

    '    End If

    '    'TEST VISTA DATABASE
    '    '=======================================================
    '    If Not IO.File.Exists(vistaDatabase) Then
    '        mErrorMessage = "Vista Database '" & vistaDatabase & "' not found!"
    '        Return False
    '    End If

    '    db = New VistaDB.VistaDBDatabase(vistaDatabase)

    '    If Not db.Connect() Then
    '        db.Dispose()
    '        db = Nothing
    '        'cat = Nothing
    '        mErrorMessage = "Unable to connect to vista database"
    '        Return False
    '    End If

    '    'ActiveConnection must be of type "ADODB.Connection"
    '    'cat.ActiveConnection = cnnString
    '    'cat.ActiveConnection = BuildAccessConnectionString(accessDatabase)

    '    Try
    '        cnn = New ADODB.Connection
    '        cnn.ConnectionString = BuildAccessConnectionString(accessDatabase)
    '        cnn.Open()
    '        cat.ActiveConnection = cnn
    '    Catch ex As Exception
    '        mErrorMessage = ex.Message
    '        'tidy up b4 exit
    '        db.Dispose()
    '        db = Nothing
    '        cat = Nothing
    '        cnn = Nothing
    '        Return False
    '    End Try

    '    db.EnumTables(tables)

    '    If Not tables Is Nothing Then
    '        For Each tableName In tables
    '            'get schema
    '            t = New VistaDB.VistaDBTable(db, tableName)
    '            t.Open()

    '            'write to access database.
    '            ADOXtable = New ADOX.Table
    '            ADOXtable.Name = tablePrefix & tableName

    '            For i = 1 To t.Columns.Count()

    '                fieldName = t.ColumnName(i)

    '                Select Case t.ColumnType(fieldName)
    '                    Case VistaDB.VistaDBType.Blob

    '                    Case VistaDB.VistaDBType.Boolean
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adBoolean)

    '                    Case VistaDB.VistaDBType.Character
    '                        'ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adChar, t.ColumnWidth(fieldName))
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adVarWChar, t.ColumnWidth(fieldName))

    '                        'With ADOXtable

    '                        '    Debug.WriteLine("Properties: " & .Properties.Count.ToString)

    '                        '    For Each p As ADOX.Property In .Properties
    '                        '        Debug.WriteLine(p.Name & " = " & CType(p.Value, String))
    '                        '    Next



    '                        'End With

    '                    Case VistaDB.VistaDBType.Currency
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adCurrency)
    '                    Case VistaDB.VistaDBType.Date
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adDate)
    '                    Case VistaDB.VistaDBType.DateTime
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adDate)
    '                    Case VistaDB.VistaDBType.Double
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adDouble)
    '                    Case VistaDB.VistaDBType.Guid
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adGUID)
    '                    Case VistaDB.VistaDBType.Int32
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adInteger)
    '                    Case VistaDB.VistaDBType.Int64
    '                        'Note: access doesn't support Int64 as a LonInt in access is an Int in vb.net
    '                        'ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adBigInt)
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adInteger)
    '                    Case VistaDB.VistaDBType.Memo
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adLongVarWChar)
    '                    Case VistaDB.VistaDBType.Picture
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adLongVarBinary)
    '                    Case VistaDB.VistaDBType.Varchar
    '                        ADOXtable.Columns.Append(fieldName, ADOX.DataTypeEnum.adVarWChar, t.ColumnWidth(fieldName))
    '                End Select


    '            Next 'Field

    '            'Now process the indexes/PK


    '            'append table to access database.

    '            'will cause error if table exits
    '            cat.Tables.Append(ADOXtable)


    '            'Now we append the data :DDD
    '            If Not schemaOnly Then

    '                rs = New ADODB.Recordset

    '                rs.Open("SELECT * FROM [" & tablePrefix & tableName & "]", cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

    '                t.First()

    '                Do Until t.EndOfSet

    '                    rs.AddNew()

    '                    For i = 1 To t.Columns.Count

    '                        fieldName = t.ColumnName(i)

    '                        Select Case t.ColumnType(fieldName)
    '                            Case VistaDB.VistaDBType.Blob

    '                            Case VistaDB.VistaDBType.Boolean
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetBoolean(fieldName)
    '                            Case VistaDB.VistaDBType.Character
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetString(fieldName)
    '                            Case VistaDB.VistaDBType.Currency
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetCurrency(fieldName)
    '                            Case VistaDB.VistaDBType.Date
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDate(fieldName)
    '                            Case VistaDB.VistaDBType.DateTime
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDateTime(fieldName)
    '                            Case VistaDB.VistaDBType.Double
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDouble(fieldName)
    '                            Case VistaDB.VistaDBType.Guid
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetGuid(fieldName)
    '                            Case VistaDB.VistaDBType.Int32
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetInt32(fieldName)
    '                            Case VistaDB.VistaDBType.Int64
    '                                'Note: access doesn't support Int64 as a LonInt in access is an Int in vb.net
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetInt32(fieldName)
    '                            Case VistaDB.VistaDBType.Memo
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetMemo(fieldName)
    '                            Case VistaDB.VistaDBType.Picture
    '                                'skipping for now
    '                                'rs(fieldName).Value = t.GetBlob(
    '                            Case VistaDB.VistaDBType.Varchar
    '                                If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetString(fieldName)
    '                        End Select

    '                        t.Next()
    '                    Next 'Field

    '                    'save as we go, this could cause error here ???
    '                    rs.Update()

    '                Loop 'next record

    '                If Not rs Is Nothing Then
    '                    If rs.State <> 0 Then rs.Close()
    '                    rs = Nothing
    '                End If

    '            End If

    '            'tidy up
    '            t.Close()
    '            t = Nothing


    '        Next

    '    End If

    '    'clean up
    '    t = Nothing

    '    If Not db Is Nothing Then
    '        If db.Connected Then db.Close()
    '        db.Dispose()
    '        db = Nothing
    '    End If

    '    ADOXtable = Nothing
    '    cat.ActiveConnection = Nothing
    '    cat = Nothing

    '    If Not cnn Is Nothing Then
    '        If cnn.State <> 0 Then cnn.Close()
    '        cnn = Nothing
    '    End If

    '    Return True

    'End Function

    Public Function ConvertToAccess(ByVal vistaDatabase As String, ByVal accessDatabase As String, ByVal schemaOnly As Boolean, ByVal tablePrefix As String) As Boolean

        mErrorMessage = ""

        If tablePrefix Is Nothing Then tablePrefix = ""

        Dim cnnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & accessDatabase 'BuildAccessConnectionString(accessDatabase)
        'Dim tables(), sIndexs() As String
        Dim tables As ArrayList = Nothing
        'Dim tableName, fieldName, tableSuffix As String
        Dim tableName, fieldName As String
        Dim i As Integer
        Dim iTable, iTableCount As Integer
        Dim lRecordCount, lRecordPos As Long

        Dim db As DDA.IVistaDBDatabase = Nothing
        Dim t As DDA.IVistaDBTableSchema = Nothing
        Dim tbl As DDA.IVistaDBTable = Nothing
        Dim value As VistaDB.IVistaDBValue = Nothing

        'Dim indexInfo As VistaDB.RTagInfo

        Dim rs As DAO.Recordset = Nothing

        Dim dbEng As DAO.DBEngine = Nothing
        Dim dbA As DAO.Database = Nothing
        Dim daoTable As DAO.TableDef = Nothing
        Dim f As DAO.Field = Nothing
        'Dim idx As DAO.Index


        dbEng = New DAO.DBEngine

        'TEST ACCESS DATABASE
        '=======================================================
        If IO.File.Exists(accessDatabase) Then
            '
            ''it must already exist
            'If Not IO.File.Exists(accessDatabase) Then
            '    mErrorMessage = "Access database '" & accessDatabase & "' not found!"
            '    Return False
            'End If

            'do we need to check for existing tables??, if they exists will create error
            dbA = dbEng.OpenDatabase(accessDatabase)
        Else
            'create it
            RaiseEvent ProgressChanged(-1, "Creating new Database...")
            Try
                dbA = dbEng.CreateDatabase(accessDatabase, AccessDBGen.dbLangGeneral)

            Catch ex As Exception
                mErrorMessage = ex.Message
                Return False
            End Try

            RaiseEvent ProgressChanged(-1, "New Database created successfully")

        End If

        'TEST VISTA DATABASE
        '=======================================================
        If Not IO.File.Exists(vistaDatabase) Then
            mErrorMessage = "Vista Database '" & vistaDatabase & "' not found!"
            Return False
        End If

        Try
            db = Engine.DDA.OpenDatabase(vistaDatabase, VistaDBDatabaseOpenMode.NonexclusiveReadOnly, Nothing)
            'db.Connect
        Catch ex As Exception
            'db.Dispose()
            db = Nothing
            'cat = Nothing
            mErrorMessage = "Unable to connect to vista database"
            Return False
        End Try


        tables = db.EnumTables

        iTable = 0

        If tables IsNot Nothing Then

            iTableCount = tables.Count

            For Each tableName In tables


                RaiseEvent ProgressChanged(Convert.ToInt32(iTable / iTableCount * 100), "Processing Table [" & tableName & "]")

                'get schema
                t = db.TableSchema(tableName)

                'write to access database.

                daoTable = New DAO.TableDef
                daoTable.Name = tablePrefix & tableName

                For i = 0 To t.ColumnCount - 1

                    fieldName = t(i).Name

                    Select Case t(i).Type
                        Case VistaDBType.Image, VistaDBType.VarBinary
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbLongBinary)
                        Case VistaDBType.Bit
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbBoolean)
                        Case VistaDBType.VarChar, VistaDBType.Char, VistaDBType.NChar, VistaDBType.NVarChar
                            'max field len for text is 255, any bigger & its a memo

                            If t(i).MaxLength > 255 Then
                                f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbMemo)
                            Else
                                f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbText)
                                f.Size = t(i).MaxLength
                                f.AllowZeroLength = True
                            End If
                        Case VistaDBType.Text, VistaDBType.NText
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbMemo)
                        Case VistaDBType.Money, VistaDBType.SmallMoney
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbCurrency)
                        Case VistaDBType.DateTime, VistaDBType.SmallDateTime
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbDate)
                        Case VistaDBType.Timestamp
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbTimeStamp)
                        Case VistaDBType.Float, VistaDBType.Real
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbDouble)
                        Case VistaDBType.Decimal
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbDecimal)
                            'set sizes?
                        Case VistaDBType.UniqueIdentifier
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbGUID)
                        Case VistaDBType.TinyInt
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbByte)
                        Case VistaDBType.SmallInt
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbInteger)
                        Case VistaDBType.Int
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbLong)
                        Case VistaDBType.BigInt
                            'Note: access doesn't support Int64 as a LonInt in access is an Int in vb.net
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbLong)
                        Case Else
                            'dont know, just make it a text for now
                            f = daoTable.CreateField(fieldName, DAO.DataTypeEnum.dbText)
                            f.Size = 255
                            f.AllowZeroLength = True
                    End Select

                    'universal field type stuff
                    f.Required = Not t(i).AllowNull

                    'append field to data table?
                    daoTable.Fields.Append(f)


                Next 'Field

                'ToDo: To Access - process the indexes/PK

                't.EnumIndexes(sIndexs)

                'If Not sIndexs Is Nothing Then
                '    For Each sIndex As String In sIndexs
                '        If t.GetIndex(sIndex, indexInfo.bActive, indexInfo.iOrderIndex, indexInfo.bUnique, indexInfo.bPrimary, indexInfo.bDesc, indexInfo.cpKeyExpr, indexInfo.bFts) Then

                '            idx = New DAO.Index
                '            With idx

                '                .Name = sIndex
                '                '.Fields = .CreateField(indexinfo.cpKeyExpr

                '                .Primary = indexInfo.bPrimary
                '                .Unique = indexInfo.bUnique
                '                '.IgnoreNulls = indexinfo.

                '            End With

                '            dbA.TableDefs(tableName).CreateIndex(idx)


                '        End If
                '    Next
                'End If

                'append table to access database. 
                'tables must have at least 1 col in access
                If t.ColumnCount > 0 Then
                    dbA.TableDefs.Append(daoTable)
                    iTable += 1
                End If


                'will cause error if table exits



                'Now we append the data :DDD
                '==================================================================================
                If Not schemaOnly Then

                    'cnn = New ADODB.Connection
                    'cnn.ConnectionString = BuildAccessConnectionString(accessDatabase)
                    'cnn.Open()

                    'rs = New ADODB.Recordset

                    'rs.Open("SELECT * FROM [" & tablePrefix & tableName & "]", cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

                    rs = dbA.OpenRecordset("SELECT * FROM [" & tablePrefix & tableName & "]") ', DAO.LockTypeEnum.dbOptimistic)

                    tbl = db.OpenTable(t.Name, False, True)

                    tbl.First()

                    lRecordCount = tbl.RowCount

                    RaiseEvent ProgressChanged(-1, "Inserting " & lRecordCount.ToString("#,##0") & " Records into Table [" & tableName & "]")


                    Do Until tbl.EndOfTable

                        rs.AddNew()

                        For i = 0 To t.ColumnCount - 1

                            fieldName = t(i).Name
                            value = tbl.Get(i)

                            'lets try this way
                            If Not value.IsNull Then
                                Select Case value.Type
                                    Case VistaDBType.UniqueIdentifier
                                        rs(fieldName).Value = "{" & value.Value.ToString & "}"
                                    Case Else
                                        'ok to just insert as is
                                        rs(fieldName).Value = value.Value
                                End Select
                            End If



                            'Select Case value.Type
                            '    Case VistaDBType.Bit
                            '        If Not value.IsNull Then rs(fieldName).Value = value.Value
                            '    Case VistaDB.VistaDBType.Character
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetString(fieldName)
                            '    Case VistaDB.VistaDBType.Currency
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetCurrency(fieldName)
                            '    Case VistaDB.VistaDBType.Date
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDate(fieldName).ToString(My.Resources.SqlDateFormat)
                            '    Case VistaDB.VistaDBType.DateTime
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDateTime(fieldName).ToString(My.Resources.SqlDateTimeFormat)
                            '    Case VistaDB.VistaDBType.Double
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetDouble(fieldName)
                            '    Case VistaDB.VistaDBType.Guid
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = "{" & t.GetGuid(fieldName).ToString & "}"
                            '    Case VistaDB.VistaDBType.Int32
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetInt32(fieldName)
                            '    Case VistaDB.VistaDBType.Int64
                            '        'Note: access doesn't support Int64 as a LonInt in access is an Int in vb.net
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetInt32(fieldName)
                            '    Case VistaDB.VistaDBType.Memo
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetMemo(fieldName)

                            '    Case VistaDB.VistaDBType.Picture, VistaDB.VistaDBType.Blob
                            '        'skipping for now
                            '        'rs(fieldname).AppendChunk(t.GetBlob(
                            '    Case VistaDB.VistaDBType.VarChar
                            '        If Not t.GetNull(fieldName) Then rs(fieldName).Value = t.GetString(fieldName)
                            'End Select

                        Next 'Field

                        'save as we go, this could cause error here ???
                        rs.Update()

                        tbl.Next()
                        lRecordPos += 1
                    Loop 'next record

                    If Not rs Is Nothing Then
                        rs.Close()
                        'If rs.State <> 0 Then rs.Close()
                        rs = Nothing
                    End If

                End If

                'tidy up
                If tbl IsNot Nothing Then
                    If tbl.IsClosed = False Then tbl.Close()
                    tbl.Dispose()
                    tbl = Nothing
                End If


            Next

        End If

        'clean up
        t = Nothing

        'Vista
        If db IsNot Nothing Then
            If Not db.IsClosed Then db.Close()
            db.Dispose()
            db = Nothing
        End If

        'DAO
        daoTable = Nothing
        rs = Nothing

        If dbA IsNot Nothing Then
            dbA.Close()
            dbA = Nothing
        End If

        If Not dbEng Is Nothing Then
            dbEng = Nothing
        End If

        RaiseEvent OnComplete(accessDatabase)

        Return True

    End Function

End Class
