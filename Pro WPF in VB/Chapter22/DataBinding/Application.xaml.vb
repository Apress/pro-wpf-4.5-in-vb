Imports StoreDatabase

Public Class Application

    Private Shared _storeDB As New StoreDB()
    Public Shared ReadOnly Property StoreDB() As StoreDB
        Get
            Return _storeDB
        End Get
    End Property

    Private Shared _storeDBDataSet As New StoreDBDataSet()
    Public Shared ReadOnly Property StoreDBDataSet() As StoreDBDataSet
        Get
            Return _storeDBDataSet
        End Get
    End Property
End Class