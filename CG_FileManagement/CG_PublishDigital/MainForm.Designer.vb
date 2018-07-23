<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.gr_datacustomer = New System.Windows.Forms.GroupBox()
        Me.cb_grouppermanent = New System.Windows.Forms.ComboBox()
        Me.c_permanent = New System.Windows.Forms.CheckBox()
        Me.cb_presetcustomer = New System.Windows.Forms.ComboBox()
        Me.t_judulfile = New System.Windows.Forms.TextBox()
        Me.t_customer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.g_datasetting = New System.Windows.Forms.GroupBox()
        Me.t_jmlpage = New System.Windows.Forms.Label()
        Me.t_satuanqty = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.n_qtycetak = New System.Windows.Forms.NumericUpDown()
        Me.n_noorder = New System.Windows.Forms.NumericUpDown()
        Me.c_bahan = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.t_harga = New System.Windows.Forms.TextBox()
        Me.cb_bahan = New System.Windows.Forms.ComboBox()
        Me.cb_jenisorder = New System.Windows.Forms.ComboBox()
        Me.cb_operator = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.g_cdr = New System.Windows.Forms.GroupBox()
        Me.rb_noconv = New System.Windows.Forms.RadioButton()
        Me.rb_convbitmap = New System.Windows.Forms.RadioButton()
        Me.rb_convcurve = New System.Windows.Forms.RadioButton()
        Me.g_pdf = New System.Windows.Forms.GroupBox()
        Me.pgNumRange = New System.Windows.Forms.TextBox()
        Me.rb_setpage = New System.Windows.Forms.RadioButton()
        Me.rb_currpage = New System.Windows.Forms.RadioButton()
        Me.rb_allpage = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cb_imposition = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cb_sisimuka = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_layout = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_Finishing = New System.Windows.Forms.TabControl()
        Me.tb_finishinga3 = New System.Windows.Forms.TabPage()
        Me.pn_finishinga3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_finishingptp = New System.Windows.Forms.TabPage()
        Me.pn_finishingptp = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_finishingkn = New System.Windows.Forms.TabPage()
        Me.pn_finishingkn = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_finishingbr = New System.Windows.Forms.TabPage()
        Me.pn_finishingbr = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_finishinglf = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lst_finishingfn = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_fnframe = New System.Windows.Forms.CheckBox()
        Me.grp_laminasilf = New System.Windows.Forms.GroupBox()
        Me.rb_nonelf = New System.Windows.Forms.RadioButton()
        Me.rb_doff = New System.Windows.Forms.RadioButton()
        Me.rb_glossy = New System.Windows.Forms.RadioButton()
        Me.tb_finishingbw = New System.Windows.Forms.TabPage()
        Me.pn_finishingbw = New System.Windows.Forms.FlowLayoutPanel()
        Me.g_preview = New System.Windows.Forms.GroupBox()
        Me.t_preview = New System.Windows.Forms.TextBox()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.bt_OK = New System.Windows.Forms.Button()
        Me.statuslabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsProgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bWorker = New System.ComponentModel.BackgroundWorker()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pb_header = New System.Windows.Forms.PictureBox()
        Me.gr_datacustomer.SuspendLayout()
        Me.g_datasetting.SuspendLayout()
        CType(Me.n_qtycetak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.n_noorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g_cdr.SuspendLayout()
        Me.g_pdf.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tb_Finishing.SuspendLayout()
        Me.tb_finishinga3.SuspendLayout()
        Me.tb_finishingptp.SuspendLayout()
        Me.tb_finishingkn.SuspendLayout()
        Me.tb_finishingbr.SuspendLayout()
        Me.tb_finishinglf.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grp_laminasilf.SuspendLayout()
        Me.tb_finishingbw.SuspendLayout()
        Me.g_preview.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gr_datacustomer
        '
        Me.gr_datacustomer.Controls.Add(Me.cb_grouppermanent)
        Me.gr_datacustomer.Controls.Add(Me.c_permanent)
        Me.gr_datacustomer.Controls.Add(Me.cb_presetcustomer)
        Me.gr_datacustomer.Controls.Add(Me.t_judulfile)
        Me.gr_datacustomer.Controls.Add(Me.t_customer)
        Me.gr_datacustomer.Controls.Add(Me.Label4)
        Me.gr_datacustomer.Controls.Add(Me.Label3)
        Me.gr_datacustomer.Location = New System.Drawing.Point(12, 65)
        Me.gr_datacustomer.Name = "gr_datacustomer"
        Me.gr_datacustomer.Size = New System.Drawing.Size(549, 110)
        Me.gr_datacustomer.TabIndex = 1
        Me.gr_datacustomer.TabStop = False
        Me.gr_datacustomer.Text = "Data Customer"
        '
        'cb_grouppermanent
        '
        Me.cb_grouppermanent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_grouppermanent.Enabled = False
        Me.cb_grouppermanent.FormattingEnabled = True
        Me.cb_grouppermanent.Location = New System.Drawing.Point(252, 80)
        Me.cb_grouppermanent.Name = "cb_grouppermanent"
        Me.cb_grouppermanent.Size = New System.Drawing.Size(153, 21)
        Me.cb_grouppermanent.TabIndex = 21
        '
        'c_permanent
        '
        Me.c_permanent.AutoSize = True
        Me.c_permanent.Location = New System.Drawing.Point(96, 82)
        Me.c_permanent.Name = "c_permanent"
        Me.c_permanent.Size = New System.Drawing.Size(150, 17)
        Me.c_permanent.TabIndex = 20
        Me.c_permanent.Text = "Salin ke Folder Permanent"
        Me.c_permanent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.c_permanent.UseVisualStyleBackColor = True
        '
        'cb_presetcustomer
        '
        Me.cb_presetcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_presetcustomer.FormattingEnabled = True
        Me.cb_presetcustomer.Location = New System.Drawing.Point(411, 23)
        Me.cb_presetcustomer.Name = "cb_presetcustomer"
        Me.cb_presetcustomer.Size = New System.Drawing.Size(131, 21)
        Me.cb_presetcustomer.TabIndex = 2
        Me.cb_presetcustomer.TabStop = False
        '
        't_judulfile
        '
        Me.t_judulfile.Location = New System.Drawing.Point(95, 53)
        Me.t_judulfile.Name = "t_judulfile"
        Me.t_judulfile.Size = New System.Drawing.Size(447, 20)
        Me.t_judulfile.TabIndex = 3
        '
        't_customer
        '
        Me.t_customer.Location = New System.Drawing.Point(95, 24)
        Me.t_customer.Name = "t_customer"
        Me.t_customer.Size = New System.Drawing.Size(310, 20)
        Me.t_customer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Judul File"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nama Customer"
        '
        'g_datasetting
        '
        Me.g_datasetting.Controls.Add(Me.t_jmlpage)
        Me.g_datasetting.Controls.Add(Me.t_satuanqty)
        Me.g_datasetting.Controls.Add(Me.Label13)
        Me.g_datasetting.Controls.Add(Me.n_qtycetak)
        Me.g_datasetting.Controls.Add(Me.n_noorder)
        Me.g_datasetting.Controls.Add(Me.c_bahan)
        Me.g_datasetting.Controls.Add(Me.Label9)
        Me.g_datasetting.Controls.Add(Me.t_harga)
        Me.g_datasetting.Controls.Add(Me.cb_bahan)
        Me.g_datasetting.Controls.Add(Me.cb_jenisorder)
        Me.g_datasetting.Controls.Add(Me.cb_operator)
        Me.g_datasetting.Controls.Add(Me.Label8)
        Me.g_datasetting.Controls.Add(Me.Label7)
        Me.g_datasetting.Controls.Add(Me.Label6)
        Me.g_datasetting.Controls.Add(Me.Label5)
        Me.g_datasetting.Location = New System.Drawing.Point(12, 180)
        Me.g_datasetting.Name = "g_datasetting"
        Me.g_datasetting.Size = New System.Drawing.Size(299, 206)
        Me.g_datasetting.TabIndex = 2
        Me.g_datasetting.TabStop = False
        Me.g_datasetting.Text = "Data Setting"
        '
        't_jmlpage
        '
        Me.t_jmlpage.Location = New System.Drawing.Point(201, 179)
        Me.t_jmlpage.Name = "t_jmlpage"
        Me.t_jmlpage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.t_jmlpage.Size = New System.Drawing.Size(92, 16)
        Me.t_jmlpage.TabIndex = 19
        Me.t_jmlpage.Text = "Jumlah Page: 1"
        Me.t_jmlpage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        't_satuanqty
        '
        Me.t_satuanqty.AutoSize = True
        Me.t_satuanqty.Location = New System.Drawing.Point(150, 181)
        Me.t_satuanqty.Name = "t_satuanqty"
        Me.t_satuanqty.Size = New System.Drawing.Size(28, 13)
        Me.t_satuanqty.TabIndex = 18
        Me.t_satuanqty.Text = "LBR"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Qty Cetak"
        '
        'n_qtycetak
        '
        Me.n_qtycetak.Location = New System.Drawing.Point(97, 177)
        Me.n_qtycetak.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.n_qtycetak.Name = "n_qtycetak"
        Me.n_qtycetak.Size = New System.Drawing.Size(52, 20)
        Me.n_qtycetak.TabIndex = 7
        '
        'n_noorder
        '
        Me.n_noorder.Location = New System.Drawing.Point(97, 101)
        Me.n_noorder.Name = "n_noorder"
        Me.n_noorder.Size = New System.Drawing.Size(52, 20)
        Me.n_noorder.TabIndex = 4
        '
        'c_bahan
        '
        Me.c_bahan.AutoSize = True
        Me.c_bahan.Location = New System.Drawing.Point(97, 153)
        Me.c_bahan.Name = "c_bahan"
        Me.c_bahan.Size = New System.Drawing.Size(122, 17)
        Me.c_bahan.TabIndex = 6
        Me.c_bahan.Text = "Pakai Bahan Sendiri"
        Me.c_bahan.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Harga Desain"
        '
        't_harga
        '
        Me.t_harga.Location = New System.Drawing.Point(97, 48)
        Me.t_harga.Name = "t_harga"
        Me.t_harga.Size = New System.Drawing.Size(196, 20)
        Me.t_harga.TabIndex = 2
        '
        'cb_bahan
        '
        Me.cb_bahan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_bahan.FormattingEnabled = True
        Me.cb_bahan.Location = New System.Drawing.Point(97, 125)
        Me.cb_bahan.Name = "cb_bahan"
        Me.cb_bahan.Size = New System.Drawing.Size(196, 21)
        Me.cb_bahan.TabIndex = 5
        '
        'cb_jenisorder
        '
        Me.cb_jenisorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_jenisorder.FormattingEnabled = True
        Me.cb_jenisorder.Location = New System.Drawing.Point(97, 73)
        Me.cb_jenisorder.Name = "cb_jenisorder"
        Me.cb_jenisorder.Size = New System.Drawing.Size(196, 21)
        Me.cb_jenisorder.TabIndex = 3
        '
        'cb_operator
        '
        Me.cb_operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_operator.FormattingEnabled = True
        Me.cb_operator.Location = New System.Drawing.Point(97, 22)
        Me.cb_operator.Name = "cb_operator"
        Me.cb_operator.Size = New System.Drawing.Size(196, 21)
        Me.cb_operator.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Bahan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "No. Order"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Jenis Order"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Operator Setting"
        '
        'g_cdr
        '
        Me.g_cdr.Controls.Add(Me.rb_noconv)
        Me.g_cdr.Controls.Add(Me.rb_convbitmap)
        Me.g_cdr.Controls.Add(Me.rb_convcurve)
        Me.g_cdr.Location = New System.Drawing.Point(317, 180)
        Me.g_cdr.Name = "g_cdr"
        Me.g_cdr.Size = New System.Drawing.Size(123, 97)
        Me.g_cdr.TabIndex = 3
        Me.g_cdr.TabStop = False
        Me.g_cdr.Text = "Pengaturan CDR"
        '
        'rb_noconv
        '
        Me.rb_noconv.AutoSize = True
        Me.rb_noconv.Location = New System.Drawing.Point(6, 67)
        Me.rb_noconv.Name = "rb_noconv"
        Me.rb_noconv.Size = New System.Drawing.Size(100, 17)
        Me.rb_noconv.TabIndex = 2
        Me.rb_noconv.Text = "Jangan Convert"
        Me.rb_noconv.UseVisualStyleBackColor = True
        '
        'rb_convbitmap
        '
        Me.rb_convbitmap.AutoSize = True
        Me.rb_convbitmap.Location = New System.Drawing.Point(6, 44)
        Me.rb_convbitmap.Name = "rb_convbitmap"
        Me.rb_convbitmap.Size = New System.Drawing.Size(112, 17)
        Me.rb_convbitmap.TabIndex = 1
        Me.rb_convbitmap.Text = "Convert ke Bitmap"
        Me.rb_convbitmap.UseVisualStyleBackColor = True
        '
        'rb_convcurve
        '
        Me.rb_convcurve.AutoSize = True
        Me.rb_convcurve.Location = New System.Drawing.Point(7, 21)
        Me.rb_convcurve.Name = "rb_convcurve"
        Me.rb_convcurve.Size = New System.Drawing.Size(108, 17)
        Me.rb_convcurve.TabIndex = 0
        Me.rb_convcurve.Text = "Convert ke Curve"
        Me.rb_convcurve.UseVisualStyleBackColor = True
        '
        'g_pdf
        '
        Me.g_pdf.Controls.Add(Me.pgNumRange)
        Me.g_pdf.Controls.Add(Me.rb_setpage)
        Me.g_pdf.Controls.Add(Me.rb_currpage)
        Me.g_pdf.Controls.Add(Me.rb_allpage)
        Me.g_pdf.Location = New System.Drawing.Point(446, 181)
        Me.g_pdf.Name = "g_pdf"
        Me.g_pdf.Size = New System.Drawing.Size(115, 97)
        Me.g_pdf.TabIndex = 4
        Me.g_pdf.TabStop = False
        Me.g_pdf.Text = "Pengaturan PDF"
        '
        'pgNumRange
        '
        Me.pgNumRange.Location = New System.Drawing.Point(56, 67)
        Me.pgNumRange.Name = "pgNumRange"
        Me.pgNumRange.Size = New System.Drawing.Size(52, 20)
        Me.pgNumRange.TabIndex = 3
        '
        'rb_setpage
        '
        Me.rb_setpage.AutoSize = True
        Me.rb_setpage.Location = New System.Drawing.Point(6, 67)
        Me.rb_setpage.Name = "rb_setpage"
        Me.rb_setpage.Size = New System.Drawing.Size(53, 17)
        Me.rb_setpage.TabIndex = 2
        Me.rb_setpage.Text = "Page:"
        Me.rb_setpage.UseVisualStyleBackColor = True
        '
        'rb_currpage
        '
        Me.rb_currpage.AutoSize = True
        Me.rb_currpage.Location = New System.Drawing.Point(6, 43)
        Me.rb_currpage.Name = "rb_currpage"
        Me.rb_currpage.Size = New System.Drawing.Size(74, 17)
        Me.rb_currpage.TabIndex = 1
        Me.rb_currpage.Text = "Page Aktif"
        Me.rb_currpage.UseVisualStyleBackColor = True
        '
        'rb_allpage
        '
        Me.rb_allpage.AutoSize = True
        Me.rb_allpage.Location = New System.Drawing.Point(6, 19)
        Me.rb_allpage.Name = "rb_allpage"
        Me.rb_allpage.Size = New System.Drawing.Size(86, 17)
        Me.rb_allpage.TabIndex = 0
        Me.rb_allpage.Text = "Semua Page"
        Me.rb_allpage.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cb_imposition)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.cb_sisimuka)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.cb_layout)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Location = New System.Drawing.Point(318, 283)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(243, 104)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Layout"
        '
        'cb_imposition
        '
        Me.cb_imposition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_imposition.Enabled = False
        Me.cb_imposition.FormattingEnabled = True
        Me.cb_imposition.Location = New System.Drawing.Point(97, 73)
        Me.cb_imposition.Name = "cb_imposition"
        Me.cb_imposition.Size = New System.Drawing.Size(139, 21)
        Me.cb_imposition.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Imposition"
        '
        'cb_sisimuka
        '
        Me.cb_sisimuka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_sisimuka.Enabled = False
        Me.cb_sisimuka.FormattingEnabled = True
        Me.cb_sisimuka.Location = New System.Drawing.Point(97, 46)
        Me.cb_sisimuka.Name = "cb_sisimuka"
        Me.cb_sisimuka.Size = New System.Drawing.Size(139, 21)
        Me.cb_sisimuka.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Sisi Muka"
        '
        'cb_layout
        '
        Me.cb_layout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_layout.FormattingEnabled = True
        Me.cb_layout.Location = New System.Drawing.Point(97, 19)
        Me.cb_layout.Name = "cb_layout"
        Me.cb_layout.Size = New System.Drawing.Size(139, 21)
        Me.cb_layout.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Layout / Ukuran"
        '
        'tb_Finishing
        '
        Me.tb_Finishing.Controls.Add(Me.tb_finishinga3)
        Me.tb_Finishing.Controls.Add(Me.tb_finishingptp)
        Me.tb_Finishing.Controls.Add(Me.tb_finishingkn)
        Me.tb_Finishing.Controls.Add(Me.tb_finishingbr)
        Me.tb_Finishing.Controls.Add(Me.tb_finishinglf)
        Me.tb_Finishing.Controls.Add(Me.tb_finishingbw)
        Me.tb_Finishing.Location = New System.Drawing.Point(13, 393)
        Me.tb_Finishing.Name = "tb_Finishing"
        Me.tb_Finishing.SelectedIndex = 0
        Me.tb_Finishing.Size = New System.Drawing.Size(548, 174)
        Me.tb_Finishing.TabIndex = 6
        '
        'tb_finishinga3
        '
        Me.tb_finishinga3.AutoScroll = True
        Me.tb_finishinga3.Controls.Add(Me.pn_finishinga3)
        Me.tb_finishinga3.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishinga3.Name = "tb_finishinga3"
        Me.tb_finishinga3.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_finishinga3.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishinga3.TabIndex = 0
        Me.tb_finishinga3.Text = "Finishing A3"
        Me.tb_finishinga3.UseVisualStyleBackColor = True
        '
        'pn_finishinga3
        '
        Me.pn_finishinga3.AutoScroll = True
        Me.pn_finishinga3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pn_finishinga3.Location = New System.Drawing.Point(3, 3)
        Me.pn_finishinga3.Name = "pn_finishinga3"
        Me.pn_finishinga3.Size = New System.Drawing.Size(531, 142)
        Me.pn_finishinga3.TabIndex = 0
        '
        'tb_finishingptp
        '
        Me.tb_finishingptp.Controls.Add(Me.pn_finishingptp)
        Me.tb_finishingptp.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishingptp.Name = "tb_finishingptp"
        Me.tb_finishingptp.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishingptp.TabIndex = 5
        Me.tb_finishingptp.Text = "Finishing Photo Print"
        Me.tb_finishingptp.UseVisualStyleBackColor = True
        '
        'pn_finishingptp
        '
        Me.pn_finishingptp.AutoScroll = True
        Me.pn_finishingptp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pn_finishingptp.Location = New System.Drawing.Point(5, 3)
        Me.pn_finishingptp.Name = "pn_finishingptp"
        Me.pn_finishingptp.Size = New System.Drawing.Size(531, 142)
        Me.pn_finishingptp.TabIndex = 1
        '
        'tb_finishingkn
        '
        Me.tb_finishingkn.Controls.Add(Me.pn_finishingkn)
        Me.tb_finishingkn.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishingkn.Name = "tb_finishingkn"
        Me.tb_finishingkn.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishingkn.TabIndex = 2
        Me.tb_finishingkn.Text = "Finishing KN"
        Me.tb_finishingkn.UseVisualStyleBackColor = True
        '
        'pn_finishingkn
        '
        Me.pn_finishingkn.Location = New System.Drawing.Point(3, 3)
        Me.pn_finishingkn.Name = "pn_finishingkn"
        Me.pn_finishingkn.Size = New System.Drawing.Size(534, 142)
        Me.pn_finishingkn.TabIndex = 0
        '
        'tb_finishingbr
        '
        Me.tb_finishingbr.Controls.Add(Me.pn_finishingbr)
        Me.tb_finishingbr.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishingbr.Name = "tb_finishingbr"
        Me.tb_finishingbr.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishingbr.TabIndex = 3
        Me.tb_finishingbr.Text = "Finishing Brosur"
        Me.tb_finishingbr.UseVisualStyleBackColor = True
        '
        'pn_finishingbr
        '
        Me.pn_finishingbr.Location = New System.Drawing.Point(3, 4)
        Me.pn_finishingbr.Name = "pn_finishingbr"
        Me.pn_finishingbr.Size = New System.Drawing.Size(534, 141)
        Me.pn_finishingbr.TabIndex = 0
        '
        'tb_finishinglf
        '
        Me.tb_finishinglf.Controls.Add(Me.GroupBox3)
        Me.tb_finishinglf.Controls.Add(Me.GroupBox2)
        Me.tb_finishinglf.Controls.Add(Me.grp_laminasilf)
        Me.tb_finishinglf.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishinglf.Name = "tb_finishinglf"
        Me.tb_finishinglf.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_finishinglf.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishinglf.TabIndex = 1
        Me.tb_finishinglf.Text = "Finishing Large Format"
        Me.tb_finishinglf.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lst_finishingfn)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(282, 134)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipe Finishing"
        '
        'lst_finishingfn
        '
        Me.lst_finishingfn.FormattingEnabled = True
        Me.lst_finishingfn.Location = New System.Drawing.Point(7, 19)
        Me.lst_finishingfn.Name = "lst_finishingfn"
        Me.lst_finishingfn.Size = New System.Drawing.Size(269, 108)
        Me.lst_finishingfn.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_fnframe)
        Me.GroupBox2.Location = New System.Drawing.Point(295, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 82)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lainnya"
        '
        'cb_fnframe
        '
        Me.cb_fnframe.AutoSize = True
        Me.cb_fnframe.Location = New System.Drawing.Point(9, 19)
        Me.cb_fnframe.Name = "cb_fnframe"
        Me.cb_fnframe.Size = New System.Drawing.Size(101, 17)
        Me.cb_fnframe.TabIndex = 0
        Me.cb_fnframe.Tag = "FRM"
        Me.cb_fnframe.Text = "Bingkai / Frame"
        Me.cb_fnframe.UseVisualStyleBackColor = True
        '
        'grp_laminasilf
        '
        Me.grp_laminasilf.Controls.Add(Me.rb_nonelf)
        Me.grp_laminasilf.Controls.Add(Me.rb_doff)
        Me.grp_laminasilf.Controls.Add(Me.rb_glossy)
        Me.grp_laminasilf.Location = New System.Drawing.Point(295, 7)
        Me.grp_laminasilf.Name = "grp_laminasilf"
        Me.grp_laminasilf.Size = New System.Drawing.Size(239, 46)
        Me.grp_laminasilf.TabIndex = 1
        Me.grp_laminasilf.TabStop = False
        Me.grp_laminasilf.Text = "Laminasi"
        '
        'rb_nonelf
        '
        Me.rb_nonelf.AutoSize = True
        Me.rb_nonelf.Location = New System.Drawing.Point(140, 19)
        Me.rb_nonelf.Name = "rb_nonelf"
        Me.rb_nonelf.Size = New System.Drawing.Size(96, 17)
        Me.rb_nonelf.TabIndex = 2
        Me.rb_nonelf.Text = "Tidak Laminasi"
        Me.rb_nonelf.UseVisualStyleBackColor = True
        '
        'rb_doff
        '
        Me.rb_doff.AutoSize = True
        Me.rb_doff.Location = New System.Drawing.Point(83, 20)
        Me.rb_doff.Name = "rb_doff"
        Me.rb_doff.Size = New System.Drawing.Size(45, 17)
        Me.rb_doff.TabIndex = 1
        Me.rb_doff.Tag = "LD"
        Me.rb_doff.Text = "Doff"
        Me.rb_doff.UseVisualStyleBackColor = True
        '
        'rb_glossy
        '
        Me.rb_glossy.AutoSize = True
        Me.rb_glossy.Location = New System.Drawing.Point(9, 19)
        Me.rb_glossy.Name = "rb_glossy"
        Me.rb_glossy.Size = New System.Drawing.Size(56, 17)
        Me.rb_glossy.TabIndex = 0
        Me.rb_glossy.Tag = "LG"
        Me.rb_glossy.Text = "Glossy"
        Me.rb_glossy.UseVisualStyleBackColor = True
        '
        'tb_finishingbw
        '
        Me.tb_finishingbw.Controls.Add(Me.pn_finishingbw)
        Me.tb_finishingbw.Location = New System.Drawing.Point(4, 22)
        Me.tb_finishingbw.Name = "tb_finishingbw"
        Me.tb_finishingbw.Size = New System.Drawing.Size(540, 148)
        Me.tb_finishingbw.TabIndex = 4
        Me.tb_finishingbw.Text = "Finishing BW"
        Me.tb_finishingbw.UseVisualStyleBackColor = True
        '
        'pn_finishingbw
        '
        Me.pn_finishingbw.Location = New System.Drawing.Point(3, 4)
        Me.pn_finishingbw.Name = "pn_finishingbw"
        Me.pn_finishingbw.Size = New System.Drawing.Size(534, 141)
        Me.pn_finishingbw.TabIndex = 0
        '
        'g_preview
        '
        Me.g_preview.Controls.Add(Me.t_preview)
        Me.g_preview.Location = New System.Drawing.Point(13, 569)
        Me.g_preview.Name = "g_preview"
        Me.g_preview.Size = New System.Drawing.Size(548, 42)
        Me.g_preview.TabIndex = 7
        Me.g_preview.TabStop = False
        Me.g_preview.Text = "Preview"
        '
        't_preview
        '
        Me.t_preview.Location = New System.Drawing.Point(9, 16)
        Me.t_preview.Name = "t_preview"
        Me.t_preview.ReadOnly = True
        Me.t_preview.Size = New System.Drawing.Size(532, 20)
        Me.t_preview.TabIndex = 0
        Me.t_preview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bt_cancel
        '
        Me.bt_cancel.Location = New System.Drawing.Point(486, 617)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(75, 23)
        Me.bt_cancel.TabIndex = 0
        Me.bt_cancel.Text = "Batal"
        Me.bt_cancel.UseVisualStyleBackColor = True
        '
        'bt_OK
        '
        Me.bt_OK.Location = New System.Drawing.Point(405, 617)
        Me.bt_OK.Name = "bt_OK"
        Me.bt_OK.Size = New System.Drawing.Size(75, 23)
        Me.bt_OK.TabIndex = 9
        Me.bt_OK.Text = "OK"
        Me.bt_OK.UseVisualStyleBackColor = True
        '
        'statuslabel
        '
        Me.statuslabel.Name = "statuslabel"
        Me.statuslabel.Size = New System.Drawing.Size(39, 17)
        Me.statuslabel.Text = "Ready"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabel, Me.tsProgBar})
        Me.StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip.Location = New System.Drawing.Point(0, 655)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(570, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 11
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'tsProgBar
        '
        Me.tsProgBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsProgBar.Name = "tsProgBar"
        Me.tsProgBar.Size = New System.Drawing.Size(200, 16)
        Me.tsProgBar.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 617)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bWorker
        '
        Me.bWorker.WorkerReportsProgress = True
        Me.bWorker.WorkerSupportsCancellation = True
        '
        'errProvider
        '
        Me.errProvider.BlinkRate = 0
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'pb_header
        '
        Me.pb_header.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pb_header.Image = Global.CG_FileManagement.My.Resources.Resources.FileSiapPrint
        Me.pb_header.Location = New System.Drawing.Point(12, 12)
        Me.pb_header.Name = "pb_header"
        Me.pb_header.Size = New System.Drawing.Size(549, 47)
        Me.pb_header.TabIndex = 13
        Me.pb_header.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.ClientSize = New System.Drawing.Size(570, 677)
        Me.Controls.Add(Me.pb_header)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.bt_OK)
        Me.Controls.Add(Me.bt_cancel)
        Me.Controls.Add(Me.g_preview)
        Me.Controls.Add(Me.tb_Finishing)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.g_pdf)
        Me.Controls.Add(Me.g_cdr)
        Me.Controls.Add(Me.g_datasetting)
        Me.Controls.Add(Me.gr_datacustomer)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Publish CG Digital"
        Me.gr_datacustomer.ResumeLayout(False)
        Me.gr_datacustomer.PerformLayout()
        Me.g_datasetting.ResumeLayout(False)
        Me.g_datasetting.PerformLayout()
        CType(Me.n_qtycetak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.n_noorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g_cdr.ResumeLayout(False)
        Me.g_cdr.PerformLayout()
        Me.g_pdf.ResumeLayout(False)
        Me.g_pdf.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tb_Finishing.ResumeLayout(False)
        Me.tb_finishinga3.ResumeLayout(False)
        Me.tb_finishingptp.ResumeLayout(False)
        Me.tb_finishingkn.ResumeLayout(False)
        Me.tb_finishingbr.ResumeLayout(False)
        Me.tb_finishinglf.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grp_laminasilf.ResumeLayout(False)
        Me.grp_laminasilf.PerformLayout()
        Me.tb_finishingbw.ResumeLayout(False)
        Me.g_preview.ResumeLayout(False)
        Me.g_preview.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gr_datacustomer As System.Windows.Forms.GroupBox
    Friend WithEvents cb_presetcustomer As System.Windows.Forms.ComboBox
    Friend WithEvents t_judulfile As System.Windows.Forms.TextBox
    Friend WithEvents t_customer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents g_datasetting As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_bahan As System.Windows.Forms.ComboBox
    Friend WithEvents cb_jenisorder As System.Windows.Forms.ComboBox
    Friend WithEvents cb_operator As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents t_harga As System.Windows.Forms.TextBox
    Friend WithEvents g_cdr As System.Windows.Forms.GroupBox
    Friend WithEvents rb_noconv As System.Windows.Forms.RadioButton
    Friend WithEvents rb_convbitmap As System.Windows.Forms.RadioButton
    Friend WithEvents rb_convcurve As System.Windows.Forms.RadioButton
    Friend WithEvents g_pdf As System.Windows.Forms.GroupBox
    Friend WithEvents rb_setpage As System.Windows.Forms.RadioButton
    Friend WithEvents rb_currpage As System.Windows.Forms.RadioButton
    Friend WithEvents rb_allpage As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_sisimuka As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_layout As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents c_bahan As System.Windows.Forms.CheckBox
    Friend WithEvents cb_imposition As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents n_noorder As System.Windows.Forms.NumericUpDown
    Friend WithEvents tb_Finishing As System.Windows.Forms.TabControl
    Friend WithEvents tb_finishinga3 As System.Windows.Forms.TabPage
    Friend WithEvents tb_finishinglf As System.Windows.Forms.TabPage
    Friend WithEvents g_preview As System.Windows.Forms.GroupBox
    Friend WithEvents t_preview As System.Windows.Forms.TextBox
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents n_qtycetak As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_finishingkn As System.Windows.Forms.TabPage
    Friend WithEvents tb_finishingbr As System.Windows.Forms.TabPage
    Friend WithEvents tb_finishingbw As System.Windows.Forms.TabPage
    Friend WithEvents bt_OK As System.Windows.Forms.Button
    Friend WithEvents t_satuanqty As System.Windows.Forms.Label
    Friend WithEvents pn_finishinga3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents statuslabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsProgBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents pn_finishingkn As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pn_finishingbr As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pn_finishingbw As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents t_jmlpage As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lst_finishingfn As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_fnframe As System.Windows.Forms.CheckBox
    Friend WithEvents grp_laminasilf As System.Windows.Forms.GroupBox
    Friend WithEvents rb_nonelf As System.Windows.Forms.RadioButton
    Friend WithEvents rb_doff As System.Windows.Forms.RadioButton
    Friend WithEvents rb_glossy As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents pgNumRange As System.Windows.Forms.TextBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pb_header As System.Windows.Forms.PictureBox
    Friend WithEvents tb_finishingptp As System.Windows.Forms.TabPage
    Friend WithEvents pn_finishingptp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents c_permanent As System.Windows.Forms.CheckBox
    Friend WithEvents cb_grouppermanent As System.Windows.Forms.ComboBox
End Class
