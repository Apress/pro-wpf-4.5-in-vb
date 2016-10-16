Imports System.Windows.Interactivity

Public Class PlaySoundAction
    Inherits TriggerAction(Of FrameworkElement)

    Public Shared ReadOnly SourceProperty As DependencyProperty = _
  DependencyProperty.Register("Source", GetType(Uri), _
  GetType(PlaySoundAction), New PropertyMetadata(Nothing))

    Public Property Source() As Uri
        Get
            Return CType(GetValue(PlaySoundAction.SourceProperty), Uri)
        End Get
        Set(ByVal value As Uri)
            SetValue(PlaySoundAction.SourceProperty, value)
        End Set
    End Property

    Private container As Panel
    Private media As MediaElement

    Protected Overrides Sub Invoke(ByVal args As Object)
        ' Find a place to insert the MediaElement.
        container = FindContainer()

        If container IsNot Nothing Then
            ' Create and configure the MediaElement.
            media = New MediaElement()
            media.Source = Me.Source

            AddHandler media.MediaEnded, AddressOf MediaEnded
            AddHandler media.MediaFailed, AddressOf MediaEnded

            ' Add the MediaElement and begin playback.
            container.Children.Add(media)
        End If
    End Sub

    Private Sub MediaEnded()
        container.Children.Remove(media)
    End Sub

    Private Function FindContainer() As Panel
        Dim element As FrameworkElement = Me.AssociatedObject

        ' Search for some sort of panel where the MediaElement can be inserted.            
        Do While element IsNot Nothing
            If TypeOf element Is Panel Then
                Return CType(element, Panel)
            End If

            element = TryCast(VisualTreeHelper.GetParent(element), FrameworkElement)
        Loop
        Return Nothing
    End Function

End Class
