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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class BindDataUsingWorksheetDesigner : System.Web.UI.Page
    {
        protected DataSet1 dataSet11;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindWithInSheetHeaders()
        {
            // Create dataset object
            this.dataSet11 = new DataSet1();

            // Create database object
            ExampleDatabase db = new ExampleDatabase();

            // Create path to database file
            string path = (this.Master as Site).GetDataDir();

            // Create connection string
            db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Miscellaneous\\Database\\demos.mdb";
            try
            {
                // Connects to database and fetches data.
                db.oleDbDataAdapter1.Fill(dataSet11);

                // Create webworksheet object
                GridWorksheet sheet = GridWeb1.WorkSheets[0];

                // Clears the sheet.
                sheet.Cells.Clear();

                // Enables creating in-sheet headers.
                sheet.EnableCreateBindColumnHeader = true;

                // Data cells begin from row 2.
                sheet.BindStartRow = 2;

                // Creates some title cells.
                sheet.Cells["A1"].PutValue("The Product Table");
                sheet.Cells["A1"].Style.Font.Size = new FontUnit("20pt");
                sheet.Cells["A1"].Style.HorizontalAlign = HorizontalAlign.Center;
                sheet.Cells["A1"].Style.VerticalAlign = VerticalAlign.Middle;
                sheet.Cells["A1"].Style.BackColor = Color.SkyBlue;
                sheet.Cells["A1"].Style.ForeColor = Color.Blue;
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
            // Create dataset object
            this.dataSet11 = new DataSet1();

            // Create database object
            ExampleDatabase db = new ExampleDatabase();

            // Create path to database file
            string path = (this.Master as Site).GetDataDir();

            // Create connection string
            db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Miscellaneous\\Database\\demos.mdb";
            try
            {
                // Connects to database and fetches data.
                db.oleDbDataAdapter1.Fill(dataSet11);

                // Create web worksheet object
                GridWorksheet sheet = GridWeb1.WorkSheets[0];

                // Clears the sheet.
                sheet.Cells.Clear();
                sheet.Cells.UnMerge(0, 0, 2, 11);

                // Disables creating in-sheet headers.
                sheet.EnableCreateBindColumnHeader = false;

                // Data cells begin from row 0.
                sheet.BindStartRow = 0;

                // Unfreezes the header rows.
                sheet.UnFreezePanes();
                
                // Bind the sheet to the dataset.
                sheet.DataBind();
            }
            finally
            {
                // Close database connection
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
                        // Create path to database file
                        ExampleDatabase db = new ExampleDatabase();
                        string path = (this.Master as Site).GetDataDir();

                        // Create connection string
                        db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Miscellaneous\\Database\\demos.mdb";
                        try
                        {
                            // Update database
                            db.oleDbDataAdapter1.Update((DataSet)GridWeb1.WebWorksheets[0].DataSource);
                        }
                        finally
                        {
                            // Close connection
                            db.oleDbConnection1.Close();
                        }
                    }
                    else
                    {
                        // Set error message
                        ShowErrorMsg("Can't update from remote machine!");
                    }
                    break;

                case "ADD":
                    if (GridWeb1.ActiveSheetIndex == 0)
                    {
                        // Create new active row
                        GridWeb1.WebWorksheets.ActiveSheet.CreateNewBindRow();

                        // Scrolls the panel to the bottom.
                        GridWeb1.ViewPanelScrollTop = "1200";
                    }
                    break;

                case "DELETE":
                    if (GridWeb1.ActiveSheetIndex == 0)
                    {
                        if (GridWeb1.ActiveCell != null)
                            // Delete bind row
                            GridWeb1.WebWorksheets.ActiveSheet.DeleteBindRow(GridWeb1.ActiveCell.Row);
                    }
                    break;
            }
        }

        protected void chkCreateSheetHeader_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkCreateSheetHeader.Checked)
                // Bind sheet headers
                BindWithInSheetHeaders();
            else
                // Bind with out sheet headers
                BindWithoutInSheetHeaders();
        }

        protected void chkControlHeaderBar_CheckedChanged(object sender, System.EventArgs e)
        {
            // Set header bar property
            GridWeb1.ShowHeaderBar = chkControlHeaderBar.Checked;
        }

        protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();     
        }

        private void ShowErrorMsg(string msg)
        {
            // Display error message
            Literal script = new Literal();
            script.Text = "<script language='javascript'>alert(\"" + msg + "\");</script>";
            this.Controls.Add(script);
        }

        protected void chkNoScrollBar_CheckedChanged(object sender, System.EventArgs e)
        {
            // Set scroll property
            //GridWeb1.NoScroll = chkNoScrollBar.Checked;
        }

        // Binds sheet.
        protected void BtnBind_Click(object sender, System.EventArgs e)
        {
            if (chkCreateSheetHeader.Checked)
                // Bind sheet headers
                BindWithInSheetHeaders();
            else
                // Bind with out sheet headers
                BindWithoutInSheetHeaders();
        }

        protected void GridWeb1_SubmitCommand(object sender, CellEventArgs e)
        {

        }
    }

}
