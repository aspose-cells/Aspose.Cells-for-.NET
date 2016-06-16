using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningTextFilewithCustomSeparator
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir + "Book11.csv";

            // Instantiate Text File's LoadOptions
            TxtLoadOptions txtLoadOptions = new TxtLoadOptions();

            // Specify the separator
            txtLoadOptions.Separator = Convert.ToChar(",");

            // Specify the encoding type
            txtLoadOptions.Encoding = System.Text.Encoding.UTF8;

            // Create a Workbook object and opening the file from its path
            Workbook wb = new Workbook(filePath, txtLoadOptions);

            // Save file
            wb.Save(dataDir+ "output.txt");
           // ExEnd:1

        }
    }
}