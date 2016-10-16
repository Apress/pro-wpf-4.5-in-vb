Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline
Imports System.Windows
Imports System.IO

<AddInBase> _
Public MustInherit Class ImageProcessorAddInView
	Public MustOverride Function GetVisual(ByVal imageStream As Stream) As FrameworkElement
End Class
