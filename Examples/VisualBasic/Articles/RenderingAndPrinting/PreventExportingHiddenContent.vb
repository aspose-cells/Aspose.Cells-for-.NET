
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class PreventExportingHiddenContent
        Public Shared Sub Run()
            ' ExStart:PreventExportingHiddenContentWhileSavingToHTML
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("WorkbookWithHiddenContent.xlsx"))

            ' Do not export hidden worksheet contents
            Dim options As New HtmlSaveOptions()
            options.ExportHiddenWorksheet = False

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("HtmlWithoutHiddenContent_out_.html"), options)
            ' ExEnd:PreventExportingHiddenContentWhileSavingToHTML
        End Sub
    End Class
End Namespace
