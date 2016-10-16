Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline
Imports System.Windows
Imports System.IO

<HostAdapter> _
Public Class ImageProcessorContractToViewHostAdapter
	Inherits HostView.ImageProcessorHostView
	Private contract As Contract.IImageProcessorContract
	Private contractHandle As ContractHandle

	Public Sub New(ByVal contract As Contract.IImageProcessorContract)
		Me.contract = contract
		contractHandle = New ContractHandle(contract)
	End Sub

	Public Overrides Function GetVisual(ByVal imageStream As Stream) As FrameworkElement
		Return FrameworkElementAdapters.ContractToViewAdapter(contract.GetVisual(imageStream))
	End Function
End Class
