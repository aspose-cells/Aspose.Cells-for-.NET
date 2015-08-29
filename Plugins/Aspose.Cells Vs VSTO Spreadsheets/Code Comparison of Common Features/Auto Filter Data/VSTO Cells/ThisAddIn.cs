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
            Excel.Application ExcelApp = Application;

            //Add a Workbook.
            Excel.Workbook objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Get the First sheet.
            Excel.Worksheet sheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];

            //Add data into A1 and B1 Cells as headers.
            sheet.Cells[1, 1] = "Product ID";
            sheet.Cells[1, 2] = "Product Name";

            //Add data into details cells.
            sheet.Cells[2, 1] = 1;
            sheet.Cells[3, 1] = 2;
            sheet.Cells[4, 1] = 3;
            sheet.Cells[5, 1] = 4;
            sheet.Cells[2, 2] = "Apples";
            sheet.Cells[3, 2] = "Bananas";
            sheet.Cells[4, 2] = "Grapes";
            sheet.Cells[5, 2] = "Oranges";

            //Enable Auto-filter.           
            sheet.EnableAutoFilter = true;

            //Create the range.
            Excel.Range range = sheet.get_Range("A1", "B5");

            //Auto-filter the range.
            range.AutoFilter("1", "<>", Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlOr, "", true);

            //Auto-fit the second column.
            sheet.get_Range("B1", "B5").EntireColumn.AutoFit();

            //Save the copy of workbook as .xlsx file.
            objBook.SaveCopyAs("vsto_autofilter.xlsx");
 
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
