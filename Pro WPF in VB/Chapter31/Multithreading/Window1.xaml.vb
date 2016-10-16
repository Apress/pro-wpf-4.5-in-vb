Imports System.Threading
Imports System.Windows.Threading

Public Class Window1

    Private Sub cmdBreakRules_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim thread As New Thread(AddressOf UpdateTextWrong)
        thread.Start()
    End Sub

    Private Sub UpdateTextWrong()
        txt.Text = "Here is some new text."
    End Sub

    Private Sub cmdFollowRules_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim thread As New Thread(AddressOf UpdateTextRight)
        thread.Start()
    End Sub

    Private Sub UpdateTextRight()
        Me.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New ThreadStart(AddressOf UpdateMethod))
    End Sub

    Private Sub UpdateMethod()
        txt.Text = "Here is some new text."
    End Sub

    Private Sub cmdBackgroundWorker_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim test As New BackgroundWorkerTest()
        test.ShowDialog()
    End Sub
End Class