Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class StartForm
    Private Panels As New List(Of Panel)
    Private VisiblePanel As Panel = Nothing

    Private Sub CGUndangan_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        tb_Data.Visible = False
        For Each page As TabPage In tb_Data.TabPages
            Dim panel As Panel = TryCast(page.Controls(0), Panel)
            Panels.Add(panel)

            panel.Parent = tb_Data.Parent
            panel.Location = tb_Data.Location
            panel.Visible = False
        Next
    End Sub

    Private Sub tv_listData_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tv_listData.AfterSelect
        Dim index As Integer = Integer.Parse(e.Node.Tag.ToString)
        'If index <> Nothing Then
        DisplayPanel(index)
        'End If
    End Sub

    Private Sub DisplayPanel(index As Integer)
        If Panels.Count < 1 Then Return
        'If VisiblePanel = Panels(index) Then Return
        If VisiblePanel IsNot Nothing Then VisiblePanel.Visible = False
        Panels(index).Visible = True
        VisiblePanel = Panels(index)
    End Sub
End Class