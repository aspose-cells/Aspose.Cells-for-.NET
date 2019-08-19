using System;
using System.IO;
using Aspose.Cells;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DeleteRedundantSpacesWhileImportingFromHtml
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            // Sample Html containing redundant spaces after <br> tag
            string html = "<html> <body> <table> <tr> <td> <br>    This is sample data <br>    This is sample data<br>    This is sample data</td> </tr> </table> </body> </html>";

            // Convert Html to byte array
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(html);

            // Set Html load options and keep precision true
            HtmlLoadOptions loadOptions = new Aspose.Cells.HtmlLoadOptions(LoadFormat.Html);
            loadOptions.DeleteRedundantSpaces = true;

            // Convert byte array into stream
            MemoryStream stream = new MemoryStream(byteArray);

            // Create workbook from stream with Html load options
            Workbook workbook = new Workbook(stream, loadOptions);

            // Access first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Auto fit the sheet columns
            sheet.AutoFitColumns();

            // Save the workbook
            workbook.Save(outputDir + "outputDeleteRedundantSpacesWhileImportingFromHtml.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

            Console.WriteLine("DeleteRedundantSpacesWhileImportingFromHtml executed successfully.\r\n");
        }
    }
}
