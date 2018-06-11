Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json.Linq

Public Class ClsFileIO
    Dim jhandler As ClsJsonManager
    Dim BaseURL As String = Globals.JsonObj("cgConfig")("BaseURL").ToString
    Dim Tahun As String = Date.Today.Year.ToString
    Dim Bulan As String = Date.Today.Month.ToString
    Dim BulanNama As String
    Dim Tanggal As String = Date.Today.Day.ToString
    'Dim RootDir As Dictionary(Of String, JArray) = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgConfig")("TopDirectory"))
    'Dim FolderTipe As Dictionary(Of String, JArray) = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgConfig")("FolderTipeFile"))
    'Dim FolderDivisi As Dictionary(Of String, JArray) = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgConfig")("FolderDivisi"))
    'Dim FolderJenisOrder As Dictionary(Of String, JArray) = jhandler.ParseJsonToDictionary(Globals.JsonObj("cgConfig")("FolderJenisOrder"))

    Private Function GetEnglishMonth() As String
        Dim monthNames As New List(Of String) From {"", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
        GetEnglishMonth = monthNames(Date.Today.Month)
    End Function

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
            Throw New Exception("Folder " + Path + " tidak bisa diakses.")
        End Try
    End Function

    Public Function BaseURLValid() As Boolean
        Do
            Try
                Directory.Exists(BaseURL)
                Return True
                Exit Do
            Catch ex As Exception
                If MessageBox.Show(ex.Message + Environment.NewLine + "Pastikan foldernya bisa dibuka di Windows Explorer. Coba lagi?", "Kesalahan Akses Datacenter", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) <> DialogResult.Retry Then
                    Return False
                    Exit Do
                End If
            End Try
        Loop
    End Function

    Private Function IsFileLocked(exception As Exception) As Boolean
        'source: StackOverflow.com/questions/11287502/
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
End Class
