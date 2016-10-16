Public Class SelectProductPageFunction

    Private Sub lnkOK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Return the selection information.
        Dim item As ListBoxItem = CType(lstProducts.SelectedItem, ListBoxItem)
        Dim product As New Product(item.Content.ToString())
        OnReturn(New ReturnEventArgs(Of Product)(product))
    End Sub

    Private Sub lnkCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Indicate that nothing was selected.
        OnReturn(Nothing)
    End Sub

End Class

Public Class Product
	Private name_Renamed As String

	Public Property Name() As String
		Get
			Return name_Renamed
		End Get
		Set(ByVal value As String)
			name_Renamed = value
		End Set
	End Property

	Public Sub New(ByVal name As String)
		Me.Name = name
	End Sub
End Class

