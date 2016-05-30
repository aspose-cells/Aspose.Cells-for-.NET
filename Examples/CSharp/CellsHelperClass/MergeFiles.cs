using System.IO;
using System;
using Aspose.Cells;

namespace CSharp.CellsHelperClass
{
    public class MergeFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
           
            // Create an Array (length=2)
            string[] files = new string[2];
            // Specify files with their paths to be merged
            files[0] = dataDir + "Book1.xls";
            files[1] = dataDir + "Book2.xls";
            
            // Create a cachedFile for the process
            string cacheFile = dataDir + "test.txt";
            
            // Output File to be created
            string dest = dataDir + "output.xlsx";

            // Merge the files in the output file. Supports only .xls files
            CellsHelper.MergeFiles(files, cacheFile, dest);


            // Now if you need to rename your sheets, you may load the output file
            Workbook workbook = new Workbook(dataDir + "output.xlsx");

            int i = 1;

            // Browse all the sheets to rename them accordingly
            foreach (Worksheet sheet in workbook.Worksheets)
            {
                sheet.Name = "Sheet1" + i.ToString();
                i++;

            }

            // Re-save the file
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1


        }
    }
}
