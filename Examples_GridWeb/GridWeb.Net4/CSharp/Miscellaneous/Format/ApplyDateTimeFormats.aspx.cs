using System;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format
{
    public partial class ApplyDateTimeFormats : System.Web.UI.Page
    {
        Aspose.Cells.GridWeb.GridTableItemStyle style = null;

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
            GridWeb1.WorkSheets.Add("Date&Time Format");

            GridCell cell;
            GridCells cells = GridWeb1.WorkSheets[0].Cells;
            cells["A1"].PutValue("Number Type");
            cells["A2"].PutValue("Date 1:");
            cells["A3"].PutValue("Date 2:");
            cells["A4"].PutValue("Date 3:");
            cells["A5"].PutValue("Date 4:");

            cells["A6"].PutValue("Time 1:");
            cells["A7"].PutValue("Time 2:");
            cells["A8"].PutValue("Time 3:");
            cells["A9"].PutValue("Time 4:");
            cells["A10"].PutValue("Time 5:");
            cells["A11"].PutValue("Time 6:");
            cells["A12"].PutValue("Time 7:");
            cells["A13"].PutValue("Time 8:");

            cells["A14"].PutValue("EasternDate 1:");
            cells["A15"].PutValue("EasternDate 2:");
            cells["A16"].PutValue("EasternDate 3:");
            cells["A17"].PutValue("EasternDate 4:");
            cells["A18"].PutValue("EasternDate 5:");
            cells["A19"].PutValue("EasternDate 6:");
            cells["A20"].PutValue("EasternDate 7:");
            cells["A21"].PutValue("EasternDate 8:");
            cells["A22"].PutValue("EasternDate 9:");
            cells["A23"].PutValue("EasternDate 10:");
            cells["A24"].PutValue("EasternDate 11:");
            cells["A25"].PutValue("EasternDate 12:");
            cells["A26"].PutValue("EasternDate 13:");

            cells["A27"].PutValue("EasternTime 1:");
            cells["A28"].PutValue("EasternTime 2:");
            cells["A29"].PutValue("EasternTime 3:");
            cells["A30"].PutValue("EasternTime 4:");
            cells["A31"].PutValue("EasternTime 5:");
            cells["A32"].PutValue("EasternTime 6:");


            cell = cells["B1"];
            cell.PutValue("Format Results");

            cell = cells["B2"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Date1);


            cell = cells["B3"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Date2);

            cell = cells["B4"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Date3);

            cell = cells["B5"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Date4);

            cell = cells["B6"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time1);

            cell = cells["B7"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time2);


            cell = cells["B8"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time3);


            cell = cells["B9"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time4);


            cell = cells["B10"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time5);


            cell = cells["B11"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time6);


            cell = cells["B12"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time7);


            cell = cells["B13"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.Time8);


            cell = cells["B14"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate1);


            cell = cells["B15"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate2);


            cell = cells["B16"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate3);


            cell = cells["B17"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate4);


            cell = cells["B18"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate5);


            cell = cells["B19"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate6);


            cell = cells["B20"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate7);


            cell = cells["B21"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate8);


            cell = cells["B22"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate9);


            cell = cells["B23"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate10);


            cell = cells["B24"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate11);


            cell = cells["B25"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate12);


            cell = cells["B26"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternDate13);


            cell = cells["B27"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime1);


            cell = cells["B28"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime2);


            cell = cells["B29"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime3);


            cell = cells["B30"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime4);


            cell = cells["B31"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime5);


            cell = cells["B32"];
            cell.PutValue(DateTime.Now);
            cell.SetNumberType((int)NumberType.EasternTime6);


            cells.SetColumnWidth(0, 40);
            cells.SetColumnWidth(1, 40);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.InitData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridWeb1.WorkSheets.Clear();
            GridWeb1.WorkSheets.Add();

            GridCells cells = GridWeb1.WorkSheets[0].Cells;

            cells["A1"].PutValue("Number Type");
            cells["B1"].PutValue("Format Results");

            cells["A2"].PutValue(DropDownList1.SelectedItem.Text);
            cells["B2"].PutValue(TextBox1.Text, true);

            cells["B2"].SetNumberType((int)(NumberType)Convert.ToInt16(DropDownList1.SelectedItem.Value));


            cells.SetColumnWidth(0, 40);
            cells.SetColumnWidth(1, 40);
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
