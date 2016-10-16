Imports System.ComponentModel

Public Class BackgroundWorkerTest

    Private backgroundWorker As BackgroundWorker

    Public Sub New()
        InitializeComponent()
        backgroundWorker = CType(Me.FindResource("backgroundWorker"), BackgroundWorker)
    End Sub

    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Disable the button and clear previous results.
        cmdFind.IsEnabled = False
        cmdCancel.IsEnabled = True
        lstPrimes.Items.Clear()

        ' Get the search range.
        Dim fromValue, toValue As Integer
        If (Not Int32.TryParse(txtFrom.Text, fromValue)) Then
            MessageBox.Show("Invalid From value.")
            Return
        End If
        If (Not Int32.TryParse(txtTo.Text, toValue)) Then
            MessageBox.Show("Invalid To value.")
            Return
        End If

        ' Start the search for primes on another thread.
        Dim input As New FindPrimesInput(fromValue, toValue)
        backgroundWorker.RunWorkerAsync(input)
    End Sub

    Private Sub backgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        ' Get the input values.
        Dim input As FindPrimesInput = CType(e.Argument, FindPrimesInput)

        ' Start the search for primes and wait.
        Dim primes() As Integer = Worker.FindPrimes(input.From, input.To, backgroundWorker)

        If backgroundWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If

        ' Return the result.
        e.Result = primes
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled Then
            MessageBox.Show("Search cancelled.")
        ElseIf Not e.Error Is Nothing Then
            ' An error was thrown by the DoWork event handler.
            MessageBox.Show(e.Error.Message, "An Error Occurred")
        Else
            Dim primes As Integer() = CType(e.Result, Integer())
            For Each prime As Integer In primes
                lstPrimes.Items.Add(prime)
            Next
        End If
        cmdFind.IsEnabled = True
        cmdCancel.IsEnabled = False
        progressBar.Value = 0
    End Sub

    Private Sub backgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        progressBar.Value = e.ProgressPercentage
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        backgroundWorker.CancelAsync()
    End Sub
End Class