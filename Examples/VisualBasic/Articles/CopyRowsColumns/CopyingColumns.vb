Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.CopyRowsColumns
    Public Class CopyingColumns
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook
            'Open an existing excel file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            'Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            'Get the Cells collection
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells
            'Copy the first column to the third column
            cells.CopyColumn(cells, 0, 2)
            'Save the excel file
            workbook.Save(dataDir & "outaspose-sample.out.xlsx")


        End Sub
    End Class
End Namespace