Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class LoadWorkbookWithPrinterSize
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a sample workbook and add some data inside the first worksheet
            Dim workbook As New Workbook()
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            worksheet.Cells("P30").PutValue("This is sample data.")

            ' Save the workbook in memory stream
            Dim ms As New MemoryStream()
            workbook.Save(ms, SaveFormat.Xlsx)
            ms.Position = 0

            ' Now load the workbook from memory stream with A5 paper size
            Dim opts As New LoadOptions(LoadFormat.Xlsx)
            opts.SetPaperSize(PaperSizeType.PaperA5)
            workbook = New Workbook(ms, opts)

            ' Save the workbook in pdf format
            workbook.Save(dataDir + "LoadWorkbookWithPrinterSize-a5_out_.pdf")

            ' Now load the workbook again from memory stream with A3 paper size
            ms.Position = 0
            opts = New LoadOptions(LoadFormat.Xlsx)
            opts.SetPaperSize(PaperSizeType.PaperA3)
            workbook = New Workbook(ms, opts)

            ' Save the workbook in pdf format
            workbook.Save(dataDir & Convert.ToString("LoadWorkbookWithPrinterSize-a3_out_.pdf"))
            ' ExEnd:1          
        End Sub
    End Class
End Namespace
