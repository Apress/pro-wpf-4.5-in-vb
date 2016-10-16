<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MixedForm
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
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(20, 53)
        Me.flowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(340, 271)
        Me.flowLayoutPanel1.TabIndex = 3
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(20, 11)
        Me.button1.Margin = New System.Windows.Forms.Padding(2)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(126, 28)
        Me.button1.TabIndex = 2
        Me.button1.Text = "WinForms Content"
        Me.button1.UseVisualStyleBackColor = True
        '
        'MixedForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 350)
        Me.Controls.Add(Me.flowLayoutPanel1)
        Me.Controls.Add(Me.button1)
        Me.Name = "MixedForm"
        Me.Text = "MixedForm"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents button1 As System.Windows.Forms.Button
End Class
