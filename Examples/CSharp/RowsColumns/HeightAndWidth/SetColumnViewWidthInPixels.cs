using System;

namespace Aspose.Cells.Examples.CSharp.RowsColumns.HeightAndWidth
{
    public class SetColumnViewWidthInPixels
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "Book1.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the width of the column in pixels
            worksheet.Cells.SetViewColumnWidthPixel(7, 200);

            workbook.Save(outDir + "SetColumnViewWidthInPixels_Out.xlsx");
            // ExEnd:1

            Console.WriteLine("SetColumnViewWidthInPixels executed successfully.");
        }
    }
}
