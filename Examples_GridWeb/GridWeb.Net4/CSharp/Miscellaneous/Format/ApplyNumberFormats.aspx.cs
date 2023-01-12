using System;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format
{
    public partial class ApplyNumberFormats : System.Web.UI.Page
    {
        Aspose.Cells.GridWeb.GridTableItemStyle style = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                initData();

                
            }
        }

        private void initData()
        {

           
            GridWorksheet sheet=GridWeb1.WorkSheets.Add("Number Format");
            //set sheets selectedIndex to the added one
            GridWeb1.ActiveSheetIndex = sheet.Index;

            GridCell cell;
            GridCells cells = sheet.Cells;
            cells["A1"].PutValue("Number Type");
            cells["A2"].PutValue("General:");
            cells["A3"].PutValue("Decimal 1:");
            cells["A4"].PutValue("Decimal 2:");
            cells["A5"].PutValue("Decimal 3:");
            cells["A6"].PutValue("Decimal 4:");

            cells["A7"].PutValue("Currency 1:");
            cells["A8"].PutValue("Currency 2:");
            cells["A9"].PutValue("Currency 3:");
            cells["A10"].PutValue("Currency 4:");
            cells["A11"].PutValue("Currency 5:");
            cells["A12"].PutValue("Currency 6:");
            cells["A13"].PutValue("Currency 7:");
            cells["A14"].PutValue("Currency 8:");
            cells["A15"].PutValue("Currency 9:");
            cells["A16"].PutValue("Currency 10:");
            cells["A17"].PutValue("Currency 11:");
            cells["A18"].PutValue("Currency 12:");

            cells["A19"].PutValue("Percentage 1:");
            cells["A20"].PutValue("Percentage 2:");

            cells["A21"].PutValue("Fraction 1:");
            cells["A22"].PutValue("Fraction 2:");

            cells["A23"].PutValue("Accounting 1:");
            cells["A24"].PutValue("Accounting 2:");
            cells["A25"].PutValue("Accounting 31:");
            cells["A26"].PutValue("Accounting 4:");

            cells["A27"].PutValue("Scientific 1:");
            cells["A28"].PutValue("Scientific 2:");

            cells["A29"].PutValue("Text:");


            cell = cells["B1"];
            cell.PutValue("Format Results");

            cell = cells["B2"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.General);


            cell = cells["B3"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Decimal1);


            cell = cells["B4"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Decimal2);


            cell = cells["B5"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Decimal3);


            cell = cells["B6"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Decimal4);


            cell = cells["B7"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency1);


            cell = cells["B8"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency2);


            cell = cells["B9"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency3);


            cell = cells["B10"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency4);


            cell = cells["B11"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency5);


            cell = cells["B12"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency6);


            cell = cells["B13"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency7);


            cell = cells["B14"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency8);


            cell = cells["B15"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency9);


            cell = cells["B16"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency10);


            cell = cells["B17"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency11);


            cell = cells["B18"];
            cell.PutValue(12345.6789);

            cell.SetNumberType((int)NumberType.Currency12);


            cell = cells["B19"];
            cell.PutValue(0.56789);

            cell.SetNumberType((int)NumberType.Percentage1);


            cell = cells["B20"];
            cell.PutValue(0.56789);

            cell.SetNumberType((int)NumberType.Percentage2);


            cell = cells["B21"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Fraction1);


            cell = cells["B22"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Fraction2);


            cell = cells["B23"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Accounting1);


            cell = cells["B24"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Accounting2);


            cell = cells["B25"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Accounting3);


            cell = cells["B26"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Accounting4);


            cell = cells["B27"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Scientific1);


            cell = cells["B28"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Scientific2);


            cell = cells["B29"];
            cell.PutValue(1234.56789);

            cell.SetNumberType((int)NumberType.Text);



            cells.SetColumnWidth(0, 40);
            cells.SetColumnWidth(1, 40);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            initData();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            GridWeb1.WorkSheets.Clear();
            GridWeb1.WorkSheets.Add();

            GridCells cells = GridWeb1.WorkSheets[0].Cells;
            cells["A1"].PutValue("Number Type");
            cells["B1"].PutValue("Format Results");

            cells["A2"].PutValue(DropDownList1.SelectedItem.Text);


            cells["B2"].SetNumberType((int)(NumberType)Convert.ToInt16(DropDownList1.SelectedItem.Value));

            cells["B2"].PutValue(TextBox1.Text, true);
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

