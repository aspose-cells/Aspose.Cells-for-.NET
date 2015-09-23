using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.cms.businesslogic.member;
using Aspose.Cells;
using System.Drawing;
using System.IO;

namespace Aspose.UmbracoMemberExportToExcel
{
    public partial class AsposeMemberExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Visible = false;
                if (!Page.IsPostBack)
                    LoadMembers();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
                ErrorLabel.Visible = true;
            }

        }

        void LoadMembers()
        {
            IEnumerable<Member> listMembers = Member.GetAllAsList();
            UmbracoMembersGridView.DataSource = listMembers;
            UmbracoMembersGridView.DataBind();

            if (UmbracoMembersGridView.Rows.Count > 0)
            {
                UmbracoMembersGridView.UseAccessibleHeader = true;
                UmbracoMembersGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for license and apply if exists
                string licenseFile = Server.MapPath("~/App_Data/Aspose.Cells.lic");
                if (File.Exists(licenseFile))
                {
                    License license = new License();
                    license.SetLicense(licenseFile);
                }

                List<Member> selectedMembersList = new List<Member>();

                foreach (GridViewRow row in UmbracoMembersGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("SelectedCheckBox") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string email = UmbracoMembersGridView.DataKeys[row.RowIndex].Value.ToString();
                            selectedMembersList.Add(Member.GetMemberFromEmail(email));
                        }
                    }
                }

                if (selectedMembersList.Count() < 1)
                {
                    selectedMembersList = Member.GetAllAsList().ToList<Member>();
                }

                //Instantiate a new Workbook
                Workbook book = new Workbook();
                //Clear all the worksheets
                book.Worksheets.Clear();
                //Add a new Sheet "Data";
                Worksheet sheet = book.Worksheets.Add("MembersExport");

                //We pick a few columns not all to import to the worksheet
                sheet.Cells.ImportCustomObjects((System.Collections.ICollection)selectedMembersList,
                new string[] { "Text", "LoginName", "Email", "CreateDateTime" }, true, 0, 0, selectedMembersList.Count(), true, "dd/mm/yyyy", false);

                Worksheet worksheet = book.Worksheets[0];

                ApplyCellStyle(ref worksheet, "A1");
                worksheet.Cells["A1"].PutValue("Name");

                ApplyCellStyle(ref worksheet, "B1");
                ApplyCellStyle(ref worksheet, "C1");
                ApplyCellStyle(ref worksheet, "D1");

                worksheet.Cells.InsertRow(0);
                worksheet.Cells.InsertColumn(0);

                worksheet.AutoFitColumns();

                string fileName = System.Guid.NewGuid().ToString() + "." + ExportTypeDropDown.SelectedValue;

                if (SaveCopyToDiskCheckBox.Checked)
                {
                    string exportDirectory = Server.MapPath("~/App_Data/AsposeMemberExport");
                    if (!Directory.Exists(exportDirectory)) Directory.CreateDirectory(exportDirectory);
                    book.Save(exportDirectory + "/" + fileName);
                }
                book.Save(this.Response, fileName, ContentDisposition.Attachment, GetSaveFormat(ExportTypeDropDown.SelectedValue));
                Response.End();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
                ErrorLabel.Visible = true;
            }
        }

        private XlsSaveOptions GetSaveFormat(string format)
        {
            XlsSaveOptions saveOption = new XlsSaveOptions(SaveFormat.Xlsx);

            switch (format)
            {
                case "xlsx":
                    saveOption = new XlsSaveOptions(SaveFormat.Xlsx); break;
                case "xlsb":
                    saveOption = new XlsSaveOptions(SaveFormat.Xlsb); break;
                case "xls":
                    saveOption = new XlsSaveOptions(SaveFormat.Excel97To2003); break;
                case "txt":
                    saveOption = new XlsSaveOptions(SaveFormat.TabDelimited); break;
                case "csv":
                    saveOption = new XlsSaveOptions(SaveFormat.CSV); break;
                case "ods":
                    saveOption = new XlsSaveOptions(SaveFormat.ODS); break;
            }

            return saveOption;
        }

        private void ApplyCellStyle(ref Worksheet worksheet, string cellName)
        {
            Cell cell = worksheet.Cells[cellName];
            Aspose.Cells.Style style = cell.GetStyle();
            style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.TopBorder].Color = Color.Black;
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.BottomBorder].Color = Color.Black;
            style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.LeftBorder].Color = Color.Black;
            style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.RightBorder].Color = Color.Black;

            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = Color.LightGray;

            style.Font.IsBold = true;
            cell.SetStyle(style);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ErrorLabel.Visible)
            {
                ErrorLabel.Text = "<br>" + ErrorLabel.Text + "<br>";
            }
        }
    }
}