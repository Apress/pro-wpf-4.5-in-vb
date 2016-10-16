Imports System.Windows.Controls.Primitives

<TemplatePart(Name:="FlipButton", Type:=GetType(ToggleButton)), _
TemplatePart(Name:="FlipButtonAlternate", Type:=GetType(ToggleButton)), _
TemplateVisualState(Name:="Normal", GroupName:="ViewStates"), _
TemplateVisualState(Name:="Flipped", GroupName:="ViewStates")> _
Public Class FlipPanel
    Inherits Control
    Public Shared ReadOnly FrontContentProperty As DependencyProperty = DependencyProperty.Register("FrontContent", GetType(Object), GetType(FlipPanel), Nothing)
    Public Shared ReadOnly BackContentProperty As DependencyProperty = DependencyProperty.Register("BackContent", GetType(Object), GetType(FlipPanel), Nothing)
    Public Shared ReadOnly CornerRadiusProperty As DependencyProperty = DependencyProperty.Register("CornerRadius", GetType(CornerRadius), GetType(FlipPanel), Nothing)
    Public Shared ReadOnly IsFlippedProperty As DependencyProperty = DependencyProperty.Register("IsFlipped", GetType(Boolean), GetType(FlipPanel), Nothing)

    Public Property FrontContent() As Object
        Get
            Return GetValue(FrontContentProperty)
        End Get
        Set(ByVal value As Object)
            SetValue(FrontContentProperty, value)
        End Set
    End Property

    Public Property BackContent() As Object
        Get
            Return GetValue(BackContentProperty)
        End Get
        Set(ByVal value As Object)
            SetValue(BackContentProperty, value)
        End Set
    End Property

    Public Property CornerRadius() As CornerRadius
        Get
            Return CType(GetValue(CornerRadiusProperty), CornerRadius)
        End Get
        Set(ByVal value As CornerRadius)
            SetValue(CornerRadiusProperty, value)
        End Set
    End Property

    Public Property IsFlipped() As Boolean
        Get
            Return CBool(GetValue(IsFlippedProperty))
        End Get
        Set(ByVal value As Boolean)
            SetValue(IsFlippedProperty, value)


            ChangeVisualState(True)
        End Set
    End Property

    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(FlipPanel), New FrameworkPropertyMetadata(GetType(FlipPanel)))
    End Sub


    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        Dim flipButton As ToggleButton = TryCast(MyBase.GetTemplateChild("FlipButton"), ToggleButton)
        If Not flipButton Is Nothing Then
            AddHandler flipButton.Click, AddressOf flipButton_Click
        End If

        ' Allow for two flip buttons if needed (one for each side of the panel).
        ' This is an optional design, as the control consumer may use template
        ' that places the flip button outside of the panel sides, like the 
        ' default template does.
        Dim flipButtonAlternate As ToggleButton = TryCast(MyBase.GetTemplateChild("FlipButtonAlternate"), ToggleButton)
        If flipButtonAlternate IsNot Nothing Then
            AddHandler flipButtonAlternate.Click, AddressOf flipButton_Click
        End If

        Me.ChangeVisualState(False)
    End Sub

    Private Sub flipButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.IsFlipped = Not Me.IsFlipped
    End Sub

    Private Sub ChangeVisualState(ByVal useTransitions As Boolean)
        If (Not Me.IsFlipped) Then
            VisualStateManager.GoToState(Me, "Normal", useTransitions)
        Else
            VisualStateManager.GoToState(Me, "Flipped", useTransitions)
        End If

        ' Disable flipped side to prevent tabbing to invisible buttons.            
        Dim front As UIElement = TryCast(FrontContent, UIElement)
        If Not front Is Nothing Then
            If IsFlipped Then
                front.Visibility = Visibility.Hidden
            Else
                front.Visibility = Visibility.Visible
            End If
        End If
        Dim back As UIElement = TryCast(BackContent, UIElement)
        If Not back Is Nothing Then
            If IsFlipped Then
                back.Visibility = Visibility.Visible
            Else
                back.Visibility = Visibility.Hidden
            End If
        End If

    End Sub

End Class

