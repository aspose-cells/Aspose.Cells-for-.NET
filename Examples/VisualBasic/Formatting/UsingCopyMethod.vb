Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Formatting
    Public Class UsingCopyMethod
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "Book1.xlsx", FileMode.Open)

            ' Instantiating a Workbook object
            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Copying conditional format settings from cell "A1" to cell "B1"
            ' worksheet.CopyConditionalFormatting(0, 0, 0, 1)

            Dim TotalRowCount As Integer = 0

            For i As Integer = 0 To workbook.Worksheets.Count - 1
                Dim sourceSheet As Worksheet = workbook.Worksheets(i)

                Dim sourceRange As Range = sourceSheet.Cells.MaxDisplayRange

                Dim destRange As Range = worksheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn, sourceRange.RowCount, sourceRange.ColumnCount)

                destRange.Copy(sourceRange)

                TotalRowCount = sourceRange.RowCount + TotalRowCount
            Next

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")

            ' Closing the file stream to free all resources
            fstream.Close()

            ' ExEnd:1
        End Sub
    End Class
End Namespace
