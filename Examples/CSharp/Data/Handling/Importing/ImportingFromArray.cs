using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.Handling.Importing
{
    public class ImportingFromArray
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Creating an array containing names as string values
            string[] names = new string[] { "laurence chen", "roman korchagin", "kyle huang" };

            //Importing the array of names to 1st row and first column vertically
            worksheet.Cells.ImportArray(names, 0, 0, true);

            //Saving the Excel file
            workbook.Save(dataDir + "DataImport.out.xls");

        }
    }
}