Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Linq

Public Class StoreDB
    Private connectionString As String = My.Settings.Default.Store

	Public Function GetProduct(ByVal ID As Integer) As Product
		Dim con As New SqlConnection(connectionString)
		Dim cmd As New SqlCommand("GetProductByID", con)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.AddWithValue("@ProductID", ID)

		Try
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
			If reader.Read() Then
				' Create a Product object that wraps the 
				' current record.
                Dim product As New Product(CStr(reader("ModelNumber")), CStr(reader("ModelName")), CDec(reader("UnitCost")), CStr(reader("Description")), _
                                                       CInt(reader("CategoryID")), CStr(reader("CategoryName")), CStr(reader("ProductImage")))
				Return product
			Else
				Return Nothing
			End If
		Finally
			con.Close()
		End Try
	End Function

	Public Function GetProducts() As ICollection(Of Product)
		Dim con As New SqlConnection(connectionString)
		Dim cmd As New SqlCommand("GetProducts", con)
		cmd.CommandType = CommandType.StoredProcedure

        Dim products As New ObservableCollection(Of Product)()
		Try
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()
			Do While reader.Read()
				' Create a Product object that wraps the 
				' current record.
                Dim product As New Product(CStr(reader("ModelNumber")), CStr(reader("ModelName")), CDec(reader("UnitCost")), CStr(reader("Description")), _
                                           CInt(reader("CategoryID")), CStr(reader("CategoryName")), CStr(reader("ProductImage")))
				' Add to collection
				products.Add(product)
			Loop
		Finally
			con.Close()
		End Try

		Return products
	End Function

	Public Function GetProductsSlow() As ICollection(Of Product)
		System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5))
		Return GetProducts()
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

	Public Function GetCategoriesAndProducts() As ICollection(Of Category)
		Dim con As New SqlConnection(connectionString)
		Dim cmd As New SqlCommand("GetProducts", con)
		cmd.CommandType = CommandType.StoredProcedure
		Dim adapter As New SqlDataAdapter(cmd)

		Dim ds As New DataSet()
		adapter.Fill(ds, "Products")
		cmd.CommandText = "GetCategories"
		adapter.Fill(ds, "Categories")

		' Set up a relation between these tables (optional).
		Dim relCategoryProduct As New DataRelation("CategoryProduct", ds.Tables("Categories").Columns("CategoryID"), ds.Tables("Products").Columns("CategoryID"))
		ds.Relations.Add(relCategoryProduct)

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

    Public Function GetCategories() As ICollection(Of Category)
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("GetCategories", con)
        cmd.CommandType = CommandType.StoredProcedure

        Dim categories As New ObservableCollection(Of Category)()
        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Do While reader.Read()
                ' Create a Category object that wraps the 
                ' current record.
                Dim category As New Category(CStr(reader("CategoryName")), CInt(reader("CategoryID")))
                ' Add to collection
                categories.Add(Category)
            Loop
        Finally
            con.Close()
        End Try

        Return categories
    End Function

End Class

