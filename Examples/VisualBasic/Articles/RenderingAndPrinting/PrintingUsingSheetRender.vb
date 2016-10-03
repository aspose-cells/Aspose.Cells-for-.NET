
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class PrintingUsingSheetRender
        Public Shared Sub Run()
            ' ExStart:1
            'Assign your printer name to variable "strPrinterName" and uncomment The Method: sr.ToPrinter(strPrinterName) in the last line 
            Dim strPrinterName As String = "{Replace_With_Printer_Name}"

            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a workbook.
            'Open an Excel file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            'Define a worksheet.
            Dim worksheet As Worksheet

            'Get the second sheet.
            worksheet = workbook.Worksheets(1)

            'Apply different Image / Print options.
            Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            options.PrintingPage = PrintingPageType.[Default]
            Dim sr As New SheetRender(worksheet, options)

            Console.WriteLine("Printing SampleBook.xlsx")
            'Print the sheet.
            'sr.ToPrinter(strPrinterName);
            Console.WriteLine("Pinting finished.")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
