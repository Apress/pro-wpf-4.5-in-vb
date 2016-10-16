Imports System.Globalization

Public Class PositivePriceRule
	Inherits ValidationRule
    Private _min As Decimal = 0
    Private _max As Decimal = Decimal.MaxValue

    Public Property Min() As Decimal
        Get
            Return _min
        End Get
        Set(ByVal value As Decimal)
            _min = value
        End Set
    End Property

    Public Property Max() As Decimal
        Get
            Return _max
        End Get
        Set(ByVal value As Decimal)
            _max = value
        End Set
    End Property


	Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
		Dim price As Decimal = 0

		Try
			If (CStr(value)).Length > 0 Then
				' Allow number styles with currency symbols like $.
				price = Decimal.Parse(CStr(value), System.Globalization.NumberStyles.Any)
			End If
		Catch e As Exception
			Return New ValidationResult(False, "Illegal characters.")
		End Try

		If (price < Min) OrElse (price > Max) Then
			Return New ValidationResult(False, "Not in the range " & Min & " to " & Max & ".")
		Else
			Return New ValidationResult(True, Nothing)
		End If
	End Function
End Class
