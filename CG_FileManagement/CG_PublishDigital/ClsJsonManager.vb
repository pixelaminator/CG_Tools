Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class ClsJsonManager
    Public Sub FillTabwithCB(ByVal frm As Control, cbdata As JArray, XOffset As Integer, YOffset As Integer, maxRow As Integer, tab As FlowLayoutPanel)
        Dim i As Integer = 0
        Dim CBTotal As Integer
        'Dim myCb As New List(Of CheckBox)
        For Each cur In cbdata
            Dim cb = New CheckBox()
            Dim txt As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonConvert.SerializeObject(cur))

            Dim cbname As String = "cb" + CBTotal.ToString
            cb.Name = cbname
            cb.Text = txt("type").ToString
            cb.Margin = New Padding(0)
            cb.AutoSize = False

            tab.Controls.Add(cb)

            'Dim matches() As Control
            'matches = frm.Controls.Find(cbname, True)
            'myCb.Add(DirectCast(matches(0), CheckBox))

            CBTotal += 1
        Next
    End Sub

    Public Function ParseJsonToDictionary(ByVal json As JToken) As Dictionary(Of String, JArray)
        ParseJsonToDictionary = JsonConvert.DeserializeObject(Of Dictionary(Of String, JArray))(JsonConvert.SerializeObject(json))
    End Function

    Public Sub FillCBfromJson(ByVal cb As ComboBox, json As Object, Optional ByVal value As String = "", Optional display As String = "")
        cb.ValueMember = value
        cb.DisplayMember = display
        cb.DataSource = json
    End Sub

    Public Sub FillListFromJson(ByVal lst As ListBox, json As Object, Optional ByVal value As String = "", Optional display As String = "")
        lst.ValueMember = value
        lst.DisplayMember = display
        lst.DataSource = json
    End Sub
End Class
