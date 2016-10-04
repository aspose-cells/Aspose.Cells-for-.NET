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
using Aspose.Cells.GridWeb.DemosCS;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.DemosCS.DataBind;

public partial class demos_DataBind_DataBind3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        // Creates the collection.
        MyCollection list = new MyCollection();
        System.Random rand = new System.Random();
        for (int i = 0; i < 5; i++)
        {
          //Create custom record object and set properties
          MyCustomRecord rec = new MyCustomRecord();
          rec.DateField1 = DateTime.Now;
          rec.DoubleField1 = rand.NextDouble();
          rec.IntField1 = rand.Next();
          rec.StringField1 = "ABC_" + i;
          ((IList)list).Add(rec);
        }

        //Create web worksheet object
        WebWorksheet sheet = GridWeb1.WebWorksheets[0];

        // Uses the collection as datasource.
        sheet.DataSource = list;

        // Creates bind columns.
        sheet.CreateAutoGenratedColumns();

        // Sets the DateFiled1's validation to DateTime.
        sheet.BindColumns["DateField1"].Validation.ValidationType = ValidationType.DateTime;

        // Binding.
        sheet.DataBind();
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

    // Custom command button event handler.
  protected void GridWeb1_CustomCommand(object sender, string command)
    {
      switch (command)
      {
        case "ADD":
          if (GridWeb1.ActiveSheetIndex == 0)
          {
            //Create new active row
            GridWeb1.WebWorksheets.ActiveSheet.CreateNewBindRow();
            // Scrolls the panel to the bottom.
            GridWeb1.ViewPanelScrollTop = int.MaxValue.ToString();
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

    // Initialize new bind row.
    private void GridWeb1_InitializeNewBindRow(WebWorksheet sender, object bindObject)
    {
      // Handles the initialize new bind row event.
      MyCustomRecord rec = (MyCustomRecord)bindObject;
      rec.DateField1 = DateTime.Now;
    }
}
