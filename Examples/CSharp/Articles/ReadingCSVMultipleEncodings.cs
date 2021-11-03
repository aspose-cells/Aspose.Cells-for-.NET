using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ReadingCSVMultipleEncodings
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Set Multi Encoded Property to True
            TxtLoadOptions options = new TxtLoadOptions();
            options.IsMultiEncoded = true;

            // Load the csv file into Workbook
            Workbook workbook = new Workbook(sourceDir + "sampleReadingCSVMultipleEncodings.csv", options);

            // Save it in XLSX format
            workbook.Save(outputDir + "outputReadingCSVMultipleEncodings.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("ReadingCSVMultipleEncodings executed successfully.");
        }
    }
}