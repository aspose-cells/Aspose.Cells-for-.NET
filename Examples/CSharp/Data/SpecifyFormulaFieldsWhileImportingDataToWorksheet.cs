using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    class SpecifyFormulaFieldsWhileImportingDataToWorksheet 
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        //User-defined class to hold data items
        class DataItems
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public string Formula1 { get; set; }
            public string Formula2 { get; set; }
        }

        public static void Run()
        {
            //List to hold data items
            List<DataItems> dis = new List<DataItems>();

            //Define 1st data item and add it in list
            DataItems di = new DataItems();
            di.Number1 = 2002;
            di.Number2 = 3502;
            di.Formula1 = "=SUM(A2,B2)";
            di.Formula2 = "=HYPERLINK(\"https://www.aspose.com\",\"Aspose Website\")";
            dis.Add(di);

            //Define 2nd data item and add it in list
            di = new DataItems();
            di.Number1 = 2003;
            di.Number2 = 3503;
            di.Formula1 = "=SUM(A3,B3)";
            di.Formula2 = "=HYPERLINK(\"https://www.aspose.com\",\"Aspose Website\")";
            dis.Add(di);

            //Define 3rd data item and add it in list
            di = new DataItems();
            di.Number1 = 2004;
            di.Number2 = 3504;
            di.Formula1 = "=SUM(A4,B4)";
            di.Formula2 = "=HYPERLINK(\"https://www.aspose.com\",\"Aspose Website\")";
            dis.Add(di);

            //Define 4th data item and add it in list
            di = new DataItems();
            di.Number1 = 2005;
            di.Number2 = 3505;
            di.Formula1 = "=SUM(A5,B5)";
            di.Formula2 = "=HYPERLINK(\"https://www.aspose.com\",\"Aspose Website\")";
            dis.Add(di);

            //Create workbook object
            Workbook wb = new Workbook();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Specify import table options
            ImportTableOptions opts = new ImportTableOptions();

            //Specify which field is formula field, here the last two fields are formula fields
            opts.IsFormulas = new bool[] { false, false, true, true };

            //Import custom objects
            ws.Cells.ImportCustomObjects(dis, 0, 0, opts);

            //Calculate formula
            wb.CalculateFormula();

            //Autofit columns
            ws.AutoFitColumns();

            //Save the output Excel file
            wb.Save(outputDir + "outputSpecifyFormulaFieldsWhileImportingDataToWorksheet.xlsx");

            Console.WriteLine("SpecifyFormulaFieldsWhileImportingDataToWorksheet executed successfully.");
        }
    }
}
