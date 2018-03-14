Public Class StartForm
    '1 = File dari Konsumen
    '2 = File Setting CG

    Private Sub FileCustomer_Click(sender As Object, e As System.EventArgs) Handles Bt_FileCustomer.Click
        Globals.SaveOption = 1
        Close()
    End Sub

    Private Sub Bt_FileSetting_Click(sender As Object, e As System.EventArgs)
        Globals.SaveOption = 2
        Close()
    End Sub
End Class