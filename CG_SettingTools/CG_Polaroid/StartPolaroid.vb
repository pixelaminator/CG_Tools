Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class StartPolaroid
    Dim ClsFunc As New ClsFunctions()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.TopMost = True
    End Sub

    Private Sub createPolaroid_Click(sender As Object, e As System.EventArgs) Handles bt_CreatePolaroid.Click
        For Each ctl As Control In Controls
            ctl.Enabled = False
        Next
        bt_Abort.Enabled = True
        Try
            bWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK)
            bWorker.Dispose()
            Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles bt_Browse.Click
        If (folderBrowser.ShowDialog() = DialogResult.OK) Then
            t_alamat.Text = folderBrowser.SelectedPath
        End If
    End Sub

    Private Sub bWorker_DoWork(ByVal sender As Object, e As DoWorkEventArgs) Handles bWorker.DoWork
        ClsFunc.InitPolaroid(t_alamat.Text, CType(sender, BackgroundWorker))
    End Sub

    Private Sub bWorker_ReportProgress(ByVal sender As Object, e As ProgressChangedEventArgs) Handles bWorker.ProgressChanged
        Dim i As Integer
        ts_progress.Maximum = 100
        For i = 0 To ClsFunc.ProgressNumberMax
            ts_progress.Value = e.ProgressPercentage
            t_status.Text = ClsFunc.ProgressMessage
        Next
    End Sub

    Private Sub bWorker_ProgressComplete() Handles bWorker.RunWorkerCompleted
        ts_progress.Value = 0
        t_status.Text = "Ready"
        For Each ctl As Control In Controls
            ctl.Enabled = True
        Next
        'TODO: Look for workaround about CrossThreading issue
        bt_CreatePolaroid.Enabled = False
        bt_Abort.Enabled = False
    End Sub

    Private Sub bt_Abort_Click(sender As Object, e As System.EventArgs) Handles bt_Abort.Click
        If bWorker.IsBusy Then
            bWorker.CancelAsync()
            While bWorker.IsBusy
                Application.DoEvents()
            End While
        End If
    End Sub

    Private Sub bt_RotateClockwise_Click(sender As Object, e As EventArgs) Handles bt_RotateClockwise.Click
        ClsFunc.PhotoRotate(-90)
    End Sub

    Private Sub bt_RotateCounterClockwise_Click(sender As Object, e As EventArgs) Handles bt_RotateCounterClockwise.Click
        ClsFunc.PhotoRotate(90)
    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        ClsFunc.PhotoDelete()
    End Sub

    Private Sub bt_FillContent_Click(sender As Object, e As EventArgs)
        ClsFunc.PhotoFit()
    End Sub

    Private Sub bt_FittoFrame_Click(sender As Object, e As EventArgs) Handles bt_FittoFrame.Click
        ClsFunc.PhotoFit()
    End Sub

    Private Sub btRedo_Click(sender As Object, e As EventArgs) Handles btRedo.Click
        ClsFunc.DocRedo()
    End Sub

    Private Sub btUndo_Click(sender As Object, e As EventArgs) Handles btUndo.Click
        ClsFunc.DocUndo()
    End Sub
End Class