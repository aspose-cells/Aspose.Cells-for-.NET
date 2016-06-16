using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class Implement1904DateSystem
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Initialize a new Workbook
            // Open an excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            // Implement 1904 date system
            workbook.Settings.Date1904 = true;

            // Save the excel file
            workbook.Save(dataDir+ "Mybook.out.xlsx");
            // ExEnd:1
 
            
            
        }
    }
}
