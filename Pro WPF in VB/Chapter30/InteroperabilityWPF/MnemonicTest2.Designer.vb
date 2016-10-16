<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MnemonicTest2
    Inherits System.Windows.Forms.Form
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(118, 171)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Alt+&C"
        Me.button1.UseVisualStyleBackColor = True
        '		Me.button1.Click += New System.EventHandler(Me.button1_Click);
        ' 
        ' MnemonicTest2
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.button1)
        Me.Name = "MnemonicTest2"
        Me.Text = "MnemonicTest2"
        '		Me.Load += New System.EventHandler(Me.MnemonicTest2_Load);
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents button1 As System.Windows.Forms.Button

End Class