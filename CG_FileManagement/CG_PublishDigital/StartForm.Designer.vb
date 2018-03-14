<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartForm
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
        Me.ImageLogo = New System.Windows.Forms.PictureBox()
        Me.Bt_FileCustomer = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.ImageLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageLogo
        '
        Me.ImageLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImageLogo.Image = Global.CG_FileManagement.My.Resources.Resources.CGToolsFileManagementSystem
        Me.ImageLogo.InitialImage = Nothing
        Me.ImageLogo.Location = New System.Drawing.Point(12, 12)
        Me.ImageLogo.Name = "ImageLogo"
        Me.ImageLogo.Size = New System.Drawing.Size(584, 57)
        Me.ImageLogo.TabIndex = 2
        Me.ImageLogo.TabStop = False
        '
        'Bt_FileCustomer
        '
        Me.Bt_FileCustomer.Location = New System.Drawing.Point(12, 75)
        Me.Bt_FileCustomer.Name = "Bt_FileCustomer"
        Me.Bt_FileCustomer.Size = New System.Drawing.Size(272, 110)
        Me.Bt_FileCustomer.TabIndex = 0
        Me.Bt_FileCustomer.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Bt_FileCustomer.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(272, 110)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(290, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(306, 226)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button2.UseVisualStyleBackColor = True
        '
        'StartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 310)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ImageLogo)
        Me.Controls.Add(Me.Bt_FileCustomer)
        Me.Name = "StartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pilih Tujuan Penyimpanan File"
        CType(Me.ImageLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Bt_FileCustomer As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
