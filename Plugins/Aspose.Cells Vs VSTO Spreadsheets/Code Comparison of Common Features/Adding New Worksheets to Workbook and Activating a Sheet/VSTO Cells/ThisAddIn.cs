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
            string myPath = "Book1.xls";

            //Open the excel file.
            excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);

            //Declare a Worksheet object.
            Excel.Worksheet newWorksheet;

            //Add 5 new worksheets to the workbook and fill some data
            //into the cells.
            for (int i = 1; i < 6; i++)
            {

                //Add a worksheet to the workbook.
                newWorksheet = (Excel.Worksheet)excelApp.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                //Name the sheet.
                newWorksheet.Name = "New_Sheet" + i.ToString();

                //Get the Cells collection.
                Excel.Range cells = newWorksheet.Cells;

                //Input a string value to a cell of the sheet.
                cells.set_Item(i, i, "New_Sheet" + i.ToString());
            }

            //Activate the first worksheet by default.
            ((Excel.Worksheet)excelApp.ActiveWorkbook.Sheets[1]).Activate();

            //Save As the excel file.
            excelApp.ActiveWorkbook.SaveCopyAs("out_Book1.xls");

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
