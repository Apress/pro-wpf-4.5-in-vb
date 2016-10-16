Imports System.Printing

Public Class PrintQueues

    ' This code doesn't include any error handling in order to be as clear as possible.
    ' Obviously, error handling is required when accessing a printer.
    ' (For example, Windows security settings could cause an error.)        

    Private printServer As New PrintServer()

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As EventArgs)
        lstQueues.DisplayMemberPath = "FullName"
        lstQueues.SelectedValuePath = "FullName"
        lstQueues.ItemsSource = printServer.GetPrintQueues()
    End Sub

    Private Sub lstQueues_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
        lblQueueStatus.Text = "Queue Status: " & queue.QueueStatus.ToString()
        lblJobStatus.Text = ""
        lstJobs.DisplayMemberPath = "JobName"
        lstJobs.SelectedValuePath = "JobIdentifier"

        lstJobs.ItemsSource = queue.GetPrintJobInfoCollection()
    End Sub

    Private Sub lstJobs_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        If lstJobs.SelectedValue Is Nothing Then
            lblJobStatus.Text = ""
        Else
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            Dim job As PrintSystemJobInfo = queue.GetJob(CInt(Fix(lstJobs.SelectedValue)))

            lblJobStatus.Text = "Job Status: " & job.JobStatus.ToString()
        End If
    End Sub


    Private Sub cmdPauseQueue_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstQueues.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            queue.Pause()
        End If
    End Sub
    Private Sub cmdResumeQueue_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstQueues.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            queue.Resume()
        End If
    End Sub
    Private Sub cmdRefreshQueue_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstQueues.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            queue.Refresh()
        End If
    End Sub
    Private Sub cmdPurgeQueue_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstQueues.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            queue.Purge()
        End If
    End Sub


    Private Sub cmdPauseJob_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstJobs.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            Dim job As PrintSystemJobInfo = queue.GetJob(CInt(Fix(lstJobs.SelectedValue)))
            job.Pause()
        End If
    End Sub
    Private Sub cmdResumeJob_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstJobs.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            Dim job As PrintSystemJobInfo = queue.GetJob(CInt(Fix(lstJobs.SelectedValue)))
            job.Resume()
        End If
    End Sub
    Private Sub cmdRefreshJob_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstJobs.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            Dim job As PrintSystemJobInfo = queue.GetJob(CInt(Fix(lstJobs.SelectedValue)))
            job.Refresh()

            lstJobs_SelectionChanged(Nothing, Nothing)
        End If
    End Sub
    Private Sub cmdCancelJob_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not lstJobs.SelectedValue Is Nothing Then
            Dim queue As PrintQueue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString())
            Dim job As PrintSystemJobInfo = queue.GetJob(CInt(Fix(lstJobs.SelectedValue)))
            job.Cancel()

            lstQueues_SelectionChanged(Nothing, Nothing)
        End If
    End Sub
End Class