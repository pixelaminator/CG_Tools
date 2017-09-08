Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class JsonHandler
    'Dim frm As PublishDigital
    'Public Sub New(pd As PublishDigital)
    '    frm = pd
    'End Sub
    Public Shared Sub FillTabwithCB(ByVal frm As PublishDigital, cbdata As JArray, XOffset As Integer, YOffset As Integer, maxRow As Integer)
        Dim i As Integer = 0
        Dim loopIndex As Integer
        Dim myCb As New List(Of CheckBox)
        For Each cur In cbdata
            Dim cb = New CheckBox()
            frm.pn_finishinga3.Controls.Add(cb)
            Dim txt As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonConvert.SerializeObject(cur))
            loopIndex += 1

            Dim cbname As String = "cb" + CType(loopIndex, String)
            cb.Name = cbname
            cb.Text = CType(txt("type"), String)
            cb.Margin = New Padding(0)
            cb.AutoSize = False

            Dim matches() As Control
            matches = frm.Controls.Find(cbname, True)
            myCb.Add(DirectCast(matches(0), CheckBox))

            'AddHandler cb.CheckedChanged, AddressOf DynCheckboxChangeHandler
        Next
    End Sub
    Public Shared Function ParseJsonToDictionary(ByVal json As JToken) As Dictionary(Of String, JArray)
        ParseJsonToDictionary = JsonConvert.DeserializeObject(Of Dictionary(Of String, JArray))(JsonConvert.SerializeObject(json))
    End Function
    Public Shared Sub FillCBfromJson(ByVal cb As ComboBox, json As Object, Optional ByVal value As String = "", Optional display As String = "")
        cb.ValueMember = value
        cb.DisplayMember = display
        cb.DataSource = json
    End Sub
    Public Shared Sub CekDuaMuka(frm As PublishDigital)
        Dim bahan2muka As Boolean
        Dim parsed = ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(CType(frm.cb_jenisorder.SelectedValue, String))(frm.cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            frm.cb_sisimuka.Enabled = False
        Else
            frm.cb_sisimuka.Enabled = True
        End If
    End Sub
    'Public Shared Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    '    FinishingCBChecked()
    'End Sub
End Class
