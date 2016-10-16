Public Class PageWithPersistentData
   
    Private Shared MyPageDataProperty As DependencyProperty

    Shared Sub New()
        Dim metadata As New FrameworkPropertyMetadata()
        metadata.Journal = True

        MyPageDataProperty = DependencyProperty.Register("MyPageDataProperty", GetType(String), GetType(PageWithPersistentData), metadata, Nothing)
    End Sub

    Private Property MyPageData() As String
        Set(ByVal value As String)
            SetValue(MyPageDataProperty, value)
        End Set
        Get
            Return CStr(GetValue(MyPageDataProperty))
        End Get
    End Property

    Public Sub SetText(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MyPageData = txt.Text
        txt.Text = ""
    End Sub

    Public Sub GetText(ByVal sender As Object, ByVal e As RoutedEventArgs)
        lbl.Content = "Retrieved: " & MyPageData
    End Sub
End Class