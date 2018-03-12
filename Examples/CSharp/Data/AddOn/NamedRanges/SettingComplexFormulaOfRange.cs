using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class SettingComplexFormulaOfRange
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Create an instance of Workbook
            Workbook book = new Workbook();

            // Get the WorksheetCollection
            WorksheetCollection worksheets = book.Worksheets;

            // Add a new Named Range with name "data"
            int index = worksheets.Names.Add("data");

            // Access the newly created Named Range from the collection
            Name data = worksheets.Names[index];

            // Set RefersTo property of the Named Range to a cell range in same worksheet
            data.RefersTo = "=Sheet1!$A$1:$A$10";

            // Add another Named Range with name "range"
            index = worksheets.Names.Add("range");

            // Access the newly created Named Range from the collection
            Name range = worksheets.Names[index];

            // Set RefersTo property to a formula using the Named Range data
            range.RefersTo = "=INDEX(data,Sheet1!$A$1,1):INDEX(data,Sheet1!$A$1,9)";

            // Save the workbook
            book.Save(outputDir + "outputSettingComplexFormulaOfRange.xlsx");

            Console.WriteLine("SettingComplexFormulaOfRange executed successfully.");
        }
    }
}
