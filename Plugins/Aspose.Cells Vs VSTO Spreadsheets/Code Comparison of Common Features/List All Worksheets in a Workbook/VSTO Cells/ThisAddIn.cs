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
            Excel.Application excelApp = Application;

            //Specify the template excel file path.
            string myPath = @"E:\Dropbox\Personal\aspose-for-vsto\Files\List All Worksheets in a Workbook.xlsx";

            //Open the excel file.
            Microsoft.Office.Interop.Excel.Workbook ThisWorkbook = excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value);
            ListSheets(ThisWorkbook);
            
        }
        private void ListSheets(Microsoft.Office.Interop.Excel.Workbook workbook)
        {
            int index = 0;

            Excel.Range rng = this.Application.get_Range("A1", missing);

            foreach (Excel.Worksheet displayWorksheet in workbook.Worksheets)
            {
                rng.get_Offset(index, 0).Value2 = displayWorksheet.Name;
                index++;
            }
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
