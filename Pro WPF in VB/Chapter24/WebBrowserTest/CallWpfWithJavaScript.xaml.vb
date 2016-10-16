Imports System.Runtime.InteropServices

Public Class CallWpfWithJavaScript
    Public Sub New()
        InitializeComponent()

        webBrowser.Navigate("file:///" & System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location), "sample.htm"))
        webBrowser.ObjectForScripting = New HtmlBridge()
    End Sub

End Class

<ComVisible(True)> _
Public Class HtmlBridge
    Public Sub WebClick(ByVal source As String)
        MessageBox.Show("Received: " & source)
    End Sub
End Class


