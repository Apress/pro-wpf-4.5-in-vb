Imports StoreDatabase
Imports System.Reflection

Public Class ProductByCategoryStyleSelector
    Inherits StyleSelector

    Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
        Dim product As Product = CType(item, Product)
        Dim window As Window = Application.Current.MainWindow

        If product.CategoryName = "Travel" Then
            Return CType(window.FindResource("TravelProductStyle"), Style)
        Else
            Return CType(window.FindResource("DefaultProductStyle"), Style)
        End If
    End Function
End Class

Public Class SingleCriteriaHighlightStyleSelector
    Inherits StyleSelector
    Private _defaultStyle As Style
    Public Property DefaultStyle() As Style
        Get
            Return _defaultStyle
        End Get
        Set(ByVal value As Style)
            _defaultStyle = value
        End Set
    End Property

    Private _highlightStyle As Style
    Public Property HighlightStyle() As Style
        Get
            Return _highlightStyle
        End Get
        Set(ByVal value As Style)
            _highlightStyle = value
        End Set
    End Property

    Private _propertyToEvaluate As String
    Public Property PropertyToEvaluate() As String
        Get
            Return _propertyToEvaluate
        End Get
        Set(ByVal value As String)
            _propertyToEvaluate = value
        End Set
    End Property

    Private _propertyValueToHighlight As String
    Public Property PropertyValueToHighlight() As String
        Get
            Return _propertyValueToHighlight
        End Get
        Set(ByVal value As String)
            _propertyValueToHighlight = value
        End Set
    End Property

    Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
        Dim product As Product = CType(item, Product)

        ' Use reflection to get the property to check.
        Dim type As Type = product.GetType()
        Dim prop As PropertyInfo = type.GetProperty(PropertyToEvaluate)

        ' Decide if this product should be highlighted
        ' based on the property value.
        If prop.GetValue(product, Nothing).ToString() = PropertyValueToHighlight Then
            Return HighlightStyle
        Else
            Return DefaultStyle
        End If
    End Function
End Class



