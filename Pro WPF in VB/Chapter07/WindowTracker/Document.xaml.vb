Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

''' <summary>
''' Interaction logic for Document.xaml
''' </summary>

Public Partial Class Document
	Inherits Window
	Public Sub New()
		InitializeComponent()
	End Sub

	Public Sub SetContent(ByVal content As String)
		Me.Content = content
	End Sub
End Class