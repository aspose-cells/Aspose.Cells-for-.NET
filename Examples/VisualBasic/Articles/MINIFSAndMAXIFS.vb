Namespace Articles
    Public Class MINIFSAndMAXIFS
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source workbook containing MINIFS and MAXIFS functions
            Dim wb As New Workbook(dataDir & Convert.ToString("sample_MINIFS_MAXIFS.xlsx"))

            ' Perform Aspose.Cells formula calculation
            wb.CalculateFormula()

            ' Save the calculations result in pdf format
            Dim opts As New PdfSaveOptions()
            opts.OnePagePerSheet = True
            wb.Save(dataDir & Convert.ToString("output_out.pdf"), opts)
            ' ExEnd:1
        End Sub
    End Class
End Namespace