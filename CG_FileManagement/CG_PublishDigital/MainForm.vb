Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Linq
Imports System.Diagnostics
Imports System.Reflection

Public Class MainForm
    Dim init As Boolean
    Dim AssemblyLoadError As Boolean
    Dim CodeFinishing() As String
    Dim jhandler As New ClsJsonManager
    Dim ClsTabMgr As New ClsTabManager
    Dim ClsFileName As New ClsFileNaming
    Dim jsonPath As String
    Dim jsonTxt As String
    Dim TabFinishing As New List(Of TabPage)
    Dim ActivePanelFinishing As Control
    Dim _SelectedJenisOrderIndex As Integer = -1
    'Dim _ActivePanelFinishing As Control

#Region "Form Load"
    Private Sub PublishDigital_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        'Loads 3rd party assembly from addon folder
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyLoadHandler
        'If ANY exceptions happens, close the form.
        Try
            InitForm()
        Catch ex As Exception
            MessageBox.Show("Ada kesalahan dalam loading program. Hubungi IT untuk install ulang CG Tools." + Environment.NewLine + "Pesan error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Function AssemblyLoadHandler(ByVal sender As Object,
                       ByVal args As ResolveEventArgs) As [Assembly]
        'This handler is called only when the common language runtime tries to bind to the assembly and fails.        

        'Retrieve the list of referenced assemblies in an array of AssemblyName.
        Dim objExecutingAssemblies As [Assembly]
        objExecutingAssemblies = [Assembly].GetExecutingAssembly()
        Dim arrReferencedAssmbNames() As AssemblyName
        arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies()

        'Loop through the array of referenced assembly names.
        Dim strAssmbName As AssemblyName
        For Each strAssmbName In arrReferencedAssmbNames
            Dim MyAssembly As [Assembly]
            'Look for the assembly names that have raised the "AssemblyResolve" event.
            If (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) = args.Name.Substring(0, args.Name.IndexOf(","))) Then

                'Build the path of the assembly from where it has to be loaded.
                Dim strTempAssmbPath As String
                strTempAssmbPath = Application.StartupPath + "\Addons\CG_Tools\" & args.Name.Substring(0, args.Name.IndexOf(",")) & ".dll"

                'Load the assembly from the specified path. 
                Try
                    MyAssembly = [Assembly].LoadFrom(strTempAssmbPath)
                    'Return the loaded assembly.
                    Return MyAssembly
                Catch ex As Exception
                    AssemblyLoadError = True
                    Exit Function
                End Try
            End If
        Next
    End Function
#End Region

#Region "GUI Event Handler"
    Private Sub Cb_jenisorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenisorder.SelectedIndexChanged
        If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then InitBahanUkuran()
        DisplayTabFinishing()
        KodeJenisOrder()
        If init = True Then
            GenerateCodeFinishing()
            CekBahanSendiri()
            CekLayoutSize()
            CekImposition()
            InitQtyPages()
            InitLayoutList()
        End If
        GeneratePreview()
    End Sub

    Private Sub C_bahan_CheckedChanged(sender As Object, e As EventArgs) Handles c_bahan.CheckedChanged
        'Kalau jenis order tidak berganti tidak usah jalanin code
        If cb_jenisorder.SelectedIndex > -1 AndAlso Not cb_jenisorder.Equals(_SelectedJenisOrderIndex) Then
            If cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList Then
                cb_bahan.SelectedValue = ""
                cb_bahan.DropDownStyle = ComboBoxStyle.Simple
                cb_sisimuka.Enabled = True
            Else
                cb_bahan.DropDownStyle = ComboBoxStyle.DropDownList
                cb_bahan.SelectedIndex = 0
            End If
            _SelectedJenisOrderIndex = cb_jenisorder.SelectedIndex
        End If

    End Sub

    Private Sub Cb_bahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_bahan.SelectedIndexChanged
        If c_bahan.Checked = False Then
            CekDuaMuka()
            ClsFileName.Bahan = cb_bahan.SelectedValue.ToString
            GeneratePreview()
        End If
    End Sub

    Private Sub cb_bahan_TextChanged(sender As Object, e As EventArgs) Handles cb_bahan.TextChanged
        ClsFileName.Bahan = cb_bahan.Text
        GeneratePreview()
    End Sub

    Private Sub Bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Close()
    End Sub

    Private Sub FrmClose_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AssemblyLoadError = False Then Globals.JsonObj = Nothing
    End Sub

    Private Sub Cb_operator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_operator.SelectedIndexChanged
        ClsFileName.NamaSetter = cb_operator.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub t_harga_TextChanged(sender As Object, e As EventArgs) Handles t_harga.TextChanged
        ClsFileName.Harga = t_harga.Text
        GeneratePreview()
    End Sub

    Private Sub n_noorder_ValueChanged(sender As Object, e As EventArgs) Handles n_noorder.ValueChanged
        ClsFileName.NoOrder = n_noorder.Value.ToString
        GeneratePreview()
    End Sub

    Private Sub n_qtycetak_ValueChanged(sender As Object, e As EventArgs) Handles n_qtycetak.ValueChanged
        'Somehow triggered before all assemblies fully loaded, therefore init check.
        If init = True Then InitQtyPages()
    End Sub

    Private Sub cb_sisimuka_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sisimuka.SelectedIndexChanged
        ClsFileName.SisiMuka = cb_sisimuka.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub cb_imposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_imposition.SelectedIndexChanged
        ClsFileName.TypeImposition = cb_imposition.SelectedValue.ToString
        GeneratePreview()
    End Sub

    Private Sub t_customer_TextChanged(sender As Object, e As EventArgs) Handles t_customer.TextChanged
        ClsFileName.NamaCustomer = t_customer.Text
        GeneratePreview()
    End Sub

    Private Sub t_judulfile_TextChanged(sender As Object, e As EventArgs) Handles t_judulfile.TextChanged
        ClsFileName.JudulFile = t_judulfile.Text
        GeneratePreview()
    End Sub

    Private Sub cb_presetcustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_presetcustomer.SelectedIndexChanged
        If init = True Then t_customer.Text = cb_presetcustomer.SelectedValue.ToString
    End Sub

    Private Sub cb_layout_TextChanged(sender As Object, e As EventArgs) Handles cb_layout.TextChanged
        If cb_layout.DropDownStyle = ComboBoxStyle.DropDownList Then
            ClsFileName.LayoutSize = cb_layout.SelectedValue.ToString
        Else
            ClsFileName.LayoutSize = cb_layout.Text
        End If
        GeneratePreview()
    End Sub
#End Region

    Private Sub CekDuaMuka()
        Dim bahan2muka As Boolean
        Dim parsed = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgJenisOrder")("dataJenisOrder"))
        bahan2muka = CType(parsed(cb_jenisorder.SelectedValue.ToString)(cb_bahan.SelectedIndex)("duamuka"), Boolean)
        If bahan2muka = False Then
            cb_sisimuka.Enabled = False
            ClsFileName.SisiMuka = ""
            GeneratePreview()
        Else
            cb_sisimuka.Enabled = True
            If init = True Then cb_sisimuka_SelectedIndexChanged(cb_sisimuka, New EventArgs)
        End If
    End Sub

    Private Sub CekLayoutSize()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("layouteditable"), Boolean) = True Then
            cb_layout.DropDownStyle = ComboBoxStyle.DropDown
        Else
            cb_layout.DropDownStyle = ComboBoxStyle.DropDownList
        End If
    End Sub

    Private Sub CekImposition()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("useimposition"), Boolean) = True Then
            cb_imposition.Enabled = True
            cb_imposition_SelectedIndexChanged(cb_imposition, New EventArgs)
        Else
            cb_imposition.Enabled = False
            ClsFileName.TypeImposition = ""
            GeneratePreview()
        End If
    End Sub

    Private Sub CekBahanSendiri()
        If CType(Globals.JsonObj("cgJenisOrder")("katJenisOrder")(cb_jenisorder.SelectedIndex)("bahaneditable"), Boolean) = True Then
            c_bahan.Enabled = True
            'C_bahan_CheckedChanged(c_bahan, New EventArgs)
        Else
            c_bahan.Checked = False
            c_bahan.Enabled = False
        End If
    End Sub

    Private Sub KodeJenisOrder()
        ClsFileName.JenisOrder = Globals.JsonObj("cgKodeOrder")(cb_jenisorder.SelectedIndex).ToString
        GeneratePreview()
    End Sub

    Private Sub AddChkHandler(ByVal panel As FlowLayoutPanel)
        For Each ctrl As CheckBox In panel.Controls
            AddHandler ctrl.CheckedChanged, AddressOf DynCheckboxChangeHandler
        Next
    End Sub

    Private Sub DynCheckboxChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
        GenerateCodeFinishing()
    End Sub

    Private Sub GenerateCodeFinishing()
        Dim i As Integer
        ReDim CodeFinishing(ActivePanelFinishing.Controls.Count - 1)
        For Each ctrl As CheckBox In ActivePanelFinishing.Controls
            Dim cbchk As CheckBox = DirectCast(ActivePanelFinishing.Controls("cb" + CStr(i)), CheckBox)
            If cbchk.Checked = True Then
                Dim chk As String = cbchk.Name
                'Gets an integer from a string (in this case "cb10" will return "10")
                Dim chkname As Integer = CInt(System.Text.RegularExpressions.Regex.Match(chk, "\d+").Value)
                'TODO: Try not to get dependent on jenisorder.
                Dim chkdata As String = Globals.JsonObj("cgFinishing")(cb_jenisorder.SelectedValue.ToString)(chkname)("kode").ToString
                CodeFinishing(chkname) = chkdata
            End If
            i += 1
        Next
        Dim FilteredNamaFile = From ar In CodeFinishing Where ar <> "" Select ar
        Dim result As String = String.Join(",", FilteredNamaFile.ToArray)
        ClsFileName.KodeFinishing = result
        GeneratePreview()
    End Sub

    'Private Property ActivePanelFinishing As Control
    '    Get
    '        Return _ActivePanelFinishing
    '    End Get
    '    Set(value As Control)
    '        _ActivePanelFinishing = value
    '    End Set
    'End Property

    Private Sub DisplayTabFinishing()
        For Each i As TabPage In TabFinishing
            ClsTabMgr.SetInvisible(i)
        Next
        Dim items As List(Of Integer) = Enumerable.Range(0, cb_jenisorder.Items.Count).ToList
        Dim selecteditem As Integer = cb_jenisorder.SelectedIndex
        Dim hiddentabindex As List(Of Integer) = items.Where(Function(number, index) index <> selecteditem).ToList

        Dim ActiveTabPage As Control = TabFinishing(cb_jenisorder.SelectedIndex)
        ClsTabMgr.SetVisible(ActiveTabPage.Name, tb_Finishing)
        ActivePanelFinishing = ActiveTabPage.Controls(0)
    End Sub

    Private Sub GeneratePreview()
        t_preview.Text = ClsFileName.DoFileName()
    End Sub
End Class