using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers
{
    class EvaluateIsBlank
    {
        //Input directory
        static string sourceDir = RunExamples.Get_SourceDirectory();
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();
        public static void Main()
        {

            // ExStart:1
            // Initialize DataSet object
            DataSet ds1 = new DataSet();

            // Fill dataset from XML file
            ds1.ReadXml(sourceDir + @"sampleIsBlank.xml");

            // Initialize template workbook containing smart marker with ISBLANK
            Workbook workbook = new Workbook(sourceDir + @"sampleIsBlank.xlsx");

            // Get the target value in the XML file whose value is to be examined
            string thridValue = ds1.Tables[0].Rows[2][0].ToString();

            // Check if that value is empty which will be tested using ISBLANK
            if (thridValue == string.Empty)
            {
                Console.WriteLine("The third value is empty");
            }
            // Instantiate a new WorkbookDesigner
            WorkbookDesigner designer = new WorkbookDesigner();

            // Set flag UpdateReference to true to indicate that references in other worksheets will be updated
            designer.UpdateReference = true;

            // Specify the Workbook
            designer.Workbook = workbook;

            // Use this flag to treat the empty string as null. If false, then ISBLANK will not work
            designer.UpdateEmptyStringAsNull = true;

            // Specify data source for the designer 
            designer.SetDataSource(ds1.Tables["comparison"]);

            // Process the smart markers and populate the data source values
            designer.Process();

            // Save the resultant workbook
            workbook.Save(outputDir + @"outputSampleIsBlank.xlsx");
            // ExEnd:1
            Console.WriteLine("EvaluateIsBlank executed successfully.");
        }
    }
}
