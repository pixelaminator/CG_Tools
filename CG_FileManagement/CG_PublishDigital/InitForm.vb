Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing
Imports System

Partial Class PublishDigital
    Public Sub initSetter()
        fillCBfromJson(cb_operator, jsonObj("cgSetter"), "kode", "nama")
    End Sub
    Public Sub initJenisOrder()
        fillCBfromJson(cb_jenisorder, jsonObj("cgJenisOrder")("katJenisOrder"), "id", "nama")
    End Sub
    Public Sub initBahanUkuran()
        Dim parsedJenis = parseJsonToDictionary(jsonObj("cgJenisOrder")("dataJenisOrder"))
        fillCBfromJson(cb_bahan, parsedJenis(cb_jenisorder.SelectedValue).Root, "kode", "bahan")
    End Sub
    Public Sub initfinishingA3()
        fillTabwithCB(jsonObj("cgFinishing")("a3colorfn"), 7, 7, 5)
    End Sub

End Class