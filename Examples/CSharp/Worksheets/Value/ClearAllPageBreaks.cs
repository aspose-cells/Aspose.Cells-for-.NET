using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class ClearAllPageBreaks
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Clearing all page breaks
            workbook.Worksheets[0].HorizontalPageBreaks.Clear();
            workbook.Worksheets[0].VerticalPageBreaks.Clear();

            // Save the Excel file.
            workbook.Save(dataDir + "ClearAllPageBreaks_out.xls");
            // ExEnd:1
        }
    }
}
