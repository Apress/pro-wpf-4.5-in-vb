Imports System.Windows

Public Class CustomResources
    Public Shared ReadOnly Property SadTileBrush() As ComponentResourceKey
        Get
            Return New ComponentResourceKey(GetType(CustomResources), "SadTileBrush")
        End Get
    End Property
End Class
