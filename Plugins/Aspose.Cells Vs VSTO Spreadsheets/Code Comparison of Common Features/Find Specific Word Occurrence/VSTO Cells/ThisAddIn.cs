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
            Excel.Application excelApp = Application;

            //Specify the template excel file path.
            string myPath = "Book1.xls";

            //Open the excel file.
            Microsoft.Office.Interop.Excel.Workbook ThisWorkbook = excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value,
                  Missing.Value, Missing.Value);
            Excel.Worksheet Worksheet = ThisWorkbook.Worksheets["Sheet1"];

            findNow(Worksheet, "test");

            //Save the file.
            excelApp.ActiveWorkbook.Save();

            excelApp.Quit();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        private void findNow(Excel.Worksheet worksheet, string textToFind)
        {
            Excel.Range range;
            string address;
            string first; // it will store the address of the cell where we find the word for the very first time<br/>
            // This is to ensure that we will not trap in a loop
            // As after finding the whole document, search returns to first cell
            // So if we find that the currently finded cell is same to the firstly founded address, then stop the processing

            range = worksheet.Cells.Find(textToFind, worksheet.get_Range("A1", "A1"),
            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
            false, false);
            // This will find the 1st occurance of the word in our Excel file

            if (range != null) // Check whether it has found something in our file or not
            {
                first = range.get_Address(
                    true, true, Excel.XlReferenceStyle.xlA1, null, null); // Save the address of the first found item

                MessageBox.Show("1st match found at cell " + first);

                range = worksheet.Cells.FindNext(range);
                // Continue searching items using FindNext

                address = range.get_Address(
                    true, true, Excel.XlReferenceStyle.xlA1, null, null);
                // get the address of newly searched cell

                while (!address.Equals(first))
                {
                    // this loop will find all the occurances of your word
                    MessageBox.Show("match found at cell " + address);
                    range = worksheet.Cells.FindNext(range);
                    address = range.get_Address(
                      true, true, Excel.XlReferenceStyle.xlA1, null, null);
                }
            }
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
