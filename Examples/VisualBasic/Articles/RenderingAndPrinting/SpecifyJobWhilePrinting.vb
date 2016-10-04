
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class SpecifyJobWhilePrinting
        Public Shared Sub Run()
            'ExStart:1

            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create workbook object from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            'Specify Printer and Job Name
            Dim printerName As String = ""

            While String.IsNullOrEmpty(printerName) AndAlso String.IsNullOrWhiteSpace(printerName)
                Console.WriteLine("Please Enter Your Printer Name:")
                printerName = Console.ReadLine()
            End While

            Dim jobName As String = "Job Name while Printing with Aspose.Cells"

            'Print workbook using WorkbookRender
            Dim wr As New WorkbookRender(workbook, New ImageOrPrintOptions())
            Try
                wr.ToPrinter(printerName, jobName)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            'Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Print worksheet using SheetRender
            Dim sr As New SheetRender(worksheet, New ImageOrPrintOptions())
            Try
                sr.ToPrinter(printerName, jobName)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            'ExEnd:1
        End Sub
    End Class
End Namespace
