using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Management
{
    public class RemovingWorksheetsUsingSheetIndex
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

            //Removing a worksheet using its sheet index
            workbook.Worksheets.RemoveAt(0);

            //Save workbook
            workbook.Save(dataDir + "output.out.xls");
            
        }
    }
}