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
End Class

