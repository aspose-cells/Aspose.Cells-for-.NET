using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    class UpdateRichTextCells
    {
        static void Main()
        {
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample.xlsx";
            string outputPath = dataDir + "Output.xlsx";

            Workbook workbook = new Workbook(inputPath);

            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell = worksheet.Cells["A1"];

            Console.WriteLine("Before updating the font settings....");

            FontSetting[] fnts = cell.GetCharacters();

            for (int i = 0; i < fnts.Length; i++)
            {
                Console.WriteLine(fnts[i].Font.Name);
            }

            //Modify the first FontSetting Font Name
            fnts[0].Font.Name = "Arial";

            //And update it using SetCharacters() method
            cell.SetCharacters(fnts);

            Console.WriteLine();

            Console.WriteLine("After updating the font settings....");

            fnts = cell.GetCharacters();

            for (int i = 0; i < fnts.Length; i++)
            {
                Console.WriteLine(fnts[i].Font.Name);
            }

            //Save workbook
            workbook.Save(outputPath);
        }
    }
}
