using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Management
{
    public class AddingWorksheetsToNewExcelFile
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

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet";

            //Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");
        }
    }
}