Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Partial Class MainForm
    Private Sub InitForm()
        jsonPath = Application.StartupPath + "\Addons\CG_Tools\cgSave.json"
        Try
            jsonTxt = File.ReadAllText(jsonPath)
        Catch ex As FileNotFoundException
            MessageBox.Show("File cgSaveLocal.json tidak ditemukan! Hubungi IT untuk install ulang Tools." + Environment.NewLine + Environment.NewLine + "Pesan Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Exit Sub
        End Try
        Try
            Globals.JsonObj = JObject.Parse(jsonTxt)
        Catch ex As Exception
            MessageBox.Show("Ada kesalahan dalam loading data. Hubungi IT untuk install ulang Tools." + Environment.NewLine + Environment.NewLine + "Pesan Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        InitTabFinishing() '<== Harus paling dulu!
        InitSetter()
        InitPresetCustomer()
        InitJenisOrder()
        InitFinishingA3()
        InitFinishingA3bw()
        InitFinishingLF()
        InitFinishingBR()
        InitFinishingKN()
        InitLayoutList()
        InitSisiMuka()
        InitImposition()
        InitFolder()
        InitQtyPages()
        AddChkHandler(pn_finishinga3)
        AddChkHandler(pn_finishingbw)
        AddChkHandler(pn_finishingkn)
        AddChkHandler(pn_finishingbr)
        init = True
    End Sub

    Private Sub InitPresetCustomer()
        jhandler.FillCBfromJson(cb_presetcustomer, Globals.JsonObj("cgPreset")("customer"))
    End Sub

    Private Sub InitSetter()
        jhandler.FillCBfromJson(cb_operator, Globals.JsonObj("cgSetter"), "kode", "nama")
    End Sub

    Private Sub InitJenisOrder()
        jhandler.FillCBfromJson(cb_jenisorder, Globals.JsonObj("cgJenisOrder")("katJenisOrder"), "id", "nama")
    End Sub

    Private Sub InitBahanUkuran()
        Dim parsedJenis = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        jhandler.FillCBfromJson(cb_bahan, parsedJenis(cb_jenisorder.SelectedValue.ToString).Root, "kode", "bahan")
    End Sub

    Private Sub InitFinishingA3()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("a3color"), JArray), 7, 7, 5, pn_finishinga3)
    End Sub

    Private Sub InitFinishingKN()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("kartunama"), JArray), 7, 7, 5, pn_finishingkn)
    End Sub

    Private Sub InitFinishingLF()
        jhandler.FillListFromJson(lst_finishingfn, DirectCast(Globals.JsonObj("cgFinishing")("largeformat"), JArray), "kode", "type")
    End Sub

    Private Sub InitFinishingBR()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("brosur"), JArray), 7, 7, 5, pn_finishingbr)
    End Sub

    Private Sub InitFinishingA3bw()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("a3bw"), JArray), 7, 7, 5, pn_finishingbw)
    End Sub

    Private Sub InitSisiMuka()
        jhandler.FillCBfromJson(cb_sisimuka, Globals.JsonObj("cgLayout")("sisimuka"), "kode", "type")
    End Sub

    Private Sub InitLayoutList()
        Dim parsedJenis = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgLayout")("layoutsize"))
        jhandler.FillCBfromJson(cb_layout, parsedJenis(cb_jenisorder.SelectedValue.ToString).Root, "kode", "type")
    End Sub

    Private Sub InitImposition()
        jhandler.FillCBfromJson(cb_imposition, Globals.JsonObj("cgLayout")("imposition"), "kode", "type")
    End Sub

    Private Sub InitFolder()
        cb_folder.Items.AddRange(Globals.TypeFolder.ToArray)
        cb_folder.SelectedIndex = 0
        jhandler.FillCBfromJson(cb_grouporder, Globals.JsonObj("cgPermanent")("kategori"))
    End Sub

    Private Sub InitTabFinishing()
        For i As Integer = 0 To tb_Finishing.TabPages.Count - 1
            TabFinishing.Add(tb_Finishing.TabPages(i))
        Next
    End Sub

    Private Sub InitQtyPages()
        Dim JmlPage = cdraw.ActiveDocument.Pages.Count.ToString
        t_jmlpage.Text = "Jumlah Page: " + JmlPage
        t_satuanqty.Text = Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("satuan").ToString
        ClsFileName.JmlPageQty = JmlPage + "pg@" + n_qtycetak.Value.ToString + t_satuanqty.Text
        GeneratePreview()
    End Sub
End Class