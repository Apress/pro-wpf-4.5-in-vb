
Partial Public Class UserNameWinForm
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
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' cmdOK
        ' 
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(48, 129)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 35)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdCancel
        ' 
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(133, 129)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 35)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(23, 35)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(163, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Please enter your name."
        ' 
        ' txtName
        ' 
        Me.txtName.Location = New System.Drawing.Point(26, 65)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(210, 22)
        Me.txtName.TabIndex = 3
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0F, 16.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 189)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Name = "Form1"
        Me.Text = "Windows Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private cmdOK As System.Windows.Forms.Button
    Private cmdCancel As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private txtName As System.Windows.Forms.TextBox
End Class