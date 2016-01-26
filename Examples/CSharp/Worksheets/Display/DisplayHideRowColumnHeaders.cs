using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Display
{
    public class DisplayHideRowColumnHeaders
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

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Hiding the headers of rows and columns
            worksheet.IsRowColumnHeadersVisible = false;

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            //Closing the file stream to free all resources
            fstream.Close(); 
        }
    }
}