Imports System.IO
Imports Aspose.Cells

Namespace Articles.WorkingWithHTMLFormat
    Public Class ExpandTextFromRightToLeft
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load source excel file inside the workbook object
            Dim wb As New Workbook(dataDir & "sample.xlsx")

            ' Save workbook in html format
            wb.Save(dataDir & "ExpandTextFromRightToLeft_out_" + CellsHelper.GetVersion() + ".html", SaveFormat.Html)
            ' ExEnd:1           

        End Sub
    End Class
End Namespace

