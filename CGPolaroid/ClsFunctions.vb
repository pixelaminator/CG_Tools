Imports vgApp = Corel.Interop.VGCore
Imports Doc = Corel.Interop.VGCore.Document
Imports Corel.Interop.VGCore
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections

Public Class ClsFunctions
    Dim lastAppliedIndex As Integer
    Dim CurrPageIndex As Integer
    Dim TotalPages As Integer
    Dim TotalFiles As Integer
    Dim MaxFiles As Integer = 500
    Dim ProcessedFiles As Integer
    Const TotalTiles As Integer = 24 'change this when dynamic generator implemented
    Dim TilesCountInAPage As Integer
    Public ProgressNumber As Integer = 0
    Public ProgressNumberMax As Integer
    Public ProgressMessage As String
    Public ProgressAllFiles As Integer
    Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.cdraw

    Public Sub InitPolaroid(folderPath As String, setborder As Boolean, bworker As BackgroundWorker)
        cdraw.CreateDocument()

        cdraw.ActiveDocument.ReferencePoint = cdrReferencePoint.cdrCenter
        cdraw.ActiveDocument.Unit = cdrUnit.cdrMillimeter

        Dim files() As String
        files = getFiles(folderPath, "*.gif|*.jpg|*.jpeg|*.png|*.bmp", SearchOption.TopDirectoryOnly)

        TotalFiles = files.Length
        CurrPageIndex = 1
        ProcessedFiles = 0

        If TotalFiles <= TotalTiles + 1 Then
            TilesCountInAPage = TotalFiles
            ProgressNumberMax = TotalFiles
        Else
            ProgressNumberMax = TotalTiles + 1
            TilesCountInAPage = TotalTiles + 1
        End If

        If TotalFiles > MaxFiles Then
            MessageBox.Show("Maksimal jumlah foto yang bisa disusun dalam satu file adalah " & MaxFiles.ToString & " foto." + Environment.NewLine + "Jumlah foto yang ada di dalam folder yang dipilih: " & files.Length.ToString & " foto.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        TotalPages = CInt(Math.Ceiling(files.Length / (TotalTiles + 1)))

        Dim i As Integer
        Dim index As Integer
        index = 0
        For i = 1 To TotalPages
            If bworker.CancellationPending <> True Then
                DoPolaroid(files, index, setborder, bworker)
                If bworker.CancellationPending <> True AndAlso cdraw.ActiveDocument.Pages.Count < TotalPages Then
                    cdraw.ActiveDocument.AddPages(1)
                    CurrPageIndex += 1
                    index = lastAppliedIndex
                    If TotalFiles - ProcessedFiles < TotalTiles Then
                        TilesCountInAPage = TotalFiles - ProcessedFiles
                        ProgressNumberMax = TilesCountInAPage
                    End If
                End If
            Else
                Exit For
            End If
        Next

        cdraw.Application.Optimization = False
        cdraw.Application.EventsEnabled = True
        cdraw.Application.Refresh()
    End Sub

    Sub DoPolaroid(files() As String, startIndex As Integer, setborder As Boolean, bw As BackgroundWorker)
        Dim XMaxTile As Integer
        Dim currTile, prevTile As Integer
        Dim photo As Shape

        XMaxTile = 5
        currTile = 1
        prevTile = 0

        cdraw.Application.Optimization = True
        cdraw.Application.EventsEnabled = False
        cdraw.ActiveDocument.ReferencePoint = cdrReferencePoint.cdrCenter
        cdraw.ActiveDocument.Unit = cdrUnit.cdrMillimeter

        cdraw.ActivePage.SetSize(330, 483)

        Dim boxes As IList(Of ShapeRange) = New List(Of ShapeRange)()
        Dim i As Integer

        ProgressNumber = 0

        For i = 0 To TotalTiles
            If bw.CancellationPending <> True AndAlso startIndex < files.Length Then
                AddProgress(bw, "Membuat bingkai " & i + 1 & "/" & TilesCountInAPage & " (Page " & CurrPageIndex & "/" & TotalPages & ")")
                boxes.Add(CreatePolaroidBox(setborder))
                photo = getImportImage(files(startIndex))
                If photo.SizeWidth > photo.SizeHeight Then
                    photo.Rotate(90)
                End If
                ScaleImage(photo, 70, 50)
                photo.AddToPowerClip(boxes(i).Item(2), cdrTriState.cdrTrue)
                If i > 0 Then
                    If currTile <> XMaxTile Then
                        boxes(currTile).PositionX = boxes(prevTile).PositionX + boxes(prevTile).SizeWidth
                        boxes(currTile).PositionY = boxes(prevTile).PositionY
                        currTile = currTile + 1
                        prevTile = prevTile + 1
                    Else
                        boxes(currTile).PositionY = boxes(currTile - 4).PositionY - boxes(currTile - 4).SizeHeight
                        currTile = currTile + 1
                        prevTile = prevTile + 1
                        XMaxTile = XMaxTile + 5
                    End If
                End If
                startIndex += 1
            Else
                Exit For
            End If
        Next

        ProgressNumber = 0

        cdraw.ActivePage.Shapes.All.CreateSelection()
        cdraw.ActiveSelection.Group()
        cdraw.ActiveSelection.Move(15, -16.5)
        cdraw.ActiveSelection.Ungroup()

        lastAppliedIndex = startIndex
    End Sub

    Sub AddProgress(bw As BackgroundWorker, msg As String)
        ProgressNumber += 1
        ProcessedFiles += 1
        bw.ReportProgress(CInt((ProgressNumber / ProgressNumberMax) * 100))
        ProgressMessage = msg
        ProgressAllFiles = CInt((ProcessedFiles / TotalFiles) * 100)
    End Sub

    Function CreatePolaroidBox(setborder As Boolean) As ShapeRange
        Dim shRange As New ShapeRange

        cdraw.ActiveDocument.DrawingOriginX = -cdraw.ActivePage.SizeWidth / 2
        cdraw.ActiveDocument.DrawingOriginY = cdraw.ActivePage.SizeHeight / 2

        Dim border As Shape
        border = cdraw.ActiveLayer.CreateRectangle(0#, 0#, 60, -90)
        border.Fill.ApplyNoFill()
        If setborder = False Then border.Outline.SetNoOutline()

        Dim photoFrame As Shape
        photoFrame = cdraw.ActiveLayer.CreateRectangle(0#, 0#, 50, -70)
        photoFrame.Fill.ApplyNoFill()
        photoFrame.Outline.SetNoOutline()
        photoFrame.Move(5, -5)

        Dim s3 As Shape
        s3 = cdraw.ActiveLayer.CreateRectangle(0#, 1, 1, 0#)
        s3.AddToPowerClip(photoFrame, cdrTriState.cdrTrue)
        s3.RemoveFromContainer()
        s3.Delete()

        shRange.Add(border)
        shRange.Add(photoFrame)

        CreatePolaroidBox = shRange
    End Function

    Private Sub ScaleImage(ByVal OldImage As Shape, TargetHeight As Integer, ByVal TargetWidth As Integer)
        Dim NewWidth As Integer
        NewWidth = TargetWidth

        Dim NewHeight As Integer
        NewHeight = CInt(NewWidth / OldImage.SizeWidth * OldImage.SizeHeight)

        If NewHeight < TargetHeight Then
            NewHeight = TargetHeight
            NewWidth = CInt(NewHeight / OldImage.SizeHeight * OldImage.SizeWidth)
        End If

        OldImage.SetSize(NewWidth, NewHeight)
    End Sub

    Private Function getImportImage(ByVal lokasiImage As String) As Shape
        Dim impopt As StructImportOptions
        Dim impflt As ImportFilter
        Dim p As Shape

        impopt = cdraw.CreateStructImportOptions
        With impopt
            .Mode = cdrImportMode.cdrImportFull
            .MaintainLayers = True
        End With
        On Error Resume Next
        impflt = cdraw.ActiveLayer.ImportEx(lokasiImage, cdrFilter.cdrAutoSense, impopt)
        impflt.Finish()

        p = cdraw.ActiveDocument.ActiveShape
        getImportImage = p
    End Function

    Private Function FindAllPCShapes(Optional LngLevel As Long = 0) As ShapeRange ' Shelby's function
        Dim S As Shape
        Dim srPowerClipped As New ShapeRange, srJustClipped As New ShapeRange
        Dim sr As ShapeRange, srAll As New ShapeRange
        Dim bFound As Boolean, i&

        bFound = False
        sr = cdraw.ActiveSelection.Shapes.FindShapes()
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

    Private Function GetPowerclipPhoto() As Shape
        Dim shRange As ShapeRange
        shRange = FindAllPCShapes.Shapes.FindShapes(, cdrShapeType.cdrBitmapShape)

        If shRange.Count <> 0 Then
            GetPowerclipPhoto = shRange.Item(1)
        Else
            Return Nothing
        End If
    End Function

    Public Sub PhotoRotate(Angle As Integer)
        If cdraw.Documents.Count = 0 Then Exit Sub

        cdraw.Application.Optimization = True

        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim shRange As ShapeRange
            Dim S As Shape

            shRange = cdraw.ActiveSelectionRange

            For Each S In shRange
                S.CreateSelection()
                Dim photo As Shape
                photo = GetPowerclipPhoto()
                If photo IsNot Nothing Then photo.Rotate(Angle)
            Next
            shRange.CreateSelection()
            cdraw.Application.Optimization = False
            cdraw.Application.Refresh()
        End If
    End Sub

    Public Sub PhotoDelete()
        If cdraw.Documents.Count = 0 Then Exit Sub

        cdraw.Application.Optimization = True

        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim shRange As ShapeRange
            Dim S As Shape

            shRange = cdraw.ActiveSelectionRange

            For Each S In shRange
                S.CreateSelection()
                Dim photo As Shape
                photo = GetPowerclipPhoto()
                If photo IsNot Nothing Then photo.Delete()
            Next
            shRange.CreateSelection()
            cdraw.Application.Optimization = False
            cdraw.Application.Refresh()
        End If
    End Sub

    Public Sub PhotoFit()
        If cdraw.Documents.Count = 0 Then Exit Sub

        cdraw.Application.Optimization = True
        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim shRange As ShapeRange
            Dim S As Shape

            shRange = cdraw.ActiveSelectionRange

            For Each S In shRange
                S.CreateSelection()
                Dim photo As Shape
                photo = GetPowerclipPhoto()
                If photo IsNot Nothing Then ScaleImage(photo, 70, 50)
            Next
            shRange.CreateSelection()
            cdraw.Application.Optimization = False
            cdraw.Application.Refresh()
        End If
    End Sub

    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String,
     ByVal searchOption As System.IO.SearchOption) As String()
        ' ArrayList will hold all file names
        Dim alFiles As ArrayList = New ArrayList()

        ' Create an array of filter string
        Dim MultipleFilters() As String = Filter.Split(CType("|", Char()))

        ' for each filter find mathing file names
        For Each FileFilter As String In MultipleFilters
            ' add found file names to array list
            alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        ' returns string array of relevant file names
        Return CType(alFiles.ToArray(Type.GetType("System.String")), String())
    End Function

    Public Function CountPhotosInADirectory(ByVal folderPath As String) As Integer
        Dim files() As String
        files = getFiles(folderPath, "*.gif|*.jpg|*.jpeg|*.png|*.bmp", SearchOption.TopDirectoryOnly)
        CountPhotosInADirectory = files.Length
    End Function
End Class
