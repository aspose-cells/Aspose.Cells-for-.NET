using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.Processing.Processing.FilteringAndValidation
{
    public class AutofilterData
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Creating AutoFilter by giving the cells range of the heading row
            worksheet.AutoFilter.Range = "A1:B1";

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.out.xls");
            //ExEnd:1

        }
    }
}
