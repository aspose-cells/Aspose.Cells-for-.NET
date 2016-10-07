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
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;
using Aspose.Cells.GridWeb.DemosCS;
using System.Drawing;
using Aspose.Cells.GridWeb.DemosCS.DataBind;

public partial class demos_DataBind_DataBind2 : System.Web.UI.Page
{
  
  protected Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1 dataSet11;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        //Create dataset object
        this.dataSet11 = new Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet1();

        //Create web worksheet object
        WebWorksheet sheet = GridWeb1.WebWorksheets[0];

        // Specifies the datasource for the sheet.
        sheet.DataSource = dataSet11;
        sheet.DataMember = "Products";

        // Creates in-sheet column headers.
        sheet.EnableCreateBindColumnHeader = true;

        // Data cells begin at row 1;
        sheet.BindStartRow = 1;

        // Creates the data field column automatically.
        sheet.CreateAutoGenratedColumns();

        // Modifies a column's number type.
        sheet.BindColumns["UnitPrice"].NumberType = NumberType.Currency3;

        // The "product name" field is required.
        Aspose.Cells.GridWeb.Validation v = new Aspose.Cells.GridWeb.Validation();
        v.IsRequired = true;
        sheet.BindColumns["ProductName"].Validation = v;

        // Modifies column headers' background color.
        for (int i = 0; i < sheet.BindColumns.Count; i++)
        {
          sheet.BindColumns[i].ColumnHeaderStyle.BackColor = Color.SkyBlue;
        }

        //Create demo database object
        ExampleDatabase db = new ExampleDatabase();

        //Create path to database file
        string path = Server.MapPath("~");
        path = path.Substring(0, path.LastIndexOf("\\"));

        //Create connection string 
        db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
        try
        {
          // Loads data from database.
          db.oleDbDataAdapter1.Fill(dataSet11);
        }
        finally
        {
          //Close connection
          db.oleDbConnection1.Close();
        }

        // Binding.
        sheet.DataBind();
      }
    }

  protected void GridWeb1_CustomCommand(object sender, string command)
    {
      switch (command)
      {
        case "UPDATE":
          // Only available for local users.
          if (Request.UserHostAddress == "127.0.0.1")
          {
            //Create demo database object
            ExampleDatabase db = new ExampleDatabase();

            //Create path to database file
            string path = Server.MapPath("~");
            path = path.Substring(0, path.LastIndexOf("\\"));

            //Create connection string             
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
            //Set error message
            ShowErrorMsg("Can't update from remote machine!");
          }
          break;

        case "ADD":
          if (GridWeb1.ActiveSheetIndex == 0)
          {
            //Create new row
            GridWeb1.WebWorksheets.ActiveSheet.CreateNewBindRow();
            // Scrolls the panel to the bottom.
            GridWeb1.ViewPanelScrollTop = "1200";
          }
          break;

        case "DELETE":
          if (GridWeb1.ActiveSheetIndex == 0)
          {
            if (GridWeb1.ActiveCell != null)
              //Delete active row
              GridWeb1.WebWorksheets.ActiveSheet.DeleteBindRow(GridWeb1.ActiveCell.Row);
          }
          break;
      }
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

  protected void chkControlHeaderBar_CheckedChanged(object sender, System.EventArgs e)
    {
      //Set header bar property
      GridWeb1.ShowHeaderBar = chkControlHeaderBar.Checked;
    }

    private void ShowErrorMsg(string msg)
    {
      //Display error message
      Literal script = new Literal();
      script.Text = "<script language='javascript'>alert(\"" + msg + "\");</script>";
      this.Controls.Add(script);
    }

}
