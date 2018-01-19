using System;
using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ModifyExistingStyle
{
    public class ModifyThroughSampleExcelFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load the workbook
            Workbook workbook = new Workbook(sourceDir + "sampleModifyThroughSampleExcelFile.xlsx");

            // Get named style
            Style style = workbook.GetNamedStyle("MyCustomStyle");

            // Set the font color.
            style.Font.Color = System.Drawing.Color.Red;
            style.ForegroundColor = Color.Green;

            // Update the style. 
            style.Update();

            // Save the excel file.	
            workbook.Save(outputDir + "outputModifyThroughSampleExcelFile.xlsx");

            Console.WriteLine("ModifyThroughSampleExcelFile executed successfully.");
        }
    }
}
