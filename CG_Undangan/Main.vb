Imports RGiesecke.DllExport
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Module Main
    Public AssemblyLoadError As Boolean

    Sub New()
        'Loads 3rd party assembly from addon folder
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyLoadHandler
    End Sub

    <DllExport("CGUndangan")>
    Public Sub CG_Undangan()
        Dim undangan As New MainForm
        undangan.ShowDialog()
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
                strTempAssmbPath = Application.StartupPath + "\Addons\CG_Tools\bin\" & args.Name.Substring(0, args.Name.IndexOf(",")) & ".dll"

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
End Module


