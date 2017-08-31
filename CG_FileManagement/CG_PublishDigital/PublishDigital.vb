Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Public Class PublishDigital
    Public jsonPath As String
    Public Shared jsonTxt As String
    Public Shared jsonObj As JObject

    Private Sub PublishDigital_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        jsonPath = Application.StartupPath + "\Addons\CG_Tools\cgSave.json"
        If File.Exists(jsonPath) = False Then
            MessageBox.Show("File cgSaveLocal.json tidak ditemukan! Hubungi IT untuk install ulang Tools.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If
        jsonTxt = File.ReadAllText(jsonPath)
        'Using r As New StreamReader(jsonPath)
        '    Dim jsonTxt As String = r.ReadToEnd()
            jsonObj = JObject.Parse(jsonTxt)
        'End Using
        initSetter()
        initJenisOrder()
        initfinishingA3()
    End Sub

    Private Sub cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        initBahanUkuran()
    End Sub

    Private Sub bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Close()
    End Sub

    Private Sub c_bahan_CheckedChanged(sender As Object, e As EventArgs) Handles c_bahan.CheckedChanged
        If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then
            cb_bahan.SelectedValue = ""
            cb_bahan.DropDownStyle = ComboBoxStyle.Simple
            cb_sisimuka.Enabled = True
        Else
            cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList
            cb_bahan.SelectedIndex = 0
        End If
    End Sub

    Private Sub cb_bahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_bahan.SelectedIndexChanged
        If c_bahan.Checked = False Then
            cekDuaMuka()
        End If
    End Sub
End Class