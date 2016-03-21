using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.Grouping
{
    public class UngroupingRowsAndColumns
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

            //Ungrouping first six rows (from 0 to 5)
            worksheet.Cells.UngroupRows(0, 5);

            //Ungrouping first three columns (from 0 to 2)
            worksheet.Cells.UngroupColumns(0, 2);

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.out.xls");

            //Closing the file stream to free all resources
            fstream.Close();
            //ExEnd:1
        }
    }
}
