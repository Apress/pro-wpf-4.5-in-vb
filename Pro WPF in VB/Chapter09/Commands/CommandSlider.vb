Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows

Public Class CommandSlider
	Inherits Slider
    Implements ICommandSource

    'ICommand Interface Memembers
    'make Command a dependency property so it can be DataBound
    Public Shared ReadOnly CommandProperty As DependencyProperty = DependencyProperty.Register("Command", GetType(ICommand), GetType(CommandSlider), New PropertyMetadata(CType(Nothing, ICommand), New PropertyChangedCallback(AddressOf CommandChanged)))

    Public Property Command() As ICommand
        Get
            Return CType(GetValue(CommandProperty), ICommand)
        End Get
        Set(ByVal value As ICommand)
            SetValue(CommandProperty, value)
        End Set
    End Property
    'make CommandTarget a dependency property so it can be DataBound
    Public Shared ReadOnly CommandTargetProperty As DependencyProperty = DependencyProperty.Register("CommandTarget", GetType(IInputElement), GetType(CommandSlider), New PropertyMetadata(CType(Nothing, IInputElement)))

    Public Property CommandTarget() As IInputElement
        Get
            Return CType(GetValue(CommandTargetProperty), IInputElement)
        End Get
        Set(ByVal value As IInputElement)
            SetValue(CommandTargetProperty, value)
        End Set
    End Property

    'make CommandParameter a dependency property so it can be DataBound
    Public Shared ReadOnly CommandParameterProperty As DependencyProperty = DependencyProperty.Register("CommandParameter", GetType(Object), GetType(CommandSlider), New PropertyMetadata(CObj(Nothing)))

    Public Property CommandParameter() As Object
        Get
            Return CObj(GetValue(CommandParameterProperty))
        End Get
        Set(ByVal value As Object)
            SetValue(CommandParameterProperty, value)
        End Set
    End Property

    ' Command dependency property change callback
    Private Shared Sub CommandChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim cs As CommandSlider = CType(d, CommandSlider)
        cs.HookUpCommand(CType(e.OldValue, ICommand), CType(e.NewValue, ICommand))
    End Sub
    ' Add a new command to the Command Property
    Private Sub HookUpCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
        'if oldCommand is not null, then we need to remove the handlers
        If Not oldCommand Is Nothing Then
            RemoveCommand(oldCommand, newCommand)
        End If
        AddCommand(oldCommand, newCommand)
    End Sub

    ' Remove an old command from the Command Property
    Private Sub RemoveCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
        Dim handler As EventHandler = AddressOf CanExecuteChanged
        RemoveHandler oldCommand.CanExecuteChanged, handler
    End Sub

    ' add the command
    Private Sub AddCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
        Dim handler As New EventHandler(AddressOf CanExecuteChanged)
        canExecuteChangedHandler = handler
        If Not newCommand Is Nothing Then
            AddHandler newCommand.CanExecuteChanged, canExecuteChangedHandler
        End If
    End Sub
    Private Sub CanExecuteChanged(ByVal sender As Object, ByVal e As EventArgs)

        If Not Me.Command Is Nothing Then
            Dim command As RoutedCommand = TryCast(Me.Command, RoutedCommand)

            ' if RoutedCommand
            If Not command Is Nothing Then
                If command.CanExecute(CommandParameter, CommandTarget) Then
                    Me.IsEnabled = True
                Else
                    Me.IsEnabled = False
                End If
                ' if not RoutedCommand
            Else
                If Me.Command.CanExecute(CommandParameter) Then
                    Me.IsEnabled = True
                Else
                    Me.IsEnabled = False
                End If
            End If
        End If
    End Sub

    'if Command is defined, then moving the slider will invoke the command;
    'otherwise, the silder will behave normally
    Protected Overrides Sub OnValueChanged(ByVal oldValue As Double, ByVal newValue As Double)
        MyBase.OnValueChanged(oldValue, newValue)

        If Not Me.Command Is Nothing Then
            Dim command As RoutedCommand = TryCast(Me.Command, RoutedCommand)

            If Not command Is Nothing Then
                command.Execute(CommandParameter, CommandTarget)
            Else
                CType(Me.Command, ICommand).Execute(CommandParameter)
            End If
        End If
    End Sub

    'keep a copy of the handler so it doesn't get garbage collected
    Private Shared canExecuteChangedHandler As EventHandler

    Private ReadOnly Property PrivateCommand() As ICommand Implements ICommandSource.Command
        Get
            Return Command
        End Get
    End Property

    Private ReadOnly Property PrivateCommandTarget() As IInputElement Implements ICommandSource.CommandTarget
        Get
            Return CommandTarget
        End Get
    End Property

    Private ReadOnly Property PrivateCommandParameter() As Object Implements ICommandSource.CommandParameter
        Get
            Return CommandParameter
        End Get
    End Property

End Class
