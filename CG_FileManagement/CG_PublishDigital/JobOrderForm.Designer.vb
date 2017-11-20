<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobOrderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.g_JobOrder = New System.Windows.Forms.GroupBox()
        Me.dt_pukul = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_preview = New System.Windows.Forms.Button()
        Me.t_uraianpekerjaan = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.t_ketsampel = New System.Windows.Forms.TextBox()
        Me.dt_TglSelesai = New System.Windows.Forms.DateTimePicker()
        Me.dt_TglMasuk = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t_noinvoice = New System.Windows.Forms.TextBox()
        Me.PdfViewer1 = New PdfiumViewer.PdfViewer()
        Me.pb_header = New System.Windows.Forms.PictureBox()
        Me.g_JobOrder.SuspendLayout()
        CType(Me.pb_header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'g_JobOrder
        '
        Me.g_JobOrder.Controls.Add(Me.dt_pukul)
        Me.g_JobOrder.Controls.Add(Me.Label4)
        Me.g_JobOrder.Controls.Add(Me.Label6)
        Me.g_JobOrder.Controls.Add(Me.bt_preview)
        Me.g_JobOrder.Controls.Add(Me.t_uraianpekerjaan)
        Me.g_JobOrder.Controls.Add(Me.Label5)
        Me.g_JobOrder.Controls.Add(Me.t_ketsampel)
        Me.g_JobOrder.Controls.Add(Me.dt_TglSelesai)
        Me.g_JobOrder.Controls.Add(Me.dt_TglMasuk)
        Me.g_JobOrder.Controls.Add(Me.Label3)
        Me.g_JobOrder.Controls.Add(Me.Label2)
        Me.g_JobOrder.Controls.Add(Me.Label1)
        Me.g_JobOrder.Controls.Add(Me.t_noinvoice)
        Me.g_JobOrder.Location = New System.Drawing.Point(12, 65)
        Me.g_JobOrder.Name = "g_JobOrder"
        Me.g_JobOrder.Size = New System.Drawing.Size(345, 332)
        Me.g_JobOrder.TabIndex = 1
        Me.g_JobOrder.TabStop = False
        Me.g_JobOrder.Text = "Data Job Order"
        '
        'dt_pukul
        '
        Me.dt_pukul.CustomFormat = "HH:mm"
        Me.dt_pukul.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_pukul.Location = New System.Drawing.Point(98, 125)
        Me.dt_pukul.Name = "dt_pukul"
        Me.dt_pukul.ShowUpDown = True
        Me.dt_pukul.Size = New System.Drawing.Size(200, 20)
        Me.dt_pukul.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Pukul"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Uraian Pekerjaan"
        '
        'bt_preview
        '
        Me.bt_preview.Location = New System.Drawing.Point(203, 286)
        Me.bt_preview.Name = "bt_preview"
        Me.bt_preview.Size = New System.Drawing.Size(132, 36)
        Me.bt_preview.TabIndex = 2
        Me.bt_preview.Text = "Preview >>"
        Me.bt_preview.UseVisualStyleBackColor = True
        '
        't_uraianpekerjaan
        '
        Me.t_uraianpekerjaan.Location = New System.Drawing.Point(98, 158)
        Me.t_uraianpekerjaan.Name = "t_uraianpekerjaan"
        Me.t_uraianpekerjaan.Size = New System.Drawing.Size(237, 20)
        Me.t_uraianpekerjaan.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Ket. Sample"
        '
        't_ketsampel
        '
        Me.t_ketsampel.Location = New System.Drawing.Point(98, 191)
        Me.t_ketsampel.Multiline = True
        Me.t_ketsampel.Name = "t_ketsampel"
        Me.t_ketsampel.Size = New System.Drawing.Size(237, 84)
        Me.t_ketsampel.TabIndex = 8
        '
        'dt_TglSelesai
        '
        Me.dt_TglSelesai.CustomFormat = "dd/MM/yyyy"
        Me.dt_TglSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_TglSelesai.Location = New System.Drawing.Point(98, 92)
        Me.dt_TglSelesai.Name = "dt_TglSelesai"
        Me.dt_TglSelesai.Size = New System.Drawing.Size(200, 20)
        Me.dt_TglSelesai.TabIndex = 5
        '
        'dt_TglMasuk
        '
        Me.dt_TglMasuk.CustomFormat = "dd/MM/yyyy"
        Me.dt_TglMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_TglMasuk.Location = New System.Drawing.Point(98, 59)
        Me.dt_TglMasuk.Name = "dt_TglMasuk"
        Me.dt_TglMasuk.Size = New System.Drawing.Size(200, 20)
        Me.dt_TglMasuk.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tgl. Selesai"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tgl. Masuk"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No. Invoice"
        '
        't_noinvoice
        '
        Me.t_noinvoice.Location = New System.Drawing.Point(98, 26)
        Me.t_noinvoice.Name = "t_noinvoice"
        Me.t_noinvoice.Size = New System.Drawing.Size(237, 20)
        Me.t_noinvoice.TabIndex = 0
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PdfViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PdfViewer1.Location = New System.Drawing.Point(363, 12)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.ShowBookmarks = False
        Me.PdfViewer1.Size = New System.Drawing.Size(471, 385)
        Me.PdfViewer1.TabIndex = 3
        Me.PdfViewer1.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth
        '
        'pb_header
        '
        Me.pb_header.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pb_header.Image = Global.CG_FileManagement.My.Resources.Resources.BuatJobOrder
        Me.pb_header.Location = New System.Drawing.Point(12, 12)
        Me.pb_header.Name = "pb_header"
        Me.pb_header.Size = New System.Drawing.Size(345, 47)
        Me.pb_header.TabIndex = 14
        Me.pb_header.TabStop = False
        '
        'JobOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 412)
        Me.Controls.Add(Me.pb_header)
        Me.Controls.Add(Me.PdfViewer1)
        Me.Controls.Add(Me.g_JobOrder)
        Me.Name = "JobOrderForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buat Job Order..."
        Me.g_JobOrder.ResumeLayout(False)
        Me.g_JobOrder.PerformLayout()
        CType(Me.pb_header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents g_JobOrder As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents t_noinvoice As System.Windows.Forms.TextBox
    Friend WithEvents dt_TglSelesai As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_TglMasuk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents t_ketsampel As System.Windows.Forms.TextBox
    Friend WithEvents bt_preview As System.Windows.Forms.Button
    Friend WithEvents PdfViewer1 As PdfiumViewer.PdfViewer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents t_uraianpekerjaan As System.Windows.Forms.TextBox
    Friend WithEvents pb_header As System.Windows.Forms.PictureBox
    Friend WithEvents dt_pukul As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
