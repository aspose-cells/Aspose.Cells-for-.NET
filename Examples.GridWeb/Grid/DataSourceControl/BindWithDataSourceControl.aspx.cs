﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class demos_DataSourceControl_BindWithDataSourceControl : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		// Sets the actual database path
		string path = Server.MapPath("~");
		path = path.Substring(0, path.LastIndexOf("\\")) + "\\database\\Northwind.mdb";
		AccessDataSource1.DataFile = path;

		if (!IsPostBack&&!GridWeb1.IsPostBack)
		{
            //Bind web worksheet object
			GridWeb1.WebWorksheets[0].DataBind();
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
                    //Update datasource
					GridWeb1.WebWorksheets[0].DataSourceControlUpdate(AccessDataSource1);
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
                    //Bind to new active row
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

	private void ShowErrorMsg(string msg)
	{
        //Display error message
		Literal script = new Literal();
		script.Text = "<script language='javascript'>alert(\"" + msg + "\");</script>";
		this.Controls.Add(script);
	}

    protected void AccessDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
