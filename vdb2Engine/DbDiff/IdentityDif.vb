Public Class IdentityDif

    'Doesn't Require Alter Table
    't.DropIdentity(name as string)
    't.SetIdentity("OID", "1", 1)

    Dim _Name As String
    Dim _Seed As String
    Dim _StepValue As Double


    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Seed() As String
        Get
            Return _Seed
        End Get
        Set(ByVal value As String)
            _Seed = value
        End Set
    End Property

    Public Property StepValue() As Double
        Get
            Return _StepValue
        End Get
        Set(ByVal value As Double)
            _StepValue = value
        End Set
    End Property

End Class
