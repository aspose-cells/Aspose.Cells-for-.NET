using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddWordArtWatermarkToWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();

            // Get the first default sheet
            Worksheet sheet = workbook.Worksheets[0];

            // Add Watermark
            Aspose.Cells.Drawing.Shape wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
            "CONFIDENTIAL", "Arial Black", 50, false, true
            , 18, 8, 1, 1, 130, 800);

            // Get the fill format of the word art
           FillFormat wordArtFormat = wordart.Fill;            

            // Set the transparency
            wordArtFormat.Transparency = 0.9;

            // Make the line invisible
            LineFormat lineFormat = wordart.Line;          

            dataDir = dataDir + "Watermark_Test.out.xls";
            // Save the file
            workbook.Save(dataDir);
            // ExEnd:1     

            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
            
        }
    }
}
