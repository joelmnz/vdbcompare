Imports VistaDB
Imports VistaDB.DDA
Imports VistaDB.Provider

Public Class FieldDiff

    'Dim ci As VistaDB.VDBColumnInfo
    'Dim ci As VistaDB.DDA.IVistaDBColumn
    Dim _FieldDiffType As ICommon.DiffActionTypeEnum
    Dim _IdentityValue As String
    Dim _Name As String
    Dim _Width As Integer
    Dim _Decimals As Integer
    Dim _Required As Boolean
    Dim _Identity As Boolean
    Dim _IdentityStep As Double
    Dim _DefaultValue As String
    Dim _DataType As VistaDB.VistaDBType
    Dim _PrimaryKey As Boolean
    Dim _UseDefaultInUpdate As Boolean

    Public Sub New()
        'ci = New VistaDB.VDBColumnInfo
    End Sub
    'Public Sub New(ByVal fieldName As String)
    '    ci = New VDBColumnInfo

    '    ci.Name = fieldName

    'End Sub
    Public Sub New(ByVal c As DDA.IVistaDBColumn, ByVal ts As DDA.IVistaDBTableSchema, ByVal difType As ICommon.DiffActionTypeEnum)
        'ci = New VDBColumnInfo

        _FieldDiffType = difType
        Me.Fill(c, ts)
    End Sub

    'Public Sub New(ByVal columnName As String, ByVal ts As DDA.IVistaDBTableSchema, ByVal difType As ICommon.DiffActionTypeEnum)

    'End Sub

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(ByVal value As Integer)
            _Width = value
        End Set
    End Property

    Public Property Decimals() As Integer
        Get
            Return _Decimals
        End Get
        Set(ByVal value As Integer)
            _Decimals = value
        End Set
    End Property

    Public Property Required() As Boolean
        Get
            Return Not _Required
        End Get
        Set(ByVal value As Boolean)
            _Required = Not value
        End Set
    End Property

    Public Property AllowNull() As Boolean
        Get
            Return _Required
        End Get
        Set(ByVal value As Boolean)
            _Required = value
        End Set
    End Property

    Public Property Identity() As Boolean
        Get
            Return _Identity
        End Get
        Set(ByVal value As Boolean)
            _Identity = value
        End Set
    End Property

    Public Property IdentityStep() As Double
        Get
            Return _IdentityStep
        End Get
        Set(ByVal value As Double)
            _IdentityStep = value
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
            Return _DefaultValue
        End Get
        Set(ByVal value As String)
            _DefaultValue = value
        End Set
    End Property


    Public Property DataType() As VistaDB.VistaDBType
        Get
            Return _DataType
        End Get
        Set(ByVal value As VistaDBType)
            _DataType = value
        End Set
    End Property

    Public Property PrimaryKey() As Boolean
        Get
            Return _PrimaryKey
        End Get
        Set(ByVal value As Boolean)
            _PrimaryKey = value

        End Set
    End Property

    Public Property UseDefaultInUpdate() As Boolean
        Get
            Return _UseDefaultInUpdate
        End Get
        Set(ByVal value As Boolean)
            _UseDefaultInUpdate = value
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

    Public Sub Fill(ByVal c As IVistaDBColumn, ByVal ts As IVistaDBTableSchema)
        FieldDiff.Fill(Me, c, ts)
    End Sub

    Public Shared Sub Fill(ByVal fd As FieldDiff, ByVal c As IVistaDBColumn, ByVal ts As IVistaDBTableSchema)
        With fd
            .Name = c.Name

            .DataType = c.Type

            'If IsNumeric(c.MaxLength) Then
            '    .Width = c.MaxValue
            'End If
            .Width = c.MaxLength

            .Decimals = 0 'c.ColumnDecimals

            .AllowNull = c.AllowNull

            'If c.PrimaryKey Then
            '    .PrimaryKey = c.PrimaryKey
            '    .Required = True
            'End If

            Dim defaultInfo As IVistaDBDefaultValueInformation = ts.Defaults(c.Name)
            If defaultInfo IsNot Nothing Then
                .DefaultValue = defaultInfo.Expression
                .UseDefaultInUpdate = defaultInfo.UseInUpdate
            End If

            Dim identityInfo As IVistaDBIdentityInformation = ts.Identities(c.Name)

            If identityInfo IsNot Nothing Then
                .Identity = True
                .IdentityValue = identityInfo.SeedValue
                .IdentityStep = identityInfo.StepExpression
                'initial value ?
            End If

            Dim idx As IVistaDBIndexInformation = ts.Indexes("")




        End With


    End Sub

    'Public Shared Function FromColumn(ByVal c As IVistaDBColumn) As FieldDiff
    '    If c Is Nothing Then Return Nothing
    '    Dim fd As New FieldDiff
    '    FieldDiff.Fill(fd, c)
    '    Return fd
    'End Function

End Class
