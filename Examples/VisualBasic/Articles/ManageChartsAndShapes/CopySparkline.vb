Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class CopySparkline
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first sparkline group
            Dim group As SparklineGroup = worksheet.SparklineGroupCollection(0)

            ' Add Data Ranges and Locations inside this sparkline group
            group.SparklineCollection.Add("D5:O5", 4, 15)
            group.SparklineCollection.Add("D6:O6", 5, 15)
            group.SparklineCollection.Add("D7:O7", 6, 15)
            group.SparklineCollection.Add("D8:O8", 7, 15)

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace