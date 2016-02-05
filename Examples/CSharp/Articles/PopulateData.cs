using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class PopulateData
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;
            cells["A1"].PutValue("data1");
            cells["B1"].PutValue("data2");
            cells["A2"].PutValue("data3");
            cells["B2"].PutValue("data4");
            workbook.Save(dataDir + "book1.out.xlsx");
            
            
        }
    }
}