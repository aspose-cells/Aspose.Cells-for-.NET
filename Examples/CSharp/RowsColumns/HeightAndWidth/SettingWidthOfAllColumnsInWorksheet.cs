using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.HeightAndWidth
{
    public class SettingWidthOfAllColumnsInWorksheet
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
           // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Setting the width of all columns in the worksheet to 20.5
            worksheet.Cells.StandardWidth = 20.5;

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.out.xls");

            //Closing the file stream to free all resources
            fstream.Close(); 
        }
    }
}