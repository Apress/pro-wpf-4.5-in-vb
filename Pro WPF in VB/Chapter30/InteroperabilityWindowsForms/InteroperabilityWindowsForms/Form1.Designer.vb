<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdShowMixedForm = New System.Windows.Forms.Button
        Me.cmdShowRight = New System.Windows.Forms.Button
        Me.cmdShowWrong = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdShowMixedForm
        '
        Me.cmdShowMixedForm.Location = New System.Drawing.Point(29, 126)
        Me.cmdShowMixedForm.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdShowMixedForm.Name = "cmdShowMixedForm"
        Me.cmdShowMixedForm.Size = New System.Drawing.Size(134, 37)
        Me.cmdShowMixedForm.TabIndex = 5
        Me.cmdShowMixedForm.Text = "Show a form with mixed content"
        Me.cmdShowMixedForm.UseVisualStyleBackColor = True
        '
        'cmdShowRight
        '
        Me.cmdShowRight.Location = New System.Drawing.Point(29, 75)
        Me.cmdShowRight.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdShowRight.Name = "cmdShowRight"
        Me.cmdShowRight.Size = New System.Drawing.Size(134, 37)
        Me.cmdShowRight.TabIndex = 4
        Me.cmdShowRight.Text = "Show a modeless WPF Window (the right way)"
        Me.cmdShowRight.UseVisualStyleBackColor = True
        '
        'cmdShowWrong
        '
        Me.cmdShowWrong.Location = New System.Drawing.Point(29, 24)
        Me.cmdShowWrong.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdShowWrong.Name = "cmdShowWrong"
        Me.cmdShowWrong.Size = New System.Drawing.Size(134, 37)
        Me.cmdShowWrong.TabIndex = 3
        Me.cmdShowWrong.Text = "Show a modeless WPF Window (the wrong way)"
        Me.cmdShowWrong.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.cmdShowMixedForm)
        Me.Controls.Add(Me.cmdShowRight)
        Me.Controls.Add(Me.cmdShowWrong)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents cmdShowMixedForm As System.Windows.Forms.Button
    Private WithEvents cmdShowRight As System.Windows.Forms.Button
    Private WithEvents cmdShowWrong As System.Windows.Forms.Button

End Class
