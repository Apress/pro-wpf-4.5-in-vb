Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline
Imports System.AddIn.Contract

<AddInContract> _
Public Interface IImageProcessorContract
	Inherits IContract
	Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()

	Sub Initialize(ByVal hostObj As IHostObjectContract)
End Interface

Public Interface IHostObjectContract
	Inherits IContract
	Sub ReportProgress(ByVal progressPercent As Integer)
End Interface
