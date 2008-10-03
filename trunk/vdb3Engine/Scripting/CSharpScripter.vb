Public Class CSharpScripter
  Implements vDBCompare.ICommon.IScripter

  Private Const PRIMARY_KEY As String = "PRIMARY_KEY"
  'Private Const IF_TABLE_EXISTS As String = "If (!db.IsTableExist(""{0}"")) {"
  Private Const END_IF As String = "}"
  Private Const NEW_TABLE As String = "ts = db.NewTable(""{0}"");" '"t = New VistaDBTable(db,""{0}"");"
  Private Const OPEN_TABLE As String = "if (!(t.Opened)) { t.Open();}"
  Private Const CREATE_COLUMN As String = "ts.AddColumn(""{0}"", {1})" ', {2}, {3}, {4}, False, False, False, False, False);"
  Private Const ALTER_COLUMN As String = "t.AlterColumn(""{0}"", {1}, {2}, {3}, {4}, false, false, false, false, false);" '"t.AlterColumn(""{0}"", {1}, {2}, {3}, {4}, False, False, False, False, False);"
  Private Const SET_IDENTITY As String = "t.CreateIdentity(""{0}"", ""{1}"", {2}, null);" '"t.SetIdentity(""{0}"", ""{1}"", {2});"
  Private Const SET_DEFAULT As String = "t.CreateDefaultValue(""{0}"", ""{1}"", {2});"
  Private Const IS_INDEX_EXISTS As String = "If (!(vDb3UpdateHelper.IsIndexExists(db, ts.Name, ""{0}""))) {"
  Private Const CREATE_INDEX As String = "ts.DefineIndex(""{0}"", ""{1}"", {2}, {3})" ', {4});"
  Private Const CLOSE_TABLE As String = "if (t.IsClosed == false) {t.Close();}" '"If (t.Opened) {t.Close();}"
  Private Const DROP_TABLE As String = "db.DropTable(""{0}"");"

  Public ReadOnly Property LanguageName() As String Implements vDBCompare.ICommon.IScripter.LanguageName
    Get
      Return "C#"
    End Get
  End Property

  Public ReadOnly Property LanguageType() As vDBCompare.ICommon.ScriptLanguageEnum Implements vDBCompare.ICommon.IScripter.LanguageType
    Get
      Return vDBCompare.ICommon.ScriptLanguageEnum.CSharp
    End Get
  End Property

  Public Function GenerateScript(ByVal differences As Object) As String Implements vDBCompare.ICommon.IScripter.GenerateScript
    If differences Is Nothing Then Return "NONE"

    Return "C# Script for vdb3 not done, please check for updates."

    'Dim diffObject As DbDiff = CType(differences, DbDiff)

    ''DbDiff
    'Dim sb As New System.Text.StringBuilder
    'Dim scriptFileds As Boolean = True
    ''start

    'sb.Append(Me.ScriptHeader)

    'For Each t As TableDiff In diffObject.Tables.Values
    '    Select Case t.DiffAction
    '        Case ICommon.DiffActionTypeEnum.Add

    '            sb.AppendLine("'Table: " & t.TableName)
    '            sb.AppendLine("If db.IsTableExist(""" & t.TableName & """) = False Then")

    '            sb.AppendLine("t = New VistaDBTable(db, """ & t.TableName & """)")
    '            sb.AppendLine()
    '            sb.AppendLine("t.CreateNew()")
    '            sb.AppendLine()
    '            sb.AppendLine("'Columns") 'should only ever be adding columns

    '            For Each f As FieldDiff In t.Fields.Values
    '                If f.DiffAction = ICommon.DiffActionTypeEnum.Add Then
    '                    't.CreateColumn("Sys_Id", VistaDBType.Guid, 16, 0, True, False, False, False, False, False)
    '                    sb.Append("t.CreateColumn(""")
    '                    sb.Append(f.Name)               'name
    '                    sb.Append(""", VistaDBType.")
    '                    sb.Append(f.DataType.ToString)  'data type
    '                    sb.Append(", ")
    '                    sb.Append(f.Width)              'width
    '                    sb.Append(", ")
    '                    sb.Append(f.Decimals)           'decimals
    '                    sb.Append(", ")
    '                    'PK can NOT be null!!!
    '                    If f.PrimaryKey Then
    '                        sb.Append("True")
    '                    Else
    '                        sb.Append(f.Required.ToString)          'required
    '                    End If
    '                    sb.Append(", False, False, False, False, False)")


    '                    sb.Append(Environment.NewLine)
    '                Else
    '                    sb.AppendLine("'#Invalid action for column [" & f.Name & "]")
    '                End If 'all other actions should be INVALID in this context!
    '            Next

    '            sb.AppendLine()
    '            sb.AppendLine("t.CreateFinalize()")
    '            sb.AppendLine()
    '            'PKs, Indexes, etc...

    '            sb.AppendLine("If t.Opened = False Then t.Open()")
    '            sb.AppendLine()

    '            For Each f As FieldDiff In t.Fields.Values

    '                If f.Identity Then
    '                    sb.AppendLine("t.SetIdentity(""" & f.Name & """, """ & f.IdentityValue & """, " & f.IdentityStep.ToString & ")")
    '                ElseIf f.DefaultValue <> "" Then
    '                    'identities shound't have defaults
    '                    'need to determine if the default value is used in updates some how
    '                    sb.AppendLine("t.SetDefaultValue(""" & f.Name & """, """ & f.DefaultValue & """, False)")

    '                End If
    '            Next

    '            'Indexes
    '            For Each idx As IndexDiff In t.Indexs
    '                sb.AppendLine("If t.IsIndexExists(""" & idx.Name & """) = False Then")
    '                sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, VistaDB.VDBIndexOption." & idx.IndexType.ToString & ", " & idx.Descending.ToString & ", 0)")
    '                sb.AppendLine("End If")
    '            Next

    '            sb.AppendLine()
    '            sb.AppendLine("If t.Opened Then t.Close()")
    '            sb.AppendLine("t = Nothing")
    '            sb.AppendLine("End If")
    '            sb.AppendLine()


    '        Case ICommon.DiffActionTypeEnum.Alter
    '            If t.HasChanges Then
    '                sb.AppendLine("'Table: " & t.TableName)
    '                sb.AppendLine("If db.IsTableExist(""" & t.TableName & """) Then")

    '                sb.AppendLine("t = New VistaDBTable(db, """ & t.TableName & """)")

    '                If t.HasFieldChanges Then 'as may only contain index changes
    '                    sb.AppendLine("t.AlterTable()")

    '                    'columns.. should be either alter,add or drop

    '                    For Each f As FieldDiff In t.Fields.Values
    '                        Select Case f.DiffAction
    '                            Case ICommon.DiffActionTypeEnum.Add
    '                                sb.Append("t.CreateColumn(""")
    '                                sb.Append(f.Name)               'name
    '                                sb.Append(""", ")
    '                                sb.Append(f.DataType.ToString)  'data type
    '                                sb.Append(", ")
    '                                sb.Append(f.Width)              'width
    '                                sb.Append(", ")
    '                                sb.Append(f.Decimals)           'decimals
    '                                sb.Append(", ")
    '                                sb.Append(f.Required.ToString)          'required
    '                                sb.Append(", False, False, False, False, False)")
    '                                sb.Append(Environment.NewLine)
    '                            Case ICommon.DiffActionTypeEnum.Alter
    '                                sb.Append("t.AlterColumn(""")
    '                                sb.Append(f.Name)               'name
    '                                sb.Append(""", ")
    '                                sb.Append(f.DataType.ToString)  'data type
    '                                sb.Append(", ")
    '                                sb.Append(f.Width)              'width
    '                                sb.Append(", ")
    '                                sb.Append(f.Decimals)           'decimals
    '                                sb.Append(", ")
    '                                sb.Append(f.Required)          'required
    '                                sb.Append(", False, False, False, False, False)")
    '                                sb.Append(Environment.NewLine)
    '                            Case ICommon.DiffActionTypeEnum.Drop
    '                                '??
    '                                sb.AppendLine("'Drop Column " & f.Name)
    '                                sb.AppendLine("'t.DropColumn(""" & f.Name & """)")
    '                                'this is not tested, from the looks of the function you need to call this later (outside of alter table()
    '                        End Select

    '                    Next

    '                    sb.AppendLine("t.AlterTableFinalize(True)")
    '                End If

    '                sb.AppendLine()


    '                'set defaults, indexes, keys (after AlterTableFinalize)
    '                'Indexes
    '                For Each idx As IndexDiff In t.Indexs
    '                    sb.AppendLine("If t.IsIndexExists(""" & idx.Name & """) = False Then")
    '                    sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, VistaDB.VDBIndexOption." & idx.IndexType.ToString & ", " & idx.Descending.ToString & ", 0)")
    '                    sb.AppendLine("End If")
    '                    sb.AppendLine()
    '                Next

    '                sb.AppendLine("t = Nothing")
    '                sb.AppendLine("End If 'Table Exists")
    '                sb.AppendLine()
    '            End If


    '        Case ICommon.DiffActionTypeEnum.Drop
    '            sb.Append("'Drop Table [")
    '            sb.Append(t.TableName)
    '            sb.Append("]")
    '            sb.Append(Environment.NewLine)
    '            'returns boolean
    '            sb.AppendLine("db.DropTable(""" & t.TableName & """)")
    '            scriptFileds = False
    '        Case ICommon.DiffActionTypeEnum.None
    '            'fields only
    '            sb.Append("'? Table [")
    '            sb.Append(t.TableName)
    '            sb.Append("]")
    '            sb.Append(Environment.NewLine)
    '    End Select

    '    sb.AppendLine()

    'Next 'table

    'sb.Append(Me.ScriptFooter)
    ''end
    'Return sb.ToString
  End Function

  Public ReadOnly Property ScriptFooter() As String Implements vDBCompare.ICommon.IScripter.ScriptFooter
    Get
      Return Me.CComment("}") & ControlChars.NewLine & _
      Me.CComment("ToDo: PUT YOUR CODE TO UPDATE DB VERSION HERE (Optional)") & ControlChars.NewLine & _
      Me.CComment("e.g. UPDATE tblSettings SET [Value]='123' WHERE [Key]='dbversion'")

      'Dim sb As New System.Text.StringBuilder
      'sb.AppendLine()
      ''sb.AppendLine("Return True")
      ''sb.AppendLine("'End Function")
      'Return sb.ToString
    End Get
  End Property

  Public ReadOnly Property ScriptHeader() As String Implements vDBCompare.ICommon.IScripter.ScriptHeader
    Get
      Dim sb As New System.Text.StringBuilder
      'sb.AppendLine("Public Function UpdateSchema(db as VistaDB.VistaDBDatabase) as Boolean")
      sb.AppendLine(Me.CComment("using VistaDB.DDA;"))
      sb.AppendLine(Me.CComment("Vista DB v3 Code"))
      sb.AppendLine("// Assumes an object db as IVistaDBDatabase is used (and initialized) for the database to be updated.")
      sb.AppendLine("// You should be able to copy this code directly to the body of an UpdateDbSchema function")
      sb.AppendLine()
      sb.AppendLine("IVistaDBTableSchema ts;")
      sb.AppendLine("IVistaDBTable t;")
      sb.AppendLine("System.Collections.ArrayList arTables = db.EnumTables();")
      sb.AppendLine()

      Return sb.ToString
    End Get
  End Property

  Public Function CComment(ByVal comment As String) As String Implements vDBCompare.ICommon.IScripter.CComment
    Return "// " & comment
  End Function

  Public Function CIfTableExists(ByVal tableName As String, ByVal equals As Boolean) As String Implements vDBCompare.ICommon.IScripter.CIfTableExists

    'Return String.Format(IF_TABLE_EXISTS, tableName)
    Return "if (arTables.Contains(""" & tableName & """) == " & equals.ToString.ToLower & ") {"

  End Function

  Public Function CEndIf() As String Implements vDBCompare.ICommon.IScripter.CEndIf
    Return END_IF
  End Function

  Public Function CNewTable(ByVal tableName As String) As String Implements vDBCompare.ICommon.IScripter.CNewTable
    'Return "t = New VistaDBTable(db, """ & tableName & """)"
    Return String.Format(NEW_TABLE, tableName)
  End Function

  Public Function CCreateColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements vDBCompare.ICommon.IScripter.CCreateColumn
    't.CreateColumn("OID", VistaDBType.Int32, 4, 0, True, False, False, False, False, False)
    'Return "t.CreateColumn(""" & columnName & """, " & dataType & ", " & width.ToString & ", 0, True, False, False, False, False, False)"
    'Return String.Format(CREATE_COLUMN, columnName, dataType, width, decimals, required)

    Dim sCreate As String

    sCreate = "ts.AddColumn(""" & columnName & """, " & dataType & ", " & width.ToString & ");" & _
    ControlChars.NewLine & _
    "ts.DefineColumnAttributes(""" & columnName & """, " & required.ToString.ToLower & ", false, false, false, null, null);" & _
    ControlChars.NewLine

    Return sCreate
  End Function

  Public Function COpenTable() As String Implements vDBCompare.ICommon.IScripter.COpenTable
    Return OPEN_TABLE
  End Function

  Public Function CSetIdentity(ByVal columnName As String, ByVal identityValue As String, ByVal identityStep As Double) As String Implements vDBCompare.ICommon.IScripter.CSetIdentity

    't.SetIdentity(""" & f.Name & """, """ & f.IdentityValue & """, " & f.IdentityStep.ToString & ")"
    't.CreateIdentity("OID", "1", "1")
    Return String.Format(SET_IDENTITY, columnName, identityValue, identityStep)
  End Function

  Public Function CSetDefault(ByVal columnName As String, ByVal defaultValue As String, ByVal useInUpdates As Boolean) As Object Implements vDBCompare.ICommon.IScripter.CSetDefault
    't.SetDefaultValue(""" & f.Name & """, """ & f.DefaultValue & """, False)
    Return String.Format(SET_DEFAULT, columnName, defaultValue, useInUpdates)
  End Function

  Public Function CIsIndexExists(ByVal indexName As String) As String Implements vDBCompare.ICommon.IScripter.CIsIndexExists
    'Return String.Format(IS_INDEX_EXISTS, indexName)
    Return "if (!(vDb3UpdateHelper.IsIndexExists(db, ts.Name, """ & indexName & """))) {"

  End Function

  'Public Function CCreateIndex(ByVal indexName As String, ByVal keyExpr As String, ByVal indexOptionType As String, ByVal desc As Boolean, ByVal local As Integer) As String Implements vDBCompare.ICommon.IScripter.CCreateIndex
  '  'local is usually 0
  '  't.CreateIndex("Primary", "OID", bool primary, bool unique);
  '  Return String.Format(CREATE_INDEX, indexName, keyExpr, indexOptionType, desc, False)
  '  'ToDO: check this CCreateIndex c#
  'End Function

  Public Function CCloseTable() As String Implements vDBCompare.ICommon.IScripter.CCloseTable
    Return CLOSE_TABLE
  End Function

  Public Function CSetNothing(ByVal objectName As String) As String Implements vDBCompare.ICommon.IScripter.CSetNothing
    Return objectName & " = null;"
  End Function

  Public Function CAlterColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements vDBCompare.ICommon.IScripter.CAlterColumn
    'ALTER_COLUMN
    'Return String.Format(ALTER_COLUMN, columnName, dataType, width, decimals, required.ToString.ToLower)

    'vdb3 alter column
    'ts = db.TableSchema("tableName")
    'ts.AlterColumnType("Name", VistaDB.VistaDBType.VarChar, 100, 0)
    'ts.DefineColumnAttributes("Name", False, False, False, False, Nothing, Nothing)
    'db.AlterTable(STR_TblTest, ts)

    Return "ts.AlterColumnType(""" & columnName & """, " & dataType & ", " & width.ToString & ", 0);" & ControlChars.NewLine & _
            "ts.DefineColumnAttributes(""" & columnName & """, " & required.ToString.ToLower & ", false, false, false, null, null);" & ControlChars.NewLine


  End Function

  Public Function CDropTable(ByVal tableName As String) As String Implements vDBCompare.ICommon.IScripter.CDropTable
    Return String.Format(DROP_TABLE, tableName)
  End Function

  Public Function CStatement(ByVal code As String) As String Implements vDBCompare.ICommon.IScripter.CStatement
    Return code & ";"
  End Function


  Public Function CIf(ByVal criteriaExpression As String, ByVal resultsIn As Boolean) As String Implements ICommon.IScripter.CIf
    Return "if (" & criteriaExpression & " == " & resultsIn.ToString.ToLower & ")" & ControlChars.NewLine & _
    "  {"
  End Function

  Public Function COpenTable(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTable
    'this applies to vdb3
    Return "t = db.OpenTable(""" & tableName & """, false, false);"
  End Function

  Public Function COpenTableSchema(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTableSchema
    'this applies to vdb3
    Return "ts = db.TableSchema(""" & tableName & """);"
  End Function

  Public ReadOnly Property ScriptRequiredFunctions() As String Implements ICommon.IScripter.ScriptRequiredFunctions
    Get
      Return My.Resources.Code_vdb3UpdateHelper_CS
    End Get
  End Property

  Public Function CCreateIndex(ByVal indexDiff As Object) As String Implements ICommon.IScripter.CCreateIndex
    If TypeOf indexDiff Is IndexDiff Then
      Dim idx As IndexDiff = CType(indexDiff, IndexDiff)
      Return String.Format(CREATE_INDEX, idx.Name, idx.KeyExpr, idx.Descending, idx.Unique)
    Else
      Return ""
    End If
  End Function

End Class
