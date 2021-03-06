﻿#ExternalChecksum("..\..\..\SynchronizedAnimation.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","E41E147B7871A4DBEA3553C996255336")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.17929
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''SynchronizedAnimation
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class SynchronizedAnimation
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",4)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents DocumentRoot As SynchronizedAnimation
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",37)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents mediaStoryboard As System.Windows.Media.Animation.BeginStoryboard
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",47)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents media As System.Windows.Controls.MediaElement
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",48)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lblAnimated As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",49)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents sliderPosition As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",51)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ellipse As System.Windows.Shapes.Ellipse
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\SynchronizedAnimation.xaml",52)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lblTime As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/SoundAndVideo;component/synchronizedanimation.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\SynchronizedAnimation.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.DocumentRoot = CType(target,SynchronizedAnimation)
            Return
        End If
        If (connectionId = 2) Then
            
            #ExternalSource("..\..\..\SynchronizedAnimation.xaml",8)
            AddHandler CType(target,System.Windows.Media.Animation.Storyboard).CurrentTimeInvalidated, New System.EventHandler(AddressOf Me.storyboard_CurrentTimeInvalidated)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 3) Then
            Me.mediaStoryboard = CType(target,System.Windows.Media.Animation.BeginStoryboard)
            Return
        End If
        If (connectionId = 4) Then
            Me.media = CType(target,System.Windows.Controls.MediaElement)
            
            #ExternalSource("..\..\..\SynchronizedAnimation.xaml",47)
            AddHandler Me.media.MediaOpened, New System.Windows.RoutedEventHandler(AddressOf Me.media_MediaOpened)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            Me.lblAnimated = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 6) Then
            Me.sliderPosition = CType(target,System.Windows.Controls.Slider)
            
            #ExternalSource("..\..\..\SynchronizedAnimation.xaml",49)
            AddHandler Me.sliderPosition.ValueChanged, New System.Windows.RoutedPropertyChangedEventHandler(Of Double)(AddressOf Me.sliderPosition_ValueChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 7) Then
            Me.ellipse = CType(target,System.Windows.Shapes.Ellipse)
            Return
        End If
        If (connectionId = 8) Then
            Me.lblTime = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

