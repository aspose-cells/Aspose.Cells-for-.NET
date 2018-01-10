using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class SettingScaleCropAndLinksUpToDateProperties
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Setting ScaleCrop and LinksUpToDate BuiltIn Document Properties
            workbook.BuiltInDocumentProperties.ScaleCrop = true;
            workbook.BuiltInDocumentProperties.LinksUpToDate = true;

            // Saving the Excel file
            workbook.Save(outputDir + "outputSettingScaleCropAndLinksUpToDateProperties.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SettingScaleCropAndLinksUpToDateProperties executed successfully.");
        }
    }
}
