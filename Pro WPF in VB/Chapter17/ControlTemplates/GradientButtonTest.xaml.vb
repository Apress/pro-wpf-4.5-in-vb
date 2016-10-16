Public Class GradientButtonTest
  
    Private Sub Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("You clicked " & (CType(sender, Button)).Name)
    End Sub

    Private Sub chkGreen_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim resourceDictionary As New ResourceDictionary()
        resourceDictionary.Source = New Uri("Resources/GradientButtonVariant.xaml", UriKind.Relative)
        Me.Resources.MergedDictionaries(0) = resourceDictionary

        ' Alternate approach using the resource class.
        'Dim resourceDictionary As New GradientButtonVariant
        'Me.Resources.MergedDictionaries(0) = resourceDictionary
    End Sub

    Private Sub chkGreen_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim resourceDictionary As New ResourceDictionary()
        resourceDictionary.Source = New Uri("Resources/GradientButton.xaml", UriKind.Relative)
        Me.Resources.MergedDictionaries(0) = resourceDictionary
    End Sub
End Class