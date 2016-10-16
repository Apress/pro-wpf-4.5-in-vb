Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn
Imports System.Windows

<AddIn("Negative Image Processor", Version := "1.0.0.0", Publisher := "Imaginomics", Description := "Inverts colors to look like a photo negative")> _
Public Class NegativeImageProcessor
    Inherits AddInView.ImageProcessorAddInView

	Public Overrides Function GetVisual(ByVal imageStream As System.IO.Stream) As FrameworkElement
		Return New ImagePreview(imageStream)
	End Function
End Class
