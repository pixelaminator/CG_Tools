Public Class StartForm
    Private WithEvents publish As New MainForm()
    Private Sub FileCustomer_Click(sender As Object, e As System.EventArgs) Handles Bt_FileCustomer.Click
        Close()
    End Sub

    Private Sub Bt_FileSetting_Click(sender As Object, e As System.EventArgs) Handles Bt_FileSetting.Click
        Close()
    End Sub
End Class