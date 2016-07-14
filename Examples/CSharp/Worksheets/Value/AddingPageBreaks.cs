using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class AddingPageBreaks
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Add a page break at cell Y30
            workbook.Worksheets[0].HorizontalPageBreaks.Add("Y30");
            workbook.Worksheets[0].VerticalPageBreaks.Add("Y30");

            // Save the Excel file.
            workbook.Save(dataDir + "AddingPageBreaks_out.xls");
            // ExEnd:1
        }
    }
}
