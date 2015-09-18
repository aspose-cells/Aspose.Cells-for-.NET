using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Aspose.Excel.GridViewExport.Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));


            for (int index = 1; index < 50; index++)
            {
                DataRow dr = dataTable.NewRow();
                dr[0] = index;
                dr[1] = "Product - " + dr[0];
                dr[2] = index + 5;
                dataTable.Rows.Add(dr);
            }

            ExportGridViewToExcel1.ExportDataSource = dataTable;
            ExportGridViewToExcel1.DataSource = dataTable;
            ExportGridViewToExcel1.DataBind();
        }

        protected void ExportGridViewToExcel1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExportGridViewToExcel1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}