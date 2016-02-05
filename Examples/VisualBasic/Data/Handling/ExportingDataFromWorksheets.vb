Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace Aspose.Cells.Examples.Data.Handling
    Public Class ExportingDataFromWorksheets
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

            'Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            Dim dataTable As DataTable = worksheet.Cells.ExportDataTable(0, 0, 7, 2, True)

            System.Console.WriteLine("Number of Rows in Data Table: " & dataTable.Rows.Count)

            'Closing the file stream to free all resources
            fstream.Close()

        End Sub
    End Class
End Namespace