
Public Enum ScriptLanguageEnum As Integer
    VbNet = 0
    [Text] = 1 'plain output of what the changes are
    [CSharp] = 2
    VSql = 3    'ToDo: Implement VSql generation
    Delphi = 4  'ToDo: implement Delphi generation

End Enum

Public Enum DiffActionTypeEnum As Integer
    None = 0    'need none for table that has field changes, this case should use Alter!!!
    Add = 1
    Alter = 2
    Drop = 3
End Enum



Public Interface IScriptEngine

    Function GetDifferences(ByVal vdbFile1 As String, ByVal vdbFile2 As String, ByVal processIndexes As Boolean) As Object 'DbDiff

    Function GenerateCreateDatabaseScript(ByVal vdbFile As String, ByVal outputLanguage As ScriptLanguageEnum) As String

    'Function GenerateScript(ByVal differences As DbDiff, ByVal outputLanguage As ScriptLanguageEnum, ByVal processIndexes As Boolean) As String
    Function GenerateScript(ByVal differences As Object, ByVal outputLanguage As ScriptLanguageEnum, ByVal processIndexes As Boolean) As String

End Interface
