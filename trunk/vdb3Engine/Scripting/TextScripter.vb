Public Class TextScripter
  Implements vDBCompare.ICommon.IScripter

  Public Function GenerateScript(ByVal differences As Object) As String Implements ICommon.IScripter.GenerateScript
    If differences Is Nothing Then Return "NONE"

    Dim diffObject As DbDiff = CType(differences, DbDiff)

    Dim sb As New System.Text.StringBuilder
    Dim scriptFileds As Boolean = True
    'start

    For Each t As TableDiff In diffObject.Tables.Values
      Select Case t.DiffAction
        Case ICommon.DiffActionTypeEnum.Add
          sb.Append("Create Table [")
          sb.Append(t.TableName)
          sb.Append("]")
          sb.Append(Environment.NewLine)
        Case ICommon.DiffActionTypeEnum.Alter
          sb.Append("Alter Table [")
          sb.Append(t.TableName)
          sb.Append("]")
          sb.Append(Environment.NewLine)
        Case ICommon.DiffActionTypeEnum.Drop
          sb.Append("Drop Table [")
          sb.Append(t.TableName)
          sb.Append("]")
          sb.Append(Environment.NewLine)
          scriptFileds = False
        Case ICommon.DiffActionTypeEnum.None
          'fields only
          sb.Append("Alter Table [")
          sb.Append(t.TableName)
          sb.Append("]")
          sb.Append(Environment.NewLine)
      End Select

      If scriptFileds Then
        For Each f As FieldDiff In t.Fields.Values
          Select Case f.DiffAction
            Case ICommon.DiffActionTypeEnum.Add
              sb.Append("Add Column [")
              sb.Append(f.Name)
              sb.Append("], Type: ")
              sb.Append(f.DataType.ToString)
              sb.Append(", Size: ")
              sb.Append(f.Width)
              If f.Decimals > 0 Then
                sb.Append(", Decimals: ")
                sb.Append(f.Decimals)
              End If

              sb.Append(Environment.NewLine)

            Case ICommon.DiffActionTypeEnum.Alter
              sb.Append("Alter Column [")
              sb.Append(f.Name)
              sb.Append("], Type: ")
              sb.Append(f.DataType.ToString)
              sb.Append(", Size: ")
              sb.Append(f.Width)
              If f.Decimals > 0 Then
                sb.Append(", Decimals: ")
                sb.Append(f.Decimals)
              End If

              sb.Append(Environment.NewLine)
            Case ICommon.DiffActionTypeEnum.Drop
              sb.Append("Drop Column [")
              sb.Append(f.Name)
              sb.Append("]")
              sb.Append(Environment.NewLine)
            Case ICommon.DiffActionTypeEnum.None
              '? this isn't right!
              sb.Append("No action for column [")
              sb.Append(f.Name)
              sb.Append("]")
              sb.Append(Environment.NewLine)
          End Select
        Next
      End If

      sb.AppendLine()
      sb.AppendLine()

    Next 'table

    'end
    Return sb.ToString
  End Function

  Public ReadOnly Property LanguageName() As String Implements ICommon.IScripter.LanguageName
    Get
      Return "Text"
    End Get
  End Property

  Public ReadOnly Property LanguageType() As ICommon.ScriptLanguageEnum Implements ICommon.IScripter.LanguageType
    Get
      Return ICommon.ScriptLanguageEnum.Text
    End Get
  End Property

  Public ReadOnly Property ScriptFooter() As String Implements ICommon.IScripter.ScriptFooter
    Get
      Return ""
    End Get
  End Property

  Public ReadOnly Property ScriptHeader() As String Implements ICommon.IScripter.ScriptHeader
    Get
      Return ""
    End Get
  End Property

  Public Function CComment(ByVal comment As String) As String Implements ICommon.IScripter.CComment
    Return comment
  End Function

  Public Function CIfTableExists(ByVal tableName As String, ByVal equals As Boolean) As String Implements ICommon.IScripter.CIfTableExists
    Return tableName
  End Function

  Public Function CEndIf() As String Implements ICommon.IScripter.CEndIf
    Return ""
  End Function

  Public Function CNewTable(ByVal tableName As String) As String Implements ICommon.IScripter.CNewTable
    Return ""
  End Function

  Public Function CCreateColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements ICommon.IScripter.CCreateColumn
    Return "Create Column [" & columnName & "]"
  End Function

  Public Function COpenTable() As String Implements ICommon.IScripter.COpenTable
    Return ""
  End Function

  Public Function CSetIdentity(ByVal columnName As String, ByVal identityValue As String, ByVal identityStep As Double) As String Implements ICommon.IScripter.CSetIdentity
    Return "Identity Column : " & columnName
  End Function

	Public Function CSetDefault(ByVal columnName As String, ByVal defaultValue As String, ByVal useInUpdates As Boolean) As String Implements ICommon.IScripter.CSetDefault
		Return "Default: " & columnName & " = " & defaultValue
	End Function

  Public Function CIsIndexExists(ByVal indexName As String) As String Implements ICommon.IScripter.CIsIndexExists
    Return ""
  End Function

  'Public Function CCreateIndex(ByVal indexName As String, ByVal keyExpr As String, ByVal indexOptionType As String, ByVal desc As Boolean, ByVal local As Integer) As String Implements ICommon.IScripter.CCreateIndex
  '  Return "Index: " & indexName
  'End Function

  Public Function CCloseTable() As String Implements ICommon.IScripter.CCloseTable
    Return ""
  End Function

  Public Function CSetNothing(ByVal objectName As String) As String Implements ICommon.IScripter.CSetNothing
    Return ""
  End Function

  Public Function CAlterColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String Implements ICommon.IScripter.CAlterColumn
    Return "Alter Column " & columnName
  End Function

  Public Function CDropTable(ByVal tableName As String) As String Implements ICommon.IScripter.CDropTable
    Return "Drop Table: " & tableName
  End Function

  Public Function CStatement(ByVal code As String) As String Implements ICommon.IScripter.CStatement
    Return ""
  End Function

  Public Function CIf(ByVal criteriaExpression As String, ByVal resultsIn As Boolean) As String Implements ICommon.IScripter.CIf
    Return ""
  End Function

  Public Function COpenTable(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTable
    Return ""
  End Function

  Public Function COpenTableSchema(ByVal tableName As String) As String Implements ICommon.IScripter.COpenTableSchema
    Return ""
  End Function

  Public ReadOnly Property ScriptRequiredFunctions() As String Implements ICommon.IScripter.ScriptRequiredFunctions
    Get
      Return ""
    End Get
  End Property

  Public Function CCreateIndex(ByVal index As Object) As String Implements ICommon.IScripter.CCreateIndex
    If TypeOf index Is IndexDiff Then
      Return "Index: " & CType(index, IndexDiff).Name
    Else
      Return ""
    End If
  End Function

End Class
