Imports System.IO
Imports Microsoft.Win32

Public Class RichTextEditor

    Private Sub cmdBold_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If richTextBox.Selection.Text = "" Then
            Dim fontWeight As FontWeight = richTextBox.Selection.Start.Paragraph.FontWeight
            If fontWeight = FontWeights.Bold Then
                fontWeight = FontWeights.Normal
            Else
                fontWeight = FontWeights.Bold
            End If

            richTextBox.Selection.Start.Paragraph.FontWeight = fontWeight
            Return
        End If

        Dim obj As Object = richTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty)
        If obj Is DependencyProperty.UnsetValue Then
            Dim range As New TextRange(richTextBox.Selection.Start, richTextBox.Selection.Start)
            MessageBox.Show(range.GetPropertyValue(TextElement.FontWeightProperty).ToString())
        Else
            Dim fontWeight As FontWeight = CType(obj, FontWeight)

            If fontWeight = FontWeights.Bold Then
                fontWeight = FontWeights.Normal
            Else
                fontWeight = FontWeights.Bold
            End If

            richTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, fontWeight)
        End If
    End Sub

    Private Sub cmdShowXAML_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        UpdateMarkupDisplay()
    End Sub


    Private Sub UpdateMarkupDisplay()
        Dim range As TextRange
        range = New TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd)

        Dim stream As New MemoryStream()
        range.Save(stream, DataFormats.Xaml)
        stream.Position = 0

        Dim r As New StreamReader(stream)

        txtFlowDocumentMarkup.Text = r.ReadToEnd()
        r.Close()
        stream.Close()
    End Sub


    Private Sub cmdOpen_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*"

        If openFile.ShowDialog() = True Then
            ' Create a TextRange around the entire document.
            Dim documentTextRange As New TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd)

            Using fs As FileStream = File.Open(openFile.FileName, FileMode.Open)
                If Path.GetExtension(openFile.FileName).ToLower() = ".rtf" Then
                    documentTextRange.Load(fs, DataFormats.Rtf)
                Else
                    documentTextRange.Load(fs, DataFormats.Xaml)
                End If
            End Using
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim saveFile As New SaveFileDialog()
        saveFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*"

        If saveFile.ShowDialog() = True Then
            ' Create a TextRange around the entire document.
            Dim documentTextRange As New TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd)

            ' If this file exists, it's overwritten.
            Using fs As FileStream = File.Create(saveFile.FileName)
                If Path.GetExtension(saveFile.FileName).ToLower() = ".rtf" Then
                    documentTextRange.Save(fs, DataFormats.Rtf)
                Else
                    documentTextRange.Save(fs, DataFormats.Xaml)
                End If
            End Using
        End If
    End Sub

    Private Sub cmdNew_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        richTextBox.Document = New FlowDocument()
    End Sub

    Private Sub richTextBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.RightButton = MouseButtonState.Pressed Then
            Dim location As TextPointer = richTextBox.GetPositionFromPoint(Mouse.GetPosition(richTextBox), True)
            Dim word As TextRange = WordBreaker.GetWordRange(location)
            txtFlowDocumentMarkup.Text = word.Text
        End If
    End Sub
End Class