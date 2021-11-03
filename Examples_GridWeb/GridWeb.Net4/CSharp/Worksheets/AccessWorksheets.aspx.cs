using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class AccessWorksheets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb1 and load data 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Clear();
                GridWeb1.WorkSheets.Add();
                LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void btnViewWorksheets_Click(object sender, EventArgs e)
        {
            // ExStart:AccessWorksheetUsingIndex
            // Accessing a worksheet using its index
            GridWorksheet sheet = GridWeb1.WorkSheets[0];
            Label1.Text = "Sheet at index 0 is : " + sheet.Name + "<br/>";
            // ExEnd:AccessWorksheetUsingIndex

            // ExStart:AccessWorksheetUsingName
            // Accessing a worksheet using its name
            GridWorksheet sheet1 = GridWeb1.WorkSheets["Catalog"];
            Label1.Text += "Index of sheet  Catalog is : " + sheet1.Index + "<br/>";
            // ExEnd:AccessWorksheetUsingName
        }
    }
}