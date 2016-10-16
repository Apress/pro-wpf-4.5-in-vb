Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.AddIn.Pipeline
Imports System.Windows
Imports System.IO
Imports System.AddIn.Contract

<AddInAdapter> _
Public Class ImageProcessorViewToContractAdapter
	Inherits ContractBase
	Implements Contract.IImageProcessorContract

    Private view As AddInView.ImageProcessorAddInView

	Public Sub New(ByVal view As AddInView.ImageProcessorAddInView)
		Me.view = view
	End Sub

    Public Function GetVisual(ByVal imageStream As Stream) As INativeHandleContract Implements Contract.IImageProcessorContract.GetVisual
        Return FrameworkElementAdapters.ViewToContractAdapter(view.GetVisual(imageStream))
    End Function
End Class

