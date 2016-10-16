Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public MustInherit Class ImageProcessorHostView
	Public MustOverride Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()

	Public MustOverride Sub Initialize(ByVal host As HostObject)
End Class

Public MustInherit Class HostObject
	Public MustOverride Sub ReportProgress(ByVal progressPercent As Integer)
End Class
