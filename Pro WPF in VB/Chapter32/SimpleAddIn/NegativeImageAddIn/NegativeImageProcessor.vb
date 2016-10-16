Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn

<AddIn("Negative Image Processor", Version:="1.0.0.0", Publisher:="Imaginomics", Description:="Inverts colors to look like a photo negative")> _
Public Class NegativeImageProcessor
    Inherits AddInView.ImageProcessorAddInView

    Public Overrides Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
        For i As Integer = 0 To pixels.Length - 3
            pixels(i) = CByte(255 - pixels(i))
            pixels(i + 1) = CByte(255 - pixels(i + 1))
            pixels(i + 2) = CByte(255 - pixels(i + 2))
        Next
        Return pixels
    End Function
End Class
