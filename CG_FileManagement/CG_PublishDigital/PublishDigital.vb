Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class PublishDigital
    Dim init As New InitForm(Me)
    Dim jhandler As New JsonHandler(Me)
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
        Globals.JsonObj = JObject.Parse(jsonTxt)
        'End Using
        init.Setter()
        init.JenisOrder()
        init.FinishingA3()
        init.LayoutList()
        init.SisiMuka()
        init.Imposition()
        init.Folder()
    End Sub

    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        init.BahanUkuran()
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
            JsonHandler.CekDuaMuka()
        End If
    End Sub
End Class