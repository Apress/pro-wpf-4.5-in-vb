Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline

<AddInAdapter> _
Public Class ImageProcessorViewToContractAdapter
	Inherits ContractBase
	Implements Contract.IImageProcessorContract

    Private view As AddInView.ImageProcessorAddInView

	Public Sub New(ByVal view As AddInView.ImageProcessorAddInView)
		Me.view = view
	End Sub

    Public Function ProcessImageBytes(ByVal pixels As Byte()) As Byte() Implements Contract.IImageProcessorContract.ProcessImageBytes
        Return view.ProcessImageBytes(pixels)
    End Function

    Public Sub Initialize(ByVal hostObj As Contract.IHostObjectContract) Implements Contract.IImageProcessorContract.Initialize
        view.Initialize(New HostObjectContractToViewAddInAdapter(hostObj))
    End Sub
End Class

Public Class HostObjectContractToViewAddInAdapter
	Inherits AddInView.HostObject
	Private contract As Contract.IHostObjectContract
	Private handle As ContractHandle

	Public Sub New(ByVal contract As Contract.IHostObjectContract)
		Me.contract = contract
		Me.handle = New ContractHandle(contract)
	End Sub

	Public Overrides Sub ReportProgress(ByVal progressPercent As Integer)
		contract.ReportProgress(progressPercent)
	End Sub
End Class


