Imports VistaDB
Imports System.Windows.Forms

'Public Enum ScriptLanguageEnum As Integer
'    VbNet = 0
'    [Text] = 1 'plain output of what the changes are
'    [CSharp] = 2
'    VSql = 3    'ToDo: Implement VSql generation
'    Delphi = 4  'ToDo: implement Delphi generation

'End Enum

'Public Enum DiffActionTypeEnum As Integer
'    None = 0    'need none for table that has field changes, this case should use Alter!!!
'    Add = 1
'    Alter = 2
'    Drop = 3
'End Enum

Public Class vdbScriptEngine

#Region "  VB.NET Script  "

  Public Shared Function ScriptToVB(ByVal dbFile As String) As String

    'If Not G.FullLicense Then Return "This feature is not available in the free version, please visit the website or contact support to purchase the upgrade."

    Dim sb As System.Text.StringBuilder

    Dim db As VistaDBDatabase
    Dim t As VistaDBTable
    'Dim c As VistaDB.VistaDBColumn
    Dim tables() As String = Nothing
    Dim indexes() As String = Nothing
    Dim tableName As String
    Dim indexInfo As VistaDB.RTagInfo = Nothing

    If dbFile = "" Then Return "No Database File Supplied!"

    db = New VistaDBDatabase(dbFile, False, True)


    If Not db.Connect Then
      db.Dispose()
      db = Nothing
      Return "Unable to connect to database!"
    End If

    tables = Nothing
    db.EnumTables(tables)

    If tables Is Nothing Then
      Return "The Database '" & dbFile & "' Contains no tables."
    End If

    sb = New System.Text.StringBuilder

    'create basic script output objects
    With sb
      .Append("'// Auto Generated script by vDBCompare (Meikle Programming)")
      .Append(vbCrLf)
      .Append("'// Generated At: ")
      .Append(Now.ToLongDateString)
      .Append(" ")
      .Append(Now.ToLongTimeString)
      .Append(vbCrLf)
      '.Append("'// 25-Sep-06: Scripting Engine still under construction, this will not be the entire script!!! (only missing tables are scripted for now.")
      .Append("'// ")
      .Append(Now.ToString("d-MMM-yy H:mm tt"))
      .Append(" : Scripting Entire code needed to Create New Database")
      .Append(vbCrLf)
      .Append(vbCrLf)
      .Append("Dim db as VistaDB.VistaDBDatabase")
      .Append(vbCrLf)
      .Append("Dim t As VistaDB.VistaDBTable")
      .Append(vbCrLf)
      .Append(vbCrLf)
      .Append("db = New VistaDB.VistaDBDatabase(""")
      .Append(dbFile)
      .Append(""", True, False)")
      .Append(vbCrLf)
      .Append(vbCrLf)
      .Append(vbCrLf)
      .Append(vbCrLf)

    End With

    If Not tables Is Nothing Then
      For Each tableName In tables

        'reset stuff
        t = New VistaDB.VistaDBTable(db, tableName)
        t.Open()

        sb.Append(vdbScriptEngine.ScriptTable(t))

        'close tables as we go (if necessary)
        If Not t Is Nothing Then
          If t.Opened Then t.Close()
          t = Nothing
        End If


      Next 'table
    End If


    'clean up
    If db.Connected Then db.Close()

    db.Dispose()

    db = Nothing


    Return sb.ToString

  End Function

  Public Shared Function ScriptTable(ByVal t As VistaDBTable) As String
    If t Is Nothing Then Return ""

    Dim sb As New System.Text.StringBuilder
    Dim tableName As String = t.TableName
    Dim c As VistaDB.VistaDBColumn = Nothing
    Dim indexes() As String
    Dim sIndex As String
    Dim indexInfo As VistaDB.RTagInfo

    indexInfo.cpKeyExpr = ""


    With sb
      .Append("'======================================================")
      .Append(vbCrLf)
      .Append("'// Create Table [" & tableName & "]")
      .Append(vbCrLf)
      .Append("'// Safety checks...")
      .Append(vbCrLf)
      .Append("If Not db.IsTableExist(""")
      .Append(tableName)
      .Append(""") Then")

      .Append(vbCrLf)
      .Append("t = New VistaDBTable(db, """ & tableName & """)")
      .Append(vbCrLf)
      .Append("t.TableName = """ & tableName & """")
      .Append(vbCrLf)
      .Append("t.CreateNew()")
      .Append(vbCrLf)


      For Each c In t.Columns

        If c.PrimaryKey Then
          .Append("'// Primary Key Field")
          .Append(vbCrLf)
        End If
        If c.Identity Then
          .Append("'// Identity Column")
          .Append(vbCrLf)
        End If

        .Append("t.CreateColumn(""")
        .Append(c.Name)
        .Append(""", VistaDBType.")
        .Append(c.VistaDBType.ToString)
        .Append(", ")
        .Append(c.ColumnWidth)
        .Append(", ")
        .Append(c.ColumnDecimals)
        .Append(", ")
        .Append(Not c.AllowNull)
        .Append(", ")
        .Append("False, False, False, False, False)")

        .Append(vbCrLf)
        'Next 'field 
      Next

      .Append(vbCrLf)
      .Append("t.CreateFinalize()")
      .Append(vbCrLf)
      .Append(vbCrLf)

      .Append("'Create Primary Key(s) & auto Identities...")
      .Append(vbCrLf)
      .Append("If Not t.Opened Then t.Open()")
      .Append(vbCrLf)

      'auto id's first
      For Each c In t.Columns
        If c.Identity Then
          't.SetIdentity("OID", "1", 1)
          .Append("'// Auto Id")
          .Append(vbCrLf)
          .Append("t.SetIdentity(""")
          .Append(c.Name)
          .Append(""", ""1"", 1)")
          .Append(vbCrLf)
        End If
      Next

      indexes = Nothing
      t.EnumIndexes(indexes)

      If Not indexes Is Nothing Then
        For Each sIndex In indexes

          If t.GetIndex(sIndex, indexInfo.bActive, indexInfo.iOrderIndex, indexInfo.bUnique, indexInfo.bPrimary, indexInfo.bDesc, indexInfo.cpKeyExpr, indexInfo.bFts) Then
            .Append("'// Index: ")
            .Append(sIndex)
            .Append(vbCrLf)

            .Append("t.CreateIndex(""")
            .Append(sIndex)
            .Append(""", """)
            .Append(indexInfo.cpKeyExpr)
            If indexInfo.bPrimary Then
              .Append(""", VistaDB.VDBIndexOption.Primary, ")
            ElseIf indexInfo.bUnique Then
              .Append(""", VistaDB.VDBIndexOption.Unique, ")
            ElseIf indexInfo.bStandardIndex Then
              .Append(""", VistaDB.VDBIndexOption.Standard, ")
            End If

            .Append(indexInfo.bDesc.ToString)
            .Append(", ")
            .Append(indexInfo.ulLocaleId)
            .Append(")")
            .Append(vbCrLf)
          End If

        Next
      End If

      '// Clean up
      .Append(vbCrLf)
      .Append("'// Clean Up")
      .Append(vbCrLf)
      .Append("If t.Opened Then t.Close()")
      .Append(vbCrLf)
      .Append("t = Nothing")


      .Append(vbCrLf)
      .Append(vbCrLf)

      .Append("End If")
      .Append(vbCrLf)
      .Append(vbCrLf)
    End With

    Return sb.ToString

  End Function

#End Region


  Public Shared Function GetDifferences(ByVal vdbFile1 As String, ByVal vdbFile2 As String, ByVal processIndexes As Boolean) As DbDiff

    'assuming valid stuff has been passed! (files exists etc..)

    Dim differences As New DbDiff

    Dim db1, db2 As VistaDBDatabase
    Dim t1 As VistaDB.VistaDBTable = Nothing
    Dim t2 As VistaDB.VistaDBTable = Nothing
    Dim c As VistaDB.VistaDBColumn

    Dim tables1() As String = Nothing
    Dim tables2() As String = Nothing
    Dim indexes() As String = Nothing
    Dim tableName, sIndex As String
    Dim indexInfo As VistaDB.RTagInfo

    Dim td As New TableDiff

    indexInfo.cpKeyExpr = ""
    indexInfo.cpForExpr = ""

    db1 = New VistaDB.VistaDBDatabase(vdbFile1, False, True)
    db2 = New VistaDB.VistaDBDatabase(vdbFile2, False, True)

    If Not db1.Connected Then db1.Connect()
    If Not db2.Connected Then db2.Connect()


    db1.EnumTables(tables1)
    db2.EnumTables(tables2)

    If Not tables1 Is Nothing Then
      For Each tableName In tables1
        t1 = New VistaDB.VistaDBTable(db1, tableName)
        t1.Open()

        'does this table exist in the 2nd db
        '===========================================================
        If db2.IsTableExist(tableName) Then
          '===========================================================
          'Checking all fields exist
          t2 = New VistaDB.VistaDBTable(db2, tableName)
          t2.Open()

          'reset for each table

          td = Nothing

          For Each c In t1.Columns
            'check the field exists
            If Engine.ColumnExists(t2, c.Name) Then
              'check data type
              If t1.ColumnType(c.Name) = t2.ColumnType(c.Name) Then
                'check data length
                If c.ColumnWidth <> t2.ColumnWidth(c.Name) Then
                  'sizes are different
                  If td Is Nothing Then
                    td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Alter)
                    differences.Tables.Add(tableName, td)
                  End If

                  td.Fields.Add(c.Name, New FieldDiff(c, ICommon.DiffActionTypeEnum.Alter))

                End If
              Else
                'different data type
                If td Is Nothing Then
                  td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Alter)
                  differences.Tables.Add(tableName, td)
                End If

                td.Fields.Add(c.Name, New FieldDiff(c, ICommon.DiffActionTypeEnum.Alter))
              End If
            Else 'column does not exist
              If td Is Nothing Then
                td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Alter)
                differences.Tables.Add(tableName, td)
              End If

              td.Fields.Add(c.Name, New FieldDiff(c, ICommon.DiffActionTypeEnum.Add))
            End If
          Next


          'check for fields that may need to be dropped
          For Each c In t2.Columns
            If Not Engine.ColumnExists(t1, c.Name) Then
              'drop field
              If td Is Nothing Then
                td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Alter)
                differences.Tables.Add(tableName, td)
              End If

              td.Fields.Add(c.Name, New FieldDiff(c, ICommon.DiffActionTypeEnum.Drop))
            End If
          Next '

          '===========================================================
        Else 'table doesn't exist
          '===========================================================
          '===========================================================
          'new table
          td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Add)

          differences.Tables.Add(tableName, td)

          'adding all fields
          For Each c In t1.Columns
            td.Fields.Add(c.Name, New FieldDiff(c, ICommon.DiffActionTypeEnum.Add))
            'Next 'field 
          Next
        End If 'db2.IsTableExist(tableName)

        'check for identities
        'check for PK's
        'check for Indexes

        't1.EnumConstraints ?
        't1.EnumForeignKeys ?
        't1.EnumIdentities -> done above
        't1.EnumIndexes -> done below
        't1.EnumTriggers ?

        If processIndexes Then
          t1.EnumIndexes(indexes)

          If Not indexes Is Nothing Then
            For Each sIndex In indexes

              If t1.GetIndex(sIndex, indexInfo.bActive, indexInfo.iOrderIndex, indexInfo.bUnique, indexInfo.bPrimary, indexInfo.bDesc, indexInfo.cpKeyExpr, indexInfo.bFts, indexInfo.bStandardIndex, indexInfo.cpForExpr) Then

                'Active doesn't seem to work, leave out for now
                'If indexInfo.bActive Then
                If td Is Nothing Then
                  td = New TableDiff(tableName, ICommon.DiffActionTypeEnum.Alter)
                  differences.Tables.Add(tableName, td)
                End If

                Dim idx As New IndexDiff
                With idx
                  .Name = sIndex
                  'Trace.WriteLine("Index: " & .Name & " = " & indexInfo.cpForExpr)
                  .KeyExpr = indexInfo.cpKeyExpr
                  .Descending = indexInfo.bDesc
                  If indexInfo.bPrimary Then
                    .IndexType = VDBIndexOption.Primary
                  ElseIf indexInfo.bUnique Then
                    .IndexType = VDBIndexOption.Unique
                  ElseIf indexInfo.bStandardIndex Then
                    .IndexType = VDBIndexOption.Standard
                  ElseIf indexInfo.bFts Then
                    'not sure what it is but don't think its every used.
                    .IndexType = VDBIndexOption.FTS
                  Else
                    'normal? what is that?
                    .IndexType = VDBIndexOption.Standard
                  End If
                End With
                '.Append(indexInfo.ulLocaleId)
                td.Indexs.Add(idx)
                'End If
              End If

            Next
          End If 'Not indexes Is Nothing
        End If 'processIndexes


      Next 'tableName
    End If 'tables1 Is Nothing

    'need to close databases

    If db1 IsNot Nothing Then
      If db1.Connected Then db1.Close()
      db1.Dispose()
      db1 = Nothing
    End If


    If db2 IsNot Nothing Then
      If db2.Connected Then db2.Close()
      db2.Dispose()
      db2 = Nothing
    End If

    Return differences
  End Function

  Public Shared Function CLangType(ByVal value As Integer) As ICommon.ScriptLanguageEnum
    'values 0-4 OK (3 & 4 not supported)
    If value >= 0 And value <= 4 Then
      Return CType(value, ICommon.ScriptLanguageEnum)
    Else
      'invalid range, just return vb.net (or text?)
      Return ICommon.ScriptLanguageEnum.VbNet
    End If

  End Function

  'Public Shared Function CLangType(ByVal value As String) As ScriptLanguageEnum
  '    'not done yet!

  'End Function

  Public Shared Function GenerateCreateDatabaseScript(ByVal vdbFile As String, ByVal outputLanguage As ICommon.ScriptLanguageEnum) As String

    Return "..."
  End Function

  Public Shared Function GenerateScript(ByVal differences As DbDiff, ByVal outputLanguage As ICommon.ScriptLanguageEnum, ByVal processIndexes As Boolean) As String
    If differences Is Nothing Then Return "NONE"

    Dim lang As ICommon.IScripter = Nothing

    Select Case outputLanguage
      Case ICommon.ScriptLanguageEnum.Text
        lang = New TextScripter
      Case ICommon.ScriptLanguageEnum.VbNet
        'Return "VB.NET is undergoin an update..."
        lang = New VBScripter
      Case ICommon.ScriptLanguageEnum.CSharp
        'Return "C# is still under development"
        lang = New CSharpScripter
      Case ICommon.ScriptLanguageEnum.Delphi
        Return "Delphi is still under development"
    End Select

    'If lang IsNot Nothing Then
    '    Return "OUTPUT=" & lang.LanguageName & Environment.NewLine & Environment.NewLine & lang.GenerateScript(differences)
    'Else
    '    Return "Language type not yet supported"
    'End If

    'this is how I want it to work
    'there should be NO language specific code here!
    If differences Is Nothing Then Return lang.CComment("NONE")
    If differences.HasChanges = False Then Return lang.CComment("NONE")

    Dim sb As New System.Text.StringBuilder

    sb.Append(lang.ScriptHeader)

    For Each t As TableDiff In differences.Tables.Values
      Select Case t.DiffAction
        Case ICommon.DiffActionTypeEnum.Add
          sb.AppendLine(lang.CComment("Table: " & t.TableName))
          sb.AppendLine(lang.CIfTableExists(t.TableName, False))

          sb.AppendLine(lang.CNewTable(t.TableName))
          sb.AppendLine()
          sb.AppendLine(lang.CStatement("t.CreateNew()"))
          sb.AppendLine()
          sb.AppendLine(lang.CComment("Columns")) 'should only ever be adding columns

          For Each f As FieldDiff In t.Fields.Values
            If f.DiffAction = ICommon.DiffActionTypeEnum.Add Then
              sb.AppendLine(lang.CCreateColumn(f.Name, "VistaDB.VistaDBType." & f.DataType.ToString, f.Width, f.Decimals, f.Required))
              sb.Append(Environment.NewLine)
            Else
              sb.AppendLine(lang.CComment("# Invalid action for column [" & f.Name & "]"))
            End If 'all other actions should be INVALID in this context!
          Next

          sb.AppendLine()
          sb.AppendLine(lang.CStatement("t.CreateFinalize()"))
          sb.AppendLine()
          'PKs, Indexes, etc...

          sb.AppendLine(lang.COpenTable)
          sb.AppendLine()

          For Each f As FieldDiff In t.Fields.Values

            If f.Identity Then
              'sb.AppendLine("t.SetIdentity(""" & f.Name & """, """ & f.IdentityValue & """, " & f.IdentityStep.ToString & ")")
              sb.AppendLine(lang.CSetIdentity(f.Name, f.IdentityValue, f.IdentityStep))
            ElseIf f.DefaultValue <> "" Then
              'identities shound't have defaults
              'need to determine if the default value is used in updates some how
              'sb.AppendLine("t.SetDefaultValue(""" & f.Name & """, """ & f.DefaultValue & """, False)")
              sb.AppendLine(lang.CSetDefault(f.Name, f.DefaultValue, f.UseDefaultInUpdate))

            End If
          Next

          'Indexes
          If processIndexes Then
            For Each idx As IndexDiff In t.Indexs
              sb.AppendLine(lang.CIsIndexExists(idx.Name))
              'sb.AppendLine(lang.CCreateIndex(idx.Name, idx.KeyExpr, "VistaDB.VDBIndexOption." & idx.IndexType.ToString, idx.Descending, 0))
              sb.AppendLine(lang.CCreateIndex(idx))
              sb.AppendLine(lang.CEndIf)
            Next
          End If


          sb.AppendLine()
          sb.AppendLine(lang.CCloseTable)
          sb.AppendLine(lang.CSetNothing("t"))
          sb.AppendLine(lang.CEndIf)
          sb.AppendLine()


        Case ICommon.DiffActionTypeEnum.Alter
          If t.HasChanges Then
            sb.AppendLine(lang.CComment("Table: " & t.TableName))
            sb.AppendLine(lang.CIfTableExists(t.TableName, True))
            sb.AppendLine(lang.CNewTable(t.TableName))


            If t.HasFieldChanges Then 'as may only contain index changes
              sb.AppendLine("t.AlterTable()") 'should be same in all languages

              'columns.. should be either alter,add or drop

              For Each f As FieldDiff In t.Fields.Values
                Select Case f.DiffAction
                  Case ICommon.DiffActionTypeEnum.Add
                    sb.AppendLine(lang.CCreateColumn(f.Name, "VistaDB.VistaDBType." & f.DataType.ToString, f.Width, f.Decimals, f.Required))

                  Case ICommon.DiffActionTypeEnum.Alter
                    sb.AppendLine(lang.CAlterColumn(f.Name, "VistaDB.VistaDBType." & f.DataType.ToString, f.Width, f.Decimals, f.Required))

                  Case ICommon.DiffActionTypeEnum.Drop
                    '??
                    sb.AppendLine(lang.CComment("Drop Column " & f.Name))
                    sb.AppendLine(lang.CComment(lang.CStatement("t.DropColumn(""" & f.Name & """)")))
                    'this is not tested, from the looks of the function you need to call this later (outside of alter table()
                End Select

              Next

              sb.AppendLine(lang.CStatement("t.AlterTableFinalize(True)")) 'should be same in all languages
            End If

            sb.AppendLine()

            'Indexes
            For Each idx As IndexDiff In t.Indexs
              sb.AppendLine(lang.CIsIndexExists(idx.Name))
              'sb.AppendLine(lang.CCreateIndex(idx.Name, idx.KeyExpr, "VistaDB.VDBIndexOption." & idx.IndexType.ToString, idx.Descending, 0))
              sb.AppendLine(lang.CCreateIndex(idx))
              sb.AppendLine(lang.CEndIf)
            Next

            sb.AppendLine()
            sb.AppendLine(lang.CCloseTable)
            sb.AppendLine(lang.CSetNothing("t"))
            sb.AppendLine(lang.CEndIf)
            sb.AppendLine()
          End If


        Case ICommon.DiffActionTypeEnum.Drop
          sb.AppendLine(lang.CComment("Drop Table " & t.TableName))
          sb.AppendLine(lang.CComment(lang.CDropTable(t.TableName)))
        Case ICommon.DiffActionTypeEnum.None
          'fields only
          'sb.Append("'? Table [")
          'sb.Append(t.TableName)
          'sb.Append("]")
          'sb.Append(Environment.NewLine)
      End Select

      sb.AppendLine()

    Next 'table

    sb.Append(lang.ScriptFooter)
    'end
    Return sb.ToString

  End Function

  Public Shared Function OutPutDiff(ByVal differences As DbDiff, ByVal outputTreeView As TreeView) As Boolean
    If differences Is Nothing Then Return True 'no differences?
    If outputTreeView Is Nothing Then Return False

    Dim diffTableNode, diffFieldNode As TreeNode
    Dim loFieldName As String

    'clear output first
    outputTreeView.Nodes.Clear()

    diffTableNode = Nothing
    diffFieldNode = Nothing


    For Each t As TableDiff In differences.Tables.Values
      Select Case t.DiffAction
        Case ICommon.DiffActionTypeEnum.Add
          't.TableName
          diffTableNode = outputTreeView.Nodes.Add(t.TableName & " [ADD]")
          diffTableNode.ImageIndex = vDBCompare.ICommon.Common.TICON_TABLE_ADD

          For Each f As FieldDiff In t.Fields.Values
            If f.DiffAction = ICommon.DiffActionTypeEnum.Add Then
              loFieldName = "+ " & f.Name
              If f.PrimaryKey Then loFieldName &= " (PK)"
              If f.Identity Then loFieldName &= " (Auto)"


              diffFieldNode = diffTableNode.Nodes.Add(loFieldName)
              diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD_ADD

              diffFieldNode.Nodes.Add(f.DataType.ToString & " (" & _
                  Microsoft.VisualBasic.IIf(f.Required, "NOT NULL", "NULL") & ")")

              'sizes
              If f.Decimals <> 0 Then
                diffFieldNode.Nodes.Add("Size= " & f.Width.ToString & "," & f.Decimals.ToString)
              Else
                diffFieldNode.Nodes.Add("Size= " & f.Width.ToString)
              End If

              If f.DefaultValue <> "" Then diffFieldNode.Nodes.Add("Default=" & f.DefaultValue)



            Else
              diffFieldNode = diffTableNode.Nodes.Add(f.Name & " (# invalid action for column, should be 'Add')")
              diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD
              'sb.AppendLine(lang.CComment("# Invalid action for column [" & f.Name & "]"))
            End If 'all other actions should be INVALID in this context!
          Next


          'Indexes? may do later
          'If processIndexes Then
          For Each idx As IndexDiff In t.Indexs
            diffFieldNode = diffTableNode.Nodes.Add("INDEX : " & idx.Name & " (" & idx.KeyExpr & ", " & idx.IndexType.ToString & ")")
            diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD 'index?
          Next
          'End If

        Case ICommon.DiffActionTypeEnum.Alter ' -> moved to Else
          If t.HasChanges Then

            diffTableNode = outputTreeView.Nodes.Add(t.TableName)
            diffTableNode.ImageIndex = vDBCompare.ICommon.Common.TICON_TABLE

            If t.HasFieldChanges Then 'as may only contain index changes

              'columns.. should be either alter,add or drop

              For Each f As FieldDiff In t.Fields.Values


                loFieldName = f.Name
                If f.PrimaryKey Then loFieldName &= " (PK)"
                If f.Identity Then loFieldName &= " (Auto)"

                Select Case f.DiffAction
                  Case ICommon.DiffActionTypeEnum.Add
                    loFieldName = loFieldName & " [ADD]"


                    diffFieldNode = diffTableNode.Nodes.Add(loFieldName)
                    diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD_ADD


                  Case ICommon.DiffActionTypeEnum.Alter
                    loFieldName &= " [ALTER]"
                    diffFieldNode = diffTableNode.Nodes.Add(loFieldName)
                    diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD_ALTER
                  Case ICommon.DiffActionTypeEnum.Drop
                    loFieldName = loFieldName & " [DROP]"
                    diffFieldNode = diffTableNode.Nodes.Add(loFieldName)
                    diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD_DROP
                  Case Else
                    '??
                    loFieldName &= " [?]"
                    diffFieldNode = diffTableNode.Nodes.Add(loFieldName)
                    diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD
                End Select

                diffFieldNode.Nodes.Add(f.DataType.ToString & " (" & _
                    Microsoft.VisualBasic.IIf(f.Required, "NOT NULL", "NULL") & ")")

                'sizes
                If f.Decimals <> 0 Then
                  diffFieldNode.Nodes.Add("Size= " & f.Width.ToString & "," & f.Decimals.ToString)
                Else
                  diffFieldNode.Nodes.Add("Size= " & f.Width.ToString)
                End If

                If f.DefaultValue <> "" Then diffFieldNode.Nodes.Add("Default=" & f.DefaultValue)



              Next
            End If


            'Indexes
            For Each idx As IndexDiff In t.Indexs
              diffFieldNode = diffTableNode.Nodes.Add("INDEX : " & idx.Name & " (" & idx.KeyExpr & ", " & idx.IndexType.ToString & ")")
              diffFieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD 'index?
            Next


          End If


        Case ICommon.DiffActionTypeEnum.Drop
          diffTableNode = outputTreeView.Nodes.Add("DROP " & t.TableName)
          diffTableNode.ImageIndex = vDBCompare.ICommon.Common.TICON_TABLE_DROP
        Case ICommon.DiffActionTypeEnum.None
          'No changes? just skip for now 
      End Select

    Next 'table

	End Function

	Public Shared Function GetSchema(ByVal fileName As String) As vDBCompare.ICommon.SchemaDataSet
		Dim dsSchema As New vDBCompare.ICommon.SchemaDataSet
		Dim arTables() As String = New String() {}

		Using db As New VistaDB.VistaDBDatabase(fileName, False, True)
			db.Connect()

			db.EnumTables(arTables)

			For Each tableName As String In arTables
				Dim t As New VistaDB.VistaDBTable(db, tableName)

				t.Open()

				For Each col As VistaDB.VistaDBColumn In t.Columns
					dsSchema.TableSchema.AddTableSchemaRow(tableName, col.Name, col.VistaDBType.ToString, _
					  col.ColumnWidth, col.DefaultValue, col.AllowNull, col.Identity, col.PrimaryKey, col.ColumnDecimals)
				Next

				t.Close()
			Next 'table
			db.Close()
		End Using

		dsSchema.AcceptChanges()
		Return dsSchema
	End Function

  Public Shared Function OutPutSchema(ByVal fileName As String, ByVal outputTreeView As TreeView) As Boolean

    Dim db As VistaDB.VistaDBDatabase
    Dim t As VistaDB.VistaDBTable
    Dim tables() As String = Nothing
    Dim tableName As String
    Dim tableNode, fieldNode As TreeNode

    Dim i As Integer

    outputTreeView.Nodes.Clear()

    db = New VistaDB.VistaDBDatabase(fileName, False, True)

    If Not db.Connected Then
      db.Connect()
    End If

    db.EnumTables(tables)

    If Not tables Is Nothing Then
      outputTreeView.BeginUpdate()
      For Each tableName In tables
        tableNode = outputTreeView.Nodes.Add(tableName)
        tableNode.ImageIndex = vDBCompare.ICommon.Common.TICON_TABLE 'G.TICON_TABLE
        t = New VistaDB.VistaDBTable(db, tableName)
        t.Open()

        For i = 1 To t.Columns.Count()
          fieldNode = tableNode.Nodes.Add(t.ColumnName(i))
          fieldNode.ImageIndex = vDBCompare.ICommon.Common.TICON_FIELD
          fieldNode.Nodes.Add("Type: " & t.ColumnType(fieldNode.Text).ToString).ImageIndex = ICommon.Common.TICON_FIELD_INFO
          fieldNode.Nodes.Add("Size: " & t.ColumnWidth(fieldNode.Text).ToString).ImageIndex = ICommon.Common.TICON_FIELD_INFO
        Next

        t.Close()

      Next
      outputTreeView.EndUpdate()
    End If

    If db.Connected Then db.Close()
    db.Dispose()
    db = Nothing

  End Function

  Public Shared Function PackDatabase(ByVal dataFile As String) As Boolean
    'no error handling, calling code wants to display error message
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
        Throw ex
        Return False
      End Try
    Else
      Return False 'file not found
    End If

  End Function

  Public Shared Function ColumnExists(ByVal t As VistaDB.VistaDBTable, ByVal columnName As String) As Boolean
    Return Engine.ColumnExists(t, columnName)
  End Function

  Public Shared Function ListTables(ByVal dbFile As String) As ArrayList
    Dim ar As New ArrayList

    If IO.File.Exists(dbFile) Then

      Dim db As VistaDB.VistaDBDatabase = Nothing
      Dim tables() As String = Nothing

      Try
        db = New VistaDB.VistaDBDatabase(dbFile, False, True)

        db.Connect()
        db.EnumTables(tables)
        ar.AddRange(tables)
        'Catch ex As Exception
      Finally
        If db IsNot Nothing Then
          If db.Connected Then db.Close()
          db.Dispose()
          db = Nothing
        End If
      End Try

    End If
    Return ar
  End Function

  Public Shared Function ExportData(ByVal dbFile As String, ByVal exportTarget As String, ByVal schemaOnly As Boolean, ByVal tablesToExport As ArrayList) As Boolean

    Dim blnResult As Boolean = False
    Dim db As VistaDB.VistaDBDatabase = Nothing

    Dim tables() As String = Nothing

    Try

      db = New VistaDB.VistaDBDatabase(dbFile, False, True)

      db.Connect()

      If tablesToExport IsNot Nothing Then
        'selection

        For Each s As String In tablesToExport
          db.AddToExportList(s)
        Next
      Else
        'All tables
        db.EnumTables(tables)

        For Each table As String In tables
          db.AddToExportList(table)
        Next
      End If


      'now export the data
      blnResult = db.ExportData(exportTarget, schemaOnly)

    Catch ex As Exception
      blnResult = False
      'DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, STR_Export, MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally

      If Not db Is Nothing Then
        If db.Connected Then db.Close()
        db.Dispose()
        db = Nothing
      End If
    End Try

    Return blnResult
  End Function

End Class
