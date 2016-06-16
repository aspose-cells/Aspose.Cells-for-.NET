using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.Handling.Find
{
    public class FindingCellsContainingFormula
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

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Finding the cell containing the specified formula
            Cell cell = worksheet.Cells.FindFormula("=SUM(A5:A10)", null);

            // Printing the name of the cell found after searching worksheet
            System.Console.WriteLine("Name of the cell containing formula: " + cell.Name);

            // Closing the file stream to free all resources
            fstream.Close();
        // ExEnd:1
        }
    }
}
