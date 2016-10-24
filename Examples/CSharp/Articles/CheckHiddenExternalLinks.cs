using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CheckHiddenExternalLinks
    {
        public static void Run()
        {
            // ExStart:CheckHiddenExternalLinks
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Loads the workbook which contains hidden external links
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Access the external link collection of the workbook
            ExternalLinkCollection links = workbook.Worksheets.ExternalLinks;

            // Print all the external links and check there IsVisible property
            for (int i = 0; i < links.Count; i++)
            {
                Console.WriteLine("Data Source: " + links[i].DataSource);
                Console.WriteLine("Is Referred: " + links[i].IsReferred);
                Console.WriteLine("Is Visible: " + links[i].IsVisible);
                Console.WriteLine();
            }
            // ExEnd:CheckHiddenExternalLinks
        }
    }
}
