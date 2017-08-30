Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports RGiesecke.DllExport
Imports Corel.Interop.VGCore
Module Main
    Public WithEvents appDraw As New Corel.Interop.VGCore.Application
    <DllExport("CGToolsNET")>
    Public Sub CG_Publish()
        Dim count As Integer
        count = appDraw.Documents.Count
        If count = 0 Then
            MessageBox.Show("Tidak ada dokumen yang terbuka.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim publish As New PublishDigital
        publish.ShowDialog()
    End Sub
End Module
