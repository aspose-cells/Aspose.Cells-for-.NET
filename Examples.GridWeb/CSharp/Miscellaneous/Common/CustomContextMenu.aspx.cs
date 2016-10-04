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

public partial class demos_Common_CustomContextMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // Put user code to initialize the page here
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
          GridWeb1.WorkSheets.Clear();
          GridWeb1.WorkSheets.Add();

          //set sheets selectedIndex to 0
          GridWeb1.WorkSheets.ActiveSheetIndex = 0;
          GridWeb1.WorkSheets[0].Cells.SetColumnWidthPixel(0, 100);
      }
    }

  protected void GridWeb1_CustomCommand(object sender, string command)
  {
    switch (command)
    {
      case "COMMAND1":
            GridWeb1.WorkSheets[0].Cells["A1"].PutValue("COMMAND1");
        break;

      case "COMMAND2":
        GridWeb1.WorkSheets[0].Cells["A1"].PutValue("COMMAND2");
        break;
    }
  }
}
