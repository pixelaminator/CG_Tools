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

    Public Sub FillForm()
        Dim pdfTemplate As String = Application.StartupPath + "\Addons\CG_Tools\res\template_jo.bin"
        Dim newFile As String = Application.StartupPath + "\Addons\CG_Tools\res\GenJO.tmp"

        Try

        Catch ex As Exception
            MessageBox.Show("template_jo.bin tidak ditemukan. Mohon install ulang CG Tools.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

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

        ' flatten the form to remove editting options, set it to false
        ' to leave the form open to subsequent manual edits
        pdfStamper.FormFlattening = True
        pdfStamper.AcroFields.GenerateAppearances = True

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