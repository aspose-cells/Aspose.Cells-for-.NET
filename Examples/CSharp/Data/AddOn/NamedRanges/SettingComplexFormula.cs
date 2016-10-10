using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class SettingComplexFormula
    {
        public static void Run()
        {
            // ExStart:SettingComplexFormulaNamedRange
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook
            Workbook book = new Workbook();

            // Get the WorksheetCollection
            WorksheetCollection worksheets = book.Worksheets;

            // Add a new Named Range with name "data"
            int index = worksheets.Names.Add("data");

            // Access the newly created Named Range from the collection
            Name data = worksheets.Names[index];

            // Set RefersTo property of the Named Range to a cell range in same worksheet
            data.RefersTo = "=Sheet1!$A$1:$B$5";

            // Add another Named Range with name "range"
            index = worksheets.Names.Add("range");

            // Access the newly created Named Range from the collection
            Name range = worksheets.Names[index];

            // Set RefersTo property to a formula using the Named Range "data"
            range.RefersTo = "INDEX(data,1,1):INDEX(data,3,2)";

            // Add another Named Range with name "range"
            index = worksheets.Names.Add("complex");

            // Access the newly created Named Range "complex" from the collection
            Name complex = worksheets.Names[index];

            // Set RefersTo property to a formula using the Named Range "range"
            complex.RefersTo = "=INDEX(range,2,2)";

            // Insert the value in cells which is being referenced in the Named Range with name "data"
            worksheets[0].Cells["A1"].PutValue("1,000");
            worksheets[0].Cells["A2"].PutValue("2,000");
            worksheets[0].Cells["A3"].PutValue("3,000");
            worksheets[0].Cells["A4"].PutValue("4,000");
            worksheets[0].Cells["A5"].PutValue("5,000");
            worksheets[0].Cells["B1"].PutValue("6,000");
            worksheets[0].Cells["B2"].PutValue("7,000");
            worksheets[0].Cells["B3"].PutValue("8,000");
            worksheets[0].Cells["B4"].PutValue("9,000");
            worksheets[0].Cells["B5"].PutValue("10,000");

            // Set the formula in the cell A1 to the newly created Named Range
            worksheets[0].Cells["C1"].Formula = "complex";

            // Calculate formulas
            book.CalculateFormula();

            // Save the result in XLSX format
            book.Save(dataDir + "output_out_.xlsx");
            // ExEnd:SettingComplexFormulaNamedRange
        }
    }
}
