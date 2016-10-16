Imports System.Data
Imports System.Data.SqlClient

Public Class StoreDBDataSet
    Private connectionString As String = Settings.Default.Store

    Public Function GetProducts() As DataTable
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("GetProducts", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim adapter As New SqlDataAdapter(cmd)

        Dim ds As New DataSet()
        adapter.Fill(ds, "Products")
        Return ds.Tables(0)
    End Function

    Public Function GetCategoriesAndProducts() As DataSet
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

        Return ds
    End Function


End Class
