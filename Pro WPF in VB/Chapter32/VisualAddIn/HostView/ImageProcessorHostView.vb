Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.IO

Public MustInherit Class ImageProcessorHostView
	Public MustOverride Function GetVisual(ByVal imageStream As Stream) As FrameworkElement
End Class
