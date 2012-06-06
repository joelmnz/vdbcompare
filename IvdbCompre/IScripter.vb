Public Interface IScripter

	ReadOnly Property LanguageName() As String
	ReadOnly Property LanguageType() As ScriptLanguageEnum
	'Function GenerateScript(ByVal differences As DbDiff) As String
	Function GenerateScript(ByVal differences As Object) As String

	ReadOnly Property ScriptHeader() As String
	ReadOnly Property ScriptFooter() As String
	ReadOnly Property ScriptRequiredFunctions() As String

	'trying to be universal, lets see how this turns out.

	Function CComment(ByVal comment As String) As String
	Function CIfTableExists(ByVal tableName As String, ByVal equals As Boolean) As String
	Function CIf(ByVal criteriaExpression As String, ByVal resultsIn As Boolean) As String
	Function CEndIf() As String
	Function CNewTable(ByVal tableName As String) As String
	Function CCreateColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String
	Function CAlterColumn(ByVal columnName As String, ByVal dataType As String, ByVal width As Integer, ByVal decimals As Integer, ByVal required As Boolean) As String

	Function COpenTable() As String
	Function COpenTable(ByVal tableName As String) As String
	Function COpenTableSchema(ByVal tableName As String) As String
	Function CCloseTable() As String
	Function CSetIdentity(ByVal columnName As String, ByVal identityValue As String, ByVal identityStep As Double) As String
	Function CSetDefault(ByVal columnName As String, ByVal defaultValue As String, ByVal useInUpdates As Boolean) As String
	Function CIsIndexExists(ByVal indexName As String) As String
	'Function CCreateIndex(ByVal indexName As String, ByVal keyExpr As String, ByVal indexOptionType As String, ByVal desc As Boolean, ByVal local As Integer) As String
	Function CCreateIndex(ByVal indexDiff As Object) As String
	Function CSetNothing(ByVal objectName As String) As String
	Function CDropTable(ByVal tableName As String) As String
	Function CStatement(ByVal code As String) As String

End Interface
