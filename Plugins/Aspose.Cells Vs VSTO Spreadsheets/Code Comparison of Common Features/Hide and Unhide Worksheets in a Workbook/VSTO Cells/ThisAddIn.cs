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
            //Instantiate the Application object.
            Excel.Application excelApp = Application;

            //Specify the template Excel file path.
            string myPath = "Book1.xls";

            //Open the Excel file.
            excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);

            //Get the first sheet.
            Excel.Worksheet objSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.Sheets["Sheet1"];

            //Hide the worksheet.
            objSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

            //Save As the Excel file.
            excelApp.ActiveWorkbook.Save();

            //Unhide the worksheet.
            objSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            //Quit the Application.
            excelApp.Quit();
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
