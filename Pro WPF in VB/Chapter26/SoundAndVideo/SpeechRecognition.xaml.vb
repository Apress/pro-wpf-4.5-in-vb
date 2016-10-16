Imports System.Speech.Recognition

Public Class SpeechRecognition

    Private recognizer As New SpeechRecognizer()

    Public Sub New()
        InitializeComponent()

        Dim grammar As New GrammarBuilder()
        grammar.Append(New Choices("red", "blue", "green", "black", "white"))
        grammar.Append(New Choices("on", "off"))

        recognizer.LoadGrammar(New Grammar(grammar))
        AddHandler recognizer.SpeechDetected, AddressOf recognizer_SpeechDetected
        AddHandler recognizer.SpeechRecognized, AddressOf recognizer_SpeechRecognized
        AddHandler recognizer.SpeechRecognitionRejected, AddressOf recognizer_SpeechRejected
        AddHandler recognizer.SpeechHypothesized, AddressOf recognizer_SpeechHypothesized
    End Sub

    Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        lbl.Content = "You said: " & e.Result.Text
    End Sub

    Private Sub recognizer_SpeechDetected(ByVal sender As Object, ByVal e As SpeechDetectedEventArgs)
        lbl.Content = "Speech detected."
    End Sub

    Private Sub recognizer_SpeechHypothesized(ByVal sender As Object, ByVal e As SpeechHypothesizedEventArgs)
        lbl.Content = "Speech uncertain."
    End Sub

    Private Sub recognizer_SpeechRejected(ByVal sender As Object, ByVal e As SpeechRecognitionRejectedEventArgs)
        lbl.Content = "Speech rejected."
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
        recognizer.Dispose()
    End Sub
End Class