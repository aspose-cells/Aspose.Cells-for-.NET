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

public partial class demos_Formula_TextAndData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        ReLoadData();

        //set sheets selectedIndex to 0
        GridWeb1.ActiveSheetIndex = 0;
      }
    }

  private void ReLoadData()
  {
    //Create path to xls file
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));
    string fileName = path + "\\File\\TextAndData.xls";

   

    // Imports from a excel file.
    GridWeb1.ImportExcelFile(fileName);
  }

  protected void btnReload_Click(object sender, EventArgs e)
  {
    ReLoadData();
  }

  protected void GridWeb1_SaveCommand(object sender, EventArgs e)
  {
    // Generates a temporary file name.
    string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";
    // Saves to the file.
    this.GridWeb1.SaveToExcelFile(filename);
    // Sents the file to browser.
    Response.ContentType = "application/vnd.ms-excel";
    //Adds header.
    Response.AddHeader("content-disposition", "attachment; filename=book1.xls");
    // Writes file content to the response stream.
    Response.WriteFile(filename);
    // OK.
    Response.End();
  }
}
