Imports Aspose.Cells

Namespace Articles
    Public Class HtmlExportFrameScripts
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the required workbook to convert
            Dim w As Workbook = New Workbook(dataDir + "Sample1.xlsx")

            ' Disable exporting frame scripts and document properties
            Dim options As HtmlSaveOptions = New HtmlSaveOptions()
            options.ExportFrameScriptsAndProperties = False

            ' Save workbook as HTML
            w.Save(dataDir + "output.out.html", options)

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            ' ExEnd:1

        End Sub
    End Class
End Namespace
