Imports StoreDatabase
Imports System.Reflection

Public Class SingleCriteriaHighlightTemplateSelector
    Inherits DataTemplateSelector

    Private _defaultTemplate As DataTemplate
    Public Property DefaultTemplate() As DataTemplate
        Get
            Return _defaultTemplate
        End Get
        Set(ByVal value As DataTemplate)
            _defaultTemplate = value
        End Set
    End Property

    Private _highlightTemplate As DataTemplate
    Public Property HighlightTemplate() As DataTemplate
        Get
            Return _highlightTemplate
        End Get
        Set(ByVal value As DataTemplate)
            _highlightTemplate = value
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


    Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
        Dim product As Product = CType(item, Product)

        Dim type As Type = product.GetType()
        Dim prop As PropertyInfo = type.GetProperty(PropertyToEvaluate)
        If prop.GetValue(product, Nothing).ToString() = PropertyValueToHighlight Then
            Return HighlightTemplate
        Else
            Return DefaultTemplate
        End If
    End Function

End Class
