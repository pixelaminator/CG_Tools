Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Linq

Public Class PublishDigital
    Dim jhandler As New JsonHandler
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
        InitSetter()
        InitJenisOrder()
        InitFinishingA3()
        InitFinishingA3bw()
        InitFinishingBR()
        InitFinishingKN()
        InitLayoutList()
        InitSisiMuka()
        InitImposition()
        InitFolder()
        AddChkHandler(pn_finishinga3)
        AddChkHandler(pn_finishingbw)
        AddChkHandler(pn_finishingkn)
        AddChkHandler(pn_finishingbr)
    End Sub
    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        InitBahanUkuran()
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
            CekDuaMuka()
        End If
    End Sub
    Public Sub CekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(cb_jenisorder.SelectedValue.ToString)(cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            cb_sisimuka.Enabled = False
        Else
            cb_sisimuka.Enabled = True
        End If
    End Sub
    Public Sub AddChkHandler(ByVal panel As FlowLayoutPanel)
        For Each ctrl As CheckBox In panel.Controls
            AddHandler ctrl.CheckedChanged, AddressOf DynCheckboxChangeHandler
        Next
    End Sub
    Public Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer
        Dim cbx = DirectCast(sender, CheckBox)
        Dim p = cbx.Parent
        For Each ctrl As CheckBox In p.Controls
            i += 1
            Dim cbchk As CheckBox = DirectCast(p.Controls("cb" + CStr(i)), CheckBox)
            If cbchk.Checked = True Then
                Dim chk As String = cbchk.Name
                'Gets an integer from a string (in this case "cb10" will return "10")
                Dim chkname = System.Text.RegularExpressions.Regex.Match(chk, "\d+").Value
                'TODO: Try not to get dependent on jenisorder.
                Dim chkdata As String = Globals.JsonObj("cgFinishing")(cb_jenisorder.SelectedValue.ToString)(CInt(chkname) - 1)("kode").ToString
                MessageBox.Show(chkdata)
            End If
        Next
    End Sub
End Class