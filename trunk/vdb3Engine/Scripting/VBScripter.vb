Public Class VBScripter
  Implements vDBCompare.ICommon.IScripter

  Private Const PRIMARY_KEY As String = "PRIMARY_KEY"
  Private Const IF_TABLE_EXISTS As String = "If arTables.Contains(""{0}"") = {1} Then" '"If db.IsTableExist(""{0}"") = False Then"
  Private Const END_IF As String = "End If"
  Private Const NEW_TABLE As String = "ts = db.NewTable(""{0}"")" '"t = New VistaDBTable(db,""{0}"")"
  Private Const OPEN_TABLE As String = "If t.Opened = False Then t.Open()"
  Private Const CREATE_COLUMN As String = "ts.AddColumn(""{0}"",{1})" '"t.CreateColumn(""{0}"", {1}, {2}, {3}, {4}, False, False, False, False, False)"
  Private Const ALTER_COLUMN As String = "t.AlterColumn(""{0}"", {1}, {2}, {3}, {4}, False, False, False, False, False)"
  Private Const SET_IDENTITY As String = "t.CreateIdentity(""{0}"", ""{1}"", {2})"
  Private Const SET_DEFAULT As String = "t.CreateDefaultValue(""{0}"", ""{1}"", {2})"
  Private Const IS_INDEX_EXISTS As String = "If vDb3UpdateHelper.IsIndexExists(db, ts.Name, ""{0}"") = False Then"
  Private Const CREATE_INDEX As String = "ts.DefineIndex(""{0}"", ""{1}"", {2}, {3})" ', {4})"
  Private Const CLOSE_TABLE As String = "If t.IsClosed = False Then t.Close()"
  Private Const DROP_TABLE As String = "db.DropTable(""{0}"")" 'db.DropTable("table")


  Public ReadOnly Property LanguageName() As String Implements ICommon.IScripter.LanguageName
    Get
      Return "VB.NET"
    End Get
  End Property

  Public ReadOnly Property LanguageType() As ICommon.ScriptLanguageEnum Implements ICommon.IScripter.LanguageType
    Get
      Return ICommon.ScriptLanguageEnum.VbNet
    End Get
  End Property

  Public Function GenerateScript(ByVal differences As Object) As String Implements ICommon.IScripter.GenerateScript
    If differences Is Nothing Then Return "NONE"

    Return "VB.NET Script for vdb3 not done, please check for updates."

    'If Not TypeOf differences Is DbDiff Then
    '  Return "differences supplied to generate script are not of expected type."
    'End If

    'Dim diffObject As DbDiff = CType(differences, DbDiff)

    'Dim sb As New System.Text.StringBuilder
    'Dim scriptFileds As Boolean = True
    ''start

    'sb.Append(Me.ScriptHeader)

    'For Each t As TableDiff In diffObject.Tables.Values
    '  Select Case t.DiffAction
    '    Case ICommon.DiffActionTypeEnum.Add
    '      sb.AppendLine("'Table: " & t.TableName)
    '      sb.AppendLine("If db.IsTableExist(""" & t.TableName & """) = False Then")

    '      sb.AppendLine("t = New VistaDBTable(db, """ & t.TableName & """)")
    '      sb.AppendLine()
    '      sb.AppendLine("t.CreateNew()")
    '      sb.AppendLine()
    '      sb.AppendLine("'Columns") 'should only ever be adding columns

    '      For Each f As FieldDiff In t.Fields.Values
    '        If f.DiffAction = ICommon.DiffActionTypeEnum.Add Then
    '          't.CreateColumn("Sys_Id", VistaDBType.Guid, 16, 0, True, False, False, False, False, False)
    '          sb.Append("t.CreateColumn(""")
    '          sb.Append(f.Name)               'name
    '          sb.Append(""", VistaDBType.")
    '          sb.Append(f.DataType.ToString)  'data type
    '          sb.Append(", ")
    '          sb.Append(f.Width)              'width
    '          sb.Append(", ")
    '          sb.Append(f.Decimals)           'decimals
    '          sb.Append(", ")
    '          'PK can NOT be null!!!
    '          If f.PrimaryKey Then
    '            sb.Append("True")
    '          Else
    '            sb.Append(f.Required.ToString)          'required
    '          End If
    '          sb.Append(", False, False, False, False, False)")


    '          sb.Append(Environment.NewLine)
    '        Else
    '          sb.AppendLine("'#Invalid action for column [" & f.Name & "]")
    '        End If 'all other actions should be INVALID in this context!
    '      Next

    '      sb.AppendLine()
    '      sb.AppendLine("t.CreateFinalize()")
    '      sb.AppendLine()
    '      'PKs, Indexes, etc...

    '      sb.AppendLine("If t.Opened = False Then t.Open()")
    '      sb.AppendLine()

    '      For Each f As FieldDiff In t.Fields.Values

    '        If f.Identity Then
    '          sb.AppendLine("t.SetIdentity(""" & f.Name & """, """ & f.IdentityValue & """, " & f.IdentityStep.ToString & ")")
    '        ElseIf f.DefaultValue <> "" Then
    '          'identities shound't have defaults
    '          'need to determine if the default value is used in updates some how
    '          sb.AppendLine("t.SetDefaultValue(""" & f.Name & """, """ & f.DefaultValue & """, False)")

    '        End If
    '      Next

    '      'Indexes
    '      For Each idx As IndexDiff In t.Indexs

    '        sb.AppendLine("If t.IsIndexExists(""" & idx.Name & """) = False Then")
    '        'sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, VistaDB.VDBIndexOption." & idx.IndexType.ToString & ", " & idx.Descending.ToString & ", 0)")
    '        sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, " & idx.Primary.ToString & ", " & idx.Unique & ")")
    '        sb.AppendLine("End If")
    '      Next

    '      sb.AppendLine()
    '      sb.AppendLine("If t.Opened Then t.Close()")
    '      sb.AppendLine("t = Nothing")
    '      sb.AppendLine("End If")
    '      sb.AppendLine()


    '    Case ICommon.DiffActionTypeEnum.Alter
    '      If t.HasChanges Then
    '        sb.AppendLine("'Table: " & t.TableName)
    '        sb.AppendLine("If db.IsTableExist(""" & t.TableName & """) Then")

    '        sb.AppendLine("t = New VistaDBTable(db, """ & t.TableName & """)")

    '        If t.HasFieldChanges Then 'as may only contain index changes
    '          sb.AppendLine("t.AlterTable()")

    '          'columns.. should be either alter,add or drop

    '          For Each f As FieldDiff In t.Fields.Values
    '            Select Case f.DiffAction
    '              Case ICommon.DiffActionTypeEnum.Add
    '                sb.Append("t.CreateColumn(""")
    '                sb.Append(f.Name)               'name
    '                sb.Append(""", ")
    '                sb.Append(f.DataType.ToString)  'data type
    '                sb.Append(", ")
    '                sb.Append(f.Width)              'width
    '                sb.Append(", ")
    '                sb.Append(f.Decimals)           'decimals
    '                sb.Append(", ")
    '                sb.Append(f.Required.ToString)          'required
    '                sb.Append(", False, False, False, False, False)")
    '                sb.Append(Environment.NewLine)
    '              Case ICommon.DiffActionTypeEnum.Alter
    '                sb.Append("t.AlterColumn(""")
    '                sb.Append(f.Name)               'name
    '                sb.Append(""", ")
    '                sb.Append(f.DataType.ToString)  'data type
    '                sb.Append(", ")
    '                sb.Append(f.Width)              'width
    '                sb.Append(", ")
    '                sb.Append(f.Decimals)           'decimals
    '                sb.Append(", ")
    '                sb.Append(f.Required)          'required
    '                sb.Append(", False, False, False, False, False)")
    '                sb.Append(Environment.NewLine)
    '              Case ICommon.DiffActionTypeEnum.Drop
    '                '??
    '                sb.AppendLine("'Drop Column " & f.Name)
    '                sb.AppendLine("'t.DropColumn(""" & f.Name & """)")
    '                'this is not tested, from the looks of the function you need to call this later (outside of alter table()
    '            End Select

    '          Next

    '          sb.AppendLine("t.AlterTableFinalize(True)")
    '        End If

    '        sb.AppendLine()


    '        'set defaults, indexes, keys (after AlterTableFinalize)
    '        'Indexes
    '        For Each idx As IndexDiff In t.Indexs
    '          sb.AppendLine("If t.IsIndexExists(""" & idx.Name & """) = False Then")
    '          'sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, VistaDB.VDBIndexOption." & idx.IndexType.ToString & ", " & idx.Descending.ToString & ", 0)")
    '          sb.AppendLine("t.CreateIndex(""" & idx.Name & """, """ & idx.KeyExpr & """, " & idx.Primary.ToString & ", " & idx.Unique & ")")
    '          sb.AppendLine("End If")
    '          sb.AppendLine()
    '        Next

    '        sb.AppendLine("t = Nothing")
    '        sb.AppendLine("End If 'Table Exists")
    '        sb.AppendLine()
    '      End If


    '    Case ICommon.DiffActionTypeEnum.Drop
    '      sb.Append("'Drop Table [")
    '      sb.Append(t.TableName)
    '      sb.Append("]")
    '      sb.Append(Environment.NewLine)
    '      'returns boolean
    '      sb.AppendLine("db.DropTable(""" & t.TableName & """)")
    '      scriptFileds = False
    '    Case ICommon.DiffActionTypeEnum.None
    '      'fields only
    '      sb.Append("'? Table [")
    '      sb.Append(t.TableName)
    '      sb.Append("]")
    '      sb.Append(Environment.NewLine)
    '  End Select

    '  sb.AppendLine()

    'Next 'table

    'sb.Append(Me.ScriptFooter)


    ''end
    'Return sb.ToString
  End Function

  Public ReadOnly Property ScriptFooter() As String Implements ICommon.IScripter.ScriptFooter
    Get
      Dim sb As New System.Text.StringBuilder
      sb.AppendLine()
      'sb.AppendLine("Return True")
      sb.AppendLine("'End Function")
      sb.AppendLine()
      sb.AppendLine("'ToDo: PUT YOUR CODE TO UPDATE DB VERSION HERE (Optional)")
      sb.AppendLine("'e.g. UPDATE tblSettings SET [Value]='123' WHERE [Key]='dbversion'")
      Return sb.ToString
    End Get
  End Property

  Public ReadOnly Property ScriptHeader() As String Implements ICommon.IScripter.ScriptHeader
    Get
      Dim sb As New System.Text.StringBuilder
      'sb.AppendLine("Public Function UpdateSchema(db as VistaDB.VistaDBDatabase) as Boolean")
      sb.AppendLine("'Imports VistaDB.DDA")
      sb.AppendLine("'Vista DB v3 Code")
      sb.AppendLine("'Assumes an object db as VistaDB.VistaDBDatabase is used (and initilized) for the database to be updated.")
      sb.AppendLine("'You should be able to copy this code directly to the body of an UpdateDbSchema function")
      sb.AppendLine("'e.g.  ")
      sb.AppendLine("'Function UpdateDbSchema(db as IVistaDBDatabase) as Boolean")
      sb.AppendLine("    Dim ts As IVistaDBTableSchema")
      sb.AppendLine("    Dim t As IVistaDBTable")
      sb.AppendLine("    Dim arTables as ArrayList = db.EnumTables")
      'sb.AppendLine("If db.Mode <> VistaDBDatabaseOpenMode.ExclusiveReadWrite Then")
      'sb.AppendLine("'make it exclusive")
      'sb.AppendLine("End If")
      sb.AppendLine()
      sb.AppendLine()
      Return sb.ToString
    End Get
  End Property

  Public Function CComment(ByVal comment As String) As String Implements ICommon.IScripter.CComment
    Return "' " & comment
  End Function

  Public Function CIfTableExists(ByVal tableName As String, ByVal equals As Boolean) As String Implements ICommon.IScripter.CIfTableExists
    'Return "If db.IsTableExist(""" & tableName & """) = False Then"
    Return String.Format(IF_TABLE_EXISTS, tableName, equals)
  End Function

  Public Function CEndIf() As String Implements ICommon.IScripter.CEndIf
    Return END_IF
  End Function

  Public Function CNewTable(ByVal tableName As String) As String Implements ICommon.IScripter.CNewTable
    'Return "t = New VistaDBTable(db, """ & tableName & """)"
    Return String.Format(NEW_TABLE, tableName)
  End Function

  Public Function CCreateColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements ICommon.IScripter.CCreateColumn
    't.CreateColumn("OID", VistaDBType.Int32, 4, 0, True, False, False, False, False, False)
    'Return "t.CreateColumn(""" & columnName & """, " & dataType & ", " & width.ToString & ", 0, True, False, False, False, False, False)"
    'Return String.Format(CREATE_COLUMN, columnName, dataType, width, decimals, required)

    'VistaDB 3 Syntax
    'ts.AddColumn("OID", VistaDB.VistaDBType.Int)
    'ts.DefineColumnAttributes("OID", False, False, False, False, "OID", "Object Id Column")
    'DefineColumnAttributes(name, allowNull, readOnly, encrypted, packed, caption, description)
    Dim sCreate As String

    sCreate = "ts.AddColumn(""" & columnName & """, " & dataType & ", " & width.ToString & ")" & _
    ControlChars.NewLine & _
    "ts.DefineColumnAttributes(""" & columnName & """, " & required.ToString & ", False, False, False, Nothing, Nothing)" & ControlChars.NewLine

    Return sCreate
  End Function

  Public Function COpenTable() As String Implements ICommon.IScripter.COpenTable
    Return OPEN_TABLE
  End Function

  Public Function CSetIdentity(ByVal columnName As String, ByVal identityValue As String, ByVal identityStep As Double) As String Implements ICommon.IScripter.CSetIdentity

    't.CreateIdentity("OID", "1", "1")
    Return String.Format(SET_IDENTITY, columnName, identityValue, identityStep)
  End Function

  Public Function CSetDefault(ByVal columnName As String, ByVal defaultValue As String, ByVal useInUpdates As Boolean) As Object Implements ICommon.IScripter.CSetDefault
    't.CreateDefaultValue("ColumnName", "0", False, Nothing)
    Return String.Format(SET_DEFAULT, columnName, defaultValue, useInUpdates)
  End Function

  Public Function CIsIndexExists(ByVal indexName As String) As String Implements ICommon.IScripter.CIsIndexExists
    Return String.Format(IS_INDEX_EXISTS, indexName)
  End Function

  'Public Function CCreateIndex(ByVal indexName As String, ByVal keyExpr As String, ByVal indexOptionType As String, ByVal desc As Boolean, ByVal local As Integer) As String Implements ICommon.IScripter.CCreateIndex
  '  'local is usually 0
  '  Return String.Format(CREATE_INDEX, indexName, keyExpr, indexOptionType, desc, local)
  'End Function

  Public Function CCloseTable() As String Implements ICommon.IScripter.CCloseTable
    Return CLOSE_TABLE
  End Function

  Public Function CSetNothing(ByVal objectName As String) As String Implements ICommon.IScripter.CSetNothing
    Return objectName & " = Nothing"
  End Function

  Public Function CAlterColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements ICommon.IScripter.CAlterColumn
    'ALTER_COLUMN
    'Return String.Format(ALTER_COLUMN, columnName, dataType, width, decimals, required)

    'vdb3 alter column
    'ts = db.TableSchema("tableName")
    'ts.AlterColumnType("Name", VistaDB.VistaDBType.VarChar, 100, 0)
    'ts.DefineColumnAttributes("Name", False, False, False, False, Nothing, Nothing)
    'db.AlterTable(STR_TblTest, ts)

    'ts should already be defined & fetched from the db TableSchema()
    Return "ts.AlterColumnType(""" & columnName & """, " & dataType & ", " & width.ToString & ", 0)" & ControlChars.NewLine & _
    "ts.DefineColumnAttributes(""" & columnName & """, " & required.ToString & ", False, False, False, Nothing, Nothing)" & ControlChars.NewLine

    'when does the db.AlterTable get called? = should be after the alter column loops

    '<<<--------------------------------------------- //////////////////
    'ToDo: up to here, need to use new vdb3 format
    'ts.AlterColumn(...

  End Function

  Public Function CDropTable(ByVal tableName As String) As String Implements ICommon.IScripter.CDropTable
    Return String.Format(DROP_TABLE, tableName)
  End Function

  Public Function CStatement(ByVal code As String) As String Implements ICommon.IScripter.CStatement
    Return code
  End Function

  Public Function CIf(ByVal criteriaExpression As String, ByVal resultsIn As Boolean) As String Implements ICommon.IScripter.CIf
    Return "If " & criteriaExpression & " = " & resultsIn.ToString & " Then"
  End Function

  Public Function COpenTable(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTable
    Return "t = db.OpenTable(""" & tableName & """, False, False)"
  End Function

  Public Function COpenTableSchema(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTableSchema
    Return "ts = db.TableSchema(""" & tableName & """)"
  End Function

  Public ReadOnly Property ScriptRequiredFunctions() As String Implements ICommon.IScripter.ScriptRequiredFunctions
    Get
      'ToDo: vb ScriptRequiredFunctions
      Return My.Resources.Code_vbd3UpdateHelper_VB
    End Get
  End Property

  Public Function CCreateIndex(ByVal indexDiff As Object) As String Implements ICommon.IScripter.CCreateIndex
    If TypeOf indexDiff Is IndexDiff Then
      Dim idx As IndexDiff = CType(indexDiff, IndexDiff)
      Return String.Format(CREATE_INDEX, idx.Name, idx.KeyExpr, idx.Primary, idx.Unique)
    Else
      Return ""
    End If
  End Function

End Class
