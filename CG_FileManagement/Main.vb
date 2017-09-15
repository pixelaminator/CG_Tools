Imports System.Windows.Forms
Imports RGiesecke.DllExport
Module Main
    Public WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.AppDraw

    <DllExport("CGPublish")>
    Public Sub CG_Publish()
        Dim count As Integer
        count = cdraw.Documents.Count
        If count = 0 Then
            MessageBox.Show("Tidak ada dokumen yang terbuka.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim publish As New MainForm
        publish.ShowDialog()
    End Sub
    <DllExport("CGTestSaving")>
    Public Sub CG_TestSaving()
        Dim testSave As New SavingTest
        testSave.Show()
    End Sub
End Module
