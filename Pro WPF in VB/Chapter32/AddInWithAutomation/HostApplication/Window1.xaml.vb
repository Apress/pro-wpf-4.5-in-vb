Imports System.AddIn.Hosting
Imports System.Windows.Threading
Imports System.Threading

Public Class Window1

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim path As String = Environment.CurrentDirectory
        AddInStore.Update(path)

        Dim tokens As IList(Of AddInToken) = AddInStore.FindAddIns(GetType(HostView.ImageProcessorHostView), path)
        lstAddIns.ItemsSource = tokens

        automationHost = New AutomationHost(progressBar)
    End Sub

    Private automationHost As AutomationHost

    ' These variables are set on the UI thread and read on the background thread.
    ' For better organization, wrap these in a custom class, and pass that an instance
    ' of that class to RunBackgroundAddIn() method using the ParameterizedThreadStart
    ' delegate.
    Private originalSource As BitmapSource
    Private stride As Integer
    Private originalPixels As Byte()
    Private addin As HostView.ImageProcessorHostView

    Private Sub cmdProcessImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the byte array ready.
        originalSource = CType(img.Source, BitmapSource)
        stride = CInt(originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8)
        stride = stride + (stride Mod 4) * 4
        originalPixels = New Byte(CInt(stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8 - 1)) {}
        originalSource.CopyPixels(originalPixels, stride, 0)

        ' Start the add-in. 
        Dim token As AddInToken = CType(lstAddIns.SelectedItem, AddInToken)
        addin = token.Activate(Of HostView.ImageProcessorHostView)(AddInSecurityLevel.Internet)
        addin.Initialize(automationHost)

        ' Launch the image processing work on a separate thread.
        Dim thread As New Thread(AddressOf RunBackgroundAddIn)
        thread.Start()
    End Sub

    Private Sub RunBackgroundAddIn()
        ' Do the work.
        Dim changedPixels As Byte() = addin.ProcessImageBytes(originalPixels)

        Me.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New ParameterizedThreadStart(AddressOf UpdateDisplay), changedPixels)
    End Sub

    Private Sub UpdateDisplay(ByVal changedPixels As Byte())
        Dim newSource As BitmapSource = BitmapSource.Create(originalSource.PixelWidth, originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY, originalSource.Format, originalSource.Palette, changedPixels, stride)

        img.Source = newSource
        progressBar.Value = 0

        ' Release the add-in (it's a member variable now,
        ' so this step is explicit).
        addin = Nothing
    End Sub

    Private Sub lstAddIns_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        cmdProcessImage.IsEnabled = (lstAddIns.SelectedIndex <> -1)
    End Sub

End Class


Public Class AutomationHost
    Inherits HostView.HostObject
    Private progressBar As ProgressBar

    Public Sub New(ByVal progressBar As ProgressBar)
        Me.progressBar = progressBar
    End Sub

    Public Overrides Sub ReportProgress(ByVal progressPercent As Integer)
        progressBar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New ParameterizedThreadStart(AddressOf UpdateDisplay), progressPercent)
    End Sub

    Private Sub UpdateDisplay(ByVal progressPercent As Integer)
        progressBar.Value = progressPercent
    End Sub

End Class
