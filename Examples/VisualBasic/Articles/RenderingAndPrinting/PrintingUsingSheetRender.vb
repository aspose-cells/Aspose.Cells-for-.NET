
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class PrintingUsingSheetRender
        Public Shared Sub Run()
            ' ExStart:PrintingExcelUsingSheetRender
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a workbook with an Excel file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            Dim printerName As String = ""

            While String.IsNullOrEmpty(printerName) AndAlso String.IsNullOrWhiteSpace(printerName)
                Console.WriteLine("Please Enter Your Printer Name:")
                printerName = Console.ReadLine()
            End While

            ' Define a worksheet.
            Dim worksheet As Worksheet

            ' Get the second sheet.
            worksheet = workbook.Worksheets(1)

            ' Apply different Image/Print options.
            Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            options.PrintingPage = PrintingPageType.[Default]
            Dim sr As New SheetRender(worksheet, options)

            Console.WriteLine("Printing SampleBook.xlsx")
            ' Print the sheet.
            sr.ToPrinter(printerName)
            Console.WriteLine("Pinting finished.")
            ' ExEnd:PrintingExcelUsingSheetRender
        End Sub
    End Class
End Namespace
