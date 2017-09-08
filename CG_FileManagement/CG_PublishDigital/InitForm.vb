Imports Newtonsoft.Json.Linq

Class InitForm
    Public Sub Setter(frm As PublishDigital)
        JsonHandler.FillCBfromJson(frm.cb_operator, Globals.JsonObj("cgSetter"), "kode", "nama")
    End Sub
    Public Sub JenisOrder(frm As PublishDigital)
        JsonHandler.FillCBfromJson(frm.cb_jenisorder, Globals.JsonObj("cgJenisOrder")("katJenisOrder"), "id", "nama")
    End Sub
    Public Sub BahanUkuran(frm As PublishDigital)
        Dim parsedJenis = JsonHandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        JsonHandler.FillCBfromJson(frm.cb_bahan, parsedJenis(CType(frm.cb_jenisorder.SelectedValue, String)).Root, "kode", "bahan")
    End Sub
    Public Sub FinishingA3(frm As PublishDigital)
        JsonHandler.FillTabwithCB(frm, DirectCast(Globals.JsonObj("cgFinishing")("a3colorfn"), JArray), 7, 7, 5)
    End Sub
    Public Sub SisiMuka(frm As PublishDigital)
        JsonHandler.FillCBfromJson(frm.cb_sisimuka, Globals.JsonObj("cgLayout")("sisimuka"), "kode", "type")
    End Sub
    Public Sub LayoutList(frm As PublishDigital)
        Dim parsedJenis = JsonHandler.ParseJsonToDictionary(Globals.JsonObj("cgLayout"))
        JsonHandler.FillCBfromJson(frm.cb_layout, parsedJenis(CType(frm.cb_jenisorder.SelectedValue, String)).Root, "kode", "type")
    End Sub
    Public Sub Imposition(frm As PublishDigital)
        JsonHandler.FillCBfromJson(frm.cb_imposition, Globals.JsonObj("cgLayout")("imposition"), "kode", "type")
    End Sub
    Public Sub Folder(frm As PublishDigital)
        frm.cb_folder.Items.AddRange(Globals.TypeFolder.ToArray)
        frm.cb_folder.SelectedIndex = 0
        JsonHandler.FillCBfromJson(frm.cb_grouporder, Globals.JsonObj("cgPermanent")("kategori"))
    End Sub
End Class