Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.IO


Public Class ImagePreview
    Inherits UserControl

    Private originalSource As BitmapSource
    Private originalPixels As Byte()
    Public Sub New(ByVal imageStream As Stream)
        InitializeComponent()

        Dim imgSource As New BitmapImage()
        imgSource.BeginInit()
        imgSource.StreamSource = imageStream
        imgSource.EndInit()
        img.Source = imgSource


        originalSource = CType(img.Source, BitmapSource)
        Dim stride As Integer = CInt(originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8)
        stride = stride + (stride Mod 4) * 4
        originalPixels = New Byte(CInt(stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8 - 1)) {}

        originalSource.CopyPixels(originalPixels, stride, 0)
    End Sub

    Private Sub sliderIntensity_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
        Me.Cursor = Cursors.Wait

        Dim changedPixels As Byte() = ProcessImageBytes(CType(originalPixels.Clone(), Byte()))

        Dim stride As Integer = CInt(originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8)
        Dim newSource As BitmapSource = BitmapSource.Create(originalSource.PixelWidth, originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY, originalSource.Format, originalSource.Palette, changedPixels, stride)
        img.Source = newSource

        Me.Cursor = Nothing
    End Sub

    Private Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
        Dim scaleFactor As Double = sliderIntensity.Value / sliderIntensity.Maximum
        For i As Integer = 0 To pixels.Length - 3
            Dim val As Integer = CInt(255 * scaleFactor - pixels(i))
            If val < 0 Then val = Math.Abs(val)
            pixels(i) = CByte(val)
            val = CInt(255 * scaleFactor - pixels(i + 1))
            If val < 0 Then val = Math.Abs(val)
            pixels(i + 1) = CByte(val)
            val = CInt(255 * scaleFactor - pixels(i + 2))
            If val < 0 Then val = Math.Abs(val)
            pixels(i + 2) = CByte(val)
        Next
        Return pixels
    End Function
End Class
