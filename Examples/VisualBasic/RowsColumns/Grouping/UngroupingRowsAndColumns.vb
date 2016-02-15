Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.RowsColumns.Grouping
    Public Class UngroupingRowsAndColumns
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Ungrouping first six rows (from 0 to 5)
            worksheet.Cells.UngroupRows(0, 5)

            'Ungrouping first three columns (from 0 to 2)
            worksheet.Cells.UngroupColumns(0, 2)

            'Saving the modified Excel file
            workbook.Save(dataDir & "output.out.xls")

            'Closing the file stream to free all resources
            fstream.Close()

        End Sub
    End Class
End Namespace