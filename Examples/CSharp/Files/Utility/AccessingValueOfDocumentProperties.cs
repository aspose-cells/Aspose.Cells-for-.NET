using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    class AccessingValueOfDocumentProperties
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

            // Accessing a custom document property
            Aspose.Cells.Properties.DocumentProperty customProperty1 = customProperties[0];

            // Storing the value of the document property as an object
            object objectValue = customProperty1.Value;

            // Accessing a custom document property
            Aspose.Cells.Properties.DocumentProperty customProperty2 = customProperties[1];

            // Checking the type of the document property and then storing the value of the
            // document property according to that type
            if (customProperty2.Type == Aspose.Cells.Properties.PropertyType.String)
            {
                string value = customProperty2.Value.ToString();
                Console.WriteLine(customProperty2.Name + " : " + value);
            }
            // ExEnd:1

        }
    }
}
