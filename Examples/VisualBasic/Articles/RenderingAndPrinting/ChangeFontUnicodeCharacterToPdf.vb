
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class ChangeFontUnicodeCharacterToPdf
        Public Shared Sub Run()
            ' ExStart:ChangeFontUnicodeCharacterToPdf
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cells
            Dim cell1 As Cell = worksheet.Cells("A1")
            Dim cell2 As Cell = worksheet.Cells("B1")

            ' Set the styles of both cells to Times New Roman
            Dim style As Style = cell1.GetStyle()
            style.Font.Name = "Times New Roman"
            cell1.SetStyle(style)
            cell2.SetStyle(style)

            ' Put the values inside the cell
            cell1.PutValue("Hello without Non-Breaking Hyphen")
            cell2.PutValue("Hello" + Convert.ToChar(8209) + " with Non-Breaking Hyphen")

            ' Autofit the columns
            worksheet.AutoFitColumns()

            ' Save to Pdf without setting PdfSaveOptions.IsFontSubstitutionCharGranularity
            workbook.Save(dataDir & Convert.ToString("SampleOutput_out.pdf"))

            ' Save to Pdf after setting PdfSaveOptions.IsFontSubstitutionCharGranularity to true
            Dim opts As New PdfSaveOptions()
            opts.IsFontSubstitutionCharGranularity = True
            workbook.Save(dataDir & Convert.ToString("SampleOutput2_out.pdf"), opts)
            ' ExEnd:ChangeFontUnicodeCharacterToPdf
        End Sub
    End Class
End Namespace
