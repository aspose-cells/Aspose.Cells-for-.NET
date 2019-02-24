using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class GetHyperlinksInRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string sourceDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a Workbook object
            // Open an Excel file
            Workbook workbook = new Workbook(sourceDir + "HyperlinksSample.xlsx");

            // Get the first (default) worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a range A2:B3
            Range range = worksheet.Cells.CreateRange("A2", "B3");

            // Get Hyperlinks in range
            Hyperlink[] hyperlinks = range.Hyperlinks;

            foreach (Hyperlink link in hyperlinks)
            {
                Console.WriteLine(link.Area + " : " + link.Address);

                // To delete the link, use the Hyperlink.Delete() method.
                link.Delete();
            }

            workbook.Save(outputDir + "HyperlinksSample_out.xlsx");
            // ExEnd:1

        }
    }
}
