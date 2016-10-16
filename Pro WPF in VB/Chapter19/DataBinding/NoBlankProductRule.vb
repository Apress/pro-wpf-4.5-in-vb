Imports StoreDatabase

Public Class NoBlankProductRule
    Inherits ValidationRule

    Public Overloads Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As System.Globalization.CultureInfo) As System.Windows.Controls.ValidationResult
        Dim bindingGroup As BindingGroup = CType(value, BindingGroup)

        ' This product has the original values.
        Dim product As Product = CType(bindingGroup.Items(0), Product)

        ' Check the new values.
        Dim newModelName As String = CStr(bindingGroup.GetValue(product, "ModelName"))
        Dim newModelNumber As String = CStr(bindingGroup.GetValue(product, "ModelNumber"))

        If newModelName = "" And newModelNumber = "" Then
            Return New ValidationResult(False, "A product requires a ModelName or ModelNumber.")
        Else
            Return New ValidationResult(True, Nothing)
        End If
    End Function
End Class
