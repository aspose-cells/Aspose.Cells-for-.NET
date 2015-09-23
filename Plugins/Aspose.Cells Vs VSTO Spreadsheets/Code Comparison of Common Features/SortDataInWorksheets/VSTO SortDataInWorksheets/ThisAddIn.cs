using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace VSTO_SortDataInWorksheets
{
    public partial class ThisAddIn
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\VSTO_SortDataInWorksheet.xlsx";
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Excel.Workbook myWorkbook = this.Application.Workbooks.Open(fileName);
            Excel.Worksheet mySheet = myWorkbook.ActiveSheet;

            Excel.Range Colors = mySheet.get_Range("A1", "A10");
            Colors.Sort(
    Colors.Rows[1], Excel.XlSortOrder.xlAscending,
    Colors.Rows[2], missing, Excel.XlSortOrder.xlAscending,
    missing, Excel.XlSortOrder.xlAscending,
    Excel.XlYesNoGuess.xlNo, missing, missing,
    Excel.XlSortOrientation.xlSortColumns,
    Excel.XlSortMethod.xlPinYin,
    Excel.XlSortDataOption.xlSortNormal,
    Excel.XlSortDataOption.xlSortNormal,
    Excel.XlSortDataOption.xlSortNormal);
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
