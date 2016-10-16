Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline
Imports System.AddIn.Contract
Imports System.Windows
Imports System.IO

<AddInContract> _
Public Interface IImageProcessorContract
	Inherits IContract
	Function GetVisual(ByVal imageStream As Stream) As INativeHandleContract
End Interface
