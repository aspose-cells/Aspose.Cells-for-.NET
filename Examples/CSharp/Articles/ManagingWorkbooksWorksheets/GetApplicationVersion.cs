using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class GetApplicationVersion
    {
        public static void Run()
        {
            // ExStart:1
            // Create a workbook reference
            Workbook workbook = null;

            // Print the version number of Excel 2003 XLS file
            workbook = new Workbook("Excel2003.xls");
            Console.WriteLine("Excel 2003 XLS Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2007 XLS file
            workbook = new Workbook("Excel2007.xls");
            Console.WriteLine("Excel 2007 XLS Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2010 XLS file
            workbook = new Workbook("Excel2010.xls");
            Console.WriteLine("Excel 2010 XLS Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2013 XLS file
            workbook = new Workbook("Excel2013.xls");
            Console.WriteLine("Excel 2013 XLS Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2007 XLSX file
            workbook = new Workbook("Excel2007.xlsx");
            Console.WriteLine("Excel 2007 XLSX Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2010 XLSX file
            workbook = new Workbook("Excel2010.xlsx");
            Console.WriteLine("Excel 2010 XLSX Version: " + workbook.BuiltInDocumentProperties.Version);

            // Print the version number of Excel 2013 XLSX file
            workbook = new Workbook("Excel2013.xlsx");
            Console.WriteLine("Excel 2013 XLSX Version: " + workbook.BuiltInDocumentProperties.Version);
            // ExEnd:1
        }
    }
}
