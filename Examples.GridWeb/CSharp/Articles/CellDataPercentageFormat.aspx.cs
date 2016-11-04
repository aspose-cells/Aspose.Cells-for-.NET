using System;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class CellDataPercentageFormat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ExStart:ShowPercentageFormat
                // Access cell A1 of first gridweb worksheet
                Data.GridCell cellA1 = GridWeb1.WorkSheets[0].Cells["A1"];

                // Access cell style and set its number format to 10 which is a Percentage 0.00% format
                GridTableItemStyle st = cellA1.Style;
                st.NumberType = 10;
                cellA1.Style = st;
                // ExEnd:ShowPercentageFormat
            }
        }
    }
}