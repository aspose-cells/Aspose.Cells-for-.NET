using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SaveEachWorksheetToDifferentPDF
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            // Instantiage a new workbook and open the Excel, File from its location
            Workbook workbook = new Workbook(sourceDir + "sampleSaveEachWorksheetToDifferentPDF.xlsx");

            // Get the count of the worksheets in the workbook
            int sheetCount = workbook.Worksheets.Count;

            // Make all sheets invisible except first worksheet
            for (int i = 1; i < workbook.Worksheets.Count; i++)
            {
                workbook.Worksheets[i].IsVisible = false;
            }

            // Take Pdfs of each sheet
            for (int j = 0; j < workbook.Worksheets.Count; j++)
            {
                Worksheet ws = workbook.Worksheets[j];
                workbook.Save(outputDir + "outputSaveEachWorksheetToDifferentPDF-" + ws.Name + ".pdf");

                if (j < workbook.Worksheets.Count - 1)
                {
                    workbook.Worksheets[j + 1].IsVisible = true;
                    workbook.Worksheets[j].IsVisible = false;
                }
            }

            Console.WriteLine("SaveEachWorksheetToDifferentPDF executed successfully.");
        }
    }
}