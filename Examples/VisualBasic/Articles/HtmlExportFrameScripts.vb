Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class HtmlExportFrameScripts
        Public Shared Sub Main(ByVal args() As String)

            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the required workbook to convert
            Dim w As Workbook = New Workbook(dataDir + "Sample1.xlsx")

            ' Disable exporting frame scripts and document properties
            Dim options As HtmlSaveOptions = New HtmlSaveOptions()
            options.ExportFrameScriptsAndProperties = False

            ' Save workbook as HTML
            w.Save(dataDir + "output.out.html", options)

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()

        End Sub
    End Class
End Namespace
