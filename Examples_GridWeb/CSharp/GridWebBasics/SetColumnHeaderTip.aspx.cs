using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class SetColumnHeaderTip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false && this.GridWeb1.IsPostBack == false)
            {
                //Access the first worksheet
                GridWorksheet gridSheet = GridWeb1.WorkSheets[0];

                //Input data into the cells of the first worksheet.
                gridSheet.Cells["A1"].PutValue("Product1");
                gridSheet.Cells["A2"].PutValue("Product2");
                gridSheet.Cells["A3"].PutValue("Product3");
                gridSheet.Cells["A4"].PutValue("Product4");
                gridSheet.Cells["B1"].PutValue(100);
                gridSheet.Cells["B2"].PutValue(200);
                gridSheet.Cells["B3"].PutValue(300);
                gridSheet.Cells["B4"].PutValue(400);

                //Set the caption of the first two columns.
                gridSheet.SetColumnCaption(0, "Product Name");
                gridSheet.SetColumnCaption(1, "Price");

                //Set the column width of the first column.
                gridSheet.Cells.SetColumnWidth(0, 20);

                //Set the second column header's tip.
                gridSheet.SetColumnHeaderToolTip(1, "Unit Price of Products");

                //Set the last cell so that scroll bars appear
                gridSheet.Cells["J30"].PutValue("");

            }
        }
    }
}