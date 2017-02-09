using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    class AddingDocumentProperties
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
            Aspose.Cells.Properties.CustomDocumentPropertyCollection customProperties = workbook.Worksheets.CustomDocumentProperties;

            // Adding a custom document property to the Excel file
            Aspose.Cells.Properties.DocumentProperty publisher = customProperties.Add("Publisher", "Aspose");

            // Saving resultant spreadsheet
            workbook.Save(dataDir + "out_sample-document-properties.xlsx");
            // ExEnd:1

        }
    }
}
