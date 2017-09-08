Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class JsonHandler
    Private Shared Frm As PublishDigital
    Private Shared loopIndex As Integer

    Public Sub New(ByVal parentFrm As PublishDigital)
        Frm = parentFrm
    End Sub
    Public Shared Sub FillTabwithCB(ByVal frm As PublishDigital, cbdata As JArray, XOffset As Integer, YOffset As Integer, maxRow As Integer)
        Dim i As Integer = 0
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
    Public Shared Sub CekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(CType(Frm.cb_jenisorder.SelectedValue, String))(Frm.cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            Frm.cb_sisimuka.Enabled = False
        Else
            Frm.cb_sisimuka.Enabled = True
        End If
    End Sub
    Private Shared Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 1 To loopIndex Step 1
            Dim cbchk As CheckBox = DirectCast(Frm.pn_finishinga3.Controls("cb" + CStr(i)), CheckBox)
            If cbchk.Checked = True Then
                MessageBox.Show("test!!!!")
                't_preview.Text = DirectCast(Globals.JsonObj("cgFinishing")("a3colorfn")(CInt(DirectCast(cbchk.Name.Substring(cbchk.Name.Length - 1, 1)), Double) - 1))("kode"), String)
            End If
        Next
    End Sub
End Class
