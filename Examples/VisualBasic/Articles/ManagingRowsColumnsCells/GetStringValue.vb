Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class GetStringValue
        Public Shared Sub Run()
            ' ExStart:GetStringValueWithOrWithoutFormatting
            ' Create workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cell A1
            Dim cell As Cell = worksheet.Cells("A1")

            ' Put value inside the cell
            cell.PutValue(0.012345)

            ' Format the cell that it should display 0.01 instead of 0.012345
            Dim style As Style = cell.GetStyle()
            style.Number = 2
            cell.SetStyle(style)

            ' Get string value as Cell Style
            Dim value As String = cell.GetStringValue(CellValueFormatStrategy.CellStyle)
            Console.WriteLine(value)

            ' Get string value without any formatting
            value = cell.GetStringValue(CellValueFormatStrategy.None)
            Console.WriteLine(value)
            ' ExEnd:GetStringValueWithOrWithoutFormatting
        End Sub
    End Class
End Namespace