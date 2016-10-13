using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class ManageComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddComments_Click(object sender, EventArgs e)
        {
            // ExStart:AddComments
            // Accessing the reference of the worksheet that is currently active and add a dummy value to cell A1
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];
            sheet.Cells["A1"].PutValue("This cell has a comment added, hover to view.");

            // Resize first column
            sheet.Cells.SetColumnWidth(0, 140);

            // Adding comment to "A1" cell of the worksheet
            GridComment comment = sheet.Comments[sheet.Comments.Add("A1")];

            // Setting the comment note
            comment.Note = "These are my comments for the cell";
            // ExEnd:AddComments
        }

        protected void btnUpdateComments_Click(object sender, EventArgs e)
        {
            // ExStart:AccessComments
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing a specific cell that contains comment
            GridCell cell = sheet.Cells["A1"];

            // Accessing the comment from the specific cell
            GridComment comment = sheet.Comments[cell.Name];

            if (comment != null)
            {
                // Modifying the comment note
                comment.Note = "I have modified the comment note.";
            }
            // ExEnd:AccessComments
        }

        protected void btnRemoveComments_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveComments
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Accessing a specific cell that contains comment
            GridCell cell = sheet.Cells["A1"];

            // Removing comment from the specific cell
            sheet.Comments.RemoveAt(cell.Name);
            // ExEnd:RemoveComments
        }
    }
}