using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class CalculateIFNAFunction
    {
        public static void Run()
        {
            // ExStart:CalculateIFNAFunction
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create new workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Add data for VLOOKUP
            worksheet.Cells["A1"].PutValue("Apple");
            worksheet.Cells["A2"].PutValue("Orange");
            worksheet.Cells["A3"].PutValue("Banana");

            // Access cell A5 and A6
            Cell cellA5 = worksheet.Cells["A5"];
            Cell cellA6 = worksheet.Cells["A6"];

            // Assign IFNA formula to A5 and A6
            cellA5.Formula = "=IFNA(VLOOKUP(\"Pear\",$A$1:$A$3,1,0),\"Not found\")";
            cellA6.Formula = "=IFNA(VLOOKUP(\"Orange\",$A$1:$A$3,1,0),\"Not found\")";

            // Caclulate the formula of workbook
            workbook.CalculateFormula();

            // Print the values of A5 and A6
            Console.WriteLine(cellA5.StringValue);
            Console.WriteLine(cellA6.StringValue);
            // ExEnd:CalculateIFNAFunction
        }
    }
}
