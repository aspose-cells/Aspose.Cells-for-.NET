using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Aspose.Cells.GridWeb.Data;
using Aspose.Cells.GridWeb;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format
{
    public partial class ApplyCustomFormats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitData();

                // Set sheets selectedIndex to 0
                GridWeb1.ActiveSheetIndex = 0;
            }
        }
        private void InitData()
        {
            GridWeb1.WorkSheets.Clear();
            GridWeb1.WorkSheets.Add("Custom Format");

            GridCell cell;
            GridCells cells = GridWeb1.WorkSheets[0].Cells;
            cells["A1"].PutValue("Custom Format");
            cells["A2"].PutValue("0.0");
            cells["A3"].PutValue("0.000");
            cells["A4"].PutValue("#,##0.0");
            cells["A5"].PutValue("0.0%");
            cells["A6"].PutValue("0.000E+00");
            cells["A7"].PutValue("yyyy-m-d h:mm");

            cell = cells["B1"];
            cell.PutValue("Format Results");

            cell = cells["B2"];
            cell.PutValue(12345.6789);
            cell.SetCustom("0.0");

            cell = cells["B3"];
            cell.PutValue(12345.6789);
            cell.SetCustom("0.000");
            
            cell = cells["B4"];
            cell.PutValue(543123456.789);
            cell.SetCustom("#,##0.0");

            cell = cells["B5"];
            cell.PutValue(0.925687);
            cell.SetCustom("0.0%");

            cell = cells["B6"];
            cell.PutValue(-1234567890.5687);
            cell.SetCustom("0.000E+00");

            cell = cells["B7"];
            cell.PutValue(DateTime.Now);
            cell.SetCustom("yyyy-m-d h:mm");

            cells.SetColumnWidthPixel(0, 220);
            cells.SetColumnWidthPixel(1, 220);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InitData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridWeb1.WorkSheets.Clear();
            GridWeb1.WorkSheets.Add();

            GridCells cells = GridWeb1.WorkSheets[0].Cells;

            cells["A1"].PutValue("Custom Format");
            cells["B1"].PutValue("Format Results");

            cells["A2"].PutValue(TextBox1.Text.Trim());
            cells["B2"].PutValue(TextBox2.Text.Trim(), true);


            cells["B2"].SetCustom(TextBox1.Text.Trim());

            cells.SetColumnWidthPixel(0, 120);
            cells.SetColumnWidthPixel(1, 220);
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
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

