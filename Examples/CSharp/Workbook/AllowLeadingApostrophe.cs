using Aspose.Cells.Rendering;
using Aspose.Cells.WebExtensions;
using System;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class AllowLeadingApostrophe
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();

            Workbook workbook = new Workbook(sourceDir + "AllowLeadingApostropheSample.xlsx");
            workbook.Settings.QuotePrefixToStyle = false;

            // Open a designer spreadsheet containing smart markers
            designer.Workbook = workbook;

            List<DataObject> list = new List<DataObject>
            {
                new DataObject
                {
                     Id =1,
                     Name = "demo"
                },
                new DataObject
                {
                    Id=2,
                    Name = "'demo"
                }
            };

            // Set the data source for the designer spreadsheet
            designer.SetDataSource("sampleData", list);

            // Process the smart markers
            designer.Process();

            designer.Workbook.Save(outputDir + "AllowLeadingApostropheSample_out.xlsx");
            // ExEnd:1

            Console.WriteLine("AllowLeadingApostrophe executed successfully.");
        }
    }

    // ExStart:2
    internal class DataObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // ExEnd:2
}
