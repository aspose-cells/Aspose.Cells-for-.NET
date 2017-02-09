using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class AccessingDocumentProperties
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a Workbook object
            // Open an Excel file
            Workbook workbook = new Workbook(dataDir + "sample-document-properties.xlsx");

            // Retrieve a list of all custom document properties of the Excel file
            Aspose.Cells.Properties.DocumentPropertyCollection customProperties = workbook.Worksheets.CustomDocumentProperties;

            // Accessing a custom document property by using the property name
            Aspose.Cells.Properties.DocumentProperty customProperty1 = customProperties["ContentTypeId"];
            Console.WriteLine(customProperty1.Name + " " + customProperty1.Value);

            // Accessing the same custom document property by using the property index
            Aspose.Cells.Properties.DocumentProperty customProperty2 = customProperties[0];
            Console.WriteLine(customProperty2.Name + " " + customProperty2.Value);
            // ExEnd:1

        }
    }
}
