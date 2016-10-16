Imports System.Windows.Controls.Primitives

<TemplatePart(Name:="PART_RedSlider", Type:=GetType(RangeBase)), TemplatePart(Name:="PART_BlueSlider", Type:=GetType(RangeBase)), TemplatePart(Name:="PART_GreenSlider", Type:=GetType(RangeBase)), TemplatePart(Name:="PART_PreviewBrush", Type:=GetType(SolidColorBrush))> _
Public Class ColorPicker
    Inherits System.Windows.Controls.Control

    Shared Sub New()
        'This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
        'This style is defined in themes\generic.xaml
        DefaultStyleKeyProperty.OverrideMetadata(GetType(ColorPicker), New FrameworkPropertyMetadata(GetType(ColorPicker)))

        ColorProperty = DependencyProperty.Register("Color", GetType(Color), GetType(ColorPicker), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorChanged)))

        RedProperty = DependencyProperty.Register("Red", GetType(Byte), GetType(ColorPicker), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))

        GreenProperty = DependencyProperty.Register("Green", GetType(Byte), GetType(ColorPicker), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))

        BlueProperty = DependencyProperty.Register("Blue", GetType(Byte), GetType(ColorPicker), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))
    End Sub

    Public Sub New()
        SetUpCommands()
    End Sub

    Private Sub SetUpCommands()
        ' Set up command bindings.
        Dim binding As New CommandBinding(ApplicationCommands.Undo, AddressOf UndoCommand_Executed, AddressOf UndoCommand_CanExecute)
        Me.CommandBindings.Add(binding)
    End Sub

    Private previousColor As Nullable(Of Color)
    Private Sub UndoCommand_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = previousColor.HasValue
    End Sub
    Private Sub UndoCommand_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        ' Use simple reverse-or-redo Undo (like Notepad).
        Me.Color = CType(previousColor, Color)
    End Sub

    Public Shared ColorProperty As DependencyProperty
    Public Property Color() As Color
        Get
            Return CType(GetValue(ColorProperty), Color)
        End Get
        Set(ByVal value As Color)
            SetValue(ColorProperty, value)
        End Set
    End Property

    Public Shared RedProperty As DependencyProperty
    Public Shared GreenProperty As DependencyProperty
    Public Shared BlueProperty As DependencyProperty

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
        Dim colorPicker As ColorPicker = CType(sender, ColorPicker)

        Dim oldColor As Color = CType(e.OldValue, Color)
        Dim newColor As Color = CType(e.NewValue, Color)
        colorPicker.Red = newColor.R
        colorPicker.Green = newColor.G
        colorPicker.Blue = newColor.B

        colorPicker.previousColor = oldColor
        colorPicker.OnColorChanged(oldColor, newColor)
    End Sub

    Private Shared Sub OnColorRGBChanged(ByVal sender As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim colorPicker As ColorPicker = CType(sender, ColorPicker)
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

    Public Shared ReadOnly ColorChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, GetType(RoutedPropertyChangedEventHandler(Of Color)), GetType(ColorPicker))

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
        args.RoutedEvent = ColorPicker.ColorChangedEvent
        MyBase.RaiseEvent(args)
    End Sub

    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()

        Dim slider As RangeBase = TryCast(GetTemplateChild("PART_RedSlider"), RangeBase)
        If slider IsNot Nothing Then
            Dim binding As New Binding("Red")
            binding.Source = Me
            binding.Mode = BindingMode.TwoWay
            slider.SetBinding(RangeBase.ValueProperty, binding)
        End If
        slider = TryCast(GetTemplateChild("PART_GreenSlider"), RangeBase)
        If slider IsNot Nothing Then
            Dim binding As New Binding("Green")
            binding.Source = Me
            binding.Mode = BindingMode.TwoWay
            slider.SetBinding(RangeBase.ValueProperty, binding)
        End If
        slider = TryCast(GetTemplateChild("PART_BlueSlider"), RangeBase)
        If slider IsNot Nothing Then
            Dim binding As New Binding("Blue")
            binding.Source = Me
            binding.Mode = BindingMode.TwoWay
            slider.SetBinding(RangeBase.ValueProperty, binding)
        End If

        Dim brush As SolidColorBrush = TryCast(GetTemplateChild("PART_PreviewBrush"), SolidColorBrush)
        If brush IsNot Nothing Then
            Dim binding As New Binding("Color")
            binding.Source = brush
            binding.Mode = BindingMode.OneWayToSource
            Me.SetBinding(ColorPicker.ColorProperty, binding)
        End If
    End Sub
End Class
