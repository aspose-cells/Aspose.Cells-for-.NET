using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AbsolutePathOfExternalDataSourceFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Load your source excel file containing the external link
            Workbook wb = new Workbook(sourceDir + "sampleAbsolutePathOfExternalDataSourceFile.xlsx");

            // Access the first external link
            ExternalLink externalLink = wb.Worksheets.ExternalLinks[0];

            //Print the data source of external link, it will print existing remote path
            Console.WriteLine("External Link Data Source: " + externalLink.DataSource);

            // Remove remote path and print new data source assign the new data source to external link and print again
            string newDataSource = Path.GetFileName(externalLink.DataSource);
            externalLink.DataSource = newDataSource;
            Console.WriteLine("External Link Data Source After Removing Remote Path: " + externalLink.DataSource);

            // Change the absolute path of the workbook, it will also change the external link path
            wb.AbsolutePath = "C:\\Files\\Extra\\";

            // Now print the data source again
            Console.WriteLine("External Link Data Source After Changing Workbook.AbsolutePath to Local Path: " + externalLink.DataSource);

            // Change the absolute path of the workbook to some remote path, it will again affect the external link path
            wb.AbsolutePath = "http://www.aspose.com/WebFiles/ExcelFiles/";

            // Now print the data source again
            Console.WriteLine("External Link Data Source After Changing Workbook.AbsolutePath to Remote Path: " + externalLink.DataSource);

            Console.WriteLine("\r\nAbsolutePathOfExternalDataSourceFile executed successfully.\r\n");
        }
    }
}
