using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class GetRangeWithExternalLinks
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "SampleExternalReferences.xlsx");

            foreach (Name namedRange in workbook.Worksheets.Names)
            {
                ReferredArea[] referredAreas = namedRange.GetReferredAreas(true);
                if (referredAreas != null)
                {
                    for (int i = 0; i < referredAreas.Length; i++)
                    {
                        ReferredArea referredArea = referredAreas[i];
                        // Print the data in Referred Area
                        Console.WriteLine("IsExternalLink: " + referredArea.IsExternalLink);
                        Console.WriteLine("IsArea: " + referredArea.IsArea);
                        Console.WriteLine("SheetName: " + referredArea.SheetName);
                        Console.WriteLine("ExternalFileName: " + referredArea.ExternalFileName);
                        Console.WriteLine("StartColumn: " + referredArea.StartColumn);
                        Console.WriteLine("StartRow: " + referredArea.StartRow);
                        Console.WriteLine("EndColumn: " + referredArea.EndColumn);
                        Console.WriteLine("EndRow: " + referredArea.EndRow);
                    }
                }
            }
            // ExEnd:1

            Console.WriteLine("GetRangeWithExternalLinks executed successfully.\r\n");
        }
    }
}
