using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class HandleCustomCommandEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                InstantiateCustomCommandButton();
            }
        }

        private void InstantiateCustomCommandButton()
        {
            // Instantiating a CustomCommandButton object
            CustomCommandButton button = new CustomCommandButton();

            // Setting the command for button
            button.Command = "MyButton";

            // Setting text of the button
            button.Text = "MyButton";

            // Setting image URL of the button, should be relative to website root folder
            button.ImageUrl = "../Image/aspose.ico";

            // Adding button to CustomCommandButtons collection of GridWeb
            GridWeb1.CustomCommandButtons.Add(button);
        }

        // ExStart:HandleCustomCommandEvent
        // Creating Event Handler for CustomCommand event
        protected void GridWeb1_CustomCommand(object sender, string command)
        {
            // Identifying a specific button by checking its command
            if (command.Equals("MyButton"))
            {
                // Accessing the cells collection of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Putting value to "A1" cell
                sheet.Cells["A1"].PutValue("My Custom Command Button is Clicked.");

                // Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 30);
            }
        }
        // ExEnd:HandleCustomCommandEvent

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\";

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