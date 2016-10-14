Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ExportExcelDataToDataTableWithoutFormatting
        Public Shared Sub Run()
            ' ExStart:ExportExcelDataToDataTableWithoutFormatting
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

            ' Display the cell values as it displays in excel
            Console.WriteLine("Cell String Value: " + cell.StringValue)

            ' Display the cell value without any format
            Console.WriteLine("Cell String Value without Format: " + cell.StringValueWithoutFormat)

            ' Export Data Table Options with FormatStrategy as CellStyle
            Dim opts As New ExportTableOptions()
            opts.ExportAsString = True
            opts.FormatStrategy = CellValueFormatStrategy.CellStyle

            ' Export Data Table
            Dim dt As DataTable = worksheet.Cells.ExportDataTable(0, 0, 1, 1, opts)

            ' Display the value of very first cell
            Console.WriteLine("Export Data Table with Format Strategy as Cell Style: " + dt.Rows(0)(0).ToString())

            ' Export Data Table Options with FormatStrategy as None
            opts.FormatStrategy = CellValueFormatStrategy.None
            dt = worksheet.Cells.ExportDataTable(0, 0, 1, 1, opts)

            ' Display the value of very first cell
            Console.WriteLine("Export Data Table with Format Strategy as None: " + dt.Rows(0)(0).ToString())
            ' ExEnd:ExportExcelDataToDataTableWithoutFormatting
        End Sub
    End Class
End Namespace