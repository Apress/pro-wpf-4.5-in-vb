Imports System.ComponentModel
Imports StoreDatabase

Public Class FilterCollection

    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products

        Dim view As ICollectionView = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource)
        view.SortDescriptions.Add(New SortDescription("ModelName", ListSortDirection.Ascending))

        Dim lcview As ListCollectionView = CType(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), ListCollectionView)
        ' Now if you edit and reduce the price (below the filter condition) the record will disappear automatically.
        lcview.IsLiveFiltering = True
        lcview.LiveFilteringProperties.Add("UnitCost")

        'view.GroupDescriptions.Add(New PropertyGroupDescription("CategoryName"))

        'Dim view As ListCollectionView = CType(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), ListCollectionView)
        'view.CustomSort = New SortByModelNameLength()

    End Sub

    Private Sub cmdFilter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim minimumPrice As Decimal
        If Decimal.TryParse(txtMinPrice.Text, minimumPrice) Then
            Dim view As ListCollectionView = TryCast(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), ListCollectionView)

            If view IsNot Nothing Then
                filterer = New ProductByPriceFilterer(minimumPrice)
                view.Filter = New Predicate(Of Object)(AddressOf filterer.FilterItem)
            End If
        End If
    End Sub

    Private Sub cmdRemoveFilter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim view As ListCollectionView = TryCast(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), ListCollectionView)
        If Not view Is Nothing Then
            view.Filter = Nothing
        End If
    End Sub

    Private filterer As ProductByPriceFilterer

    Private Sub txtMinPrice_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Dim view As ListCollectionView = TryCast(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), ListCollectionView)
        If Not view Is Nothing Then
            Dim minimumPrice As Decimal
            If Decimal.TryParse(txtMinPrice.Text, minimumPrice) AndAlso (filterer IsNot Nothing) Then
                filterer.MinimumPrice = minimumPrice
                view.Refresh()
            End If
        End If
    End Sub

End Class

Public Class ProductByPriceFilterer
    Private _minimumPrice As Decimal

    Public Property MinimumPrice() As Decimal
        Get
            Return _minimumPrice
        End Get
        Set(ByVal value As Decimal)
            _minimumPrice = value
        End Set
    End Property

	Public Sub New(ByVal minimumPrice As Decimal)
		Me.MinimumPrice = minimumPrice
	End Sub

	Public Function FilterItem(ByVal item As Object) As Boolean
		Dim product As Product = TryCast(item, Product)
        If product IsNot Nothing Then
            If product.UnitCost > MinimumPrice Then
                Return True
            End If
        End If
		Return False
	End Function
End Class

Public Class SortByModelNameLength
    Implements System.Collections.IComparer

	Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
		Dim productX As Product = CType(x, Product)
		Dim productY As Product = CType(y, Product)
		Return productX.ModelName.Length.CompareTo(productY.ModelName.Length)
	End Function
End Class


