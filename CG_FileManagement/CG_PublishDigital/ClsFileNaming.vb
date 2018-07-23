Imports System.Linq

Public Class ClsFileNaming
    Private NamaFile() As String

    Public NamaCustomer As String = ""
    Public Tanggal As String = Date.Today.Year.ToString + Date.Today.Month.ToString + Date.Today.Day.ToString
    Public JudulFile As String = ""
    Public NamaSetter As String = ""
    Public NoOrder As String = ""
    Public JenisOrder As String = ""
    Public Bahan As String = ""
    Public Harga As String = ""
    Public JmlPageQty As String = ""
    Public SisiMuka As String = ""
    Public TypeImposition As String = ""
    Public LayoutSize As String = ""
    Public KodeFinishing As String = "NF"

    Public Function DoFileName() As String
        ReDim NamaFile(13)

        If KodeFinishing = "" Then KodeFinishing = "NF"

        NamaFile(0) = NamaSetter
        NamaFile(1) = Tanggal
        NamaFile(2) = NoOrder
        NamaFile(3) = NamaCustomer
        NamaFile(4) = JenisOrder
        NamaFile(5) = JudulFile
        NamaFile(6) = Bahan
        NamaFile(7) = JmlPageQty
        NamaFile(8) = SisiMuka
        NamaFile(9) = LayoutSize
        NamaFile(10) = TypeImposition
        NamaFile(11) = KodeFinishing
        NamaFile(12) = Harga

        'LINQ syntax to filter out empty elements from array
        Dim FilteredNamaFile = From ar In NamaFile Where ar <> "" Select ar
        Dim result As String = String.Join("_", FilteredNamaFile.ToArray)
        Return result
    End Function
End Class
