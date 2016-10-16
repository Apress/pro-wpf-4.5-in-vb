Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Forms.Integration


''' <summary>
''' Interaction logic for Window1.xaml
''' </summary>

Public Partial Class Window1
	Inherits System.Windows.Window
	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub cmdShowWinForm_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim frm As New Form1()
		frm.Show()
	End Sub

	Private Sub cmdShowHostWinFormControl_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim win As New HostWinFormControl()
		win.Show()
	End Sub


	Private Sub cmdEnableSupport_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		WindowsFormsHost.EnableWindowsFormsInterop()
	End Sub

	Private Sub cmdShowModalWinForm_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim frm As New Form1()
		If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
			MessageBox.Show("You clicked OK.")
		End If
	End Sub
	Private Sub cmdShowWPFMnemonic_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim win As New MnemonicTest()
		win.ShowDialog()
	End Sub
	Private Sub cmdShowWinFormMnemonic_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim frm As New MnemonicTest2()
		frm.ShowDialog()
	End Sub

End Class