' =======================================
'  _____ _____   _______          _     
' / ____/ ____| |__   __|        | |    
'| |   | |  __     | | ___   ___ | |___ 
'| |   | | |_ |    | |/ _ \ / _ \| / __|
'| |___| |__| |    | | (_) | (_) | \__ \
' \_____\_____|    |_|\___/ \___/|_|___/
'
' oleh M. Aditya Firmansyah
' Cipta Grafika Karawang, 2017
' E-mail: afansyah.dg@gmail.com
' =======================================

Imports System
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports iTextSharp
Imports Newtonsoft.Json.Linq
Imports RGiesecke.DllExport

Module Main
    Public AssemblyLoadError As Boolean
    Dim jsonPath As String
    Dim jsonTxt As String

    Sub New()
        'Loads 3rd party assembly from addon folder
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyLoadHandler
    End Sub

    <DllExport("CGPublish")>
    Public Sub CG_Publish()
        Dim count As Integer

        count = cdraw.Documents.Count
        If count = 0 Then
            MessageBox.Show("Tidak ada dokumen yang terbuka.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If SettingJSONLoaded() = False Then Exit Sub

        Dim FileIO As New ClsFileIO
        If FileIO.BaseURLValid = False Then Exit Sub

        Globals.SaveOption = 0

        Dim publish As New MainForm
        publish.ShowDialog()
    End Sub

    '<DllExport("CGTestSaving")>
    'Public Sub CG_TestSaving()
    '    Dim testSave As New SavingTest
    '    testSave.Show()
    'End Sub

    Private Function SettingJSONLoaded() As Boolean
        jsonPath = Application.StartupPath + "\Addons\CG_Tools\cgSave.json"
        Try
            jsonTxt = File.ReadAllText(jsonPath)
        Catch ex As FileNotFoundException
            MessageBox.Show("File cgSaveLocal.json tidak ditemukan! Hubungi IT untuk install ulang Tools." + Environment.NewLine + Environment.NewLine + "Pesan Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End Try
        Try
            Globals.JsonObj = JObject.Parse(jsonTxt)
        Catch ex As Exception
            MessageBox.Show("Ada kesalahan dalam loading data. Hubungi IT untuk install ulang Tools." + Environment.NewLine + Environment.NewLine + "Pesan Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End Try
        Return True
    End Function

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
                strTempAssmbPath = Application.StartupPath + "\Addons\CG_Tools\libs\" & args.Name.Substring(0, args.Name.IndexOf(",")) & ".dll"

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
End Module
