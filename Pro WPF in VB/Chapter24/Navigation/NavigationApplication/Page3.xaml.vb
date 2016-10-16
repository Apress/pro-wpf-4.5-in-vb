Public Class Page3
    
    Private Sub Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim nav As NavigationService = NavigationService.GetNavigationService(Me)
        Do While nav.CanGoBack
            Dim obj As JournalEntry = nav.RemoveBackEntry()
        Loop
    End Sub
End Class