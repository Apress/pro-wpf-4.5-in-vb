<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(20, 59)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(127, 54)
        Me.button1.TabIndex = 0
        Me.button1.Text = "OK"
        Me.button1.UseVisualStyleBackColor = True
        ' 
        ' button2
        ' 
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(20, 119)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(127, 54)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Cancel"
        Me.button2.UseVisualStyleBackColor = True
        ' 
        ' button3
        ' 
        Me.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button3.Location = New System.Drawing.Point(20, 180)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(127, 54)
        Me.button3.TabIndex = 2
        Me.button3.Text = "Show WPF"
        Me.button3.UseVisualStyleBackColor = True
        '		Me.button3.Click += New System.EventHandler(Me.button3_Click);
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(20, 21)
        Me.textBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(100, 20)
        Me.textBox1.TabIndex = 3
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(33, 260)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.MaximumSize = New System.Drawing.Size(250, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(235, 26)
        Me.label1.TabIndex = 4
        Me.label1.Text = "If you've enabled support, the Tab key will work when this window is shown modele" & "ssly."
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 314)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        '		Me.Load += New System.EventHandler(Me.Form1_Load);
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private button1 As System.Windows.Forms.Button
    Private button2 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private textBox1 As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
End Class