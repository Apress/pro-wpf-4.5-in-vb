Public Class CustomPixelShader
    Private Sub chkEffect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If chkEffect.IsChecked <> True Then
            img.Effect = Nothing
        Else
            img.Effect = New GrayscaleEffect()
        End If
    End Sub

End Class
