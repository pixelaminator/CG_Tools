Imports RGiesecke.DllExport

Public Module Main
    <DllExport("CGSpellCheck")>
    Public Sub CG_SpellCheck()
        Dim frm As New MainForm
        frm.ShowDialog()
    End Sub
End Module
