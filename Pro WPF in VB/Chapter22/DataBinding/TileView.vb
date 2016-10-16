Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Media

Public Class TileView
    Inherits ViewBase

    Private _itemTemplate As DataTemplate
    Public Property ItemTemplate() As DataTemplate
        Get
            Return _itemTemplate
        End Get
        Set(ByVal value As DataTemplate)
            _itemTemplate = value
        End Set
    End Property

    Private _selectedBackground As Brush = Brushes.Transparent
    Public Property SelectedBackground() As Brush
        Get
            Return _selectedBackground
        End Get
        Set(ByVal value As Brush)
            _selectedBackground = value
        End Set
    End Property

    Private _selectedBorderBrush As Brush = Brushes.Black
    Public Property SelectedBorderBrush() As Brush
        Get
            Return _selectedBorderBrush
        End Get
        Set(ByVal value As Brush)
            _selectedBorderBrush = value
        End Set
    End Property

	Protected Overrides ReadOnly Property DefaultStyleKey() As Object
		Get
			Return New ComponentResourceKey(Me.GetType(), "TileView")
		End Get
	End Property

	Protected Overrides ReadOnly Property ItemContainerDefaultStyleKey() As Object
		Get
			Return New ComponentResourceKey(Me.GetType(), "TileViewItem")
		End Get
	End Property
End Class
