Public Class PageWithMultipleJournalEntries
    Implements IProvideCustomContentState

    Private Sub Page_Loaded(ByVal sender As Object, ByVal e As EventArgs)
        lstSource.Items.Add("Red")
        lstSource.Items.Add("Blue")
        lstSource.Items.Add("Green")
        lstSource.Items.Add("Yellow")
        lstSource.Items.Add("Orange")
        lstSource.Items.Add("Black")
        lstSource.Items.Add("Pink")
        lstSource.Items.Add("Purple")
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If lstSource.SelectedIndex <> -1 Then
            ' Determine the best name to use in the navigation history.
            Dim nav As NavigationService = NavigationService.GetNavigationService(Me)
            Dim itemText As String = lstSource.SelectedItem.ToString()
            Dim journalName As String = "Added " & itemText

            ' Update the journal (using the method shown below.)        
            nav.AddBackEntry(GetJournalEntry(journalName))

            ' Now perform the change.
            lstTarget.Items.Add(itemText)
            lstSource.Items.Remove(itemText)
        End If
    End Sub

    Private isReplaying As Boolean
    Private Sub Replay(ByVal state As ListSelectionJournalEntry)
        Me.isReplaying = True

        lstSource.Items.Clear()
        For Each item As String In state.SourceItems
            lstSource.Items.Add(item)
        Next

        lstTarget.Items.Clear()
        For Each item As String In state.TargetItems
            lstTarget.Items.Add(item)
        Next

        restoredStateName = state.JournalEntryName
        Me.isReplaying = False
    End Sub

    Private restoredStateName As String

    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If lstTarget.SelectedIndex <> -1 Then
            ' Determine the best name to use in the navigation history.
            Dim nav As NavigationService = NavigationService.GetNavigationService(Me)
            Dim itemText As String = lstTarget.SelectedItem.ToString()
            Dim journalName As String = "Removed " & itemText

            ' Update the journal (using the method shown below.)        
            nav.AddBackEntry(GetJournalEntry(journalName))

            ' Perform the change.
            lstSource.Items.Add(itemText)
            lstTarget.Items.Remove(itemText)
        End If
    End Sub

    Private Function GetJournalEntry(ByVal journalName As String) As ListSelectionJournalEntry
        ' Get the state of both lists (using a helper method).
        Dim source As List(Of String) = GetListState(lstSource)
        Dim target As List(Of String) = GetListState(lstTarget)

        ' Create the custom state object with this information.
        ' Point the callback to the Replay method in this class.
        Return New ListSelectionJournalEntry(source, target, journalName, AddressOf Replay)
    End Function


    Public Function GetContentState() As CustomContentState Implements IProvideCustomContentState.GetContentState
        Dim journalName As String
        If restoredStateName <> "" Then
            journalName = restoredStateName
        Else
            journalName = "PageWithMultipleJournalEntries"
        End If

        Return GetJournalEntry(journalName)
    End Function

    Private Function GetListState(ByVal list As ListBox) As List(Of String)
        Dim items As List(Of String) = New List(Of String)()
        For Each item As String In list.Items
            items.Add(item)
        Next
        Return items
    End Function
End Class