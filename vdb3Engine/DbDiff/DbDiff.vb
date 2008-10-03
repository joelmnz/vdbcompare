'Imports VistaDB

Public Class DbDiff

    Dim _Tables As System.Collections.Generic.Dictionary(Of String, TableDiff)

    Public Sub New()
        _Tables = New System.Collections.Generic.Dictionary(Of String, TableDiff)
    End Sub

    Public ReadOnly Property Tables() As System.Collections.Generic.Dictionary(Of String, TableDiff)
        Get
            Return _Tables
        End Get
    End Property

    Public Function Script(ByVal scriptLang As ICommon.ScriptLanguageEnum, ByVal processIndexes As Boolean) As String
        'Return ScriptEngine.GenerateScript(Me, scriptLang, My.Settings.CodeGen_ProcessIndexes)
        Return vdbScriptEngine.GenerateScript(Me, scriptLang, processIndexes)
    End Function

    Public ReadOnly Property HasChanges() As Boolean
        Get
            If Me.Tables.Count > 0 Then Return True
            Return False
        End Get
    End Property

    Public Function WriteDifferences(ByVal outputTreeview As System.Windows.Forms.TreeView) As Boolean
        Return vdbScriptEngine.OutPutDiff(Me, outputTreeview)
    End Function


End Class
