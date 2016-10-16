Public Class Focus
    
    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        MyBase.OnActivated(e)
        cmdFocus.Focus()
    End Sub
End Class