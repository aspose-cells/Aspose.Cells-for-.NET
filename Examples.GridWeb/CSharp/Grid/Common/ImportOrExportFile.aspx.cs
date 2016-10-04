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

public partial class demos_Common_ImportOrExportFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //if first visit this page clear GridWeb1 
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
         // LoadData();
          GridWeb1.WorkSheets.Clear();
          GridWeb1.WorkSheets.Add();
      }
      HtmlMeta tag = new HtmlMeta();
      tag.Name = "description";
      tag.Content = "description of page";
      Header.Controls.Add(tag);
      HtmlMeta tagKeyword = new HtmlMeta();
      tagKeyword.Name = "keywords";
      tagKeyword.Content = "keywords of page";
      Header.Controls.Add(tagKeyword);
    }

    private String myCellClickOnAjax(object sender, CellEventArgs e)
{
    return "hello" + e.Cell.StringValue+".row:"+e.Cell.Row+",col:"+e.Cell.Column;
}

    private void LoadData()
    {
     //   License li = new  License();
      //  li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");
        
      // Gets the web application's path.
      string path = Server.MapPath("~");

      // Upper level.
      path = path.Substring(0, path.LastIndexOf("\\"));
      string fileName = path + "\\File\\List.xls";

      // Imports from a excel file.
      GridWeb1.ImportExcelFile(fileName);

      
    }

    // Handles the load file button click event and load an excel file from disk
  protected void Button1_Click(object sender, EventArgs e)
  {
    LoadData();
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

  protected void GridWeb1_SubmitCommand(object sender, EventArgs e)
  {

  }
}
