
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class PrintingRangeOfPages
        Public Shared Sub Run()
            'ExStart:1

            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            'Printer name
            Dim printerName As String = ""

            While String.IsNullOrEmpty(printerName) AndAlso String.IsNullOrWhiteSpace(printerName)
                Console.WriteLine("Please Enter Your Printer Name:")
                printerName = Console.ReadLine()
            End While

            'Print the worbook specifying the range of pages
            'Here we are printing pages 2-3
            Dim wr As New WorkbookRender(workbook, New ImageOrPrintOptions())
            Try
                wr.ToPrinter(printerName, 1, 2)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            'Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Print the worksheet specifying the range of pages
            'Here we are printing pages 2-3
            Dim sr As New SheetRender(worksheet, New ImageOrPrintOptions())
            Try
                sr.ToPrinter(printerName, 1, 2)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            'ExEnd:1
        End Sub
    End Class
End Namespace
