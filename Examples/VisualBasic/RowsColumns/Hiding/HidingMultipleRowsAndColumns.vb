Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace RowsColumns.Hiding
    Public Class HidingMultipleRowsAndColumns
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            ' Instantiating a Workbook object
            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Hiding 3,4 and 5 rows in the worksheet
            worksheet.Cells.HideRows(2, 3)

            ' Hiding 2 and 3 columns in the worksheet
            worksheet.Cells.HideColumns(1, 2)

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")

            ' Closing the file stream to free all resources
            fstream.Close()
            ' ExEnd:1

        End Sub
    End Class
End Namespace