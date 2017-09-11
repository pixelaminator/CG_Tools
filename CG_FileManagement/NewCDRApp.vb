Imports Corel.Interop.VGCore
Public Class NewCDRApp
    Public Shared WithEvents AppDraw As New Corel.Interop.VGCore.Application
    Public Sub New(app As Object)
        appDraw = CType(app, Corel.Interop.VGCore.Application)
    End Sub
End Class
