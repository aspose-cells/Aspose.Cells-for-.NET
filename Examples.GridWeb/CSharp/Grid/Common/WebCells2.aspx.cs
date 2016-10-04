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

public partial class demos_Common_WebCells2 : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !GridWeb2.IsPostBack)
      {
        InitData();

        //set sheets selectedIndex to 0
        GridWeb2.WorkSheets.ActiveSheetIndex = 0;
      }			
    }

  private void InitData()
		{
			GridWeb2.WorkSheets.Clear();
			GridWeb2.WorkSheets.Add("Students");
			 GridWorksheet sheet = GridWeb2.WorkSheets[0];
             GridCells cells = sheet.Cells;
			cells[0, 0].PutValue("Name");
            GridTableItemStyle itemstyle = cells[0, 0].Style;
            itemstyle.Font.Size = new FontUnit("10pt");
            itemstyle.Font.Bold = true;
            itemstyle.ForeColor = Color.Black;
            itemstyle.HorizontalAlign = HorizontalAlign.Center;
            itemstyle.BorderWidth = 1;
            cells[0, 0].Style = itemstyle;
			 

			cells[1,0].PutValue("Jack");
			cells[1,1].PutValue("M");
			cells[1,2].PutValue(19);
			cells[1,3].PutValue("One");

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

            GridCell  cell = cells[0, 1];
            GridTableItemStyle style = cell.Style;
            style.Font.Size = new FontUnit("22pt");
            style.Wrap = false;

            style.BackColor = Color.Gray;
            style.BorderStyle = BorderStyle.Solid;
            style.BorderWidth = new Unit(1, UnitType.Pixel);
            style.BorderColor = Color.Blue;

            style.RightBorderStyle.BorderColor = Color.Red;
            style.RightBorderStyle.BorderStyle = BorderStyle.Solid;
            style.RightBorderStyle.BorderWidth = new Unit(2, UnitType.Pixel);
            style.BottomBorderStyle.BorderColor = Color.YellowGreen;
            style.BottomBorderStyle.BorderStyle = BorderStyle.Solid;
            style.BottomBorderStyle.BorderWidth = new Unit(40, UnitType.Pixel);
            cell.Style=style;
            cells.SetRowHeight(0, 60);

				
			cells.SetColumnWidth(0, 80);
			cells.SetColumnWidth(1, 80);
			cells.SetColumnWidth(2, 80);
			cells.SetColumnWidth(3, 80);
		}

  protected void Button6_Click(object sender, EventArgs e)
  {
    InitData();
  }

protected void  Button1_Click(object sender, EventArgs e)
{  
			GridWeb2.WorkSheets[0].Cells.InsertColumn(Convert.ToInt16(TextBox1.Text.Trim()));
}

protected void  Button2_Click(object sender, EventArgs e)
{
 		GridWeb2.WorkSheets[0].Cells.DeleteColumn(Convert.ToInt16(TextBox1.Text.Trim()));
}

protected void  Button3_Click(object sender, EventArgs e)
{
		GridWeb2.WorkSheets[0].Cells.InsertRow(Convert.ToInt16(Textbox2.Text.Trim()));
}

protected void  Button4_Click(object sender, EventArgs e)
{
		GridWeb2.WorkSheets[0].Cells.DeleteRow(Convert.ToInt16(Textbox2.Text.Trim()));
}

protected void  Button5_Click(object sender, EventArgs e)
{  
			int firstRow = Convert.ToInt16(Textbox3.Text.Trim());
			int firstColumn = Convert.ToInt16(Textbox4.Text.Trim());
			int rowNumber = Convert.ToInt16(Textbox5.Text.Trim());
			int columnNumber = Convert.ToInt16(Textbox6.Text.Trim());
			GridWeb2.WorkSheets[0].Cells.Merge(firstRow,firstColumn,rowNumber,columnNumber);
}
protected void  Button7_Click(object sender, EventArgs e)
{  
			int row = Convert.ToInt16(Textbox7.Text.Trim());
			int column = Convert.ToInt16(Textbox8.Text.Trim());
			GridCell cell = GridWeb2.WorkSheets[0].Cells[row,column];
            GridCommentCollection comments = GridWeb2.WorkSheets[0].Comments;

            GridComment comment = comments[comments.Add(row, column)];
			comment.Note = Textbox9.Text.Trim();
}
protected void  Button8_Click(object sender, EventArgs e)
{
     int row = Convert.ToInt16(Textbox7.Text.Trim());
			int column = Convert.ToInt16(Textbox8.Text.Trim());
			GridCell cell = GridWeb2.WorkSheets[0].Cells[row,column];
			GridCommentCollection   comments = GridWeb2.WorkSheets[0].Comments;
            comments.RemoveAt(row, column);
}

protected void  GridWeb2_SaveCommand(object sender, EventArgs e)
{
  // Generates a temporary file name.
			string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

			// Saves to the file.
			 GridWeb2.SaveToExcelFile(filename);

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
