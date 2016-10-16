Public Class DateControls

    Private Sub DatePicker_DateValidationError(ByVal sender As Object, ByVal e As DatePickerDateValidationErrorEventArgs)
        lblError.Text = "'" & e.Text & "' is not a valid value because " & e.Exception.Message
    End Sub

    Private Sub Calendar_SelectedDatesChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        ' Check all the newly added items.
        For Each selectedDate As DateTime In e.AddedItems
            If (selectedDate.DayOfWeek = DayOfWeek.Saturday) Or (selectedDate.DayOfWeek = DayOfWeek.Sunday) Then
                lblError.Text = "Weekends are not allowed"

                CType(sender, Calendar).SelectedDates.Remove(selectedDate)
            End If
        Next

    End Sub

End Class
