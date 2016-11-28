using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class InitCustomCommandButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInitCommandButton_Click(object sender, EventArgs e)
        {
            // ExStart:InitCustomCommandButton
            // Instantiating a CustomCommandButton object
            CustomCommandButton button = new CustomCommandButton();

            // Setting the command, text and image URL for button. Image should be relative to website root folder
            button.Command = "MyButton";
            button.Text = "MyButton";
            button.ImageUrl = "../Image/aspose.ico";
    
            // Adding button to CustomCommandButtons collection of GridWeb
            GridWeb1.CustomCommandButtons.Add(button);
            // ExEnd:InitCustomCommandButton
        }

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