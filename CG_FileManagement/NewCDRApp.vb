Imports Corel.Interop.VGCore
Imports Microsoft.VisualBasic.Interaction
Public Module CDRApp
    Public WithEvents cdraw As Corel.Interop.VGCore.Application
    'Public Sub New(app As Object)
    '    appDraw = CType(app, Corel.Interop.VGCore.Application)
    'End Sub
    Sub New()
        If cdraw Is Nothing Then
#If X7 Then
            cdraw = CType(CreateObject("CorelDRAW.Application.17"), Application)
#ElseIf X8 Then
            cdraw = CType(CreateObject("CorelDRAW.Application.18"), Application)
#ElseIf X9 Then
            cdraw = CType(CreateObject("CorelDRAW.Application.19"), Application)
#End If
        End If
    End Sub
End Module
