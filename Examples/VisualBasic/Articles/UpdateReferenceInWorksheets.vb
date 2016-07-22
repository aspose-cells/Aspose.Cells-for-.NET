Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class UpdateReferenceInWorksheets
        Public Shared Sub Run()
            ' ExStart:UpdateReferenceInWorksheets
            ' Create workbook
            Dim wb As New Workbook()

            ' Add second sheet with name Sheet2
            wb.Worksheets.Add("Sheet2")

            ' Access first sheet and add some integer value in cell C1
            ' Also add some value in any cell to increase the number of blank rows and columns
            Dim sht1 As Worksheet = wb.Worksheets(0)
            sht1.Cells("C1").PutValue(4)
            sht1.Cells("K30").PutValue(4)

            ' Access second sheet and add formula in cell E3 which refers to cell C1 in first sheet
            Dim sht2 As Worksheet = wb.Worksheets(1)
            sht2.Cells("E3").Formula = "'Sheet1'!C1"

            ' Calculate formulas of workbook
            wb.CalculateFormula()

            ' Print the formula and value of cell E3 in second sheet before deleting blank columns and rows in Sheet1.
            Console.WriteLine("Cell E3 before deleting blank columns and rows in Sheet1.")
            Console.WriteLine("--------------------------------------------------------")
            Console.WriteLine("Cell Formula: " + sht2.Cells("E3").Formula)
            Console.WriteLine("Cell Value: " + sht2.Cells("E3").StringValue)

            ' If you comment DeleteOptions.UpdateReference property below, then the formula in cell E3 in second sheet will not be updated
            Dim opts As New DeleteOptions()
            opts.UpdateReference = True

            ' Delete all blank rows and columns with delete options
            sht1.Cells.DeleteBlankColumns(opts)
            sht1.Cells.DeleteBlankRows(opts)

            ' Calculate formulas of workbook
            wb.CalculateFormula()

            ' Print the formula and value of cell E3 in second sheet after deleting blank columns and rows in Sheet1.
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("Cell E3 after deleting blank columns and rows in Sheet1.")
            Console.WriteLine("--------------------------------------------------------")
            Console.WriteLine("Cell Formula: " + sht2.Cells("E3").Formula)
            Console.WriteLine("Cell Value: " + sht2.Cells("E3").StringValue)
            ' ExEnd:UpdateReferenceInWorksheets
        End Sub
    End Class
End Namespace
