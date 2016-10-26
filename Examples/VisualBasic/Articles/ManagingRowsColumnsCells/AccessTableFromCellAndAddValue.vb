Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Tables

Namespace Articles.ManagingRowsColumnsCells
    Public Class AccessTableFromCellAndAddValue
        Public Shared Sub Run()
            ' ExStart:AccessTableFromCellAndAddValue
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cell D5 which lies inside the table
            Dim cell As Cell = worksheet.Cells("D5")

            ' Put value inside the cell D5
            cell.PutValue("D5 Data")

            ' Access the Table from this cell
            Dim table As ListObject = cell.GetTable()

            ' Add some value using Row and Column Offset
            table.PutCellValue(2, 2, "Offset [2,2]")

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:AccessTableFromCellAndAddValue
        End Sub
    End Class
End Namespace