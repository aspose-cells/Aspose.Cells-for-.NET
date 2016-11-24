Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class LoadExcelFileWithoutChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify the load options and filter the data
            ' We do not want to load charts
            Dim options As New LoadOptions()
            options.LoadDataFilterOptions = LoadDataFilterOptions.All And Not LoadDataFilterOptions.Chart

            ' Load the workbook with specified load options
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"), options)

            ' Save the workbook in output format
            workbook.Save(dataDir & Convert.ToString("LoadExcelFileWithoutChart_out.pdf"), SaveFormat.Pdf)
            ' ExEnd:1           

        End Sub
    End Class
End Namespace

