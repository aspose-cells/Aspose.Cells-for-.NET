using System;
using System.Data;
using Aspose.Cells.GridWeb.Data;
using Aspose.Cells.GridWeb.DemosCS.DataBind;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.DataBind
{
    public partial class ExpandChildView : System.Web.UI.Page
    {
        protected Aspose.Cells.GridWeb.DemosCS.DataBind.DataSet2 dataSet21;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                BindWithoutInSheetHeaders();
            }
        }

        private void BindWithoutInSheetHeaders()
        {
            // Create dataset object
            this.dataSet21 = new DataSet2();

            // Create demo database
            DemoDatabase2 db = new DemoDatabase2();

            // Create path to database file
            string path = (this.Master as Site).GetDataDir();

            // Create connection string
            db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Miscellaneous\\Database\\Northwind.mdb";
            try
            {
                // Connects to database and fetches data.
                // Customers Table.
                db.oleDbDataAdapter1.Fill(dataSet21);
                // Orders Table.
                db.oleDbDataAdapter2.Fill(dataSet21);
                // OrderDetailTable.
                db.oleDbDataAdapter3.Fill(dataSet21);

                // Create web worksheet object 
                GridWorksheet sheet = GridWeb1.WorkSheets[0];

                // Clears the sheet.
                sheet.Cells.Clear();

                // Disables creating in-sheet headers.
                sheet.EnableCreateBindColumnHeader = false;

                // Data cells begin from row 0.
                sheet.BindStartRow = 0;

                // Bind the sheet to the dataset.    
                sheet.DataSource = dataSet21;
                sheet.DataBind();
            }
            finally
            {
                //Close connection
                db.oleDbConnection1.Close();
            }
        }

        protected void chkNoScrollBar_CheckedChanged(object sender, System.EventArgs e)
        {
            // Set scroll property
            GridWeb1.NoScroll = chkNoScrollBar.Checked;
        }

        // Handles the BindingChildView event to set the UnitPrice column.
        protected void GridWeb1_BindingChildView(Aspose.Cells.GridWeb.GridWeb childGrid, Aspose.Cells.GridWeb.Data.GridWorksheet childSheet)
        {
            DataView view = (DataView)childSheet.DataSource;
            if (view.Table.TableName == "Order Details")
            {
                //S et column data type
                childSheet.BindColumns["UnitPrice"].NumberType = NumberType.Currency3;
            }
        }

    }
}

