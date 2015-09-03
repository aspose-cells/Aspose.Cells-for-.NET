using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace VSTO_CopyWorksheets
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Excel.Workbook newWorkbook = this.Application.Workbooks.Add();
            Excel.Worksheet worksheet = newWorkbook.ActiveSheet;

            Excel.Range cells = worksheet.Cells;
            cells.set_Item(1, 1, "Some Text");

            Excel.Worksheet newWorksheet;
            newWorksheet = (Excel.Worksheet)newWorkbook.Worksheets.Add();

            worksheet.Copy(newWorksheet);
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
