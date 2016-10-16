Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class Category
    Implements INotifyPropertyChanged

    Private _categoryName As String
    Public Property CategoryName() As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
            OnPropertyChanged(New PropertyChangedEventArgs("CategoryName"))
        End Set
    End Property

    ' For DataGridComboBoxColumn example.
    Private _categoryID As Integer
    Public Property CategoryID() As Integer
        Get
            Return _categoryID
        End Get
        Set(ByVal value As Integer)
            _categoryID = value
        End Set
    End Property

    Private _products As ObservableCollection(Of Product)
    Public Property Products() As ObservableCollection(Of Product)
        Get
            Return _products
        End Get
        Set(ByVal value As ObservableCollection(Of Product))
            _products = value
            OnPropertyChanged(New PropertyChangedEventArgs("Products"))
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        If Not PropertyChangedEvent Is Nothing Then
            RaiseEvent PropertyChanged(Me, e)
        End If
    End Sub

    Public Sub New(ByVal categoryName As String, ByVal products As ObservableCollection(Of Product))
        Me.CategoryName = categoryName
        Me.Products = products
    End Sub

    Public Sub New(ByVal categoryName As String, ByVal categoryID As Integer)
        Me.CategoryName = categoryName
        Me.CategoryID = categoryID
    End Sub

End Class

