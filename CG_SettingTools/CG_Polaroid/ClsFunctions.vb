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
    Dim WithEvents cdraw As Corel.Interop.VGCore.Application = NewCDRApp.cdraw
    Dim lastAppliedIndex As Integer
    Dim CurrPageIndex As Integer = 1
    Dim TotalPages As Integer
    Dim MaxFiles As Integer = 500
    Const TotalTiles As Integer = 14
    Public ProgressNumber As Integer = 0
    Public ProgressNumberMax As Integer
    Public ProgressMessage As String

    Public Sub InitPolaroid(folderPath As String, bworker As BackgroundWorker)
        cdraw.ActiveDocument.ReferencePoint = cdrReferencePoint.cdrCenter
        cdraw.ActiveDocument.Unit = cdrUnit.cdrMillimeter

        Dim files() As String
        files = getFiles(folderPath, "*.gif|*.jpg|*.jpeg|*.png|*.bmp", SearchOption.TopDirectoryOnly)

        If files.Length > MaxFiles Then
            MessageBox.Show("Maksimal jumlah foto yang bisa disusun dalam satu file adalah " & MaxFiles.ToString & " foto." + Environment.NewLine + "Jumlah foto yang ada di dalam folder yang dipilih: " & files.Length.ToString & " foto.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        TotalPages = CInt(Math.Ceiling(files.Length / TotalTiles))

        Dim i As Integer
        Dim index As Integer
        index = 0
        For i = 1 To TotalPages
            If bworker.CancellationPending <> True Then
                DoPolaroid(files, index, bworker)
                If bworker.CancellationPending <> True AndAlso cdraw.ActiveDocument.Pages.Count < TotalPages Then
                    cdraw.ActiveDocument.AddPages(1)
                    CurrPageIndex += 1
                    index = lastAppliedIndex
                End If
            Else
                Exit For
            End If
        Next

        cdraw.Application.Optimization = False
        cdraw.Application.EventsEnabled = True
        cdraw.Application.Refresh()
    End Sub

    Sub DoPolaroid(files() As String, startIndex As Integer, bw As BackgroundWorker)
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

        cdraw.ActivePage.SetSize(483, 330)

        Dim boxes As IList(Of ShapeRange) = New List(Of ShapeRange)()
        Dim i As Integer
        ProgressNumber = 0
        ProgressNumberMax = TotalTiles + 1

        For i = 0 To TotalTiles
            If bw.CancellationPending <> True AndAlso startIndex < files.Length Then
                AddProgress(bw, "Membuat bingkai " & i + 1 & "/" & TotalTiles + 1 & " (Page " & CurrPageIndex & "/" & TotalPages & ")")
                boxes.Add(CreatePolaroidBox)
                photo = getImportImage(files(startIndex))
                'If photo.SizeWidth > photo.SizeHeight Then
                'photo.Rotate(90)
                'End If
                ScaleImage(photo, 80, 80)
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
        bw.ReportProgress(CInt((ProgressNumber / ProgressNumberMax) * 100))
        ProgressMessage = msg
    End Sub

    Function CreatePolaroidBox() As ShapeRange
        Dim shRange As New ShapeRange

        cdraw.ActiveDocument.DrawingOriginX = -cdraw.ActivePage.SizeWidth / 2
        cdraw.ActiveDocument.DrawingOriginY = cdraw.ActivePage.SizeHeight / 2

        Dim border As Shape
        border = cdraw.ActiveLayer.CreateRectangle(0#, 0#, 90, -90)
        border.Fill.ApplyNoFill()
        border.Outline.SetNoOutline()

        Dim photoFrame As Shape
        photoFrame = cdraw.ActiveLayer.CreateRectangle(0#, 0#, 80, -80)
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

        GetPowerclipPhoto = shRange.Item(1)
    End Function

    Public Sub PhotoRotate(Angle As Integer)
        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim sh As Shape
            sh = GetPowerclipPhoto()

            sh.Rotate(Angle)
        End If
    End Sub

    Public Sub PhotoDelete()
        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim sh As Shape
            sh = GetPowerclipPhoto()

            sh.Delete()
        End If
    End Sub

    Public Sub PhotoFit()
        If cdraw.ActiveSelection.Shapes.Count = 0 Then
            MessageBox.Show("Mohon pilih salah satu foto.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            Dim sh As Shape
            sh = GetPowerclipPhoto()

            ScaleImage(sh, 70, 50)
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

    Public Sub DocUndo()
        cdraw.ActiveDocument.Undo()
    End Sub

    Public Sub DocRedo()
        cdraw.ActiveDocument.Redo()
    End Sub
End Class
