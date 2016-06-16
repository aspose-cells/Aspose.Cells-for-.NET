using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Display
{
    public class HideTabs
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            // Opening the Excel file
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Hiding the tabs of the Excel file
            workbook.Settings.ShowTabs = false;


            // Shows the tabs of the Excel file
           // workbook.Settings.ShowTabs = true;

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1
        }
    }
}
