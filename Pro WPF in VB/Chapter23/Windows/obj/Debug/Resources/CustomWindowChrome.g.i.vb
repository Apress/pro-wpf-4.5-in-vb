﻿#ExternalChecksum("..\..\..\Resources\CustomWindowChrome.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","7166578BEBD0E66367771D5F39F29DDC")
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
'''CustomWindowChrome
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class CustomWindowChrome
    Inherits System.Windows.ResourceDictionary
    Implements System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    
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
        Dim resourceLocater As System.Uri = New System.Uri("/Windows;component/resources/customwindowchrome.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",1)
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
        Me._contentLoaded = true
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")>  _
    Sub System_Windows_Markup_IStyleConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IStyleConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",92)
            AddHandler CType(target,System.Windows.Controls.TextBlock).MouseLeftButtonDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.titleBar_MouseLeftButtonDown)
            
            #End ExternalSource
        End If
        If (connectionId = 2) Then
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",94)
            AddHandler CType(target,System.Windows.Controls.Button).Click, New System.Windows.RoutedEventHandler(AddressOf Me.cmdClose_Click)
            
            #End ExternalSource
        End If
        If (connectionId = 3) Then
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",115)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseLeftButtonDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.window_initiateResizeWE)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",116)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseLeftButtonUp, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.window_endResize)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",117)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseMove, New System.Windows.Input.MouseEventHandler(AddressOf Me.window_Resize)
            
            #End ExternalSource
        End If
        If (connectionId = 4) Then
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",122)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseLeftButtonDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.window_initiateResizeNS)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",123)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseLeftButtonUp, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.window_endResize)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Resources\CustomWindowChrome.xaml",124)
            AddHandler CType(target,System.Windows.Shapes.Rectangle).MouseMove, New System.Windows.Input.MouseEventHandler(AddressOf Me.window_Resize)
            
            #End ExternalSource
        End If
    End Sub
End Class
