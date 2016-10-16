Imports System.Windows.Forms.Integration

Public Class MixedForm

    Private Sub MixedForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim control As New WPFWindowLibrary.UserControl1()

        ' Create the ElementHost wrapper.
        Dim host As New ElementHost()
        host.Child = control

        ' Set the Location and Size explicitly, unless you are using
        ' a layout container like FlowLayoutPanel or TableLayoutPanel,
        ' or you are using docking.
        'host.Location = New Point(10, 10)
        host.Size = New Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height)

        ' Add the ElementHost to the form or another suitable container.
        flowLayoutPanel1.Controls.Add(host)
    End Sub
End Class