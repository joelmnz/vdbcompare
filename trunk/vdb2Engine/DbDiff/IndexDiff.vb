Public Class IndexDiff

    't.CreateIndex("PRIMARY_KEY", "OID", VistaDB.VDBIndexOption.Primary, False, 0)

    Dim _Name As String
    Dim _KeyExpr As String
    Dim _IndexType As VistaDB.VDBIndexOption
    Dim _Desc As Boolean

    'If indexInfo.bPrimary Then
    '    .Append(""", VistaDB.VDBIndexOption.Primary, ")
    'ElseIf indexInfo.bUnique Then
    '    .Append(""", VistaDB.VDBIndexOption.Unique, ")
    'ElseIf indexInfo.bStandardIndex Then
    '    .Append(""", VistaDB.VDBIndexOption.Standard, ")
    'End If

    Public Property IndexType() As VistaDB.VDBIndexOption
        Get
            Return _IndexType
        End Get
        Set(ByVal value As VistaDB.VDBIndexOption)
            _IndexType = value
        End Set
    End Property

    Public Property Descending() As Boolean
        Get
            Return _Desc
        End Get
        Set(ByVal value As Boolean)
            _Desc = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property KeyExpr() As String
        Get
            Return _KeyExpr
        End Get
        Set(ByVal value As String)
            _KeyExpr = value
        End Set
    End Property


End Class
