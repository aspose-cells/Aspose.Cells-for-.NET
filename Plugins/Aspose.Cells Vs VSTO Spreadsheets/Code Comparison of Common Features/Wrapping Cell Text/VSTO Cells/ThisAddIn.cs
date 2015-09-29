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
            //Access vsto application
            Microsoft.Office.Interop.Excel.Application app = Globals.ThisAddIn.Application;

            //Access workbook 
            Microsoft.Office.Interop.Excel.Workbook workbook = app.ActiveWorkbook;

            //Access worksheet 
            Microsoft.Office.Interop.Excel.Worksheet m_sheet = workbook.Worksheets[1];

            //Access vsto worksheet
            Microsoft.Office.Tools.Excel.Worksheet sheet = Globals.Factory.GetVstoObject(m_sheet);

            //Place some text in cell A1 without wrapping
            Microsoft.Office.Interop.Excel.Range cellA1 = sheet.Cells.get_Range("A1");
            cellA1.Value = "Sample Text Unwrapped";

            //Place some text in cell A5 with wrapping
            Microsoft.Office.Interop.Excel.Range cellA5 = sheet.Cells.get_Range("A5");
            cellA5.Value = "Sample Text Wrapped";
            cellA5.WrapText = true;

            //Save the workbook
            workbook.SaveAs("OutputVsto.xlsx");

            //Quit the application
            app.Quit();
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
