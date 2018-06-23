Imports Corel.Interop.VGCore
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows.Window

Public Class DockerUI
    'Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.cdraw
    Private corelApp As Corel.Interop.VGCore.Application
    Private WithEvents bWorker As New BackgroundWorker
    Private ClsFunc As New ClsFunctions()
    Private ProgBarWindow As New ProgressWindow
    Private progWindow As System.Windows.Window = New System.Windows.Window With {
                .Title = "Membuat Polaroid...",
                .Content = ProgBarWindow,
                .SizeToContent = System.Windows.SizeToContent.WidthAndHeight,
                .ResizeMode = System.Windows.ResizeMode.NoResize,
                .Topmost = True,
                .WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen}

    Sub New(ByVal corelApp As Corel.Interop.VGCore.Application)
        InitializeComponent()
        Me.corelApp = corelApp
    End Sub

    Private Sub Bt_Browse_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_Browse.Click
        'Dim folderBrowser As New System.Windows.Forms.FolderBrowserDialog
        'If (folderBrowser.ShowDialog() = DialogResult.OK) Then
        '    t_alamat.Text = folderBrowser.SelectedPath
        'End If
        Using dlg As New OpenFileDialog With {.AddExtension = True,
                                              .AutoUpgradeEnabled = True,
                                              .CheckFileExists = False,
                                              .CheckPathExists = True,
                                              .FileName = "Folder selection",
                                              .Filter = "All files (*.*)|*.*",
                                              .FilterIndex = 1,
                                              .SupportMultiDottedExtensions = True,
                                              .Title = "Pilih folder yang berisi foto",
                                              .ValidateNames = True}
            If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim strFilename As String = dlg.FileName
                t_alamat.Text = System.IO.Path.GetDirectoryName(strFilename)
                t_photocount.Content = "Jumlah Photo: " + CStr(ClsFunc.CountPhotosInADirectory(System.IO.Path.GetDirectoryName(strFilename)))
            End If
        End Using
    End Sub

    Private Sub bt_createPolaroid_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_createPolaroid.Click
        Try
            Dim WorkerArgs As New bWorkerArgs
            WorkerArgs.path = t_alamat.Text
            WorkerArgs.giveBorder = cb_garisoutline.IsChecked
            bWorker.WorkerReportsProgress = True
            bWorker.RunWorkerAsync(WorkerArgs)
            ProgBarWindow.ProgressMessageStatus = "Mohon Tunggu..."
            progWindow.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bWorker.Dispose()
        End Try
    End Sub

    Private Sub bWorker_DoWork(ByVal sender As Object, e As DoWorkEventArgs) Handles bWorker.DoWork
        Dim Args As bWorkerArgs = e.Argument
        ClsFunc.InitPolaroid(Args.path, Args.giveBorder, CType(sender, BackgroundWorker))
    End Sub

    Private Sub bWorker_ReportProgress(ByVal sender As Object, e As ProgressChangedEventArgs) Handles bWorker.ProgressChanged
        Dim i As Integer
        For i = 0 To ClsFunc.ProgressNumberMax
            ProgBarWindow.ProgressBarPage = e.ProgressPercentage
            ProgBarWindow.ProgressBarTotal = ClsFunc.ProgressAllFiles
            ProgBarWindow.ProgressMessageStatus = ClsFunc.ProgressMessage
        Next
    End Sub

    Private Sub bWorker_ProgressComplete() Handles bWorker.RunWorkerCompleted
        progWindow.Hide()
    End Sub

    Private Sub bt_rotateleft_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_rotateleft.Click
        ClsFunc.PhotoRotate(-90)
    End Sub

    Private Sub bt_rotateright_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_rotateright.Click
        ClsFunc.PhotoRotate(90)
    End Sub

    Private Sub bt_fittoframe_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_fittoframe.Click
        ClsFunc.PhotoFit()
    End Sub

    Private Sub bt_delete_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_delete.Click
        ClsFunc.PhotoDelete()
    End Sub
End Class

Public Class bWorkerArgs
    Public path As String
    Public giveBorder As Boolean
End Class