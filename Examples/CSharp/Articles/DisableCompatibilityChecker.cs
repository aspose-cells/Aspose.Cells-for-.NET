using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DisableCompatibilityChecker
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Open a template file
            Workbook workbook = new Workbook(dataDir+ "sample.xlsx");

            // Disable the compatibility checker
            workbook.Settings.CheckComptiliblity = false;

            dataDir = dataDir+ "Output_BK_CompCheck.out.xlsx";
            // Saving the Excel file
            workbook.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir); 
            
        }
    }
}
