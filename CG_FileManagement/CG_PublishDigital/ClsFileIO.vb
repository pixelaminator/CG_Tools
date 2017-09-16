Imports System
Imports System.IO
Imports System.Windows

Public Class ClsFileIO
    Dim BaseURL As String = Globals.JsonObj("cgConfig")("BaseURL").ToString
    Dim Tahun As String = Date.Today.Year.ToString
    Dim Bulan As String = Date.Today.Month.ToString
    Dim Tanggal As String = Date.Today.Day.ToString
    Dim FolderTipe() As String = {"CDR", "PDF"}
    Dim FolderDivisi() As String = {"GRAHA"}

    Private Function CreateFolders(ByVal Path As String) As Integer
        Try
            If Directory.Exists(Path) Then
                Return Nothing
            Else
                Directory.CreateDirectory(Path)
                Return 1
            End If
        Catch ex As UnauthorizedAccessException
            Throw New Exception("Kesalahan dalam mengakses folder " + Path)
        Catch ex As DirectoryNotFoundException
            Throw New Exception("Folder tidak ditemukan " + Path)
        End Try
    End Function

    Public Function BaseURLValid() As Boolean
        Try
            CreateFolders(BaseURL)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
End Class
