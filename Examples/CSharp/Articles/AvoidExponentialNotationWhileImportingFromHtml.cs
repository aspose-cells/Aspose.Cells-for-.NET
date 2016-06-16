using System.IO;
using System;
using Aspose.Cells;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AvoidExponentialNotationWhileImportingFromHtml
    {
        public static void Run()
        {
            // ExStart:AvoidExponentialNotationOfHTML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Sample Html containing large number with digits greater than 15
            string html = "<html><body><p>1234567890123456</p></body></html>";

            // Convert Html to byte array
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(html);

            // Set Html load options and keep precision true
            HTMLLoadOptions loadOptions = new Aspose.Cells.HTMLLoadOptions(LoadFormat.Html);
            loadOptions.KeepPrecision = true;

            // Convert byte array into stream
            MemoryStream stream = new MemoryStream(byteArray);

            // Create workbook from stream with Html load options
            Workbook workbook = new Workbook(stream, loadOptions);

            // Access first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Auto fit the sheet columns
            sheet.AutoFitColumns();

            dataDir = dataDir + "AvoidExponentialNotationOfHTML.xlsx";
            // Save the workbook
            workbook.Save(dataDir, SaveFormat.Xlsx);
            // ExEnd:AvoidExponentialNotationOfHTML    

            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
            
        }
    }
}
