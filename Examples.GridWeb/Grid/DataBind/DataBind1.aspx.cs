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
using Aspose.Cells.GridWeb.DemosCS.DataBind;
using Aspose.Cells.GridWeb.DemosCS;
using System.Drawing;

public partial class demos_DataBind_DataBind1 : System.Web.UI.Page
{
  protected Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1 dataSet11;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void BindWithInSheetHeaders()
    {
      //Create dataset object
      this.dataSet11 = new Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1();

      //Create demo database object
      DemoDatabase db = new DemoDatabase();

      //Create pathe to database file
      string path = Server.MapPath("~");
      path = path.Substring(0, path.LastIndexOf("\\"));	 

      //Create connection string
      db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
      try
      {
        // Connects to database and fetches data.
        db.oleDbDataAdapter1.Fill(dataSet11);

        //Create webworksheet object
        WebWorksheet sheet = GridWeb1.WebWorksheets[0];

        // Clears the sheet.
        sheet.Cells.Clear();

        // Enables creating in-sheet headers.
        sheet.EnableCreateBindColumnHeader = true;

        // Data cells begin from row 2.
        sheet.BindStartRow = 2;

        // Creates some title cells.
        sheet.Cells["A1"].PutValue("The Product Table");
        sheet.Cells["A1"].GetStyle().Font.Size = new FontUnit("20pt");
        sheet.Cells["A1"].GetStyle().HorizontalAlign = HorizontalAlign.Center;
        sheet.Cells["A1"].GetStyle().VerticalAlign = VerticalAlign.Middle;
        sheet.Cells["A1"].GetStyle().BackColor = Color.SkyBlue;
        sheet.Cells["A1"].GetStyle().ForeColor = Color.Blue;
        sheet.Cells.Merge(0, 0, 2, 11);
        // Freezes the header rows.
        sheet.FreezePanes(3, 0, 3, 0);
        // Bind the sheet to the dataset.
        sheet.DataBind();

       
      }
      finally
      {
        //Close connection
        db.oleDbConnection1.Close();
      }
    }

    private void BindWithoutInSheetHeaders()
    {
      //Create database object
      this.dataSet11 = new Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1();

      //Create demo database object
      DemoDatabase db = new DemoDatabase();

      //Create path to database file
      string path = Server.MapPath("~");
      path = path.Substring(0, path.LastIndexOf("\\"));	 

      //Create connection string to database file
      db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
      try
      {
        // Connects to database and fetches data.
        db.oleDbDataAdapter1.Fill(dataSet11);

        //Create web worksheet object
        WebWorksheet sheet = GridWeb1.WebWorksheets[0];

        // Clears the sheet.
        sheet.Cells.Clear();
        sheet.Cells.UnMerge(0, 0, 2, 11);
        // Disables creating in-sheet headers.
        sheet.EnableCreateBindColumnHeader = false;

        // Data cells begin from row 0.
        sheet.BindStartRow = 0;
        // Unfreezes the header rows.
        sheet.UnfreezePanes();
        // Bind the sheet to the dataset.
        sheet.DataBind();

       
      }
      finally
      {
        //Close database connection
        db.oleDbConnection1.Close();
      }
    }

    // Handles the custom command button's click event.
  protected void GridWeb1_CustomCommand(object sender, string command)
    {
      switch (command)
      {
        case "UPDATE":
          // Only available for local users.
          if (Request.UserHostAddress == "127.0.0.1")
          {
            //Create path to database file
            DemoDatabase db = new DemoDatabase();
            string path = Server.MapPath("~");
            path = path.Substring(0, path.LastIndexOf("\\"));

            //Create connection string to database file
            db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
            try
            {
              //Update database
              db.oleDbDataAdapter1.Update((DataSet)GridWeb1.WebWorksheets[0].DataSource);
            }
            finally
            {
              //Close connection
              db.oleDbConnection1.Close();
            }
          }
          else
          {
            //Det error message
            ShowErrorMsg("Can't update from remote machine!");
          }
          break;

        case "ADD":
          if (GridWeb1.ActiveSheetIndex == 0)
          {
            //Create new active row
            GridWeb1.WebWorksheets.ActiveSheet.CreateNewBindRow();
            // Scrolls the panel to the bottom.
            GridWeb1.ViewPanelScrollTop = "1200";
          }
          break;

        case "DELETE":
          if (GridWeb1.ActiveSheetIndex == 0)
          {
            if (GridWeb1.ActiveCell != null)
              //Delete bind row
              GridWeb1.WebWorksheets.ActiveSheet.DeleteBindRow(GridWeb1.ActiveCell.Row);
          }
          break;
      }
    }

    protected void chkCreateSheetHeader_CheckedChanged(object sender, System.EventArgs e)
    {
      if (chkCreateSheetHeader.Checked)
        //Bind sheet headers
        BindWithInSheetHeaders();
      else
        //Bind with out sheet headers
        BindWithoutInSheetHeaders();
    }

    protected void chkControlHeaderBar_CheckedChanged(object sender, System.EventArgs e)
    {
      //Set header bar property
      GridWeb1.ShowHeaderBar = chkControlHeaderBar.Checked;
    }

  protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
    {
      // Generates a memory stream.
      System.IO.MemoryStream ms = new System.IO.MemoryStream();

      // Saves to the stream.
      this.GridWeb1.SaveToExcelFile(ms);

      // Sents the file to browser.
      Response.ContentType = "application/vnd.ms-excel";

      //Adds header.
      Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

      // Writes file content to the response stream.
      Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);

      // OK.
      Response.End();
    }

    private void ShowErrorMsg(string msg)
    {
      //Display error message
      Literal script = new Literal();
      script.Text = "<script language='javascript'>alert(\"" + msg + "\");</script>";
      this.Controls.Add(script);
    }

    protected void chkNoScrollBar_CheckedChanged(object sender, System.EventArgs e)
    {
      //Set scroll property
      //GridWeb1.NoScroll = chkNoScrollBar.Checked;
    }

    // Binds sheet.
  protected void BtnBind_Click(object sender, System.EventArgs e)
    {
      if (chkCreateSheetHeader.Checked)
        //Bind sheet headers
        BindWithInSheetHeaders();
      else
        //Bind with out sheet headers
        BindWithoutInSheetHeaders();
    }
}
