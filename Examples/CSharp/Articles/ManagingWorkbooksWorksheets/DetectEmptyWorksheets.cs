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
            // ExStart:DetectEmptyWorksheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook and load an existing spreadsheet
            var book = new Workbook(dataDir + "sample.xlsx");
            // Loop over all worksheets in the workbook
            for (int i = 0; i < book.Worksheets.Count; i++)
            {
                Worksheet sheet = book.Worksheets[i];
                // Check if worksheet has populated cells
                if (sheet.Cells.MaxDataRow != -1)
                {
                    Console.WriteLine(sheet.Name + " is not empty because one or more cells are populated");
                }
                // Check if worksheet has shapes
                else if (sheet.Shapes.Count > 0)
                {
                    Console.WriteLine(sheet.Name + " is not empty because there are one or more shapes");
                }
                // Check if worksheet has empty initialized cells
                else
                {
                    Aspose.Cells.Range range = sheet.Cells.MaxDisplayRange;
                    var rangeIterator = range.GetEnumerator();
                    if (rangeIterator.MoveNext())
                    {
                        Console.WriteLine(sheet.Name + " is not empty because one or more cells are initialized");
                    }
                }
            }
            // ExEnd:DetectEmptyWorksheets
        }
    }
}
