Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Linq
Imports System.Diagnostics

Public Class MainForm
    Dim jhandler As New ClsJsonManager
    Dim ClsTabMgr As New ClsTabManager
    Dim jsonPath As String
    Dim jsonTxt As String
    Dim TabFinishing As New List(Of TabPage)

    Private Sub PublishDigital_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        InitForm()
    End Sub
    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        InitBahanUkuran()
        DisplayTabFinishing()
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
    Private Sub CekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(cb_jenisorder.SelectedValue.ToString)(cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            cb_sisimuka.Enabled = False
        Else
            cb_sisimuka.Enabled = True
        End If
    End Sub
    Private Sub AddChkHandler(ByVal panel As FlowLayoutPanel)
        For Each ctrl As CheckBox In panel.Controls
            AddHandler ctrl.CheckedChanged, AddressOf DynCheckboxChangeHandler
        Next
    End Sub
    Private Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
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
    Private Sub DisplayTabFinishing()
        For Each i As TabPage In TabFinishing
            ClsTabMgr.SetInvisible(i)
        Next
        Dim items As List(Of Integer) = Enumerable.Range(0, cb_jenisorder.Items.Count).ToList
        Dim selecteditem As Integer = cb_jenisorder.SelectedIndex
        Dim hiddentabindex As List(Of Integer) = items.Where(Function(number, index) index <> selecteditem).ToList
        ClsTabMgr.SetVisible(TabFinishing(cb_jenisorder.SelectedIndex).Name, tb_Finishing)
    End Sub
    Private Sub Bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Close()
    End Sub
    Private Sub FrmClose_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Globals.JsonObj = Nothing
    End Sub
End Class