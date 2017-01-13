Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class FilterDataWhileLoadingWorkbook
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Set the load options, we only want to load shapes and do not want to load data
            Dim opts As New LoadOptions(LoadFormat.Xlsx)
            opts.LoadFilter = New LoadFilter(LoadDataFilterOptions.Shape)

            ' Create workbook object from sample excel file using load options
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"), opts)

            'Save the output in pdf format
            wb.Save(dataDir & Convert.ToString("FilterDataWhileLoadingWorkbook_out.pdf"), SaveFormat.Pdf)
            ' ExEnd:1         
        End Sub
    End Class
End Namespace
