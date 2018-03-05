using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp._CellsHelper
{
    public class MergeFiles
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Create an Array (length=2)
            string[] files = new string[2];

            // Specify files with their paths to be merged
            files[0] = sourceDir + "sampleMergeFiles_Book1.xls";
            files[1] = sourceDir + "sampleMergeFiles_Book2.xls";

            // Create a cachedFile for the process
            string cacheFile = outputDir + "cacheMergeFiles.txt";

            // Output File to be created
            string dest = outputDir + "outputMergeFiles.xls";

            // Merge the files in the output file. Supports only .xls files
            CellsHelper.MergeFiles(files, cacheFile, dest);

            // Now if you need to rename your sheets, you may load the output file
            Workbook workbook = new Workbook(outputDir + "outputMergeFiles.xls");

            // Browse all the sheets to rename them accordingly
            int i = 1;
            foreach (Worksheet sheet in workbook.Worksheets)
            {
                sheet.Name = "Sheet1" + i.ToString();
                i++;
            }

            // Re-save the file
            workbook.Save(outputDir + "outputMergeFiles.xls");

            Console.WriteLine("MergeFiles executed successfully.");
        }
    }
}
