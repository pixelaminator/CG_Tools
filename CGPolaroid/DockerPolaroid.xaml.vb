Imports Corel.Interop.VGCore
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DockerUI
    'Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.cdraw
    Private corelApp As Corel.Interop.VGCore.Application
    Private WithEvents bWorker As New BackgroundWorker
    Private ClsFunc As New ClsFunctions()
    Private _PolaroidProgressMessage As String
    Private _PolaroidProgressPage As Integer
    Private _PolaroidProgressTotal As Integer

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
            If dlg.ShowDialog = DialogResult.OK Then
                Dim strFilename As String = dlg.FileName
                t_alamat.Text = System.IO.Path.GetDirectoryName(strFilename)
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
            cdraw.Status.BeginProgress()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK)
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
            PolaroidProgressPage = e.ProgressPercentage
            PolaroidProgressMessage = ClsFunc.ProgressMessage
        Next
    End Sub

    Public Property PolaroidProgressMessage As String
        Get
            Return _PolaroidProgressMessage
        End Get
        Set(value As String)
            _PolaroidProgressMessage = value
        End Set
    End Property

    Public Property PolaroidProgressPage As Integer
        Get
            Return _PolaroidProgressPage
        End Get
        Set(value As Integer)
            _PolaroidProgressPage = value
        End Set
    End Property

    Public Property PolaroidProgressTotal As Integer
        Get
            Return _PolaroidProgressTotal
        End Get
        Set(value As Integer)
            _PolaroidProgressTotal = value
        End Set
    End Property

    Private Sub bWorker_ProgressComplete() Handles bWorker.RunWorkerCompleted
        'ts_progress.Value = 0
        't_status.Text = "Ready"
        'For Each ctl As Control In Controls
        '    ctl.Enabled = True
        'Next
        cdraw.Status.EndProgress()
        'TODO: Look for workaround about CrossThreading issue
        'bt_CreatePolaroid.Enabled = False
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