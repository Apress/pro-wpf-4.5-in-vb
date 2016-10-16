Imports System.Speech.Synthesis

Public Class SpeechSynthesis

    Private Sub cmdSpeak_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim synthesizer As New SpeechSynthesizer()
        synthesizer.Speak(txtWords.Text)
    End Sub

    Private Sub cmdPromptTest_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim prompt As New PromptBuilder()

        prompt.AppendText("How are you")
        prompt.AppendBreak(TimeSpan.FromSeconds(2))
        prompt.AppendText("How ", PromptEmphasis.Reduced)
        Dim style As New PromptStyle()
        style.Rate = PromptRate.ExtraSlow
        style.Emphasis = PromptEmphasis.Strong
        prompt.StartStyle(style)
        prompt.AppendText("are ")
        prompt.EndStyle()
        prompt.AppendText("you?")



        Dim synthesizer As New SpeechSynthesizer()
        synthesizer.Speak(prompt)

    End Sub
End Class