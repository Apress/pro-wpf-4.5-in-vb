Imports System.IO
Imports System.Windows.Annotations
Imports System.Security.Principal
Imports System.Windows.Annotations.Storage

Public Class FlowDocumentAnnotations

    ' A stream for storing annotation.
    Private annotationStream As Stream

    ' The service that manages annotations.
    Private service As AnnotationService

    Protected Sub window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim identity As WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        Me.Resources("AuthorName") = identity.Name

        service = AnnotationService.GetService(docReader)

        If service Is Nothing Then
            ' Create a stream for the annotations to be stored in.
            'AnnotationStream =
            ' New FileStream("annotations.xml", FileMode.OpenOrCreate);
            annotationStream = New MemoryStream()

            ' Create the AnnotationService for your document container.
            service = New AnnotationService(docReader)

            ' Create the annotation storage.
            Dim store As AnnotationStore = New XmlStreamStore(annotationStream)

            ' Enable annotations.
            service.Enable(store)
        End If
    End Sub

    Protected Sub window_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not service Is Nothing AndAlso service.IsEnabled Then
            ' Flush annotations to stream.
            service.Store.Flush()

            ' Disable annotations.
            service.Disable()
            annotationStream.Close()
        End If
    End Sub

    Private Sub cmdShowAllAnotations_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim annotations As IList(Of Annotation) = service.Store.GetAnnotations()
        For Each annotation As Annotation In annotations
            ' Check for text information.
            If annotation.Cargos.Count > 1 Then
                ' Decode the note text.
                Dim base64Text As String = annotation.Cargos(1).Contents(0).InnerText
                Dim decoded As Byte() = Convert.FromBase64String(base64Text)

                ' Write the decoded text to a stream.
                Dim m As New MemoryStream(decoded)

                ' Get the inner text.
                'Dim section As Section = CType(XamlReader.Load(m), Section))
                'Dim range As New TextRange(section.ContentStart, section.ContentEnd)
                'Dim annotationText As String = range.Text
                'm.Position = 0

                ' Read the full XML.                    
                Dim r As New StreamReader(m)
                Dim annotationXaml As String = r.ReadToEnd()
                r.Close()
                MessageBox.Show(annotationXaml)

                ' Get the annotated text.
                Dim anchorInfo As IAnchorInfo = AnnotationHelper.GetAnchorInfo(service, annotation)
                Dim resolvedAnchor As TextAnchor = TryCast(anchorInfo.ResolvedAnchor, TextAnchor)
                If Not resolvedAnchor Is Nothing Then
                    Dim startPointer As TextPointer = CType(resolvedAnchor.BoundingStart, TextPointer)
                    Dim endPointer As TextPointer = CType(resolvedAnchor.BoundingEnd, TextPointer)

                    Dim range As New TextRange(startPointer, endPointer)
                    MessageBox.Show(range.Text)
                End If

            End If
        Next
    End Sub

End Class