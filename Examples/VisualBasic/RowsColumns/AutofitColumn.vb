Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.RowsColumns
    Public Class AutofitColumn
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & "Book1.xlsx"

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(InputPath, FileMode.Open)

            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Auto-fitting the Column of the worksheet
            worksheet.AutoFitColumn(4)

            'Saving the modified Excel file
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace
