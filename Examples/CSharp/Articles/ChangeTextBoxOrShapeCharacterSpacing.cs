using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ChangeTextBoxOrShapeCharacterSpacing
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load your excel file inside a workbook obect
            Workbook wb = new Workbook(sourceDir + "sampleChangeTextBoxOrShapeCharacterSpacing.xlsx");

            // Access your text box which is also a shape object from shapes collection
            Shape shape = wb.Worksheets[0].Shapes[0];

            // Access the first font setting object via GetCharacters() method
            FontSetting fs = (FontSetting)shape.GetCharacters()[0];

            //Set the character spacing to point 4
            fs.TextOptions.Spacing = 4;

            // Save the workbook in xlsx format
            wb.Save(outputDir + "outputChangeTextBoxOrShapeCharacterSpacing.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("ChangeTextBoxOrShapeCharacterSpacing executed successfully.\r\n");
        }
    }
}
