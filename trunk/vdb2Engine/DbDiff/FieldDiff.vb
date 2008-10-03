Imports VistaDB

Public Class FieldDiff

    Dim ci As VistaDB.VDBColumnInfo
    Dim _FieldDiffType As ICommon.DiffActionTypeEnum
    Dim _IdentityValue As String


    Public Sub New()
        ci = New VDBColumnInfo

    End Sub
    'Public Sub New(ByVal fieldName As String)
    '    ci = New VDBColumnInfo

    '    ci.Name = fieldName

    'End Sub
    Public Sub New(ByVal c As VistaDBColumn, ByVal difType As ICommon.DiffActionTypeEnum)
        ci = New VDBColumnInfo
        _FieldDiffType = difType
        Me.Fill(c)
    End Sub

    Public Property Name() As String
        Get
            Return ci.Name
        End Get
        Set(ByVal value As String)
            ci.Name = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return ci.Width
        End Get
        Set(ByVal value As Integer)
            ci.Width = value
        End Set
    End Property

    Public Property Decimals() As Integer
        Get
            Return ci.Decimals
        End Get
        Set(ByVal value As Integer)
            ci.Decimals = value
        End Set
    End Property

    Public Property Required() As Boolean
        Get
            Return Not ci.AllowNull
        End Get
        Set(ByVal value As Boolean)
            ci.AllowNull = Not value
        End Set
    End Property

    Public Property Identity() As Boolean
        Get
            Return ci.Identity
        End Get
        Set(ByVal value As Boolean)
            ci.Identity = value
        End Set
    End Property

    Public Property IdentityStep() As Double
        Get
            Return ci.IncStep
        End Get
        Set(ByVal value As Double)
            ci.IncStep = value
        End Set
    End Property

    Public Property IdentityValue() As String
        Get
            Return _IdentityValue
        End Get
        Set(ByVal value As String)
            _IdentityValue = value
        End Set
    End Property

    Public Property DefaultValue() As String
        Get
            Return ci.DefValue
        End Get
        Set(ByVal value As String)
            ci.DefValue = value
        End Set
    End Property


    Public Property DataType() As VistaDB.VistaDBType
        Get
            Return ci.DataType
        End Get
        Set(ByVal value As VistaDBType)
            ci.DataType = value
        End Set
    End Property

    Public Property PrimaryKey() As Boolean
        Get
            Return ci.PrimaryKey
        End Get
        Set(ByVal value As Boolean)
            ci.PrimaryKey = value

        End Set
    End Property

    Public Property UseDefaultInUpdate() As Boolean
        Get
            Return ci.UseDefValInUpdate
        End Get
        Set(ByVal value As Boolean)
            ci.UseDefValInUpdate = value
        End Set
    End Property


    Public Property DiffAction() As ICommon.DiffActionTypeEnum
        Get
            Return _FieldDiffType
        End Get
        Set(ByVal value As ICommon.DiffActionTypeEnum)
            _FieldDiffType = value
        End Set
    End Property

    Public Sub Fill(ByVal c As VistaDBColumn)
        FieldDiff.Fill(Me, c)
    End Sub

    Public Shared Sub Fill(ByVal fd As FieldDiff, ByVal c As VistaDBColumn)
        With fd
            .Name = c.Name
            .DataType = c.VistaDBType
            .Width = c.ColumnWidth
            .Decimals = c.ColumnDecimals


            '.AllowNull = c.AllowNull
            .Required = Not c.AllowNull

            .Identity = c.Identity
            If c.PrimaryKey Then
                .PrimaryKey = c.PrimaryKey
                .Required = True
            End If


            .DefaultValue = c.DefaultValue
            .UseDefaultInUpdate = c.UseDefaultInUpdate

        End With
        'If c.PrimaryKey Then

        'End If
        If c.Identity Then
            fd.Identity = c.IdentityValue
            fd.IdentityValue = c.IdentityValue
            fd.IdentityStep = c.IdentityStep
            'initial value ?
        End If
    End Sub

    Public Shared Function FromColumn(ByVal c As VistaDBColumn) As FieldDiff
        If c Is Nothing Then Return Nothing
        Dim fd As New FieldDiff
        FieldDiff.Fill(fd, c)
        Return fd
    End Function

End Class
