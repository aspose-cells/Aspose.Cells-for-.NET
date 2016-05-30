Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class ChangeHtmlLinkTarget
        Public Shared Sub Run()
            ' ExStart:1
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample1.xlsx"
            Dim outputPath As String = dataDir & "Output.out.html"

            Dim workbook As Workbook = New Workbook(inputPath)
            Dim opts As HtmlSaveOptions = New HtmlSaveOptions()
            opts.LinkTargetType = HtmlLinkTargetType.Self

            workbook.Save(outputPath, opts)
            Console.WriteLine("File saved: {0}", outputPath)
            ' ExEnd:1

        End Sub
    End Class
End Namespace
