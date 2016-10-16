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

	Public Overrides Sub Initialize(ByVal host As HostView.HostObject)
		Dim hostAdapter As New HostObjectViewToContractHostAdapter(host)
		contract.Initialize(hostAdapter)
	End Sub
End Class

Public Class HostObjectViewToContractHostAdapter
	Inherits ContractBase
	Implements Contract.IHostObjectContract
	Private view As HostView.HostObject

	Public Sub New(ByVal view As HostView.HostObject)
		Me.view = view
	End Sub

    Public Sub ReportProgress(ByVal progressPercent As Integer) Implements Contract.IHostObjectContract.ReportProgress
        view.ReportProgress(progressPercent)
    End Sub
End Class
