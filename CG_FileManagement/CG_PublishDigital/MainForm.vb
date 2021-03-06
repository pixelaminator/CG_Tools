﻿Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Linq
Imports System.ComponentModel

Public Class MainForm
    Dim IsFormInitialized As Boolean
    Dim DocHasMultiplePages As Boolean
    Dim CodeFinishing() As String
    Dim jhandler As New ClsJsonManager
    Dim ClsTabMgr As New ClsTabManager
    Dim ClsFileName As New ClsFileNaming
    Dim ClsCDraw As New ClsCDraw
    Dim TabFinishing As New List(Of TabPage)
    Dim ActivePanelFinishing As Control
    Dim _SelectedJenisOrderIndex As Integer = -1
    Dim _LaminasiLF As String
    Dim _TooltipShown As Boolean
    'Dim _ActivePanelFinishing As Control

#Region "Form Load"
    Private Sub PublishDigital_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Try
            InitForm()
        Catch ex As Exception
            MessageBox.Show("Ada kesalahan dalam loading program. Hubungi IT untuk install ulang CG Tools." + Environment.NewLine + "Pesan error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
#End Region

#Region "GUI Event Handler"
    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then InitBahanUkuran()
        DisplayTabFinishing()
        KodeJenisOrder()
        If IsFormInitialized = True Then
            GenerateCodeFinishing()
            CekBahanSendiri()
            CekLayoutSize()
            If DocHasMultiplePages Then CekImposition()
            InitQtyPages()
            InitLayoutList()
        End If
        GeneratePreview()
    End Sub

    Private Sub c_permanent_Click(sender As Object, e As EventArgs) Handles c_permanent.Click
        If c_permanent.Checked = True Then
            cb_grouppermanent.Enabled = True
        Else
            cb_grouppermanent.Enabled = False
        End If
    End Sub

    Private Sub C_bahan_CheckedChanged(sender As Object, e As EventArgs) Handles c_bahan.CheckedChanged
        'Kalau jenis order tidak berganti tidak usah jalanin code
        If cb_jenisorder.SelectedIndex > -1 AndAlso Not cb_jenisorder.Equals(_SelectedJenisOrderIndex) Then
            If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then
                cb_bahan.SelectedValue = ""
                cb_bahan.DropDownStyle = ComboBoxStyle.Simple
                If DocHasMultiplePages Then cb_sisimuka.Enabled = True
            Else
                cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList
                cb_bahan.SelectedIndex = 0
            End If
            _SelectedJenisOrderIndex = cb_jenisorder.SelectedIndex
        End If
    End Sub

    Private Sub Cb_bahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_bahan.SelectedIndexChanged
        If c_bahan.Checked = False Then
            If DocHasMultiplePages Then CekDuaMuka()
            ClsFileName.Bahan = cb_bahan.SelectedValue.ToString
            GeneratePreview()
        End If
    End Sub

    Private Sub cb_bahan_TextChanged(sender As Object, e As EventArgs) Handles cb_bahan.TextChanged
        ClsFileName.Bahan = cb_bahan.Text
        GeneratePreview()
    End Sub

    Private Sub Bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Close()
    End Sub

    Private Sub FrmClose_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AssemblyLoadError = False Then Globals.JsonObj = Nothing
    End Sub

    Private Sub Cb_operator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_operator.SelectedIndexChanged
        ClsFileName.NamaSetter = cb_operator.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub t_harga_TextChanged(sender As Object, e As EventArgs) Handles t_harga.TextChanged
        ClsFileName.Harga = t_harga.Text
        GeneratePreview()
    End Sub

    Private Sub n_noorder_ValueChanged(sender As Object, e As EventArgs) Handles n_noorder.ValueChanged
        ClsFileName.NoOrder = n_noorder.Value.ToString
        GeneratePreview()
    End Sub

    Private Sub n_qtycetak_ValueChanged(sender As Object, e As EventArgs) Handles n_qtycetak.ValueChanged
        InitQtyPages()
    End Sub

    Private Sub cb_sisimuka_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sisimuka.SelectedIndexChanged
        ClsFileName.SisiMuka = cb_sisimuka.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub cb_imposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_imposition.SelectedIndexChanged
        ClsFileName.TypeImposition = cb_imposition.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub t_customer_TextChanged(sender As Object, e As EventArgs) Handles t_customer.TextChanged
        ClsFileName.NamaCustomer = t_customer.Text
        GeneratePreview()
    End Sub

    Private Sub t_judulfile_TextChanged(sender As Object, e As EventArgs) Handles t_judulfile.TextChanged
        ClsFileName.JudulFile = t_judulfile.Text
        GeneratePreview()
    End Sub

    Private Sub cb_presetcustomer_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_presetcustomer.SelectedValueChanged
        If IsFormInitialized = True Then t_customer.Text = cb_presetcustomer.SelectedValue.ToString
    End Sub

    Private Sub cb_layout_TextChanged(sender As Object, e As EventArgs) Handles cb_layout.TextChanged
        If cb_layout.DropDownStyle = ComboBoxStyle.DropDownList Then
            ClsFileName.LayoutSize = cb_layout.SelectedValue.ToString
        Else
            ClsFileName.LayoutSize = cb_layout.Text
        End If
        GeneratePreview()
    End Sub

#Region "Dirty Finishing LF Code"
    'TODO: These finishing LF code should be improved someday.
    Private Sub lst_finishingfn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_finishingfn.SelectedIndexChanged
        GenerateCodeFinishing()
    End Sub

    Private Sub rb_glossy_CheckedChanged(sender As Object, e As EventArgs) Handles rb_glossy.CheckedChanged
        _LaminasiLF = "LG"
        GenerateCodeFinishing()
    End Sub

    Private Sub rb_doff_CheckedChanged(sender As Object, e As EventArgs) Handles rb_doff.CheckedChanged
        _LaminasiLF = "LD"
        GenerateCodeFinishing()
    End Sub

    Private Sub rb_nonelf_CheckedChanged(sender As Object, e As EventArgs) Handles rb_nonelf.CheckedChanged
        _LaminasiLF = ""
        GenerateCodeFinishing()
    End Sub

    Private Sub cb_fnframe_CheckedChanged(sender As Object, e As EventArgs) Handles cb_fnframe.CheckedChanged
        GenerateCodeFinishing()
    End Sub
#End Region
#End Region

    Private Sub CekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(cb_jenisorder.SelectedValue.ToString)(cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            cb_sisimuka.Enabled = False
            ClsFileName.SisiMuka = ""
            GeneratePreview()
        Else
            cb_sisimuka.Enabled = True
            If IsFormInitialized = True Then cb_sisimuka_SelectedIndexChanged(cb_sisimuka, New EventArgs)
        End If
    End Sub

    Private Sub CekLayoutSize()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("layouteditable"), Boolean) = True Then
            cb_layout.DropDownStyle = ComboBoxStyle.DropDown
        Else
            cb_layout.DropDownStyle = ComboBoxStyle.DropDownList
        End If
    End Sub

    Private Sub CekImposition()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("useimposition"), Boolean) = True Then
            cb_imposition.Enabled = True
            cb_imposition_SelectedIndexChanged(cb_imposition, New EventArgs)
        Else
            cb_imposition.Enabled = False
            ClsFileName.TypeImposition = ""
            GeneratePreview()
        End If
    End Sub

    Private Sub CekBahanSendiri()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("bahaneditable"), Boolean) = True Then
            c_bahan.Enabled = True
            'C_bahan_CheckedChanged(c_bahan, New EventArgs)
        Else
            c_bahan.Checked = False
            c_bahan.Enabled = False
        End If
    End Sub

    Private Sub KodeJenisOrder()
        ClsFileName.JenisOrder = Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("kode").ToString
        GeneratePreview()
    End Sub

    Private Sub AddChkHandler(ByVal panel As FlowLayoutPanel)
        For Each ctrl As CheckBox In panel.Controls
            AddHandler ctrl.CheckedChanged, AddressOf DynCheckboxChangeHandler
        Next
    End Sub

    Private Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
        GenerateCodeFinishing()
    End Sub

    Private Sub GenerateCodeFinishing()
        'This approach should be temporary..unless I find better method to generate controls for Finishing LF.
        If cb_jenisorder.SelectedValue.ToString = "largeformat" Then
            Dim Bingkai As String
            If cb_fnframe.Checked = True Then Bingkai = "FRM" Else Bingkai = ""
            ReDim CodeFinishing(3) 'cuman 3 karena elemen finishing large format cuman segitu
            CodeFinishing(0) = lst_finishingfn.SelectedValue.ToString
            CodeFinishing(1) = _LaminasiLF
            CodeFinishing(2) = Bingkai
        Else
            Dim i As Integer
            ReDim CodeFinishing(ActivePanelFinishing.Controls.Count - 1)
            For Each ctrl As CheckBox In ActivePanelFinishing.Controls
                Dim cbchk As CheckBox = DirectCast(ActivePanelFinishing.Controls("cb" + CStr(i)), CheckBox)
                If cbchk.Checked = True Then
                    Dim chk As String = cbchk.Name
                    'Gets an integer from a string (in this case "cb10" will return "10")
                    Dim chkname As Integer = CInt(System.Text.RegularExpressions.Regex.Match(chk, "\d+").Value)
                    'TODO: Try not to get dependent on jenisorder.
                    Dim chkdata As String = Globals.JsonObj("cgFinishing")(cb_jenisorder.SelectedValue.ToString)(chkname)("kode").ToString
                    CodeFinishing(chkname) = chkdata
                End If
                i += 1
            Next
        End If
        Dim FilteredNamaFile = From ar In CodeFinishing Where ar <> "" Select ar
        Dim result As String = String.Join(",", FilteredNamaFile.ToArray)
        ClsFileName.KodeFinishing = result
        GeneratePreview()
    End Sub

    'Private Property ActivePanelFinishing As Control
    '    Get
    '        Return _ActivePanelFinishing
    '    End Get
    '    Set(value As Control)
    '        _ActivePanelFinishing = value
    '    End Set
    'End Property

    Private Sub DisplayTabFinishing()
        For Each i As TabPage In TabFinishing
            ClsTabMgr.SetInvisible(i)
        Next
        Dim items As List(Of Integer) = Enumerable.Range(0, cb_jenisorder.Items.Count).ToList
        Dim selecteditem As Integer = cb_jenisorder.SelectedIndex
        Dim hiddentabindex As List(Of Integer) = items.Where(Function(number, index) index <> selecteditem).ToList

        Dim ActiveTabPage As Control = TabFinishing(cb_jenisorder.SelectedIndex)
        ClsTabMgr.SetVisible(ActiveTabPage.Name, tb_Finishing)
        ActivePanelFinishing = ActiveTabPage.Controls(0)
    End Sub

    Private Sub GeneratePreview()
        t_preview.Text = ClsFileName.DoFileName()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim JOForm As New JobOrderForm(Me)
        'JOForm.ShowDialog()
    End Sub

    Private Sub showTooltip(message As String, icon As ToolTipIcon, title As String, obj As IWin32Window)
        Dim tooltp As New ToolTip
        tooltp.IsBalloon = True
        tooltp.ToolTipIcon = icon
        tooltp.ToolTipTitle = title
        tooltp.Show(String.Empty, obj)
        tooltp.Show(message, obj, 3000)
        _TooltipShown = True
    End Sub

    Private Sub CheckEmptyFields(sender As Object, e As CancelEventArgs) Handles t_customer.Validating, t_judulfile.Validating, t_harga.Validating, cb_bahan.Validating, pgNumRange.Validating
        Dim ctl As Control = CType(sender, Control)
        If ctl.Text = "" Then
            e.Cancel = True
            errProvider.SetIconPadding(ctl, -20)
            errProvider.SetError(ctl, "Kolom ini tidak boleh dikosongkan.")
            If _TooltipShown = False Then showTooltip("Kolom ini tidak boleh dikosongkan.", ToolTipIcon.Warning, "Kesalahan", ctl)
        End If
    End Sub

    Private Sub PDFOption(sender As Object, e As EventArgs) Handles rb_allpage.Click, rb_currpage.Click, rb_setpage.Click
        Dim rButton As RadioButton = GetGroupBoxCheckedButton(g_pdf)

        If rButton Is rb_setpage Then
            pgNumRange.Enabled = True
            pgNumRange.CausesValidation = True
        Else
            pgNumRange.Enabled = False
            pgNumRange.CausesValidation = False
        End If
    End Sub

    Private Function GetGroupBoxCheckedButton(grp As GroupBox) As RadioButton
        Return grp.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True)
    End Function

    '------------------ Parse Publish PDF Range --------------------------
    Public Function parsePageNumbers(input As String) As List(Of Integer)
        If String.IsNullOrEmpty(input) Then
            Throw New InvalidOperationException("Tolong isi nomor Page yang hendak dipublish.")
        End If

        Dim pageNos = input.Split(","c)

        Dim ret = New List(Of Integer)()
        For Each pageString As String In pageNos
            If pageString.Contains("-") Then
                parsePageRange(ret, pageString)
            Else
                ret.Add(parsePageNumber(pageString))
            End If
        Next

        ret.Sort()
        Return ret.Distinct().ToList()
    End Function

    Private Function parsePageNumber(pageString As String) As Integer
        Dim ret As Integer

        If Not Integer.TryParse(pageString, ret) Then
            Throw New InvalidOperationException(String.Format("Nomor Page '{0}' tidak valid.", pageString))
        End If

        Return ret
    End Function

    Private Sub parsePageRange(pageNumbers As List(Of Integer), pageNo As String)
        Dim pageRange = pageNo.Split("-"c)

        If pageRange.Length <> 2 Then
            Throw New InvalidOperationException(String.Format("Rentang Page '{0}' tidak valid.", pageNo))
        End If

        Dim startPage As Integer = parsePageNumber(pageRange(0)), endPage As Integer = parsePageNumber(pageRange(1))

        If startPage > endPage Then
            Throw New InvalidOperationException(String.Format("Nomor Page {0} tidak bisa lebih besar dari {1}" + " di rentang Page '{2}'", startPage, endPage, pageNo))
        End If

        pageNumbers.AddRange(Enumerable.Range(startPage, endPage - startPage + 1))
    End Sub
    '--------------------- END PDF Parse Range --------------------------------

    '====================== Background Worker =============================
    'Do saving here

    Private Sub bWorker_DoWork(ByVal sender As Object, e As DoWorkEventArgs) Handles bWorker.DoWork
        'Select Case ClsCDraw.ConvertBitmap(CType(sender, BackgroundWorker))
        '    Case 0
        '        MessageBox.Show("Ada kesalahan dalam proses convert. Mohon informasikan kesalahan ini ke staff IT.", "Kesalahan Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    Case -1
        '        MessageBox.Show("Tidak ada objek yang diconvert.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Exit Sub
        'End Select
    End Sub

    Private Sub bWorker_ProgressChanged() Handles bWorker.ProgressChanged

    End Sub

    Private Sub bWorker_ReportProgress(ByVal sender As Object, e As ProgressChangedEventArgs) Handles bWorker.ProgressChanged
        Dim i As Integer
        tsProgBar.Maximum = 100
        For i = 0 To ClsCDraw.ProgressNumberMax
            tsProgBar.Value = e.ProgressPercentage
            statuslabel.Text = "Convert semua teks... (Page " + CStr(ClsCDraw.PageNumber) + "/" + CStr(ClsCDraw.PageNumberMax) + ")"
        Next
    End Sub

    Private Sub bWorker_ProgressComplete() Handles bWorker.RunWorkerCompleted
        tsProgBar.Value = 0
        tsProgBar.Visible = False
        statuslabel.Text = "Ready"
        For Each ctl As Control In Controls
            If TypeOf ctl IsNot StatusStrip Then
                ctl.Enabled = True
            End If
        Next
    End Sub

    Private Sub bt_OK_Click(sender As Object, e As EventArgs) Handles bt_OK.Click
        _TooltipShown = False
        errProvider.Clear()
        If Me.ValidateChildren() Then
            Try
                If GetGroupBoxCheckedButton(g_pdf) Is rb_setpage Then MessageBox.Show(String.Join(",", parsePageNumbers(pgNumRange.Text)))
            Catch ex As Exception
                showTooltip(ex.Message.ToString, ToolTipIcon.Error, "Kesalahan", pgNumRange)
                Exit Sub
            End Try
            '------------------------------
            If bWorker.IsBusy = False Then
                'Disable controls when saving
                For Each ctl As Control In Controls
                    If TypeOf ctl IsNot StatusStrip Then
                        ctl.Enabled = False
                    End If
                Next
                tsProgBar.Visible = True
                bWorker.RunWorkerAsync()
            End If
        End If
    End Sub
End Class