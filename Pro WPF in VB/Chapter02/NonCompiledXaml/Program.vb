Public Class Program
    Inherits Application

    Shared Sub Main()

        ' Create a program that will show two different windows,
        ' and will wait until both are closed before ending.
        Dim app As Program = New Program()
        app.ShutdownMode = ShutdownMode.OnLastWindowClose

        ' First approach: window with XAML content.
        Dim window1 As New Window1("Window1.xaml")
        window1.Show()

        ' Second approach: XAML for complete window.            
        Dim window2 As Xaml2009Window = Xaml2009Window.LoadWindowFromXaml("Xaml2009.xaml")
        window2.Show()

        app.Run()
    End Sub
End Class
