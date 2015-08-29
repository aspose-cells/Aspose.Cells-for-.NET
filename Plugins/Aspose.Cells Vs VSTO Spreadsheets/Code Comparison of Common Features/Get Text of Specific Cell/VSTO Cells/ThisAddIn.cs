using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Reflection;
using System.Windows.Forms;

namespace VSTO_Cells
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Instantiate the Application object.
            Excel.Application excelApp = Application;

            //Specify the template excel file path.
            string myPath = "Get Text of Specific Cell.xlsx";

            //Open the excel file.
            Microsoft.Office.Interop.Excel.Workbook ThisWorkbook = excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value);

            String res = "";
            res = ThisWorkbook.Worksheets["Sheet1"].Range("A1").Text;

            MessageBox.Show(res);

            //Save the file.
            excelApp.ActiveWorkbook.Save();

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
