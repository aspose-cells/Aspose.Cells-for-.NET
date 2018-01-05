using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers
{
    class AutoPopulateSmartMarkerDataToOtherWorksheets 
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create employees data table
            DataTable dt = new DataTable("Employees");
            dt.Columns.Add("EmployeeID", typeof(int));

            //Add rows inside the data table
            dt.Rows.Add(1230);
            dt.Rows.Add(1231);
            dt.Rows.Add(1232);
            dt.Rows.Add(1233);
            dt.Rows.Add(1234);
            dt.Rows.Add(1235);
            dt.Rows.Add(1236);
            dt.Rows.Add(1237);
            dt.Rows.Add(1238);
            dt.Rows.Add(1239);
            dt.Rows.Add(1240);
            dt.Rows.Add(1241);
            dt.Rows.Add(1242);
            dt.Rows.Add(1243);
            dt.Rows.Add(1244);
            dt.Rows.Add(1245);
            dt.Rows.Add(1246);
            dt.Rows.Add(1247);
            dt.Rows.Add(1248);
            dt.Rows.Add(1249);
            dt.Rows.Add(1250);

            //Create data reader from data table
            DataTableReader dtReader = dt.CreateDataReader();

            //Create empty workbook
            Workbook wb = new Workbook();

            //Access first worksheet and add smart marker in cell A1
            Worksheet ws = wb.Worksheets[0];
            ws.Cells["A1"].PutValue("&=Employees.EmployeeID");

            //Add second worksheet and add smart marker in cell A1
            wb.Worksheets.Add();
            ws = wb.Worksheets[1];
            ws.Cells["A1"].PutValue("&=Employees.EmployeeID");

            //Create workbook designer
            WorkbookDesigner wd = new WorkbookDesigner(wb);

            //Set data source with data reader
            wd.SetDataSource("Employees", dtReader, 15);

            //Process smart marker tags in first and second worksheet
            wd.Process(0, false);
            wd.Process(1, false);

            //Save the workbook
            wb.Save(outputDir + "outputAutoPopulateSmartMarkerDataToOtherWorksheets.xlsx");

            Console.WriteLine("AutoPopulateSmartMarkerDataToOtherWorksheets executed successfully.\r\n");
        }
    }
}
