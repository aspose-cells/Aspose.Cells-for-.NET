using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class UsePresentationPreferenceOption
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleUsePresentationPreferenceOption.xlsx");

            // Create HtmlSaveOptions object
            HtmlSaveOptions options = new HtmlSaveOptions();

            // Set the Presenation preference option
            options.PresentationPreference = true;

            // Save the Excel file to HTML with specified option
            workbook.Save(outputDir + "outputUsePresentationPreferenceOption.html", options);

            Console.WriteLine("UsePresentationPreferenceOption executed successfully.");
        }
    }
}