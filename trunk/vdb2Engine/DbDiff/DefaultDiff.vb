Public Class DefaultDiff

    't.SetDefaultValue("Income3", "0", False)

    Dim _Name As String
    Dim _sSeed As String
    Dim _UseInUpdates As Boolean
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Public Property sSeed() As String
        Get
            Return _sSeed
        End Get
        Set(ByVal value As String)
            _sSeed = value
        End Set
    End Property
    Public Property UseInUpdates() As Boolean
        Get
            Return _UseInUpdates
        End Get
        Set(ByVal value As Boolean)
            _UseInUpdates = value
        End Set
    End Property

End Class
