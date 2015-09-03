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

            //Define a range object(A1).
            Excel.Range _range;
            _range = objSheet.get_Range("A1", "A1");
            //Add a hyperlink to it.
            objSheet.Hyperlinks.Add(_range, "http://www.aspose.com/", Type.Missing, "Click to go to Aspose site", "Aspose Site!");

            //Save the excel file.
            objBook.SaveCopyAs("Hyperlink_test.xls");
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
