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

            //Put some text into different cells (A2, A4, A6, A8).
            objSheet.Cells[2, 1] = "Hair Lines";
            objSheet.Cells[4, 1] = "Thin Lines";
            objSheet.Cells[6, 1] = "Medium Lines";
            objSheet.Cells[8, 1] = "Thick Lines";

            //Define a range object(A2).
            Excel.Range _range;
            _range = objSheet.get_Range("A2", "A2");
            //Get the borders collection.
            Excel.Borders borders = _range.Borders;
            //Set the hair lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 1d;

            //Define a range object(A4).
            _range = objSheet.get_Range("A4", "A4");
            //Get the borders collection.
            borders = _range.Borders;
            //Set the thin lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;

            //Define a range object(A6).
            _range = objSheet.get_Range("A6", "A6");
            //Get the borders collection.
            borders = _range.Borders;
            //Set the medium lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 3d;

            //Define a range object(A8).
            _range = objSheet.get_Range("A8", "A8");
            //Get the borders collection.
            borders = _range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 4d;

            //Auto-fit Column A.
            objSheet.get_Range("A2", "A2").EntireColumn.AutoFit();

            //Save the excel file.
            objBook.SaveAs("ApplyBorders.xls",
            Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8,
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Type.Missing);

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
