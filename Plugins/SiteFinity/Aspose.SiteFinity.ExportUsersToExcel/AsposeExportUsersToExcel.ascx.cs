using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;

namespace Aspose.SiteFinity.ExportUsersToExcel
{
    public partial class AsposeExportUsersToExcel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserManager userManager = UserManager.GetManager();
            List<User> users = userManager.GetUsers().ToList();

            DataTable output = new DataTable("ASA");
            output.Columns.Add("LastName");
            output.Columns.Add("FirstName");
            output.Columns.Add("Email");
            output.Columns.Add("Username");
            output.Columns.Add("UserID");


            foreach (User user in users)
            {
                UserProfileManager profileManager = UserProfileManager.GetManager();
                SitefinityProfile profile = profileManager.GetUserProfile<SitefinityProfile>(user);

                DataRow dr;
                dr = output.NewRow();
                dr["FirstName"] = profile.FirstName;
                dr["Username"] = user.UserName;
                dr["Email"] = user.Email;
                dr["LastName"] = profile.LastName;
                dr["UserID"] = user.Id;

                output.Rows.Add(dr);


            }


            SitefinityUsersGridView.DataSource = output;
            //if (!IsPostBack)
            SitefinityUsersGridView.DataBind();            
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

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            string format = ExportTypeDropDown.SelectedValue;            
            
            DataTable selectedUsers = new DataTable("SU");
            selectedUsers.Columns.Add("UserID");
            selectedUsers.Columns.Add("DisplayName");
            selectedUsers.Columns.Add("Email");
            selectedUsers.Columns.Add("Username");           

            foreach (GridViewRow row in SitefinityUsersGridView.Rows)
            {               
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("SelectedCheckBox") as CheckBox);
                    if (chkRow.Checked)
                    {                        
                        string email = SitefinityUsersGridView.DataKeys[row.RowIndex].Value.ToString();
                        var userMan = UserManager.GetManager();
                        User user = userMan.GetUserByEmail(email);

                        UserProfileManager profileManager = UserProfileManager.GetManager();
                        SitefinityProfile profile = profileManager.GetUserProfile<SitefinityProfile>(user);

                        DataRow dr;
                        dr = selectedUsers.NewRow();
                        dr["UserID"] = user.Id;
                        dr["DisplayName"] = profile.FirstName + " " + profile.LastName;
                        dr["Email"] = user.Email;
                        dr["Username"] = user.UserName;
                        selectedUsers.Rows.Add(dr);
                    }
                }
            }

            if (selectedUsers.Rows.Count == 0)
            {
                NoRowSelectedErrorDiv.Visible = true;
            }
            else
            {
                // Check for license and apply if exists
                string licenseFile = Server.MapPath("~/App_Data/Aspose.Cells.lic");
                if (File.Exists(licenseFile))
                {
                    License license = new License();
                    license.SetLicense(licenseFile);
                }

                //Instantiate a new Workbook
                Workbook book = new Workbook();
                //Clear all the worksheets
                book.Worksheets.Clear();
                //Add a new Sheet "Data";
                Worksheet sheet = book.Worksheets.Add("Sitefinity Users");

                //We pick a few columns not all to import to the worksheet
                sheet.Cells.ImportDataTable(selectedUsers, true, "A1");

                Worksheet worksheet = book.Worksheets[0];

                ApplyCellStyle(ref worksheet, "A1");
                ApplyCellStyle(ref worksheet, "B1");
                ApplyCellStyle(ref worksheet, "C1");
                ApplyCellStyle(ref worksheet, "D1");

                worksheet.Cells.InsertRow(0);
                worksheet.Cells.InsertColumn(0);

                worksheet.AutoFitColumns();

                string fileName = System.Guid.NewGuid().ToString() + "." + format;

                book.Save(this.Response, fileName, ContentDisposition.Attachment, GetSaveFormat(format));
                Response.End();
            }
        }
    }
}