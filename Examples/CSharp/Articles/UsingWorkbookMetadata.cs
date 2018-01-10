using System;
using Aspose.Cells;
using Aspose.Cells.Metadata;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class UsingWorkbookMetadata
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open Workbook metadata
            MetadataOptions options = new MetadataOptions(MetadataType.DocumentProperties);
            WorkbookMetadata meta = new WorkbookMetadata(sourceDir + "sampleUsingWorkbookMetadata.xlsx", options);

            // Set some properties
            meta.CustomDocumentProperties.Add("MyTest", "This is My Test");

            // Save the metadata info
            meta.Save(outputDir + "outputUsingWorkbookMetadata.xlsx");

            // Open the workbook
            Workbook w = new Workbook(outputDir + "outputUsingWorkbookMetadata.xlsx");

            // Read document property
            Console.WriteLine("Metadata Custom Property MyTest: " + w.CustomDocumentProperties["MyTest"]);

            Console.WriteLine("UsingWorkbookMetadata executed successfully.");
        }
    }
}
