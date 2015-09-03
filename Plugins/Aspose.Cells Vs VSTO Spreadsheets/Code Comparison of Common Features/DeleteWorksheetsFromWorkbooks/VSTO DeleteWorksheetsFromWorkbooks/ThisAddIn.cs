using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace VSTO_DeleteWorksheetsFromWorkbooks
{
    public partial class ThisAddIn
    {
        private string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\DeleteWorksheetsFromWorkbooks.xlsx";
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
         Excel.Workbook myWorkbook=   this.Application.Workbooks.Open(fileName);
         myWorkbook.Sheets[2].Delete();


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
