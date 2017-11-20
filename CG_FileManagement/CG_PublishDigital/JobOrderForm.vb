Imports System
Imports System.Text
Imports System.Windows.Forms
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Collections.Generic

Public Class JobOrderForm
    Private MainForm As MainForm
    Sub New(publishForm As MainForm)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MainForm = publishForm
    End Sub


    Private Sub ListFieldNames()
        Dim pdfTemplate As String = Application.StartupPath + "\Addons\CG_Tools\TemplateJO.pdf"

        ' create a new PDF reader based on the PDF template document
        Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)

        ' create and populate a string builder with each of the
        ' field names available in the subject PDF
        Dim sb As New StringBuilder()

        Dim de As New KeyValuePair(Of String, AcroFields.Item)
        For Each de In pdfReader.AcroFields.Fields
            sb.Append(de.Key.ToString() + Environment.NewLine)
        Next
    End Sub

    Public Sub FillForm()
        Dim pdfTemplate As String = Application.StartupPath + "\Addons\CG_Tools\res\template_jo.bin"
        Dim newFile As String = Application.StartupPath + "\Addons\CG_Tools\res\GenJO.tmp"

        Dim pdfReader As New PdfReader(pdfTemplate)
        Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))

        Dim pdfFormFields As AcroFields = pdfStamper.AcroFields

        ' set form pdfFormFields

        pdfFormFields.SetField("f_NoInvoice", t_noinvoice.Text)
        pdfFormFields.SetField("f_Customer", MainForm.t_customer.Text)
        pdfFormFields.SetField("f_JenisBahan", MainForm.cb_bahan.Text)
        pdfFormFields.SetField("f_UraianPekerjaan", t_uraianpekerjaan.Text)
        pdfFormFields.SetField("f_JenisPekerjaan", MainForm.cb_jenisorder.Text)
        pdfFormFields.SetField("f_ketsampel", t_ketsampel.Text)
        pdfFormFields.SetField("f_QtyOrder", MainForm.n_qtycetak.Value.ToString + " " + MainForm.t_satuanqty.Text)
        pdfFormFields.SetField("f_NamaFile", MainForm.t_preview.Text)
        pdfFormFields.SetField("f_OperatorSetting", MainForm.cb_operator.Text)
        pdfFormFields.SetField("f_TglMasuk", dt_TglMasuk.Value.ToString("dd/MM/yyyy"))
        pdfFormFields.SetField("f_TglSelesai", dt_TglSelesai.Value.ToString("dd/MM/yyyy"))
        pdfFormFields.SetField("f_PukulSelesai", dt_pukul.Value.ToString("HH:mm"))


        ' report by reading values from completed PDF
        'Dim sTmp As String = "W-4 Completed for " +
        'pdfFormFields.GetField("f1_09(0)") + " " +
        'pdfFormFields.GetField("f1_10(0)")
        'MessageBox.Show("Finished")

        ' flatten the form to remove editting options, set it to false
        ' to leave the form open to subsequent manual edits
        pdfStamper.FormFlattening = True

        ' close the pdf
        pdfStamper.Close()
    End Sub

    Private Sub bt_preview_Click(sender As Object, e As EventArgs) Handles bt_preview.Click
        PdfViewer1.Document?.Dispose()
        FillForm()
        PdfViewer1.Document = PdfiumViewer.PdfDocument.Load(Application.StartupPath + "\Addons\CG_Tools\res\GenJO.tmp")
    End Sub

    Private Sub Form_Close() Handles Me.FormClosing
        PdfViewer1.Document?.Dispose()
    End Sub
End Class