Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class PublishDigital
    Dim init As New InitForm
    Dim jsonPath As String
    Dim jsonTxt As String

    Private Sub PublishDigital_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        jsonPath = Application.StartupPath + "\Addons\CG_Tools\cgSave.json"
        If File.Exists(jsonPath) = False Then
            MessageBox.Show("File cgSaveLocal.json tidak ditemukan! Hubungi IT untuk install ulang Tools.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If
        jsonTxt = File.ReadAllText(jsonPath)
        'Using r As New StreamReader(jsonPath)
        '    Dim jsonTxt As String = r.ReadToEnd()
        Globals.jsonObj = JObject.Parse(jsonTxt)
        'End Using
        init.Setter(Me)
        init.JenisOrder(Me)
        init.FinishingA3(Me)
        init.LayoutList(Me)
        init.SisiMuka(Me)
        init.Imposition(Me)
        init.Folder(Me)
    End Sub

    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        init.BahanUkuran(Me)
    End Sub

    Private Sub Bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Close()
    End Sub

    Private Sub C_bahan_CheckedChanged(sender As Object, e As EventArgs) Handles c_bahan.CheckedChanged
        If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then
            cb_bahan.SelectedValue = ""
            cb_bahan.DropDownStyle = ComboBoxStyle.Simple
            cb_sisimuka.Enabled = True
        Else
            cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList
            cb_bahan.SelectedIndex = 0
        End If
    End Sub

    Private Sub Cb_bahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_bahan.SelectedIndexChanged
        If c_bahan.Checked = False Then
            JsonHandler.CekDuaMuka(Me)
        End If
    End Sub

    Public Sub FinishingCBChecked()
        Dim loopindex As Integer
        For i As Integer = 1 To loopindex Step 1
            Dim cbchk As CheckBox = DirectCast(pn_finishinga3.Controls("cb" + CStr(i)), CheckBox)
            If cbchk.Checked = True Then
                't_preview.Text = DirectCast(Globals.JsonObj("cgFinishing")("a3colorfn")(CInt(DirectCast(cbchk.Name.Substring(cbchk.Name.Length - 1, 1)), Double) - 1))("kode"), String)
            End If
        Next
    End Sub
End Class