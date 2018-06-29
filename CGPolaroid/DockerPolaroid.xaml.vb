Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DockerUI
    Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.cdraw
    Private corelApp As Corel.Interop.VGCore.Application
    Private WithEvents bWorker As New BackgroundWorker
    Private ClsFunc As New ClsFunctions()
    Private ProgBarWindow As New ProgressWindow(Me)
    Const MaxFiles As Integer = 500
    Private TotalFiles As Integer
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
                TotalFiles = ClsFunc.CountPhotosInADirectory(System.IO.Path.GetDirectoryName(strFilename))
                t_photocount.Content = "Jumlah Photo: " + CStr(TotalFiles)
            End If
        End Using
    End Sub

    Private Sub bt_createPolaroid_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_createPolaroid.Click
        If TotalFiles > MaxFiles Then
            MessageBox.Show("Maksimal jumlah foto yang bisa disusun dalam satu file adalah " & MaxFiles.ToString & " foto." + Environment.NewLine + "Jumlah foto yang ada di dalam folder yang dipilih: " & TotalFiles.ToString & " foto.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Try
            Dim WorkerArgs As New bWorkerArgs
            WorkerArgs.path = t_alamat.Text
            WorkerArgs.giveBorder = cb_garisoutline.IsChecked
            WorkerArgs.autoRotate = cb_autorotate.IsChecked
            WorkerArgs.PolaroidOrientation = cb_orientation.SelectedIndex
            WorkerArgs.FrameFit = cb_framefit.SelectedIndex

            bWorker.WorkerReportsProgress = True
            bWorker.WorkerSupportsCancellation = True
            bWorker.RunWorkerAsync(WorkerArgs)

            ProgBarWindow.ProgressMessageStatus = "Mohon Tunggu..."
            Me.IsEnabled = False
            progWindow.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bWorker.Dispose()
        End Try
    End Sub

    Private Sub bWorker_DoWork(ByVal sender As Object, e As DoWorkEventArgs) Handles bWorker.DoWork
        Dim Args As bWorkerArgs = e.Argument
        'ClsFunc.InitPolaroid(Args.path, Args.giveBorder, CType(sender, BackgroundWorker))
        ClsFunc.InitPolaroid(Args, CType(sender, BackgroundWorker))
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
        Me.IsEnabled = True
    End Sub

    Public Sub bWorker_Cancel()
        If bWorker.IsBusy Then
            bWorker.CancelAsync()
            progWindow.Hide()
            Me.IsEnabled = True
        End If
    End Sub

    'TODO: Mungkin ada cara lain yang lebih baik buat menggabungkan dua method ini.
    'Private Sub CheckForBlankDocumentOnClose() Handles cdraw.DocumentClose
    '    If cdraw.Documents.Count <= 1 Then
    '        grp_tools.IsEnabled = False
    '    Else
    '        grp_tools.IsEnabled = True
    '    End If
    'End Sub

    'Private Sub CheckForBlankDocumentOnOpen() Handles cdraw.DocumentOpen, cdraw.DocumentNew
    '    If cdraw.Documents.Count >= 1 Then
    '        grp_tools.IsEnabled = True
    '    Else
    '        grp_tools.IsEnabled = False
    '    End If
    'End Sub

    Private Sub bt_rotateleft_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_rotateleft.Click
        ClsFunc.PhotoTools(ClsFunctions.PhotoActions.PhotoRotate, -90)
    End Sub

    Private Sub bt_rotateright_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_rotateright.Click
        ClsFunc.PhotoTools(ClsFunctions.PhotoActions.PhotoRotate, 90)
    End Sub

    Private Sub bt_fittoframe_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_fittoframe.Click
        ClsFunc.PhotoTools(ClsFunctions.PhotoActions.PhotoFit)
    End Sub

    Private Sub bt_delete_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles bt_delete.Click
        ClsFunc.PhotoTools(ClsFunctions.PhotoActions.PhotoDelete)
    End Sub

    Private Sub bt_filltoframe_Click(sender As Object, e As Windows.RoutedEventArgs) Handles bt_filltoframe.Click
        ClsFunc.PhotoTools(ClsFunctions.PhotoActions.PhotoFill)
    End Sub
End Class