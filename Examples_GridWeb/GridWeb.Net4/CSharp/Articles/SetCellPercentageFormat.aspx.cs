using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class SetCellPercentageFormat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitGridWeb();
            }
        }

        private void InitGridWeb()
        {
            // ExStart:SetCellPercentageFormat
            // Access cell A1 of first gridweb worksheet
            GridCell cellA1 = GridWeb1.WorkSheets[0].Cells["A1"];

            // Access cell style and set its number format to 10 which is a Percentage 0.00% format
            GridTableItemStyle st = cellA1.Style;
            st.NumberType = 10;
            cellA1.Style = st;
            // ExEnd:SetCellPercentageFormat

            cellA1.PutValue(0.03);
        }
    }
}