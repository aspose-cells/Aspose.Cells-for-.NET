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
using System.Drawing;
using Aspose.Cells.GridWeb.DemosCS;
using Aspose.Cells.GridWeb;

public partial class demos_Common_WebCells : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        InitData();

        //set sheets selectedIndex to 0
        GridWeb1.WorkSheets.ActiveSheetIndex = 0;
      }			
    }

  private void InitData()
		{
            GridWeb1.WorkSheets.Clear();
            GridWorksheet sheet = GridWeb1.WorkSheets.Add("Students");
            GridCells cells = sheet.Cells;
			cells[0, 0].PutValue("Name");
            GridTableItemStyle cellstyle = cells[0, 0].Style;
            cellstyle.Font.Size = new FontUnit("10pt");
            cellstyle.Font.Bold = true;
            cellstyle.ForeColor = Color.Black;
            cellstyle.HorizontalAlign = HorizontalAlign.Center;
            cellstyle.BorderWidth = 1;
            cells[0, 0].Style = cellstyle;



            cells[1, 0].PutValue("Jack");
            cells[1, 1].PutValue("M");
            cells[1, 2].PutValue(19);
            cells[1, 3].PutValue("One");

            cells[2, 0].PutValue("Tome");
            cells[2, 1].PutValue("M");
            cells[2, 2].PutValue(20);
            cells[2, 3].PutValue("Four");

            cells[3, 0].PutValue("Jeney");
            cells[3, 1].PutValue("W");
            cells[3, 2].PutValue(18);
            cells[3, 3].PutValue("Two");

            cells[4, 0].PutValue("Marry");
            cells[4, 1].PutValue("W");
            cells[4, 2].PutValue(17);
            cells[4, 3].PutValue("There");

            cells[5, 0].PutValue("Amy");
            cells[5, 1].PutValue("W");
            cells[5, 2].PutValue(16);
            cells[5, 3].PutValue("Four");

            cells[6, 0].PutValue("Ben");
            cells[6, 1].PutValue("M");
            cells[6, 2].PutValue(17);
            cells[6, 3].PutValue("Four");

            GridCell cell = cells[0, 1];
            Aspose.Cells.GridWeb.GridTableItemStyle style = cell.Style;
            style.Font.Size = new FontUnit("22pt");
            style.Wrap = false;

            //style.BackColor = Color.Gray;
            

            style.RightBorderStyle.BorderColor = Color.Red;
            style.RightBorderStyle.BorderStyle = BorderStyle.Dotted;
            style.BottomBorderStyle.BorderColor = Color.Green;
            style.BottomBorderStyle.BorderStyle = BorderStyle.Groove;
            style.TopBorderStyle.BorderColor = Color.Yellow;
            style.TopBorderStyle.BorderStyle = BorderStyle.Inset;
            style.LeftBorderStyle.BorderColor = Color.Coral;
            style.LeftBorderStyle.BorderStyle = BorderStyle.Solid;

           
            cells[0, 1].Style = style;
            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle1 = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle1.CopyFrom(style);
            vtstyle1.LeftBorderStyle.BorderWidth = new Unit(1, UnitType.Pixel);
            vtstyle1.TopBorderStyle.BorderWidth = new Unit(1, UnitType.Pixel);

          //  cells[0, 0].SetStyle(vtstyle1);
         //   cells[1, 2].SetStyle(style);

            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle2 = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle2.CopyFrom(style);
            vtstyle2.LeftBorderStyle.BorderWidth = new Unit(10, UnitType.Pixel);
           // style.LeftBorderStyle.BorderWidth = new Unit(50, UnitType.Pixel);
          //  cells[3, 0].SetStyle(vtstyle2);

            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle3 = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle3.CopyFrom(style);
            vtstyle3.TopBorderStyle.BorderWidth = new Unit(1, UnitType.Pixel);
            vtstyle3.BottomBorderStyle.BorderWidth = new Unit(80, UnitType.Pixel);
          //  cells[0, 1].SetStyle(vtstyle3);

            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle4 = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle4.CopyFrom(vtstyle3);
            vtstyle4.TopBorderStyle.BorderWidth = new Unit(1, UnitType.Pixel);
            vtstyle4.BottomBorderStyle.BorderWidth = new Unit(50, UnitType.Pixel);
           // cells[0, 2].SetStyle(vtstyle4);


            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle5 = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle5.CopyFrom(vtstyle3);
            vtstyle5.TopBorderStyle.BorderWidth = new Unit(1, UnitType.Pixel);
            vtstyle5.BottomBorderStyle.BorderWidth = new Unit(150, UnitType.Pixel);

            vtstyle5.RightBorderStyle.BorderWidth = new Unit(40, UnitType.Pixel);
            vtstyle5.LeftBorderStyle.BorderWidth = new Unit(20, UnitType.Pixel);

          //  cells[1, 1].SetStyle(vtstyle5);

            Aspose.Cells.GridWeb.GridTableItemStyle vtstyle = new Aspose.Cells.GridWeb.GridTableItemStyle();
            vtstyle.CopyFrom(style);
            vtstyle.RightBorderStyle.BorderWidth = new Unit(50, UnitType.Pixel);
          //  cells[1, 4].SetStyle(vtstyle);
     // cells[1, 4]
           // WebCell cellheader = sheet.
          //  cellheader.SetStyle(style);
           // GridWeb1.SetHeaderBarStyle(new HeaderBarStyle() );

            cells.SetRowHeight(0, 20);
            cells.SetRowHeight(1, 20);

				
			cells.SetColumnWidth(0, 10);
			cells.SetColumnWidth(1, 10);
			cells.SetColumnWidth(2, 10);
			cells.SetColumnWidth(3, 10);
		}

  protected void Button6_Click(object sender, EventArgs e)
  {
    InitData();
  }

protected void  Button1_Click(object sender, EventArgs e)
{
    GridWeb1.WorkSheets[0].Cells.InsertColumn(Convert.ToInt16(TextBox1.Text.Trim()));
}

protected void  Button2_Click(object sender, EventArgs e)
{
    GridWeb1.WorkSheets[0].Cells.DeleteColumn(Convert.ToInt16(TextBox1.Text.Trim()));
}

protected void  Button3_Click(object sender, EventArgs e)
{
    GridWeb1.WorkSheets[0].Cells.InsertRow(Convert.ToInt16(Textbox2.Text.Trim()));
}

protected void  Button4_Click(object sender, EventArgs e)
{
    GridWeb1.WorkSheets[0].Cells.DeleteRow(Convert.ToInt16(Textbox2.Text.Trim()));
}

protected void  Button5_Click(object sender, EventArgs e)
{  
			int firstRow = Convert.ToInt16(Textbox3.Text.Trim());
			int firstColumn = Convert.ToInt16(Textbox4.Text.Trim());
			int rowNumber = Convert.ToInt16(Textbox5.Text.Trim());
			int columnNumber = Convert.ToInt16(Textbox6.Text.Trim());
            GridWeb1.WorkSheets[0].Cells.Merge(firstRow, firstColumn, rowNumber, columnNumber);
}
protected void  Button7_Click(object sender, EventArgs e)
{  
			int row = Convert.ToInt16(Textbox7.Text.Trim());
			int column = Convert.ToInt16(Textbox8.Text.Trim());
            GridCell cell = GridWeb1.WorkSheets[0].Cells[row, column];
            GridCommentCollection comments = GridWeb1.WorkSheets[0].Comments;
            GridComment comment = comments[comments.Add(cell.Name)];
			comment.Note = Textbox9.Text.Trim();
}
protected void  Button8_Click(object sender, EventArgs e)
{
     int row = Convert.ToInt16(Textbox7.Text.Trim());
			int column = Convert.ToInt16(Textbox8.Text.Trim());
            GridCell cell = GridWeb1.WorkSheets[0].Cells[row, column];
            GridCommentCollection comments = GridWeb1.WorkSheets[0].Comments;
			comments.RemoveAt(cell.Name);
}

protected void  GridWeb1_SaveCommand(object sender, EventArgs e)
{
  // Generates a temporary file name.
			string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

			// Saves to the file.
			this.GridWeb1.SaveToExcelFile(filename);

			// Sents the file to browser.
			Response.ContentType = "application/vnd.ms-excel";
			
			//Adds header.
			Response.AddHeader( "content-disposition","attachment; filename=book1.xls");

			// Writes file content to the response stream.
			Response.WriteFile(filename);

			// OK.
			Response.End();
}
}
