Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline

<HostAdapter> _
Public Class ImageProcessorContractToViewHostAdapter
	Inherits HostView.ImageProcessorHostView
	Private contract As Contract.IImageProcessorContract
	Private contractHandle As ContractHandle

	Public Sub New(ByVal contract As Contract.IImageProcessorContract)
		Me.contract = contract
		contractHandle = New ContractHandle(contract)
	End Sub

	Public Overrides Function ProcessImageBytes(ByVal pixels As Byte()) As Byte()
		Return contract.ProcessImageBytes(pixels)
	End Function
End Class
