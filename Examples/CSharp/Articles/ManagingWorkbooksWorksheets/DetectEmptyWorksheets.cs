using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class DetectEmptyWorksheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create an instance of Workbook and load an existing spreadsheet
            var book = new Workbook(sourceDir + "sampleDetectEmptyWorksheets.xlsx");

            // Loop over all worksheets in the workbook
            for (int i = 0; i < book.Worksheets.Count; i++)
            {
                Worksheet sheet = book.Worksheets[i];
                // Check if worksheet has populated cells
                if (sheet.Cells.MaxDataRow != -1)
                {
                    Console.WriteLine(sheet.Name + " is not Empty because one or more Cells are Populated");
                }
                // Check if worksheet has shapes
                else if (sheet.Shapes.Count > 0)
                {
                    Console.WriteLine(sheet.Name + " is not Empty because there are one or more Shapes");
                }
                // Check if worksheet has empty initialized cells
                else
                {
                    Aspose.Cells.Range range = sheet.Cells.MaxDisplayRange;
                    var rangeIterator = range.GetEnumerator();
                    if (rangeIterator.MoveNext())
                    {
                        Console.WriteLine(sheet.Name + " is not Empty because one or more cells are Initialized");
                    }
                }
            }

            Console.WriteLine("DetectEmptyWorksheets executed successfully.");
        }
    }
}
