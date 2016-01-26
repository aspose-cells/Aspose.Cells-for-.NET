using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class CombineMultipleWorkbooksSingleWorkbook
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            //Define the first source
            //Open the first excel file.
            Workbook SourceBook1 = new Workbook(dataDir+ "SampleChart.xlsx");

            //Define the second source book.
            //Open the second excel file.
            Workbook SourceBook2 = new Workbook(dataDir+ "SampleImage.xlsx");

            //Combining the two workbooks
            SourceBook1.Combine(SourceBook2);

            //Save the target book file.
            SourceBook1.Save(dataDir+ "Combined.xlsx");
            
        }
    }
}