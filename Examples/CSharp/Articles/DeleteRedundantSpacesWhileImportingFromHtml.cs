using System;
using System.IO;
using System;
using Aspose.Cells;
using System.Collections;

namespace CSharp.Articles
{
    public class DeleteRedundantSpacesWhileImportingFromHtml
    {
        public static void Run()
        {
            // ExStart:DeleteRedundantSpacesWhileImportingFromHtml
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Sample Html containing redundant spaces after <br> tag
            string html = "<html> <body> <table> <tr> <td> <br>    This is sample data <br>    This is sample data<br>    This is sample data</td> </tr> </table> </body> </html>";

            // Convert Html to byte array
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(html);

            // Set Html load options and keep precision true
            HTMLLoadOptions loadOptions = new Aspose.Cells.HTMLLoadOptions(LoadFormat.Html);
            loadOptions.DeleteRedundantSpaces = true;

            // Convert byte array into stream
            MemoryStream stream = new MemoryStream(byteArray);

            // Create workbook from stream with Html load options
            Workbook workbook = new Workbook(stream, loadOptions);

            // Access first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Auto fit the sheet columns
            sheet.AutoFitColumns();

            dataDir = dataDir + "DeleteRedundantSpaces_out_.xlsx";

            // Save the workbook
            workbook.Save(dataDir, SaveFormat.Xlsx);
            // ExEnd:DeleteRedundantSpacesWhileImportingFromHtml           
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir); 
        }
    }
}
