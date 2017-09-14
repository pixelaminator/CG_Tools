Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports i00SpellCheck

Public Class MainForm
    Dim AssemblyLoadError As Boolean
    Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        'Loads 3rd party assembly from addon folder
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyLoadHandler
    End Sub

    Function AssemblyLoadHandler(ByVal sender As Object,
                       ByVal args As ResolveEventArgs) As [Assembly]
        'This handler is called only when the common language runtime tries to bind to the assembly and fails.        

        'Retrieve the list of referenced assemblies in an array of AssemblyName.
        Dim objExecutingAssemblies As [Assembly]
        objExecutingAssemblies = [Assembly].GetExecutingAssembly()
        Dim arrReferencedAssmbNames() As AssemblyName
        arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies()

        'Loop through the array of referenced assembly names.
        Dim strAssmbName As AssemblyName
        For Each strAssmbName In arrReferencedAssmbNames
            Dim MyAssembly As [Assembly]
            'Look for the assembly names that have raised the "AssemblyResolve" event.
            If (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) = args.Name.Substring(0, args.Name.IndexOf(","))) Then

                'Build the path of the assembly from where it has to be loaded.
                Dim strTempAssmbPath As String
                strTempAssmbPath = Application.StartupPath + "\Addons\CG_Tools\" & args.Name.Substring(0, args.Name.IndexOf(",")) & ".dll"

                'Load the assembly from the specified path. 
                Try
                    MyAssembly = [Assembly].LoadFrom(strTempAssmbPath)
                    'Return the loaded assembly.
                    Return MyAssembly
                Catch ex As Exception
                    AssemblyLoadError = True
                    Exit Function
                End Try
            End If
        Next
    End Function
    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim iSpellCheckDialog = TryCast(TextBox1.SpellCheck, i00SpellCheck.SpellCheckControlBase.iSpellCheckDialog)
        If iSpellCheckDialog IsNot Nothing Then
            iSpellCheckDialog.ShowDialog()
        End If
    End Sub
End Class