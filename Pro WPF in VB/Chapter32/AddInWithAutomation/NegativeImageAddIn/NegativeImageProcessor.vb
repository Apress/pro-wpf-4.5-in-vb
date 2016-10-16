Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn
Imports System.Threading

<AddIn("Negative Image Processor", Version := "1.0.0.0", Publisher := "Imaginomics", Description := "Inverts colors to look like a photo negative")> _
Public Class NegativeImageProcessor
	Inherits AddInView.ImageProcessorAddInView
	Public Overrides Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
        Dim iteration As Integer = CInt(pixels.Length / 100)

		For i As Integer = 0 To pixels.Length - 2 - 1
			pixels(i) = CByte(255 - pixels(i))
			pixels(i + 1) = CByte(255 - pixels(i + 1))
			pixels(i + 2) = CByte(255 - pixels(i + 2))

			If i Mod iteration = 0 Then
				host.ReportProgress(i \ iteration)
			End If
		Next
		Return pixels
	End Function

	Private host As AddInView.HostObject
	Public Overrides Sub Initialize(ByVal hostObj As AddInView.HostObject)
		host = hostObj
	End Sub
End Class
