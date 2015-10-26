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
            Microsoft.Office.Tools.Excel.Worksheet worksheet = Globals.Factory.GetVstoObject(m_sheet);

            //Access cells A1, A2, A3 , A4
            Microsoft.Office.Interop.Excel.Range cellA1 = worksheet.Range["A1"];
            Microsoft.Office.Interop.Excel.Range cellA2 = worksheet.Range["A2"];
            Microsoft.Office.Interop.Excel.Range cellA3 = worksheet.Range["A3"];
            Microsoft.Office.Interop.Excel.Range cellA4 = worksheet.Range["A4"];

            //Set integer values in cells A1, A2 and A3
            cellA1.Value = 10;
            cellA2.Value = 20;
            cellA3.Value = 30;

            //Add formula in cell A4
            cellA4.Formula = "=Sum(A1:A3)";

            //Set the font bold in cell A4
            cellA4.Font.Bold = true;

            //Set the background color to Yellow in cell A4
            cellA4.Interior.Color = Excel.XlRgbColor.rgbYellow;

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
