Public Delegate Sub ReplayListChange(ByVal state As ListSelectionJournalEntry)

<Serializable()> _
Public Class ListSelectionJournalEntry
    Inherits CustomContentState

    Private _sourceItems As List(Of String)
    Public ReadOnly Property SourceItems() As List(Of String)
        Get
            Return _sourceItems
        End Get
    End Property

    Private _targetItems As List(Of String)
    Public ReadOnly Property TargetItems() As List(Of String)
        Get
            Return _targetItems
        End Get
    End Property
    Private _journalName As String
    Private replayListChange As ReplayListChange

    Public Sub New(ByVal sourceItems As List(Of String), ByVal targetItems As List(Of String), ByVal journalName As String, ByVal replayListChange As ReplayListChange)
        _sourceItems = sourceItems
        _targetItems = targetItems
        _journalName = journalName

        Me.replayListChange = replayListChange
    End Sub

    ' Need to override this property, if you want a CustomJournalEntry to appear in your back/forward stack
	Public Overrides ReadOnly Property JournalEntryName() As String
		Get
            Return _journalName
		End Get
	End Property

	' MANDATORY:  Need to override this method to restore the required state.
	' Since the "navigation" is not user-initiated ie. set by the user selecting 
	' a new ListBoxItem, we set the flag to false.
	Public Overrides Sub Replay(ByVal navigationService As NavigationService, ByVal mode As NavigationMode)
		Me.replayListChange(Me)
	End Sub

End Class
