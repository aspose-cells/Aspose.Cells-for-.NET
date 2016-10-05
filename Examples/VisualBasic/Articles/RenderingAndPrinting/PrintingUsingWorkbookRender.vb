
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class PrintingUsingWorkbookRender
        Public Shared Sub Run()
            ' ExStart:PrintingUsingWorkbookRender
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a workbook with an Excel file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            Dim printerName As String = ""

            While String.IsNullOrEmpty(printerName) AndAlso String.IsNullOrWhiteSpace(printerName)
                Console.WriteLine("Please Enter Your Printer Name:")
                printerName = Console.ReadLine()
            End While

            ' Apply different Image/Print options.
            Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff
            options.PrintingPage = PrintingPageType.[Default]

            ' To print a whole workbook, iterate through the sheets and print them, or use the WorkbookRender class.
            Dim wr As New WorkbookRender(workbook, options)

            Console.WriteLine("Printing SampleBook.xlsx")
            ' Print the workbook.
            wr.ToPrinter(printerName)
            Console.WriteLine("Pinting finished.")
            ' ExEnd:PrintingUsingWorkbookRender
        End Sub
    End Class
End Namespace
