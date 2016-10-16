Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn

<AddIn("Fade Image Processor", Version := "1.0.0.0", Publisher := "SupraImage", Description := "Darkens the picture")> _
Public Class FadeImageProcessor
	Inherits AddInView.ImageProcessorAddInView

    Public Overrides Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
        Dim rand As New Random()
        Dim offset As Integer = rand.Next(0, 10)
        For i As Integer = 0 To pixels.Length - 1 - offset - 1
            If (i + offset) Mod 5 = 0 Then
                pixels(i) = 0
            End If
        Next
        Return pixels
    End Function
End Class
