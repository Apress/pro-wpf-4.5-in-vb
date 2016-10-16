
Public Class ColorPickerUserControl

    Shared Sub New()
        ColorProperty = DependencyProperty.Register("Color", GetType(Color), GetType(ColorPickerUserControl), New FrameworkPropertyMetadata(Colors.Black, New PropertyChangedCallback(AddressOf OnColorChanged)))
        RedProperty = DependencyProperty.Register("Red", GetType(Byte), GetType(ColorPickerUserControl), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))
        GreenProperty = DependencyProperty.Register("Green", GetType(Byte), GetType(ColorPickerUserControl), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))
        BlueProperty = DependencyProperty.Register("Blue", GetType(Byte), GetType(ColorPickerUserControl), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))

        CommandManager.RegisterClassCommandBinding(GetType(ColorPickerUserControl), New CommandBinding(ApplicationCommands.Undo, AddressOf UndoCommand_Executed, AddressOf UndoCommand_CanExecute))
    End Sub

    Public Shared ColorProperty As DependencyProperty

    Public Shared RedProperty As DependencyProperty
    Public Shared GreenProperty As DependencyProperty
    Public Shared BlueProperty As DependencyProperty

    Public Property Color() As Color
        Get
            Return CType(GetValue(ColorProperty), Color)
        End Get
        Set(ByVal value As Color)
            SetValue(ColorProperty, value)
        End Set
    End Property

    Public Property Red() As Byte
        Get
            Return CByte(GetValue(RedProperty))
        End Get
        Set(ByVal value As Byte)
            SetValue(RedProperty, value)
        End Set
    End Property

    Public Property Green() As Byte
        Get
            Return CByte(GetValue(GreenProperty))
        End Get
        Set(ByVal value As Byte)
            SetValue(GreenProperty, value)
        End Set
    End Property

    Public Property Blue() As Byte
        Get
            Return CByte(GetValue(BlueProperty))
        End Get
        Set(ByVal value As Byte)
            SetValue(BlueProperty, value)
        End Set
    End Property

    Private Shared Sub OnColorChanged(ByVal sender As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim colorPicker As ColorPickerUserControl = CType(sender, ColorPickerUserControl)

        Dim oldColor As Color = CType(e.OldValue, Color)
        Dim newColor As Color = CType(e.NewValue, Color)
        colorPicker.Red = newColor.R
        colorPicker.Green = newColor.G
        colorPicker.Blue = newColor.B

        colorPicker.previousColor = oldColor
        colorPicker.OnColorChanged(oldColor, newColor)
    End Sub

    Private Shared Sub OnColorRGBChanged(ByVal sender As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim colorPicker As ColorPickerUserControl = CType(sender, ColorPickerUserControl)
        Dim color As Color = colorPicker.Color
        If e.Property Is RedProperty Then
            color.R = CByte(e.NewValue)
        ElseIf e.Property Is GreenProperty Then
            color.G = CByte(e.NewValue)
        ElseIf e.Property Is BlueProperty Then
            color.B = CByte(e.NewValue)
        End If

        colorPicker.Color = color
    End Sub

    Public Shared ReadOnly ColorChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, GetType(RoutedPropertyChangedEventHandler(Of Color)), GetType(ColorPickerUserControl))

    Public Custom Event ColorChanged As RoutedPropertyChangedEventHandler(Of Color)
        AddHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
            MyBase.AddHandler(ColorChangedEvent, value)
        End AddHandler
        RemoveHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
            MyBase.RemoveHandler(ColorChangedEvent, value)
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))
        End RaiseEvent
    End Event

    Private Sub OnColorChanged(ByVal oldValue As Color, ByVal newValue As Color)
        Dim args As RoutedPropertyChangedEventArgs(Of Color) = New RoutedPropertyChangedEventArgs(Of Color)(oldValue, newValue)
        args.RoutedEvent = ColorPickerUserControl.ColorChangedEvent
        MyBase.RaiseEvent(args)
    End Sub

    Public Sub New()
        InitializeComponent()
        'SetUpCommands()
    End Sub

    Private Sub SetUpCommands()
        ' Set up command bindings.
        Dim binding As New CommandBinding(ApplicationCommands.Undo, AddressOf UndoCommand_Executed, AddressOf UndoCommand_CanExecute)
        Me.CommandBindings.Add(Binding)
    End Sub

    Private previousColor As Nullable(Of Color)

    Private Shared Sub UndoCommand_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        Dim colorPicker As ColorPickerUserControl = CType(sender, ColorPickerUserControl)
        e.CanExecute = colorPicker.previousColor.HasValue
    End Sub

    Private Shared Sub UndoCommand_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        ' Use simple reverse-or-redo Undo (like Notepad).
        Dim colorPicker As ColorPickerUserControl = CType(sender, ColorPickerUserControl)
        colorPicker.Color = CType(colorPicker.previousColor, Color)
    End Sub

End Class