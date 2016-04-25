using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.PivotTableExamples
{
    public class ChangeSourceData
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string InputPath = dataDir + "Book1.xlsx";

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(InputPath, FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Populating new data to the worksheet cells
            worksheet.Cells["A9"].PutValue("Golf");
            worksheet.Cells["B9"].PutValue("Qtr4");
            worksheet.Cells["C9"].PutValue(7000);

            //Changing named range "DataSource"
            Range range = worksheet.Cells.CreateRange(0, 0, 9, 3);
            range.Name = "DataSource";

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");

            //Closing the file stream to free all resources
            fstream.Close();
            //ExEnd:1

        }
    }
}