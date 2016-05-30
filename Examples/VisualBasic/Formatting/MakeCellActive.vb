Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Formatting
    Public Class MakeCellActive
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet in the workbook.
            Dim worksheet1 As Worksheet = workbook.Worksheets(0)

            ' Get the cells in the worksheet.
            Dim cells As Cells = worksheet1.Cells

            ' Input data into B2 cell.
            cells(1, 1).PutValue("Hello World!")

            ' Set the first sheet as an active sheet.
            workbook.Worksheets.ActiveSheetIndex = 0

            ' Set B2 cell as an active cell in the worksheet.
            worksheet1.ActiveCell = "B2"

            ' Set the B column as the first visible column in the worksheet.
            worksheet1.FirstVisibleColumn = 1

            ' Set the 2nd row as the first visible row in the worksheet.
            worksheet1.FirstVisibleRow = 1

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
