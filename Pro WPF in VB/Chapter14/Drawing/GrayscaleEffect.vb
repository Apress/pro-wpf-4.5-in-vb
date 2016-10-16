Imports System.Windows.Media.Effects

Public Class GrayscaleEffect
    Inherits ShaderEffect

    Public Sub New()
        Dim pixelShaderUri As New Uri("Grayscale_Compiled.ps", UriKind.Relative)

        ' Load the information from the .ps file.
        PixelShader = New PixelShader()
        PixelShader.UriSource = pixelShaderUri

        UpdateShaderValue(InputProperty)
    End Sub

    Public Shared ReadOnly InputProperty As DependencyProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", GetType(GrayscaleEffect), 0)

    Public Property Input() As Brush
        Get
            Return CType(GetValue(InputProperty), Brush)
        End Get
        Set(ByVal value As Brush)
            SetValue(InputProperty, value)
        End Set
    End Property
End Class
