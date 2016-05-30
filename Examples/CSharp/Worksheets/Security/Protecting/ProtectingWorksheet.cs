using System.IO;

using Aspose.Cells;

namespace CSharp.Worksheets.Security.Protecting
{
    public class ProtectingWorksheet
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
            Workbook excel = new Workbook(fstream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = excel.Worksheets[0];

            // Protecting the worksheet with a password
            worksheet.Protect(ProtectionType.All, "aspose", null);

            // Saving the modified Excel file in default format
            excel.Save(dataDir + "output.out.xls", SaveFormat.Excel97To2003);

            // Closing the file stream to free all resources
            fstream.Close();
            // ExEnd:1

        }
    }
}
