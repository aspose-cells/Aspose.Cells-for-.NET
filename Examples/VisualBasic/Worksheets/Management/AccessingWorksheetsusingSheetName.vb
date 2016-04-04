Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Worksheets.Management
    Public Class AccessingWorksheetsusingSheetName
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & "book1.xlsx"

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(InputPath, FileMode.Open)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            'Accessing a worksheet using its sheet name
            Dim worksheet As Worksheet = workbook.Worksheets("Sheet1")
            Dim cell As Cell = worksheet.Cells("A1")
            Console.WriteLine(cell.Value)

            'ExEnd:1
        End Sub
    End Class
End Namespace
