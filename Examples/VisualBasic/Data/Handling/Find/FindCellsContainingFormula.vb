Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.Handling.Find
    Public Class FindCellsContainingFormula
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

            'Finding the cell containing the specified formula
            Dim cell As Cell = worksheet.Cells.FindFormula("=SUM(A5:A10)", Nothing)

            'Printing the name of the cell found after searching worksheet
            System.Console.WriteLine("Name of the cell containing formula: " & cell.Name)

            'Closing the file stream to free all resources
            fstream.Close()

        End Sub
    End Class
End Namespace