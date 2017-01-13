using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningFilewithDataOnly
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Load only specific sheets with data and formulas
            // Other objects, items etc. would be discarded

            // Instantiate LoadOptions specified by the LoadFormat
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);

            // Set LoadFilter property to load only data & cell formatting
            loadOptions.LoadFilter = new LoadFilter(LoadDataFilterOptions.CellData);
            

            // Create a Workbook object and opening the file from its path
            Workbook book = new Workbook(dataDir + "Book1.xlsx", loadOptions);
            Console.WriteLine("File data imported successfully!");
            // ExEnd:1
            
        }
    }
}
