Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class CalculateWidthAndHeight
        Public Shared Sub Run()
            ' ExStart:CalculateWidthAndHeightOfCellValueInUnitOfPixel
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cell B2 and add some value inside it
            Dim cell As Cell = worksheet.Cells("B2")
            cell.PutValue("Welcome to Aspose!")

            ' Enlarge its font to size 16
            Dim style As Style = cell.GetStyle()
            style.Font.Size = 16
            cell.SetStyle(style)

            ' Calculate the width and height of the cell value in unit of pixels
            Dim widthOfValue As Integer = cell.GetWidthOfValue()
            Dim heightOfValue As Integer = cell.GetHeightOfValue()

            ' Print both values
            Console.WriteLine("Width of Cell Value: " + widthOfValue)
            Console.WriteLine("Height of Cell Value: " + heightOfValue)

            ' Set the row height and column width to adjust/fit the cell value inside cell
            worksheet.Cells.SetColumnWidthPixel(1, widthOfValue)
            worksheet.Cells.SetRowHeightPixel(1, heightOfValue)

            ' Save the output excel file
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:CalculateWidthAndHeightOfCellValueInUnitOfPixel
        End Sub
    End Class
End Namespace