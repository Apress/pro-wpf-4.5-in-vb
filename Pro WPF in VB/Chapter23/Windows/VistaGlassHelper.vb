Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Interop
Imports System.Windows.Media

Public Class VistaGlassHelper
	<StructLayout(LayoutKind.Sequential)> _
	Public Structure Margins
		Public cxLeftWidth As Integer ' width of left border that retains its size
		Public cxRightWidth As Integer ' width of right border that retains its size
		Public cyTopHeight As Integer ' height of top border that retains its size
		Public cyBottomHeight As Integer ' height of bottom border that retains its size
	End Structure


	Public Shared Function GetDpiAdjustedMargins(ByVal windowHandle As IntPtr, ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer) As Margins
		' Get System Dpi
		Dim desktop As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(windowHandle)
		Dim DesktopDpiX As Single = desktop.DpiX
		Dim DesktopDpiY As Single = desktop.DpiY

		' Set Margins
		Dim margins As New VistaGlassHelper.Margins()

		' Note that the default desktop Dpi is 96dpi. The  margins are
		' adjusted for the system Dpi.
		margins.cxLeftWidth = Convert.ToInt32(left * (DesktopDpiX / 96))
		margins.cxRightWidth = Convert.ToInt32(right * (DesktopDpiX / 96))
		margins.cyTopHeight = Convert.ToInt32(top * (DesktopDpiX / 96))
		margins.cyBottomHeight = Convert.ToInt32(right * (DesktopDpiX / 96))

		Return margins
	End Function

	<DllImport("DwmApi.dll")> _
	Public Shared Function DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef pMarInset As Margins) As Integer
	End Function

	Public Shared Sub ExtendGlass(ByVal win As Window, ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer)
		' Obtain the window handle for WPF application
		Dim windowInterop As New WindowInteropHelper(win)
		Dim windowHandle As IntPtr = windowInterop.Handle
		Dim mainWindowSrc As HwndSource = HwndSource.FromHwnd(windowHandle)
		mainWindowSrc.CompositionTarget.BackgroundColor = Colors.Transparent

		Dim margins As VistaGlassHelper.Margins = VistaGlassHelper.GetDpiAdjustedMargins(windowHandle, left, right, top, bottom)

		Dim returnVal As Integer = VistaGlassHelper.DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, margins)

		If returnVal < 0 Then
			Throw New NotSupportedException("Operation failed.")
		End If
	End Sub
End Class
