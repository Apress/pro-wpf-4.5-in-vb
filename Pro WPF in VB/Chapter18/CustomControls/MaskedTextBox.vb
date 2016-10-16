Imports System.ComponentModel

Public Class MaskedTextBox
    Inherits System.Windows.Controls.TextBox

    Public Shared MaskProperty As DependencyProperty

    Shared Sub New()
        MaskProperty = DependencyProperty.Register("Mask", GetType(String), GetType(MaskedTextBox), New FrameworkPropertyMetadata(AddressOf MaskChanged))

        Dim metadata As New FrameworkPropertyMetadata()
        metadata.CoerceValueCallback = AddressOf CoerceText
        TextProperty.OverrideMetadata(GetType(MaskedTextBox), metadata)

        CommandManager.RegisterClassCommandBinding(GetType(MaskedTextBox), New CommandBinding(ApplicationCommands.Paste, Nothing))
    End Sub

    Private Shared Sub MaskChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim textBox As MaskedTextBox = CType(d, MaskedTextBox)
        d.CoerceValue(TextProperty)
    End Sub

    Private Shared Function CoerceText(ByVal d As DependencyObject, ByVal value As Object) As Object
        Dim textBox As MaskedTextBox = CType(d, MaskedTextBox)
        Dim maskProvider As New MaskedTextProvider(textBox.Mask)
        maskProvider.Set(CStr(value))
        Return maskProvider.ToDisplayString()
    End Function

    Public Sub New()
        MyBase.New()
        Dim commandBinding1 As New CommandBinding(ApplicationCommands.Paste, Nothing, AddressOf SuppressCommand)
        Me.CommandBindings.Add(commandBinding1)
        Dim commandBinding2 As New CommandBinding(ApplicationCommands.Cut, Nothing, AddressOf SuppressCommand)
        Me.CommandBindings.Add(commandBinding2)
    End Sub

    Private Sub SuppressCommand(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = False
        e.Handled = True
    End Sub

    Public Property Mask() As String
        Get
            Return CStr(GetValue(MaskProperty))
        End Get
        Set(ByVal value As String)
            SetValue(MaskProperty, value)
        End Set
    End Property

    Public ReadOnly Property MaskCompleted() As Boolean
        Get
            Dim maskProvider As MaskedTextProvider = GetMaskProvider()
            Return maskProvider.MaskCompleted
        End Get
    End Property

    Protected Overrides Sub OnPreviewKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        Dim maskProvider As MaskedTextProvider = GetMaskProvider()
        Dim pos As Integer = Me.SelectionStart

        ' Deleting a character (Delete key).
        ' Currently this does nothing if you try to delete
        ' a format character (unliked MaskedTextBox, which
        ' deletes the next input character).
        ' Could use our private SkipToEditableCharacter
        ' method to change this behavior.
        If e.Key = Key.Delete AndAlso pos < (Me.Text.Length) Then
            If maskProvider.RemoveAt(pos) Then
                RefreshText(maskProvider, pos)
            End If
            e.Handled = True

            ' Deleting a character (backspace).
            ' Currently this steps over a format character
            ' (unliked MaskedTextBox, which steps over and
            ' deletes the next input character).
            ' Could use our private SkipToEditableCharacter
            ' method to change this behavior.
        ElseIf e.Key = Key.Back Then
            If pos > 0 Then
                pos -= 1
                If maskProvider.RemoveAt(pos) Then
                    RefreshText(maskProvider, pos)
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Protected Overrides Sub OnPreviewTextInput(ByVal e As TextCompositionEventArgs)
        Dim maskProvider As MaskedTextProvider = GetMaskProvider()
        Dim pos As Integer = Me.SelectionStart


        ' Adding a character.
        If pos < Me.Text.Length Then
            pos = SkipToEditableCharacter(pos)

            ' Overwrite mode is on.
            If Keyboard.IsKeyToggled(Key.Insert) Then
                If maskProvider.Replace(e.Text, pos) Then
                    pos += 1
                End If
                ' Insert mode is on.
            Else
                If maskProvider.InsertAt(e.Text, pos) Then
                    pos += 1
                End If
            End If

            ' Find the new cursor position.
            pos = SkipToEditableCharacter(pos)
        End If
        RefreshText(maskProvider, pos)
        e.Handled = True


        MyBase.OnPreviewTextInput(e)
    End Sub


    Private Sub RefreshText(ByVal maskProvider As MaskedTextProvider, ByVal pos As Integer)
        ' Refresh string.            
        Me.Text = maskProvider.ToDisplayString()

        ' Position cursor.
        Me.SelectionStart = pos
    End Sub
    Private Function GetMaskProvider() As MaskedTextProvider
        Dim maskProvider As New MaskedTextProvider(Mask)
        maskProvider.Set(Text)
        Return maskProvider
    End Function

    ' Finds the next non-mask character.
    Private Function SkipToEditableCharacter(ByVal startPos As Integer) As Integer
        Dim maskProvider As MaskedTextProvider = GetMaskProvider()

        Dim newPos As Integer = maskProvider.FindEditPositionFrom(startPos, True)
        If newPos = -1 Then
            ' Already at the end of the string.
            Return startPos
        Else
            Return newPos
        End If
    End Function
End Class

