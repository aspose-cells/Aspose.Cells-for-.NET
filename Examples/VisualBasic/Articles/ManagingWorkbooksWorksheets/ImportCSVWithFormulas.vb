Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ImportCSVWithFormulas
        Public Shared Sub Run()
            ' ExStart:ImportCSVWithFormulas
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim opts As New TxtLoadOptions()
            opts.Separator = ","c
            opts.HasFormula = True

            ' Load your CSV file with formulas in a Workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.csv"), opts)

            ' You can also import your CSV file like this
            ' The code below is importing CSV file starting from cell D4
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            worksheet.Cells.ImportCSV(dataDir & Convert.ToString("sample.csv"), opts, 3, 3)

            ' Save your workbook in Xlsx format
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:ImportCSVWithFormulas
        End Sub
    End Class
End Namespace