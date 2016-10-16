Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline

<AddInBase> _
Public MustInherit Class ImageProcessorAddInView
	Public MustOverride Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
End Class
