Public Class UserNameWinForm

    Public ReadOnly Property UserName() As String
        Get
            Return txtName.Text
        End Get
    End Property
End Class