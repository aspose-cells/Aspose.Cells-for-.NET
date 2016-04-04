using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Display
{
    public class DisplayTab
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            //Opening the Excel file
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Hiding the tabs of the Excel file
            workbook.Settings.ShowTabs = true;

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1
        }
    }
}
