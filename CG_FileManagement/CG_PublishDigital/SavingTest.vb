Imports vgApp = Corel.Interop.VGCore
Imports Doc = Corel.Interop.VGCore.Document
Imports Corel.Interop.VGCore

Public Class SavingTest

    'Public WithEvents appDraw As Corel.Interop.VGCore.Application
    Dim filename As String
    'Dim stat As New vgApp.AppStatus
    Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.appDraw

    Public Sub New()
        InitializeComponent()
        filename = "\\10.10.0.10\graha\Setting\TEST.cdr"
        bWorker.WorkerSupportsCancellation = True
        bWorker.WorkerReportsProgress = True
    End Sub

    Private Sub bt_save_Click(sender As Object, e As System.EventArgs) Handles bt_save.Click
        If bWorker.IsBusy = False Then
            bWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If bWorker.IsBusy = True Then
            bWorker.CancelAsync()
        End If
    End Sub

    Private Sub bWorker_DoWork() Handles bWorker.DoWork
        'cdraw.ActiveDocument.SaveAs(filename)
        'bWorker.ReportProgress(stat.Progress)
    End Sub
    Private Sub bWorker_ProgressChanged() Handles bWorker.ProgressChanged
        ProgressBar1.Value += 100
    End Sub
End Class