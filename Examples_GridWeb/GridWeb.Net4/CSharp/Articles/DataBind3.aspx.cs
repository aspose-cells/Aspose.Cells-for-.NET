using System;
using System.Collections;
using Aspose.Cells.GridWeb.Data;
using Aspose.Cells.GridWeb.DemosCS.DataBind;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.DataBind
{
    public partial class DataBind3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                // Creates the collection.
                MyCollection list = new MyCollection();
                System.Random rand = new System.Random();
                for (int i = 0; i < 5; i++)
                {
                    // Create custom record object and set properties
                    MyCustomRecord rec = new MyCustomRecord();
                    rec.DateField1 = DateTime.Now;
                    rec.DoubleField1 = rand.NextDouble();
                    rec.IntField1 = rand.Next();
                    rec.StringField1 = "ABC_" + i;
                    ((IList)list).Add(rec);
                }

                // Create web worksheet object
                GridWorksheet sheet = GridWeb1.WorkSheets[0];

                // Uses the collection as datasource.
                sheet.DataSource = list;

                // Creates bind columns.
                sheet.CreateAutoGenratedColumns();

                // Sets the DateFiled1's validation to DateTime.
                sheet.BindColumns["DateField1"].Validation.ValidationType = GridValidationType.DateTime;

                // Binding.
                sheet.DataBind();
            }
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

        // Custom command button event handler.
        protected void GridWeb1_CustomCommand(object sender, string command)
        {
            switch (command)
            {
                case "ADD":
                    if (GridWeb1.ActiveSheetIndex == 0)
                    {
                        // Create new active row
                        GridWeb1.WebWorksheets.ActiveSheet.CreateNewBindRow();
                        // Scrolls the panel to the bottom.
                        GridWeb1.ViewPanelScrollTop = int.MaxValue.ToString();
                    }
                    break;

                case "DELETE":
                    if (GridWeb1.ActiveSheetIndex == 0)
                    {
                        if (GridWeb1.ActiveCell != null)
                            // Delete active row
                            GridWeb1.WebWorksheets.ActiveSheet.DeleteBindRow(GridWeb1.ActiveCell.Row);
                    }
                    break;
            }
        }

        // Initialize new bind row.
        private void GridWeb1_InitializeNewBindRow(GridWorksheet sender, object bindObject)
        {
            // Handles the initialize new bind row event.
            MyCustomRecord rec = (MyCustomRecord)bindObject;
            rec.DateField1 = DateTime.Now;
        }
    }
}

