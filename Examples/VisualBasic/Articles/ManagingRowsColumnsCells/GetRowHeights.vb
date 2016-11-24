Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class GetRowHeights
        Public Shared Sub Run()
            ' ExStart:GetRowHeightsOfSourceRangeToDestinationRange
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Source worksheet
            Dim srcSheet As Worksheet = workbook.Worksheets(0)

            ' Add destination worksheet
            Dim dstSheet As Worksheet = workbook.Worksheets.Add("Destination Sheet")

            ' Set the row height of the 4th row. This row height will be copied to destination range
            srcSheet.Cells.SetRowHeight(3, 50)

            ' Create source range to be copied
            Dim srcRange As Range = srcSheet.Cells.CreateRange("A1:D10")

            ' Create destination range in destination worksheet
            Dim dstRange As Range = dstSheet.Cells.CreateRange("A1:D10")

            ' PasteOptions, we want to copy row heights of source range to destination range
            Dim opts As New PasteOptions()
            opts.PasteType = PasteType.RowHeights

            ' Copy source range to destination range with paste options
            dstRange.Copy(srcRange, opts)

            ' Write informative message in cell D4 of destination worksheet
            dstSheet.Cells("D4").PutValue("Row heights of source range copied to destination range")

            ' Save the workbook in xlsx format
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:GetRowHeightsOfSourceRangeToDestinationRange
        End Sub
    End Class
End Namespace