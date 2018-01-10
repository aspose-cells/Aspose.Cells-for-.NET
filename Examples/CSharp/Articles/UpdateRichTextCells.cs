using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class UpdateRichTextCells
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            Workbook workbook = new Workbook(sourceDir + "sampleUpdateRichTextCells.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell = worksheet.Cells["A1"];

            Console.WriteLine("Before updating the font settings....");

            FontSetting[] fnts = cell.GetCharacters();

            for (int i = 0; i < fnts.Length; i++)
            {
                Console.WriteLine(fnts[i].Font.Name);
            }

            // Modify the first FontSetting Font Name
            fnts[0].Font.Name = "Arial";

            // And update it using SetCharacters() method
            cell.SetCharacters(fnts);

            Console.WriteLine();

            Console.WriteLine("After updating the font settings....");

            fnts = cell.GetCharacters();

            for (int i = 0; i < fnts.Length; i++)
            {
                Console.WriteLine(fnts[i].Font.Name);
            }

            // Save workbook
            workbook.Save(outputDir + "outputUpdateRichTextCells.xlsx");

            Console.WriteLine("UpdateRichTextCells executed successfully.");
        }
    }
}
