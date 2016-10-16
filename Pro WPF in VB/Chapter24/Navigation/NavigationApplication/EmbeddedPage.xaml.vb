Public Class EmbeddedPage
    
    Private Sub chkOwnsJournal_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If chkOwnsJournal.IsChecked = True Then
            embeddedFrame.JournalOwnership = JournalOwnership.OwnsJournal
        Else
            embeddedFrame.JournalOwnership = JournalOwnership.UsesParentJournal
        End If
    End Sub

End Class