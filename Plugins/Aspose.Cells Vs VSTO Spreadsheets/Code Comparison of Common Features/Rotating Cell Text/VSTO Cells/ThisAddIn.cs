using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Drawing;

namespace VSTO_Cells
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //intiate Application object
            Excel.Application ExcelApp = Application;
            //Add a Workbook.
            Excel.Workbook objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Get the First sheet.
            Excel.Worksheet objSheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];

            //Put some text into cell B2.
            objSheet.Cells[2, 2] = "Aspose Heading";

            //Define a range object(B2).
            Excel.Range _range;
            _range = objSheet.get_Range("B2", "B2");

            //Specify the angle of rotation of the text.
            _range.Orientation = 45;

            //Set the background color.
            _range.Interior.Color = System.Drawing.ColorTranslator.ToWin32(Color.FromArgb(0, 51, 105));

            //Set the font color of cell text
            _range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            //Save the excel file.
            objBook.SaveCopyAs("VSTO_RotateText_test.xlsx");

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
