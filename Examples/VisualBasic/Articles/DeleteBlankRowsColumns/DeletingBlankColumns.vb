Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.DeleteBlankRowsColumns
    Public Class DeletingBlankColumns
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new Workbook.
            'Open an existing excel file.
            Dim wb As New Workbook(dataDir & "SampleInput.xlsx")

            'Create a Worksheets object with reference to
            'the sheets of the Workbook.
            Dim sheets As WorksheetCollection = wb.Worksheets

            'Get first Worksheet from WorksheetCollection
            Dim sheet As Worksheet = sheets(0)

            'Delete the Blank Rows from the worksheet
            sheet.Cells.DeleteBlankRows()

            'Save the excel file.
            wb.Save(dataDir & "output.xlsx")
            'ExEnd:1
        End Sub
    End Class
End Namespace