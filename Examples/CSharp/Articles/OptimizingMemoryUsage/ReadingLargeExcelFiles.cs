using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.OptimizingMemoryUsage
{
    public class ReadingLargeExcelFiles
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            
            // Specify the LoadOptions
            LoadOptions opt = new LoadOptions();
            
            // Set the memory preferences
            opt.MemorySetting = MemorySetting.MemoryPreference;

            // Instantiate the Workbook
            // Load the Big Excel file having large Data set in it
            Workbook wb = new Workbook(sourceDir + "sampleReadingLargeExcelFiles.xlsx", opt);

            Console.WriteLine("ReadingLargeExcelFiles executed successfully.");
        }
    }
}
