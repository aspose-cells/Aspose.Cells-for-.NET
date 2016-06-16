using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningHTMLFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            string filePath = dataDir + "Book1.html";

            // Instantiate LoadOptions specified by the LoadFormat.
            HTMLLoadOptions loadOptions = new HTMLLoadOptions(LoadFormat.Html);

            // Create a Workbook object and opening the file from its path
            Workbook wb = new Workbook(filePath, loadOptions);
            // Save the MHT file
            wb.Save(filePath + "output.xlsx");
            // ExEnd:1


        }
    }
}