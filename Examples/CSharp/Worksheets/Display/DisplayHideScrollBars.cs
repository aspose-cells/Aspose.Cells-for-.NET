using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Display
{
    public class DisplayHideScrollBars
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Hiding the vertical scroll bar of the Excel file
            workbook.Settings.IsVScrollBarVisible = false;

            //Hiding the horizontal scroll bar of the Excel file
            workbook.Settings.IsHScrollBarVisible = false;

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
    }
}