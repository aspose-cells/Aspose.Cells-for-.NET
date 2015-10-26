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
using Aspose.DNN.ImportUsersFromExcel;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using DotNetNuke.Security.Membership;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using System.Collections;


namespace Aspose.DNN.ImportUsersFromExcel
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from Aspose.DNN.ImportUsersFromExcelModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------    

    public partial class View : ImportUsersFromExcelModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

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

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            success_msg.Visible = false;
            error_msg.Visible = false;
            info_msg.Visible = false;

            // Check for license and apply if exists
            string licenseFile = Server.MapPath("~/App_Data/Aspose.Total.lic");
            if (File.Exists(licenseFile))
            {
                License license = new License();
                license.SetLicense(licenseFile);
            }
            
            try
            {
                Stream stream = ImportFileUpload.FileContent;
                Workbook wb = new Workbook(stream);

                string filePath = Server.MapPath("~/temp/");
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                filePath += "\\" + ImportFileUpload.FileName;

                wb.Save(filePath);

                Workbook workbook = new Workbook(filePath);

                Worksheet sheet = workbook.Worksheets[0];

                if(sheet.Cells.MaxDataRow > 1)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID", typeof(int)),
                            new DataColumn("Username", typeof(string)),
                            new DataColumn("DisplayName", typeof(string)),
                            new DataColumn("Email",typeof(string)) });

                    int r = 1;

                    while (r <= sheet.Cells.MaxRow)
                    {                        
                        UserInfo userInfo = UserController.GetUserByName(PortalId, sheet.Cells[r, 0].Value.ToString());
                        if (userInfo == null)
                        {
                            dt.Rows.Add(r, sheet.Cells[r, 0].Value, sheet.Cells[r, 1].Value, sheet.Cells[r, 2].Value);
                        }                        
                        r++;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        UsersGridView.DataSource = dt;
                        UsersGridView.DataBind();

                        UsersGridView.Visible = true;
                        ProcessButton.Visible = true;
                        ImportHeading.Visible = true;
                    }
                    else
                    {
                        info_msg.Visible = true;
                        info_msg.InnerText = "All the users in file already exists in DNN.";
                    }
                    
                }
                else
                {
                    error_msg.Visible = true;
                    error_msg.InnerText = "No data found in file.";
                }                                
            }
            catch( Exception exc)
            {
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }


        }

        protected void ProcessButton_Click(object sender, EventArgs e)
        {
            int importedCount = 0;
            foreach (GridViewRow row in UsersGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("SelectedCheckBox") as CheckBox);
                    if (chkRow.Checked)
                    {                        
                        UserInfo user = new UserInfo();
                        user.Email = row.Cells[2].Text;
                        user.DisplayName = row.Cells[1].Text;
                        user.Username = row.Cells[3].Text;
                        
                        UserInfo userInfo = UserController.GetUserByName(PortalId, user.Username);

                        if(userInfo == null)
                        {
                            CreateDNNUser(user);
                            importedCount++;
                        }
                        
                    }
                }
            }
            success_msg.Visible = true;
            success_msg.InnerText = importedCount.ToString() + " users imported successfully.";
        }

        private UserCreateStatus CreateDNNUser(UserInfo user)
        {
            user.Membership.Password = UserController.GeneratePassword(12).ToString();
            user.PortalID = PortalId;
            user.IsSuperUser = false;

            UserCreateStatus createStatus = UserCreateStatus.AddUser;

            //Create the User
            createStatus = UserController.CreateUser(ref user);

            if (createStatus == UserCreateStatus.Success)
            {
                RoleController objRoles = new RoleController();

                List<int> rolesList = new List<int>();

                foreach (int roleID in rolesList)
                {
                    objRoles.AddUserRole(user.PortalID, user.UserID, roleID, Null.NullDate, Null.NullDate);
                }
            }

            return createStatus;
        }

        protected void DownloadTemplate()
        {
            string fileName = "./TemplateFile.xlsx";

            FileStream fs = new FileStream(MapPath(fileName), FileMode.Open);
            long cntBytes = new FileInfo(MapPath(fileName)).Length;
            byte[] byteArray = new byte[Convert.ToInt32(cntBytes)];
            fs.Read(byteArray, 0, Convert.ToInt32(cntBytes));
            fs.Close();




            if (byteArray != null)
            {
                this.Response.Clear();
                this.Response.ContentType = "text/plain";
                this.Response.AddHeader("content-disposition", "attachment;filename=TemplateFile.xlsx");
                this.Response.BinaryWrite(byteArray);
                this.Response.End();
                this.Response.Flush();
                this.Response.Close();
            }
            File.Delete(Server.MapPath(fileName));
        }

        protected void templateFile_Click(object sender, EventArgs e)
        {
            DownloadTemplate();
        }
    }
}