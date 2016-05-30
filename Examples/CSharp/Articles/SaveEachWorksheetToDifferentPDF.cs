using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class SaveEachWorksheetToDifferentPDF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            

            // Get the Excel file path
            string filePath = dataDir+ "input.xlsx";

            // Instantiage a new workbook and open the Excel
            // File from its location
            Workbook workbook = new Workbook(filePath);

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
            workbook.Save(dataDir+ "worksheet-" + ws.Name + ".out.pdf");

                if (j < workbook.Worksheets.Count - 1)
         {
                 workbook.Worksheets[j + 1].IsVisible = true;
                 workbook.Worksheets[j].IsVisible = false;
    }
}


            
            
        }
    }
}