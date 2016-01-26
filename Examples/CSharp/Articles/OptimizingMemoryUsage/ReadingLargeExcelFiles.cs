using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.OptimizingMemoryUsage
{
    public class ReadingLargeExcelFiles
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Specify the LoadOptions
            LoadOptions opt = new LoadOptions();
            //Set the memory preferences
            opt.MemorySetting = MemorySetting.MemoryPreference;

            //Instantiate the Workbook
            //Load the Big Excel file having large Data set in it
            Workbook wb = new Workbook(dataDir+ "Book1.xlsx", opt);
            
        }
    }
}