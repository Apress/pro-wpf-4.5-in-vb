Imports System.Windows.Annotations
Imports System.Windows.Xps.Packaging
Imports System.IO
Imports System.IO.Packaging
Imports System.Windows.Annotations.Storage

Public Class XpsAnnotations


    Private service As AnnotationService
    Private doc As XpsDocument

    Private Sub window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        doc = New XpsDocument("ch19.xps", FileAccess.ReadWrite)
        docViewer.Document = doc.GetFixedDocumentSequence()

        service = AnnotationService.GetService(docViewer)
        If service Is Nothing Then
            Dim annotationUri As Uri = PackUriHelper.CreatePartUri(New Uri("AnnotationStream", UriKind.Relative))
            Dim package As Package = PackageStore.GetPackage(doc.Uri)
            Dim annotationPart As PackagePart = Nothing
            If package.PartExists(annotationUri) Then
                annotationPart = package.GetPart(annotationUri)
            Else
                annotationPart = package.CreatePart(annotationUri, "Annotations/Stream")
            End If

            ' Load annotations from the package.
            Dim store As AnnotationStore = New XmlStreamStore(annotationPart.GetStream())
            service = New AnnotationService(docViewer)
            service.Enable(store)

        End If
    End Sub

    Private Sub window_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not service Is Nothing AndAlso service.IsEnabled Then
            ' Flush annotations to stream.
            service.Store.Flush()

            ' Disable annotations.
            service.Disable()
        End If

        doc.Close()
    End Sub
End Class