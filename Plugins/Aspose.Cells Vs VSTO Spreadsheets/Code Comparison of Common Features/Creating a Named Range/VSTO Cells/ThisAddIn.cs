using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Reflection;

namespace VSTO_Cells
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Create Excel Object
            Excel.Application xl = Application;

            //Create a new Workbook
            Excel.Workbook wb = xl.Workbooks.Add(Missing.Value);

            //Get Worksheets Collection
            Excel.Sheets xlsheets = wb.Sheets;

            //Select the first sheet
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)xlsheets[1];

            //Select a range of cells
            Excel.Range range = (Excel.Range)excelWorksheet.get_Range("A1:B4", Type.Missing);

            //Add Name to Range
            range.Name = "Test_Range";

            //Put data in range cells
            foreach (Excel.Range cell in range.Cells)
            {
                cell.set_Value(Missing.Value, "Test");
            }

            //Save New Workbook
            wb.SaveCopyAs("Test_Range.xls");

            //Quit Excel Object
            xl.Quit();
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
