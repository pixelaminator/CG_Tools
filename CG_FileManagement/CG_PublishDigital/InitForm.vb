Imports Newtonsoft.Json.Linq

Partial Class PublishDigital
    Public Sub InitSetter()
        jhandler.FillCBfromJson(cb_operator, Globals.JsonObj("cgSetter"), "kode", "nama")
    End Sub
    Public Sub InitJenisOrder()
        jhandler.FillCBfromJson(cb_jenisorder, Globals.JsonObj("cgJenisOrder")("katJenisOrder"), "id", "nama")
    End Sub
    Public Sub InitBahanUkuran()
        Dim parsedJenis = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        jhandler.FillCBfromJson(cb_bahan, parsedJenis(cb_jenisorder.SelectedValue.ToString).Root, "kode", "bahan")
    End Sub
    Public Sub InitFinishingA3()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("a3color"), JArray), 7, 7, 5, pn_finishinga3)
    End Sub
    Public Sub InitFinishingKN()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("kartunama"), JArray), 7, 7, 5, pn_finishingkn)
    End Sub
    Public Sub InitFinishingBR()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("brosur"), JArray), 7, 7, 5, pn_finishingbr)
    End Sub
    Public Sub InitFinishingA3bw()
        jhandler.FillTabwithCB(Me, DirectCast(Globals.JsonObj("cgFinishing")("a3bw"), JArray), 7, 7, 5, pn_finishingbw)
    End Sub
    Public Sub InitSisiMuka()
        jhandler.FillCBfromJson(cb_sisimuka, Globals.JsonObj("cgLayout")("sisimuka"), "kode", "type")
    End Sub
    Public Sub InitLayoutList()
        Dim parsedJenis = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgLayout"))
        jhandler.FillCBfromJson(cb_layout, parsedJenis(cb_jenisorder.SelectedValue.ToString).Root, "kode", "type")
    End Sub
    Public Sub InitImposition()
        jhandler.FillCBfromJson(cb_imposition, Globals.JsonObj("cgLayout")("imposition"), "kode", "type")
    End Sub
    Public Sub InitFolder()
        cb_folder.Items.AddRange(Globals.TypeFolder.ToArray)
        cb_folder.SelectedIndex = 0
        jhandler.FillCBfromJson(cb_grouporder, Globals.JsonObj("cgPermanent")("kategori"))
    End Sub
End Class