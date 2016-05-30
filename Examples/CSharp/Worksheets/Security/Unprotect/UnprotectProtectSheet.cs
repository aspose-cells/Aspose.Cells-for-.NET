using System.IO;
using System;
using Aspose.Cells;

namespace CSharp.Worksheets.Security.Unprotect
{
    public class UnprotectingProtectedWorksheet
    {
        public static void Run()
        {
            try
            {
                // ExStart:1
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                // Instantiating a Workbook object
                Workbook workbook = new Workbook(dataDir + "book1.xls");

                // Accessing the first worksheet in the Excel file
                Worksheet worksheet = workbook.Worksheets[0];

                // Unprotecting the worksheet with a password
                worksheet.Unprotect("");

                // Save Workbook
                workbook.Save(dataDir + "output.out.xls");
                // ExEnd:1
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
    }
}
