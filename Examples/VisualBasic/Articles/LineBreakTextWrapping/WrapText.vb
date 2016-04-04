Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.LineBreakTextWrapping
    Public Class WrapText
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create Workbook Object
            Dim wb As New Workbook()

            'Open first Worksheet in the workbook
            Dim ws As Worksheet = wb.Worksheets(0)

            'Get Worksheet Cells Collection
            Dim cell As Global.Aspose.Cells.Cells = ws.Cells

            'Increase the width of First Column Width
            cell.SetColumnWidth(0, 35)

            'Increase the height of first row
            cell.SetRowHeight(0, 36)

            'Add Text to the Firts Cell
            cell(0, 0).PutValue("I am using the latest version of Aspose.Cells to test this functionality")

            'Make Cell's Text wrap
            Dim style As Style = cell(0, 0).GetStyle()
            style.IsTextWrapped = True
            cell(0, 0).SetStyle(style)

            ' Save Excel File
            wb.Save(dataDir & "output.xlsx")
            'ExEnd:1


        End Sub
    End Class
End Namespace