Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Display
    Public Class DisplayHideGridlines
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Hiding the grid lines of the first worksheet of the Excel file
            worksheet.IsGridlinesVisible = False

            'Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")

            'Closing the file stream to free all resources
            fstream.Close()
            'ExEnd:1

        End Sub
    End Class
End Namespace