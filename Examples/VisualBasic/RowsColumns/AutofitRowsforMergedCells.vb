Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.RowsColumns
    Public Class AutofitRowsforMergedCells
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & "Book1.xlsx"
            'Instantiate a new Workbook
            Dim wb As New Workbook()
            'Get the first (default) worksheet
            Dim _worksheet As Worksheet = wb.Worksheets(0)
            'Create a range A1:B1
            Dim range As Range = _worksheet.Cells.CreateRange(0, 0, 1, 2)
            'Merge the cells
            range.Merge()
            'Insert value to the merged cell A1
            _worksheet.Cells(0, 0).Value = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog....end"
            'Create a style object
            Dim style As Aspose.Cells.Style = _worksheet.Cells(0, 0).GetStyle()
            'Set wrapping text on
            style.IsTextWrapped = True
            'Apply the style to the cell
            _worksheet.Cells(0, 0).SetStyle(style)

            'Create an object for AutoFitterOptions
            Dim options As New AutoFitterOptions()
            'Set auto-fit for merged cells
            options.AutoFitMergedCells = True

            'Autofit rows in the sheet(including the merged cells)
            _worksheet.AutoFitRows(options)

            'Save the Excel file
            wb.Save(dataDir & "output.xlsx")


            'ExEnd:1

        End Sub
    End Class
End Namespace
