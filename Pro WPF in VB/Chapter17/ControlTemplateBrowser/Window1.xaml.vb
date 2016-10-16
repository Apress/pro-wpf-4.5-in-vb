Imports System.Xml
Imports System.Text
Imports System.Windows.Markup
Imports System.Reflection

Public Class Window1

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As EventArgs)
        Dim controlType As Type = GetType(Control)
        Dim derivedTypes As List(Of Type) = New List(Of Type)()

        ' Search all the types in the assembly where the Control class is defined.
        Dim controlAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetAssembly(GetType(Control))
        For Each type As Type In controlAssembly.GetTypes()
            ' Only add a type of the list if it's a Control, a concrete class, and public.
            If type.IsSubclassOf(controlType) AndAlso (Not type.IsAbstract) AndAlso type.IsPublic Then
                derivedTypes.Add(type)
            End If
        Next

        ' Sort the types by type name.
        derivedTypes.Sort(New TypeComparer())

        ' Show the list of types.
        lstTypes.ItemsSource = derivedTypes
    End Sub

    Private Sub lstTypes_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Try
            ' Get the selected type.
            Dim type As Type = CType(lstTypes.SelectedItem, Type)

            ' Instantiate the type.
            Dim info As ConstructorInfo = type.GetConstructor(System.Type.EmptyTypes)
            Dim control As Control = CType(info.Invoke(Nothing), Control)

            Dim win As Window = TryCast(control, Window)
            If win IsNot Nothing Then
                ' Create the window (but keep it minimized).
                win.WindowState = System.Windows.WindowState.Minimized
                win.ShowInTaskbar = False
                win.Show()
            Else
                ' Add it to the grid (but keep it hidden).
                control.Visibility = Visibility.Collapsed
                grid.Children.Add(control)
            End If

            ' Get the template.
            Dim template As ControlTemplate = control.Template

            ' Get the XAML for the template.
            Dim settings As New XmlWriterSettings()
            settings.Indent = True
            Dim sb As New StringBuilder()
            Dim writer As XmlWriter = XmlWriter.Create(sb, settings)
            XamlWriter.Save(template, writer)

            ' Display the template.
            txtTemplate.Text = sb.ToString()

            ' Remove the control from the grid.
            grid.Children.Remove(control)
        Catch err As Exception
            txtTemplate.Text = "<< Error generating template: " & err.Message & ">>"
        End Try
    End Sub
End Class

Public Class TypeComparer
	Implements IComparer(Of Type)
	Public Function Compare(ByVal x As Type, ByVal y As Type) As Integer Implements IComparer(Of Type).Compare
		Return x.Name.CompareTo(y.Name)
	End Function
End Class