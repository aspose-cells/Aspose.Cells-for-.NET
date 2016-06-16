using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Management
{
    public class AddWorksheetsToExistingExcelFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(dataDir + "book1.xls", FileMode.Open);

            // Instantiating a Workbook object
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            // Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            // Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet";

            // Saving the Excel file
            workbook.Save(dataDir + "output.out.xls");

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1
            
            
        }
    }
}
