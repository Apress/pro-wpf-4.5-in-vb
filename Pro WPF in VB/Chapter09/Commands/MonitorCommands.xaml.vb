Imports System.Reflection

Public Class MonitorCommands

    Private Shared _applicationUndo As RoutedUICommand

    Public Shared ReadOnly Property ApplicationUndo() As RoutedUICommand
        Get
            Return _applicationUndo
        End Get
    End Property

    Shared Sub New()
        _applicationUndo = New RoutedUICommand("ApplicationUndo", "Application Undo", GetType(MonitorCommands))
    End Sub


    Public Sub New()
        InitializeComponent()

        Me.AddHandler(CommandManager.PreviewExecutedEvent, New ExecutedRoutedEventHandler(AddressOf CommandExecuted))
    End Sub

    Private Sub window_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.RemoveHandler(CommandManager.PreviewExecutedEvent, New ExecutedRoutedEventHandler(AddressOf CommandExecuted))
    End Sub

    Private Sub CommandExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        ' Ignore menu button source.
        If TypeOf e.Source Is ICommandSource Then
            Return
        End If

        ' Ignore the ApplicationUndo command.
        If e.Command Is MonitorCommands.ApplicationUndo Then
            Return
        End If

        ' Could filter for commands you want to add to the stack
        ' (for example, not selection events).

        Dim txt As TextBox = TryCast(e.Source, TextBox)
        If Not txt Is Nothing Then
            Dim cmd As RoutedCommand = CType(e.Command, RoutedCommand)

            Dim historyItem As New CommandHistoryItem(cmd.Name, txt, "Text", txt.Text)

            Dim item As New ListBoxItem()
            item.Content = historyItem
            lstHistory.Items.Add(historyItem)
        End If
    End Sub

    Private Sub ApplicationUndoCommand_Executed(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim historyItem As CommandHistoryItem = CType(lstHistory.Items(lstHistory.Items.Count - 1), CommandHistoryItem)
        If historyItem.CanUndo Then
            historyItem.Undo()
        End If
        lstHistory.Items.Remove(historyItem)
    End Sub

    Private Sub ApplicationUndoCommand_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        If lstHistory Is Nothing OrElse lstHistory.Items.Count = 0 Then
            e.CanExecute = False
        Else
            e.CanExecute = True
        End If
    End Sub

End Class

Public Class CommandHistoryItem
    Private _commandName As String
    Public Property CommandName() As String
        Get
            Return _commandName
        End Get
        Set(ByVal value As String)
            _commandName = value
        End Set
    End Property

    Private _elementActedOn As UIElement
    Public Property ElementActedOn() As UIElement
        Get
            Return _elementActedOn
        End Get
        Set(ByVal value As UIElement)
            _elementActedOn = value
        End Set
    End Property

    Private _propertyActedOn As String
    Public Property PropertyActedOn() As String
        Get
            Return _propertyActedOn
        End Get
        Set(ByVal value As String)
            _propertyActedOn = value
        End Set
    End Property

    Private _previousState As Object
    Public Property PreviousState() As Object
        Get
            Return _previousState
        End Get
        Set(ByVal value As Object)
            _previousState = value
        End Set
    End Property

    Public Sub New(ByVal commandName As String)
        Me.New(commandName, Nothing, "", Nothing)
    End Sub

    Public Sub New(ByVal commandName As String, ByVal elementActedOn As UIElement, ByVal propertyActedOn As String, ByVal previousState As Object)
        Me.CommandName = commandName
        Me.ElementActedOn = elementActedOn
        Me.PropertyActedOn = propertyActedOn
        Me.PreviousState = previousState
    End Sub
    Public ReadOnly Property CanUndo() As Boolean
        Get
            Return (Not ElementActedOn Is Nothing AndAlso PropertyActedOn <> "")
        End Get
    End Property

    Public Sub Undo()
        Dim elementType As Type = ElementActedOn.GetType()
        Dim propInfo As PropertyInfo = elementType.GetProperty(PropertyActedOn)
        propInfo.SetValue(ElementActedOn, PreviousState, Nothing)
    End Sub

End Class
