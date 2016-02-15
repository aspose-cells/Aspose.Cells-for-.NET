using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.HeightAndWidth
{
    public class SettingWidthOfColumn
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

            //Setting the width of the second column to 17.5
            worksheet.Cells.SetColumnWidth(1, 17.5);

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.out.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
    }
}