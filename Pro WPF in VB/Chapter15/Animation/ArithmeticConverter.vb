Imports System.Text.RegularExpressions
Imports System.Windows.Data

Public Class ArithmeticConverter
    Implements IValueConverter

	Private Const ArithmeticParseExpression As String = "([+\-*/]{1,1})\s{0,}(\-?[\d\.]+)"
	Private arithmeticRegex As New Regex(ArithmeticParseExpression)

	Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

		If TypeOf value Is Double AndAlso Not parameter Is Nothing Then
			Dim param As String = parameter.ToString()

			If param.Length > 0 Then
				Dim match As Match = arithmeticRegex.Match(param)
				If Not match Is Nothing AndAlso match.Groups.Count = 3 Then
					Dim operation As String = match.Groups(1).Value.Trim()
					Dim numericValue As String = match.Groups(2).Value

					Dim number As Double = 0
					If Double.TryParse(numericValue, number) Then ' this should always succeed or our regex is broken
						Dim valueAsDouble As Double = CDbl(value)
						Dim returnValue As Double = 0

						Select Case operation
							Case "+"
								returnValue = valueAsDouble + number

							Case "-"
								returnValue = valueAsDouble - number

							Case "*"
								returnValue = valueAsDouble * number

							Case "/"
								returnValue = valueAsDouble / number
						End Select

						Return returnValue
					End If
				End If
			End If
		End If

		Return Nothing
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
		Throw New Exception("The method or operation is not implemented.")
	End Function

End Class