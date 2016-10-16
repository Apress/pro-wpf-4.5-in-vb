Partial Public Class ApplicationCore

    Private documents_Renamed As New List(Of Document)()

    Public Property Documents() As List(Of Document)
        Get
            Return documents_Renamed
        End Get
        Set(ByVal value As List(Of Document))
            documents_Renamed = value
        End Set
    End Property
End Class