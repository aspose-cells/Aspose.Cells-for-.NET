Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.CopyRowsColumns
    Public Class CopyingRows
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new workbook
            'Open an existing excel file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            'Get the first worksheet cells
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells
            'Apply formulas to the cells
            For i As Integer = 0 To 4
                cells(0, i).Formula = "=Input!" & cells(0, i).Name
            Next i
            'Copy the first row to next 10 rows
            cells.CopyRows(cells, 0, 1, 10)
            'Save the excel file
            workbook.Save(dataDir & "outaspose-sample.out.xlsx")

        End Sub
    End Class
End Namespace