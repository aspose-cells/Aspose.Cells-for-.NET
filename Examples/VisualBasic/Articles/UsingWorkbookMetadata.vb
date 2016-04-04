Imports Aspose.Cells
Imports Aspose.Cells.Metadata

Namespace Aspose.Cells.Examples.Articles
    Public Class UsingWorkbookMetadata
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open Workbook metadata
            Dim options As MetadataOptions = New MetadataOptions(MetadataType.DocumentProperties)
            Dim meta As WorkbookMetadata = New WorkbookMetadata(dataDir + "Sample1.xlsx", options)

            ' Set some properties
            meta.CustomDocumentProperties.Add("test", "test")

            ' Save the metadata info
            meta.Save(dataDir + "Sample2.out.xlsx")

            ' Open the workbook
            Dim w As Workbook = New Workbook(dataDir + "Sample2.xlsx")

            ' Read document property
            Console.WriteLine(w.CustomDocumentProperties("test"))

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            'ExEnd:1

        End Sub
    End Class
End Namespace
