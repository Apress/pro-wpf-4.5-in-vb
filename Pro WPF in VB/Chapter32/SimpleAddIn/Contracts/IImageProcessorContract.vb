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
End Interface
