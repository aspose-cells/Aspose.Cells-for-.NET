Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace RowsColumns.Hiding
    Public Class HidingRowsAndColumns
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

            ' Hiding the 3rd row of the worksheet
            worksheet.Cells.HideRow(2)

            ' Hiding the 2nd column of the worksheet
            worksheet.Cells.HideColumn(1)

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")

            ' Closing the file stream to free all resources
            fstream.Close()
            ' ExEnd:1


        End Sub
    End Class
End Namespace