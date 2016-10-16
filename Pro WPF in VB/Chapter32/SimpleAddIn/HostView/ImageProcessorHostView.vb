Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public MustInherit Class ImageProcessorHostView
	Public MustOverride Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
End Class
