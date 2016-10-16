Imports System.Windows.Media.Media3D

Public Class Materials

    Private Sub chk_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        materialsGroup.Children.Clear()
        If chkBackground.IsChecked = True Then
            rect.Visibility = Visibility.Visible
        Else
            rect.Visibility = Visibility.Hidden
        End If

        If chkDiffuse.IsChecked = True Then
            materialsGroup.Children.Add(CType(FindResource("diffuse"), Material))
        End If

        If chkSpecular.IsChecked = True Then
            materialsGroup.Children.Add(CType(FindResource("specular"), Material))
        End If

        If chkEmissive.IsChecked = True Then
            materialsGroup.Children.Add(CType(FindResource("emissive"), Material))
        End If

    End Sub
End Class