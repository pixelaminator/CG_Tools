Imports Newtonsoft.Json.Linq

Partial Class MainForm
    Dim FileIO As New ClsFileIO
    Private Sub InitForm()
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
        InitCheckMultiplePages()
        AddChkHandler(pn_finishinga3)
        AddChkHandler(pn_finishingbw)
        AddChkHandler(pn_finishingkn)
        AddChkHandler(pn_finishingbr)
        IsFormInitialized = True
        InitControlState()
    End Sub

    Private Sub InitCheckMultiplePages()
        If cdraw.ActiveDocument.Pages.Count > 1 Then
            DocHasMultiplePages = True
            cb_sisimuka.Enabled = True
            cb_imposition.Enabled = True
        End If
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

    Private Sub InitControlState()
        rb_nonelf.Checked = True
        rb_convcurve.Checked = True
        rb_allpage.Checked = True
        n_qtycetak.Value = 1
        n_qtycetak.Minimum = 1
        n_noorder.Value = 1
        n_noorder.Minimum = 1
    End Sub
End Class