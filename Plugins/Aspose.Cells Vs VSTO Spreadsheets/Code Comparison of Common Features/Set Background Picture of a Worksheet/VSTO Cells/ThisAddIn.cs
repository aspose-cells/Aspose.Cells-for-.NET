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
            //Get the First sheet.
            Excel.Worksheet objSheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];

            //Set a background picture for the sheet.
            objSheet.SetBackgroundPicture("pic.jpeg");

            //Save the excel file.
            objBook.SaveCopyAs("BackgroundPicBook.xls");
            //Quit the Application.
            ExcelApp.Quit();
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
