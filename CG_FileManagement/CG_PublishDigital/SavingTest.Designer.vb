<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SavingTest
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
        Me.bWorker = New System.ComponentModel.BackgroundWorker()
        Me.bt_save = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bt_save
        '
        Me.bt_save.Location = New System.Drawing.Point(12, 12)
        Me.bt_save.Name = "bt_save"
        Me.bt_save.Size = New System.Drawing.Size(309, 33)
        Me.bt_save.TabIndex = 0
        Me.bt_save.Text = "Save to Datacenter"
        Me.bt_save.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 60)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(461, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(327, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 33)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SavingTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 97)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.bt_save)
        Me.Name = "SavingTest"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents bt_save As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
