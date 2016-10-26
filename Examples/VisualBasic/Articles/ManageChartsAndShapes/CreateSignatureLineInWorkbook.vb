Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles.ManageChartsAndShapes
    Public Class CreateSignatureLineInWorkbook
        Public Shared Sub Run()
            ' ExStart:CreateSignatureLineInWorkbook
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Insert picture of your choice
            Dim index As Integer = workbook.Worksheets(0).Pictures.Add(0, 0, dataDir & Convert.ToString("signature.jpg"))

            ' Access picture and add signature line inside it
            Dim pic As Picture = workbook.Worksheets(0).Pictures(index)

            ' Create signature line object
            Dim s As New SignatureLine()
            s.Signer = "Simon Zhao"
            s.Title = "Development Lead"
            s.Email = "Simon.Zhao@aspose.com"

            ' Assign the signature line object to Picture.SignatureLine property
            pic.SignatureLine = s

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:CreateSignatureLineInWorkbook
        End Sub
    End Class
End Namespace