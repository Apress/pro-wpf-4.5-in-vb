Public Class SimpleInkCanvas
    
    Public Sub New()
        InitializeComponent()

        For Each mode As InkCanvasEditingMode In System.Enum.GetValues(GetType(InkCanvasEditingMode))
            lstEditingMode.Items.Add(mode)
            lstEditingMode.SelectedItem = inkCanvas.EditingMode
        Next
    End Sub

End Class