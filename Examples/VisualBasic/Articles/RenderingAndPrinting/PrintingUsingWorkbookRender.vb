
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class PrintingUsingWorkbookRender
        Public Shared Sub Run()
            'ExStart:1
            'Assign your printer name to variable "strPrinterName" and uncomment The Method: sr.ToPrinter(strPrinterName) in the last line 
            Dim strPrinterName As String = "{Replace_With_Printer_Name}"

            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a workbook.
            'Open an Excel file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            'Apply different Image / Print options.
            Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff
            options.PrintingPage = PrintingPageType.[Default]

            'To print a whole workbook, iterate through the sheets and print them, or use the WorkbookRender class.
            Dim wr As New WorkbookRender(workbook, options)

            Console.WriteLine("Printing SampleBook.xlsx")
            'Print the workbook.
            'wr.ToPrinter(strPrinterName);
            Console.WriteLine("Pinting finished.")
            'ExEnd:1
        End Sub
    End Class
End Namespace
