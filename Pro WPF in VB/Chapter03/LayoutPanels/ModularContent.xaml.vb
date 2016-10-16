Public Class ModularContent
   
    Public Sub New()
        InitializeComponent()

        MyBase.AddHandler(CheckBox.CheckedEvent, New RoutedEventHandler(AddressOf chk_Checked))
        MyBase.AddHandler(CheckBox.UncheckedEvent, New RoutedEventHandler(AddressOf chk_Unchecked))
    End Sub

    Private Sub chk_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim chk As CheckBox = CType(e.OriginalSource, CheckBox)
        Dim obj As DependencyObject = LogicalTreeHelper.FindLogicalNode(Me, chk.Content.ToString())
        CType(obj, FrameworkElement).Visibility = Visibility.Visible
    End Sub

    Private Sub chk_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim chk As CheckBox = CType(e.OriginalSource, CheckBox)
        Dim obj As DependencyObject = LogicalTreeHelper.FindLogicalNode(Me, chk.Content.ToString())
        CType(obj, FrameworkElement).Visibility = Visibility.Collapsed
    End Sub
End Class