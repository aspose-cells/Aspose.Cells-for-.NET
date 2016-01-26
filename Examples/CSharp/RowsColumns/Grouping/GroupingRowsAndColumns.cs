using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.RowsColumns.Grouping
{
    public class GroupingRowsAndColumns
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

            //Grouping first six rows (from 0 to 5) and making them hidden by passing true
            worksheet.Cells.GroupRows(0, 5, true);

            //Grouping first three columns (from 0 to 2) and making them hidden by passing true
            worksheet.Cells.GroupColumns(0, 2, true);

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            //Closing the file stream to free all resources
            fstream.Close();

            
        }
    }
}