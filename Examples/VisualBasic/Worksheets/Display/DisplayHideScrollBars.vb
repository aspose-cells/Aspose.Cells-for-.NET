Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Display
    Public Class DisplayHideScrollBars
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            'Hiding the vertical scroll bar of the Excel file
            workbook.Settings.IsVScrollBarVisible = False

            'Hiding the horizontal scroll bar of the Excel file
            workbook.Settings.IsHScrollBarVisible = False

            'Saving the modified Excel file
            workbook.Save(dataDir & "output.out.xls")

            'Closing the file stream to free all resources
            fstream.Close()
        End Sub
    End Class
End Namespace