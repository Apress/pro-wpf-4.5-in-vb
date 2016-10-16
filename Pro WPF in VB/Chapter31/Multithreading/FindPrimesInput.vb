Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class FindPrimesInput
    Private _to As Integer

    Public Property [To]() As Integer
        Get
            Return _to
        End Get
        Set(ByVal value As Integer)
            _to = value
        End Set
    End Property

    Private _from As Integer
	Public Property From() As Integer
		Get
            Return _from
		End Get
		Set(ByVal value As Integer)
            _from = value
		End Set
	End Property

    Public Sub New(ByVal fromValue As Integer, ByVal toValue As Integer)
        Me.To = toValue
        Me.From = fromValue
    End Sub

End Class
