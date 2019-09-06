using Aspose.Cells.WebExtensions;
using System;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class DetectLinkTypes
    {
        public static void Run()
        {
            // ExStart:1
            //source directory
            string SourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(SourceDir + "LinkTypes.xlsx");

            // Get the first (default) worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a range A2:B3
            Range range = worksheet.Cells.CreateRange("A1", "A7");

            // Get Hyperlinks in range
            Hyperlink[] hyperlinks = range.Hyperlinks;

            foreach (Hyperlink link in hyperlinks)
            {
                Console.WriteLine(link.TextToDisplay + ": " + link.LinkType);
            }
            // ExEnd:1

            Console.WriteLine("DetectLinkTypes executed successfully.");
        }
    }
}
