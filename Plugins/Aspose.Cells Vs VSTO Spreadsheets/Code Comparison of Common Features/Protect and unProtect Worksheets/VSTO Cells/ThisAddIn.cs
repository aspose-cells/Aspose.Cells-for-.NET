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
            //Excel.Application excelApp = Application;

            //Specify the template excel file path.
            string myPath = "Protect and unProtect Worksheets.xlsx";

            //Open the excel file.

            excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);

            //Protect the worksheet specifying a password with Structure and Windows attributes.
            ((Excel.Worksheet)excelApp.ActiveSheet).Protect("thispassword",
                missing, missing, missing, missing, missing, missing, missing, missing,
                missing, missing, missing, missing, true, missing, missing);

            //Unprotect the worksheet specifying its password.
            ((Excel.Worksheet)excelApp.ActiveSheet).Unprotect("thispassword");

            //Save the file.
            excelApp.ActiveWorkbook.Save();

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
