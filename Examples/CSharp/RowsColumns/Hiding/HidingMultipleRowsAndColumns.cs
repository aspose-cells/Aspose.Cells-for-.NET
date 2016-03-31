using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.Hiding
{
    public class HidingMultipleRowsAndColumns
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Hiding 3,4 and 5 rows in the worksheet
            worksheet.Cells.HideRows(2, 3);

            //Hiding 2 and 3 columns in the worksheet
            worksheet.Cells.HideColumns(1, 2);

            //Saving the modified Excel file
            workbook.Save(dataDir + "outputxls");

            //Closing the file stream to free all resources
            fstream.Close();
            //ExEnd:1

        }
    }
}
