/*
' Copyright (c) 2015  Aspose.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using Aspose.Cells;
using System.Collections;
using System.Data;
using System.IO;
using System.Drawing;
using DotNetNuke.Entities.Users;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace Aspose.DNN.ExportUsersAndRolesToExcel
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from Aspose.DNN.ExportUsersAndRolesToExcelModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : ExportUsersAndRolesToExcelModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArrayList dnnUsersArrayList = UserController.GetUsers(PortalId);
                if (dnnUsersArrayList.Count == 0)
                {
                    ExportButton.Visible = false;
                    ExportTypeDropDown.Visible = false;
                }

                ArrayList stuffedUsers = new ArrayList();

                DataTable output = new DataTable("ASA");
                output.Columns.Add("DisplayName");
                output.Columns.Add("Email");
                output.Columns.Add("Roles");
                output.Columns.Add("UserID");


                foreach (UserInfo user in dnnUsersArrayList)
                {

                    string roles = string.Join(",", user.Roles);

                    DataRow dr;
                    dr = output.NewRow();
                    dr["DisplayName"] = user.DisplayName;
                    dr["Email"] = user.Email;
                    dr["Roles"] = roles;
                    dr["UserID"] = user.UserID;

                    output.Rows.Add(dr);


                }

                UsersGridView.DataSource = output;
                if (!IsPostBack)
                    UsersGridView.DataBind();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            string format = ExportTypeDropDown.SelectedValue;            

            DataTable selectedUsers = new DataTable("SU");
            selectedUsers.Columns.Add("DisplayName");
            selectedUsers.Columns.Add("Email");
            selectedUsers.Columns.Add("Roles");
            selectedUsers.Columns.Add("UserID");
            

            foreach (GridViewRow row in UsersGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("SelectedCheckBox") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int userId = Convert.ToInt32(UsersGridView.DataKeys[row.RowIndex].Value.ToString());
                        UserInfo user = UserController.GetUserById(PortalId, userId);

                        string roles = string.Join(",", user.Roles);

                        DataRow dr;
                        dr = selectedUsers.NewRow();
                        dr["UserID"] = user.UserID;
                        dr["DisplayName"] = user.DisplayName;
                        dr["Email"] = user.Email;
                        dr["Roles"] = roles;                        
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
                string licenseFile = Server.MapPath("~/App_Data/Aspose.Words.lic");
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
                Worksheet sheet = book.Worksheets.Add("DNN Users");

                //We pick a few columns not all to import to the worksheet
                sheet.Cells.ImportDataTable(selectedUsers,true,"A1");

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
    }
}