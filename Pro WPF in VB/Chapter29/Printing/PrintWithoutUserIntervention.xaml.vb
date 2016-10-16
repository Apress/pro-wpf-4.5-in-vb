Imports System.Printing

Public Class PrintWithoutUserIntervention

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim dialog As New PrintDialog()
        dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue()
        dialog.PrintVisual(CType(sender, Visual), "Automatic Printout")
    End Sub
End Class