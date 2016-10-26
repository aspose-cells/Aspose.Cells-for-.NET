using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class SearchDataUsingOriginalValues
    {
        public static void Run()
        {
            // ExStart:SearchDataUsingOriginalValues
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Add 10 in cell A1 and A2
            worksheet.Cells["A1"].PutValue(10);
            worksheet.Cells["A2"].PutValue(10);

            // Add Sum formula in cell D4 but customize it as ---
            Cell cell = worksheet.Cells["D4"];

            Style style = cell.GetStyle();
            style.Custom = "---";
            cell.SetStyle(style);

            // The result of formula will be 20 but 20 will not be visible because the cell is formated as ---
            cell.Formula = "=Sum(A1:A2)";

            // Calculate the workbook
            workbook.CalculateFormula();

            // Create find options, we will search 20 using original values otherwise 20 will never be found because it is formatted as ---
            FindOptions options = new FindOptions();
            options.LookInType = LookInType.OriginalValues;
            options.LookAtType = LookAtType.EntireContent;

            Cell foundCell = null;
            object obj = 20;

            // Find 20 which is Sum(A1:A2) and formatted as ---
            foundCell = worksheet.Cells.Find(obj, foundCell, options);

            // Print the found cell
            Console.WriteLine(foundCell);

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:SearchDataUsingOriginalValues
        }
    }
}
