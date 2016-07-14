using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class RemoveSpecificPageBreak
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(dataDir + "PageBreaks.xls");

            // Removing a specific page break
            workbook.Worksheets[0].HorizontalPageBreaks.RemoveAt(0);
            workbook.Worksheets[0].VerticalPageBreaks.RemoveAt(0);

            // Save the Excel file.
            workbook.Save(dataDir + "RemoveSpecificPageBreak_out.xls");
            // ExEnd:1
        }
    }
}
