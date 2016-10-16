Imports System.Data
Imports System.Collections.ObjectModel

Public Class StoreDB
    Public Function GetProduct(ByVal ID As Integer) As Product
        Dim ds As DataSet = StoreDBDataSet.ReadDataSet()
        Dim productRow As DataRow = ds.Tables("Products").Select("ProductID = " & ID.ToString())(0)
        Dim product As New Product(CStr(productRow("ModelNumber")), CStr(productRow("ModelName")), CDec(productRow("UnitCost")), CStr(productRow("Description")), _
                                   CInt(productRow("CategoryID")), CStr(productRow("CategoryName")), CStr(productRow("ProductImage")))
        Return product
    End Function

    Public Function GetProducts() As ICollection(Of Product)
        Dim ds As DataSet = StoreDBDataSet.ReadDataSet()

        Dim products As ObservableCollection(Of Product) = New ObservableCollection(Of Product)()
        For Each productRow As DataRow In ds.Tables("Products").Rows
            products.Add(New Product(CStr(productRow("ModelNumber")), CStr(productRow("ModelName")), CDec(productRow("UnitCost")), CStr(productRow("Description")), _
                                     CInt(productRow("CategoryID")), CStr(productRow("CategoryName")), CStr(productRow("ProductImage"))))
        Next
        Return products
    End Function

    Public Function GetProductsSlow() As ICollection(Of Product)
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5))
        Return GetProducts()
    End Function

    Public Function GetCategoriesAndProducts() As ICollection(Of Category)
        Dim ds As DataSet = StoreDBDataSet.ReadDataSet()
        Dim relCategoryProduct As DataRelation = ds.Relations(0)

        Dim categories As New ObservableCollection(Of Category)()
        For Each categoryRow As DataRow In ds.Tables("Categories").Rows
            Dim products As ObservableCollection(Of Product) = New ObservableCollection(Of Product)()
            For Each productRow As DataRow In categoryRow.GetChildRows(relCategoryProduct)
                products.Add(New Product(productRow("ModelNumber").ToString(), productRow("ModelName").ToString(), CDec(productRow("UnitCost")), productRow("Description").ToString()))
            Next
            categories.Add(New Category(categoryRow("CategoryName").ToString(), products))
        Next
        Return categories
    End Function

    Public Function GetProductsFilteredWithLinq(ByVal minimumCost As Decimal) As ICollection(Of Product)
        ' Get the full list of products.
        Dim products As ICollection(Of Product) = GetProducts()

        ' Create a second collection with matching products.
        Dim matches As IEnumerable(Of Product)
        matches = From product In products _
                  Where product.UnitCost >= minimumCost _
                  Select product

        Return New ObservableCollection(Of Product)(matches.ToList())
    End Function

    Public Function GetCategories() As ICollection(Of Category)
        Dim ds As DataSet = StoreDbDataSet.ReadDataSet()

        Dim categories As New ObservableCollection(Of Category)()
        For Each categoryRow As DataRow In ds.Tables("Categories").Rows
            categories.Add(New Category(categoryRow("CategoryName").ToString(), CInt(categoryRow("CategoryID"))))
        Next
        Return categories
    End Function

End Class

