Imports System.Data

Public Class StoreDBDataSet
    Public Function GetProducts() As DataTable
        Return StoreDBDataSet.ReadDataSet().Tables(0)
    End Function

    Public Function GetCategoriesAndProducts() As DataSet
        Return StoreDBDataSet.ReadDataSet()
    End Function

    Friend Shared Function ReadDataSet() As DataSet
        Dim ds As New DataSet()
        ds.ReadXmlSchema("store.xsd")
        ds.ReadXml("store.xml")
        Return ds
    End Function

End Class
