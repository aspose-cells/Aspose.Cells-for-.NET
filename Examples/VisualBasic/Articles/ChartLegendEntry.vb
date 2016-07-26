Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles
    Class ChartLegendEntry
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the template file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("Sample.xlsx"))

            ' Access the first worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Access the first chart inside the sheet
            Dim chart As Chart = sheet.Charts(0)

            ' Set text of second legend entry fill to none
            chart.Legend.LegendEntries(1).IsTextNoFill = True

            ' Save the workbook in xlsx format
            workbook.Save(dataDir & Convert.ToString("ChartLegendEntry_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
