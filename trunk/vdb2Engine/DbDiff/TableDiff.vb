
Public Class TableDiff

    Dim _TableName As String

    Dim _Fields As System.Collections.Generic.Dictionary(Of String, FieldDiff)
    Dim _Indexs As System.Collections.Generic.List(Of IndexDiff)
    Dim _Defaults As System.Collections.Generic.List(Of DefaultDiff)


    Dim _DiffAction As vDBCompare.ICommon.DiffActionTypeEnum 'DiffActionTypeEnum


    Public Sub New()
        Init()
    End Sub

    Private Sub Init()
        _Fields = New System.Collections.Generic.Dictionary(Of String, FieldDiff)
        _Indexs = New System.Collections.Generic.List(Of IndexDiff)
        _Defaults = New System.Collections.Generic.List(Of DefaultDiff)
        '_Identies = New System.Collections.Generic.List(Of IdentityDif)
    End Sub

    Public Sub New(ByVal tableName As String, ByVal difAction As ICommon.DiffActionTypeEnum)
        Init()

        _TableName = tableName
        _DiffAction = difAction
    End Sub

    Public ReadOnly Property Defaults() As System.Collections.Generic.List(Of DefaultDiff)
        Get
            Return _Defaults
        End Get

    End Property

    Public ReadOnly Property Indexs() As System.Collections.Generic.List(Of IndexDiff)
        Get
            Return _Indexs
        End Get
    End Property
    Public ReadOnly Property Fields() As System.Collections.Generic.Dictionary(Of String, FieldDiff)
        Get
            Return _Fields
        End Get
    End Property




    Public Property TableName() As String
        Get
            Return _TableName
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property

    Public Property DiffAction() As vDBCompare.ICommon.DiffActionTypeEnum
        Get
            Return _DiffAction
        End Get
        Set(ByVal value As ICommon.DiffActionTypeEnum)
            _DiffAction = value
        End Set
    End Property

    Public ReadOnly Property HasChanges() As Boolean
        Get
            If Me.Fields.Count > 0 Then Return True
            If Me.Defaults.Count > 0 Then Return True
            If Me.Indexs.Count > 0 Then Return True
            Return False
        End Get
    End Property

    Public ReadOnly Property HasFieldChanges() As Boolean
        Get
            Return (Me.Fields.Count > 0)
        End Get
    End Property


End Class
