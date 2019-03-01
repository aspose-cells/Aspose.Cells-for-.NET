using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.RowsColumns.InsertingAndDeleting
{
    public class InsertingARowWithFormating
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

            // Inserting a row into the worksheet at 3rd position
            InsertOptions insertOptions = new InsertOptions();
            insertOptions.CopyFormatType = CopyFormatType.SameAsAbove;
            worksheet.Cells.InsertRows(2, 1, insertOptions);

            // Saving the modified Excel file
            workbook.Save(dataDir + "InsertingARowWithFormating.out.xls");

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1

        }
    }
}
