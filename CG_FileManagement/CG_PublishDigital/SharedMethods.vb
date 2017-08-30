Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Drawing
Imports System

Partial Class PublishDigital
    Public Sub fillCBfromJson(ByVal cb As ComboBox, json As Object, Optional ByVal value As String = "", Optional display As String = "")
        cb.ValueMember = value
        cb.DisplayMember = display
        cb.DataSource = json
    End Sub
    Public Sub cekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = parseJsonToDictionary(jsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = parsed(cb_jenisorder.SelectedValue)(cb_bahan.SelectedIndex)("duamuka")
        If bahan2muka = False Then
            cb_sisimuka.Enabled = False
        Else
            cb_sisimuka.Enabled = True
        End If
    End Sub
    Public Sub fillTabwithCB(ByVal cbdata As JArray, XOffset As Integer, YOffset As Integer, maxRow As Integer)
        Dim loopIndex As Integer
        Dim i As Integer = 0

        Dim myCb As New List(Of CheckBox)

        For Each cur In cbdata
            Dim cb = New CheckBox()
            pn_finishinga3.Controls.Add(cb)
            cb.Location = New Point(XOffset, YOffset)
            Dim txt As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonConvert.SerializeObject(cur))
            loopIndex += 1

            Dim cbname As String = "cb" + CType(loopIndex, String)
            cb.Name = cbname
            cb.Text = txt("type")
            cb.Margin = New Padding(0)
            cb.AutoSize = False

            Dim matches() As Control
            matches = Me.Controls.Find(cbname, True)
            myCb.Add(DirectCast(matches(0), CheckBox))
        Next
    End Sub
    Public Function parseJsonToDictionary(ByVal json As JToken) As Dictionary(Of String, JArray)
        parseJsonToDictionary = JsonConvert.DeserializeObject(Of Dictionary(Of String, JArray))(JsonConvert.SerializeObject(json))
    End Function
End Class
