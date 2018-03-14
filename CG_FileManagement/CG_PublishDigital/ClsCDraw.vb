Imports System.ComponentModel
Imports Corel.Interop.VGCore

Public Class ClsCDraw
    Public ProgressNumber As Integer = 0
    Public ProgressNumberMax As Integer
    Public PageNumber As Integer = 0
    Public PageNumberMax As Integer = cdraw.ActiveDocument.Pages.Count

    Public Function ConvertText(bw As BackgroundWorker) As Integer
        Dim pg As Page
        Dim shRange As ShapeRange
        Dim sh As Shape

        cdraw.Application.Optimization = True

        cdraw.ActiveDocument.BeginCommandGroup("Convert ke Curve")
        Try
            For Each pg In cdraw.ActiveDocument.Pages
                ProgressNumber = 0
                PageNumber += 1

                pg.Activate()
                'NOTE: This may be implemented in future updates for right now it's kind of unstable (proses convert nya jadi lebih lama)
                'shRange = FindAllPCShapes.Shapes.FindShapes(Query:="@type='text:artistic' or @type='text:paragraph' or @outline[.scalewithobject='false']")
                shRange = FindAllPCShapes.Shapes.FindShapes(Query:="@type='text:artistic' or @type='text:paragraph'")
                shRange.UngroupAll()

                ProgressNumberMax = shRange.Count

                For Each sh In shRange
                    sh.ConvertToCurves()
                    ProgressNumber += 1
                    bw.ReportProgress(CInt((ProgressNumber / ProgressNumberMax) * 100))
                    'sh.Outline.ScaleWithShape = True
                Next sh
            Next pg

            cdraw.ActiveDocument.EndCommandGroup()

            cdraw.Application.Optimization = False
            cdraw.ActiveWindow.Refresh()
            Return 1 'success
        Catch ex As System.Exception
            cdraw.ActiveDocument.EndCommandGroup()
            Return 0 'failed
            Exit Function
        End Try
    End Function

    Private Function FindAllPCShapes(Optional LngLevel As Long = 0) As ShapeRange ' Shelby's function
        Dim S As Shape
        Dim srPowerClipped As New ShapeRange, srJustClipped As New ShapeRange
        Dim sr As ShapeRange, srAll As New ShapeRange
        Dim bFound As Boolean, i&

        bFound = False
        If cdraw.ActiveSelection.Shapes.Count > 0 Then
            sr = cdraw.ActiveSelection.Shapes.FindShapes()
        Else
            sr = cdraw.ActivePage.Shapes.FindShapes()
        End If
        i = 0
        Do
            For Each S In sr.Shapes.FindShapes(Query:="!@com.powerclip.IsNull")
                srPowerClipped.AddRange(S.PowerClip.Shapes.FindShapes())
            Next S
            If srPowerClipped.Count > 0 Then bFound = True : i = i + 1
            If i = LngLevel And bFound Then FindAllPCShapes = srPowerClipped : Exit Function
            bFound = False
            srAll.AddRange(sr)
            sr.RemoveAll()
            sr.AddRange(srPowerClipped)
            If LngLevel = -1 Then srJustClipped.AddRange(srPowerClipped)
            srPowerClipped.RemoveAll()
        Loop Until sr.Count = 0

        If LngLevel = -1 Then
            FindAllPCShapes = srJustClipped
        Else
            FindAllPCShapes = srAll
        End If
    End Function

    Public Function ConvertBitmap(bw As BackgroundWorker) As Integer
        Try
            'Declare Document and Shape Object
            Dim pg As Page
            Dim X As Double
            Dim Y As Double
            Dim w As Double
            Dim h As Double
            Dim sh As Shape

            cdraw.ActiveDocument.BeginCommandGroup("Convert ke Bitmap")

            For Each pg In cdraw.ActiveDocument.Pages
                PageNumber += 1

                pg.Activate()
                pg.GetBoundingBox(X, Y, w, h)
                sh = pg.SelectShapesFromRectangle(X, Y + h, X + w, Y, False)
                If sh.Shapes.Count <> 0 Then
                    sh.ConvertToBitmapEx(cdrImageType.cdrCMYKColorImage, True, True, 300, cdrAntiAliasingType.cdrNormalAntiAliasing, True, True)
                    bw.ReportProgress(CInt((PageNumber / PageNumberMax) * 100))
                Else
                    Return -1 'Return if no data to convert
                    Exit Function
                End If
            Next pg
            cdraw.ActiveDocument.EndCommandGroup()
            Return 1 'Success
            Exit Function
        Catch ex As System.Exception
            cdraw.ActiveDocument.EndCommandGroup()
            Return 0 'Failed
            Exit Function
        End Try
    End Function
End Class
