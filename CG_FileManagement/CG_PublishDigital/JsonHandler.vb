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
            cb.Text = txt("type")
            cb.Margin = New Padding(0)
            cb.AutoSize = False

            Dim matches() As Control
            matches = frm.Controls.Find(cbname, True)
            myCb.Add(DirectCast(matches(0), CheckBox))

            AddHandler cb.CheckedChanged, AddressOf DynCheckboxChangeHandler
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
        bahan2muka = parsed(frm.cb_jenisorder.SelectedValue)(frm.cb_bahan.SelectedIndex)("duamuka")
        If bahan2muka = False Then
            frm.cb_sisimuka.Enabled = False
        Else
            frm.cb_sisimuka.Enabled = True
        End If
    End Sub
    Private Shared Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loopindex As Integer
        Dim frm As New PublishDigital
        For i As Integer = 1 To loopindex Step 1
            Dim cbchk As CheckBox = CType(frm.pn_finishinga3.Controls("cb" + CType(i, String)), CheckBox)
            If cbchk.Checked = True Then
                frm.t_preview.Text = Globals.JsonObj("cgFinishing")("a3colorfn")(CInt(cbchk.Name.Substring(cbchk.Name.Length - 1, 1) - 1))("kode")
            End If
        Next
    End Sub
End Class
