Imports System.Collections
Imports Corel.Interop.VGCore
Imports i00SpellCheck

Public Class MainForm
    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        'Dim iSpellCheckDialog = TryCast(TextBox1.SpellCheck, i00SpellCheck.SpellCheckControlBase.iSpellCheckDialog)
        'If iSpellCheckDialog IsNot Nothing Then
        '    iSpellCheckDialog.ShowDialog()
        'End If
        CollectTexts()
    End Sub

    Private Sub CollectTexts()
        Dim p As Page, s As Shape, sr As ShapeRange
        Dim i As Integer
        Dim ht As New Hashtable

        i = cdraw.ActivePage.Index
        For Each p In cdraw.ActiveDocument.Pages
            p.Activate()
            sr = cdraw.ActivePage.Shapes.FindShapes(Query:="@type = 'text:artistic' or @type = 'text:paragraph'")
            For Each s In sr
                If ht.ContainsKey(s.StaticID) = False Then
                    ht.Add(s.StaticID, s.Text.Story.Text)
                End If
            Next s
        Next p
        cdraw.ActiveDocument.Pages(i).Activate()
    End Sub
End Class