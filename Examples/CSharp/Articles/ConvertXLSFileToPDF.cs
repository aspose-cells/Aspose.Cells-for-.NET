using System;
using System.IO;
using Aspose.Cells;

namespace CSharp.Articles
{
    public class ConvertXLSFileToPDF
    {

        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {

                // Get the template excel file path.
                string designerFile = dataDir + "SampleInput.xlsx";
                // Specify the pdf file path.
                string pdfFile = dataDir + "Output.out.pdf";
                // Create a new Workbook.
                // Open the template excel file which you have to
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(designerFile);
                // Save the pdf file.
                wb.Save(pdfFile, SaveFormat.Pdf);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

            }
            // ExEnd:1
        }

    }
}
