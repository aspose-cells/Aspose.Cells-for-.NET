using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class FormatCells : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        protected void btnApplyFontStyles_Click(object sender, EventArgs e)
        {         
            // ExStart:ApplyFontStyles
            // Accessing the reference of the worksheet that is currently active and resize first row and column
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];
            sheet.Cells.Clear();
            sheet.Cells.SetColumnWidth(0, 50);
            sheet.Cells.SetRowHeight(0, 40);

            // Accessing a specific cell of the worksheet
            GridCell cell = sheet.Cells["A1"];

            // Inserting a value in cell A1
            cell.PutValue("Aspose.Cells.GridWeb");
           
            var style = cell.Style;

            // Setting font, color and alignment of cell
            style.Font.Size = new FontUnit("12pt");
            style.Font.Bold = true;
            style.ForeColor = Color.Blue;
            style.BackColor = Color.Aqua;
            style.HorizontalAlign = HorizontalAlign.Center;                        

            // Set the cell style
            cell.CopyStyle(style);
            sheet.AutoFitColumn(0);
            // ExEnd:ApplyFontStyles           
        }             

        protected void btnApplyBorderStyles_Click(object sender, EventArgs e)
        {
            // ExStart:ApplyBorderStyles
            // Accessing the reference of the worksheet that is currently active and resize first row and column
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];
            sheet.Cells.Clear();
            sheet.Cells.SetColumnWidth(0, 50);
            sheet.Cells.SetRowHeight(0, 40);

            // Accessing a specific cell of the worksheet
            GridCell cell = sheet.Cells["A1"];

            var style = cell.Style;

            // Setting the border style, width and color
            style.BorderStyle = BorderStyle.Solid;
            style.BorderWidth = new Unit(2, UnitType.Pixel);
            style.BorderColor = Color.Blue;
            
            // Set the cell style
            cell.CopyStyle(style);
            // ExEnd:ApplyBorderStyles
        }

        protected void btnApplyRangeBorderStyles_Click(object sender, EventArgs e)
        {
            // ExStart:ApplyRangeBorderStyles
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            sheet.Cells.Clear();

            // Creating an instance of WebBorderStyle
            WebBorderStyle bstyle = new WebBorderStyle();

            // Setting the border style, width and color
            bstyle.BorderStyle = BorderStyle.Double;
            bstyle.BorderWidth = new Unit(3, UnitType.Pixel);
            bstyle.BorderColor = Color.Blue;

            // Applying the instance of WebBorderStyle on a specified range of cells
            sheet.Cells.SetBorders(1, 1, 5, 4, SetBorderPosition.Cross, bstyle);
            // ExEnd:ApplyRangeBorderStyles
        }

        protected void btnApplyNumberFormats_Click(object sender, EventArgs e)
        {
            // ExStart:ApplyNumberFormats
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            sheet.Cells.Clear();
            
            sheet.Cells.SetColumnWidth(0, 50);
            sheet.Cells.SetRowHeight(0, 40);

            // Putting values to cells
            sheet.Cells["A1"].PutValue("Currency1 Number Format");
            sheet.Cells["A2"].PutValue("Custom Number Format");
            sheet.Cells["B1"].PutValue(7800);
            sheet.Cells["B2"].PutValue(2500);

            // Setting the number format of "B1" cell to Currency1
            sheet.Cells["B1"].SetNumberType((int)NumberType.Currency1);
        
            // Setting the custom number format of "B2" cell
            sheet.Cells["B2"].SetCustom("#,##0.0000");
            // ExEnd:ApplyNumberFormats
        }
    }
}