using System;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class UsingCommonSubmitButton : System.Web.UI.Page
    {
        // ExStart:UsingCommonSubmitButton
        // Implementing Page_Load event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if there is no postback
            if (!IsPostBack)
            {
                // Adding javascript function to onclick attribute of Button control
                SubmitButton.Attributes["onclick"] = GridWeb1.ClientID +
                                                ".updateData(); if (" +
                                                GridWeb1.ClientID +
                                                ".validateAll()) return true; else return false;";
            }
        }
        // ExEnd:UsingCommonSubmitButton
    }
}