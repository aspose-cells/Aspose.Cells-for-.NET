using System.IO;
using System;
using Aspose.Cells;

namespace CSharp.Articles
{
    public class CombineMultipleWorkbooksSingleWorkbook
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            // Define the first source
            // Open the first excel file.
            Workbook SourceBook1 = new Workbook(dataDir+ "SampleChart.xlsx");

            // Define the second source book.
            // Open the second excel file.
            Workbook SourceBook2 = new Workbook(dataDir+ "SampleImage.xlsx");

            // Combining the two workbooks
            SourceBook1.Combine(SourceBook2);

            dataDir = dataDir + "Combined.out.xlsx";
            // Save the target book file.
            SourceBook1.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
        }
    }
}
