using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        Aspose.Cells.GridWeb.GridTableItemStyle style = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Add();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;
            }
        }

        // Handles the "create invoice" button click event and create an invoice.
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            GridWorksheetCollection sheets = GridWeb1.WorkSheets;

            // Clears all sheets.
            sheets.Clear();

            // Creates a new worksheet named "Invoice".
            GridWorksheet sheet = sheets.Add("Invoice");

            sheet.Cells[0, 0].Value = "Order ID";
            // Sets the font size of the cell.
            sheet.Cells[0, 0].Style.Font.Size = new FontUnit("10pt");
            sheet.Cells[0, 0].Style.Font.Bold = true;
            sheet.Cells[0, 0].Style.ForeColor = Color.Blue;
            sheet.Cells[0, 0].Style.BackColor = Color.Aqua;
            sheet.Cells[0, 0].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[0, 0].Style.BorderStyle = BorderStyle.Double;
            sheet.Cells[0, 0].Style.BorderColor = Color.Gold;
            sheet.Cells[0, 0].Style.BorderWidth = 3;

            sheet.Cells[0, 1].Value = "Customer ID";
            // Another way to set the font size.
            sheet.Cells[0, 1].Style.Font.Size = new FontUnit(new Unit(10, UnitType.Point));
            sheet.Cells[0, 1].Style.Font.Bold = true;
            sheet.Cells[0, 1].Style.ForeColor = Color.Blue;
            sheet.Cells[0, 1].Style.BackColor = Color.Aqua;
            sheet.Cells[0, 1].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[0, 1].Style.BorderStyle = BorderStyle.Double;
            sheet.Cells[0, 1].Style.BorderColor = Color.Gold;
            sheet.Cells[0, 1].Style.BorderWidth = 3;

            sheet.Cells[0, 2].Value = "Salesperson";
            sheet.Cells[0, 2].Style.Font.Size = new FontUnit("10pt");
            sheet.Cells[0, 2].Style.Font.Bold = true;
            sheet.Cells[0, 2].Style.ForeColor = Color.Blue;
            sheet.Cells[0, 2].Style.BackColor = Color.Aqua;
            sheet.Cells[0, 2].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[0, 2].Style.BorderStyle = BorderStyle.Double;
            sheet.Cells[0, 2].Style.BorderColor = Color.Gold;
            sheet.Cells[0, 2].Style.BorderWidth = 3;

            sheet.Cells[0, 3].Value = "Order Date";
            sheet.Cells[0, 3].Style.Font.Size = new FontUnit("10pt");
            sheet.Cells[0, 3].Style.Font.Bold = true;
            sheet.Cells[0, 3].Style.ForeColor = Color.Blue;
            sheet.Cells[0, 3].Style.BackColor = Color.Aqua;
            sheet.Cells[0, 3].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[0, 3].Style.BorderStyle = BorderStyle.Double;
            sheet.Cells[0, 3].Style.BorderColor = Color.Gold;
            sheet.Cells[0, 3].Style.BorderWidth = 3;

            sheet.Cells[0, 4].Value = "Ship Via";
            sheet.Cells[0, 4].Style.Font.Size = new FontUnit("10pt");
            sheet.Cells[0, 4].Style.Font.Bold = true;
            sheet.Cells[0, 4].Style.ForeColor = Color.Blue;
            sheet.Cells[0, 4].Style.BackColor = Color.Aqua;
            sheet.Cells[0, 4].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[0, 4].Style.BorderStyle = BorderStyle.Double;
            sheet.Cells[0, 4].Style.BorderColor = Color.Gold;
            sheet.Cells[0, 4].Style.BorderWidth = 3;

            sheet.Cells[1, 0].Value = "11077";
            sheet.Cells[1, 0].Style.HorizontalAlign = HorizontalAlign.Right;
            sheet.Cells[1, 1].Value = "RATTC";
            sheet.Cells[1, 1].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[1, 2].Value = "Nancy Davolio";
            sheet.Cells[1, 2].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[1, 3].PutValue(Convert.ToDateTime("2004-5-10"));
            sheet.Cells[1, 3].Style.HorizontalAlign = HorizontalAlign.Right;
            style = sheet.Cells[1, 3].Style;
            sheet.Cells[1, 3].Style.NumberType = (int)NumberType.Date2;

            sheet.Cells[1, 4].Value = "United Package";
            sheet.Cells[1, 4].Style.HorizontalAlign = HorizontalAlign.Center;

            sheet.Cells[2, 0].Value = "11076";
            sheet.Cells[2, 0].Style.HorizontalAlign = HorizontalAlign.Right;
            sheet.Cells[2, 1].Value = "BONAP";
            sheet.Cells[2, 1].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[2, 2].Value = "Margaret Peacock";
            sheet.Cells[2, 2].Style.HorizontalAlign = HorizontalAlign.Center;
            sheet.Cells[2, 3].PutValue(Convert.ToDateTime("2004-5-02"));
            sheet.Cells[2, 3].Style.HorizontalAlign = HorizontalAlign.Right;
            style = sheet.Cells[2, 3].Style;
            sheet.Cells[2, 3].Style.NumberType = (int)NumberType.Date2;

            sheet.Cells[2, 4].Value = "United Package";
            sheet.Cells[2, 4].Style.HorizontalAlign = HorizontalAlign.Center;

            // Sets the column width.
            sheet.Cells.SetColumnWidth(1, 20);
            sheet.Cells.SetColumnWidth(2, 20);
            sheet.Cells.SetColumnWidth(3, 20);
            sheet.Cells.SetColumnWidth(4, 20);

            // Set the row height
            sheet.Cells.SetRowHeight(0, 20);
        }

        protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();      
        }

    }

}
