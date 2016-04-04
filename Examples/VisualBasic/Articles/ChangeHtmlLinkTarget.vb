Imports System.IO
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class ChangeHtmlLinkTarget
        Shared Sub Main()
            'ExStart:1
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample1.xlsx"
            Dim outputPath As String = dataDir & "Output.out.html"

            Dim workbook As Workbook = New Workbook(inputPath)
            Dim opts As HtmlSaveOptions = New HtmlSaveOptions()
            opts.LinkTargetType = HtmlLinkTargetType.Self

            workbook.Save(outputPath, opts)
            Console.WriteLine("File saved: {0}", outputPath)
            'ExEnd:1

        End Sub
    End Class
End Namespace
