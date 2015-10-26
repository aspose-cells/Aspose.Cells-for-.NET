using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace VSTO_Cells
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Instantiate the Application object.
            Excel.Application ExcelApp = Application;
            //Add a Workbook.
            Excel.Workbook objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            // Access a Vsto Worksheet
            Microsoft.Office.Interop.Excel.Worksheet nativeWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            Microsoft.Office.Tools.Excel.Worksheet sheet = Globals.Factory.GetVstoObject(nativeWorksheet);

            //Add sample data for pie chart
            //Add headings in A1 and B1
            sheet.Cells[1, 1] = "Products";
            sheet.Cells[1, 2] = "Users";

            //Add data from A2 till B4
            sheet.Cells[2, 1] = "Aspose.Cells";
            sheet.Cells[2, 2] = 10000;
            sheet.Cells[3, 1] = "Aspose.Slides";
            sheet.Cells[3, 2] = 8000;
            sheet.Cells[4, 1] = "Aspose.Words";
            sheet.Cells[4, 2] = 12000;

            //Chart reference
            Microsoft.Office.Tools.Excel.Chart productsChart;

            //Add a Pie Chart
            productsChart = sheet.Controls.AddChart(0, 105, 330, 200, "ProductUsers");
            productsChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPie;

            //Set chart title
            productsChart.HasTitle = true;
            productsChart.ChartTitle.Text = "Users";

            //Gets the cells that define the data to be charted.
            Microsoft.Office.Interop.Excel.Range chartRange = sheet.get_Range("A2", "B4");
            productsChart.SetSourceData(chartRange, missing);

            //Access the Active workbook from Vsto sheet
            Microsoft.Office.Interop.Excel.Workbook workbook = sheet.Application.ActiveWorkbook;

            //Save the copy of workbook as OutputVsto.xlsx
            workbook.SaveCopyAs("OutputVsto.xlsx");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
