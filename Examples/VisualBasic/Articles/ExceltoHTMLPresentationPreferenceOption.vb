Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class ExceltoHTMLPresentationPreferenceOption
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Instantiate the Workbook
            ' Instantiate the Workbook
            ' Load an Excel file
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            ' Create HtmlSaveOptions object
            Dim options As New HtmlSaveOptions()
            ' Set the Presenation preference option
            options.PresentationPreference = True

            ' Save the Excel file to HTML with specified option
            workbook.Save(dataDir & "outPresentationlayout1.out.html", options)
            ' ExEnd:1

        End Sub
    End Class
End Namespace