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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Aspose.Cells;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace Aspose.DotNetNuke.Modules.AsposeDynamicFormGeneratorExcel
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from AsposeDNNDynamicFormGeneratorSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : AsposeDNNDynamicFormGeneratorModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                    /* uncomment to load saved settings in the text boxes
                    if(Settings.Contains("Setting1"))
                        txtSetting1.Text = Settings["Setting1"].ToString();
			
                    if (Settings.Contains("Setting2"))
                        txtSetting2.Text = Settings["Setting2"].ToString();

                    */

                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                //modules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text);
                //modules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text);

                //tab module settings
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting1",  txtSetting1.Text);
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting2",  txtSetting2.Text);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        #endregion

        #region Custom Aspose Events and Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PopulateGrid();
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string SetupSeletectedItemID = "";

                if (string.Equals(e.CommandName, "EditSetupValue"))
                {
                    SetupSeletectedItemID = e.CommandArgument.ToString();
                    if (!SetupSeletectedItemID.Equals(""))
                    {
                        if (Session["AsposeDynamicFormsdataTable"] != null)
                        {
                            DataTable dt = (DataTable)Session["AsposeDynamicFormsdataTable"];
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow[] drs = dt.Select("[Field ID] = '" + SetupSeletectedItemID + "'");
                                    if (drs != null)
                                    {
                                        if (drs.Length > 0)
                                        {
                                            ddlFieldType.SelectedValue = drs[0]["Field Type"].ToString().Trim();
                                            txtFieldId.Text = drs[0]["Field ID"].ToString().Trim();
                                            txtFieldLableText.Text = drs[0]["Field Label Text"].ToString().Trim();
                                            txtFieldValues.Text = drs[0]["Field Values"].ToString().Trim();
                                            if (drs[0]["Is Display"].ToString().Trim().Equals("TRUE"))
                                            {
                                                chkIsDisplay.Checked = true;
                                            }
                                            else
                                            {
                                                chkIsDisplay.Checked = false;
                                            }
                                            txtSortId.Text = drs[0]["Sort ID"].ToString().Trim();

                                            ProcessButton.Text = "Update Field";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }

        // Save data to excel file
        protected void ProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["AsposeDynamicFormsdataTable"] != null)
                {
                    DataTable dt = (DataTable)Session["AsposeDynamicFormsdataTable"];
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DataRow[] drs = dt.Select("[Field ID] = '" + txtFieldId.Text + "'");
                            if (drs != null)
                            {
                                if (drs.Length > 0)
                                {
                                    drs[0]["Field Type"] = ddlFieldType.SelectedValue.Trim();
                                    drs[0]["Field ID"] = txtFieldId.Text.Trim();
                                    drs[0]["Field Label Text"] = txtFieldLableText.Text.Trim();
                                    drs[0]["Field Values"] = txtFieldValues.Text.Trim();
                                    if (chkIsDisplay.Checked)
                                    {
                                        drs[0]["Is Display"] = "TRUE";
                                    }
                                    else
                                    {
                                        drs[0]["Is Display"] = "FALSE";
                                    }
                                    drs[0]["Sort ID"] = txtSortId.Text.Trim();
                                    drs[0]["Modified By"] = UserId.ToString();
                                    drs[0]["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                                    dt.AcceptChanges();
                                }
                                else
                                {
                                    DataRow dr = dt.NewRow();

                                    dr["Field Type"] = ddlFieldType.SelectedValue.Trim();
                                    dr["Field ID"] = txtFieldId.Text.Trim();
                                    dr["Field Label Text"] = txtFieldLableText.Text.Trim();
                                    dr["Field Values"] = txtFieldValues.Text.Trim();
                                    if (chkIsDisplay.Checked)
                                    {
                                        dr["Is Display"] = "TRUE";
                                    }
                                    else
                                    {
                                        dr["Is Display"] = "FALSE";
                                    }
                                    dr["Sort ID"] = txtSortId.Text.Trim();
                                    dr["Modified By"] = UserId.ToString();
                                    dr["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                                    dt.Rows.Add(dr);
                                }
                                Session["AsposeDynamicFormsdataTable"] = dt;


                                // Check for license and apply if exists
                                string licenseFile = Server.MapPath("~/App_Data/Aspose.Total.lic");
                                if (File.Exists(licenseFile))
                                {
                                    License license = new License();
                                    license.SetLicense(licenseFile);
                                }

                                //Creating a file stream containing the Excel file to be opened
                                FileStream fstream = new FileStream(Server.MapPath("~/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Docs/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

                                //Instantiating a Workbook object
                                //Opening the Excel file through the file stream
                                Workbook workbook = new Workbook(fstream);

                                //Accessing a worksheet using its sheet name
                                Worksheet worksheet = workbook.Worksheets["Settings"];

                                //Closing the file stream to free all resources
                                fstream.Close();

                                workbook.Worksheets.RemoveAt("Settings");
                                worksheet = workbook.Worksheets.Add("Settings");
                                worksheet.Cells.ImportDataTable(dt, true, "A1");

                                // Apply Hearder Row/First Row text to Bold
                                Cells.Style objStyle = new Cells.Style();
                                objStyle.Font.IsBold = true;

                                StyleFlag objStyleFlag = new StyleFlag();
                                objStyleFlag.FontBold = true;

                                worksheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                                //Auto-fit all the columns
                                workbook.Worksheets["Data"].AutoFitColumns();

                                workbook.Save(Server.MapPath("~/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Docs/AsposeDynamicFormsDataFile.xlsx"), SaveFormat.Xlsx);

                                ClearFormButton_Click(sender, e);
                            }
                        }
                    }
                }
                ProcessButton.Text = "Add New Field";
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }

        // Save data to excel file
        protected void ClearFormButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessButton.Text = "Add New Field";
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }


        private void PopulateGrid()
        {
            try
            {
                // Check for license and apply if exists
                string licenseFile = Server.MapPath("~/App_Data/Aspose.Total.lic");
                if (File.Exists(licenseFile))
                {
                    License license = new License();
                    license.SetLicense(licenseFile);
                }

                DataTable dataTable = null;
                if (Session["AsposeDynamicFormsdataTable"] == null)
                {
                    //Creating a file stream containing the Excel file to be opened
                    FileStream fstream = new FileStream(Server.MapPath("~/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Docs/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

                    //Instantiating a Workbook object
                    //Opening the Excel file through the file stream
                    Workbook workbook = new Workbook(fstream);

                    //Accessing a worksheet using its sheet name
                    Worksheet worksheet = workbook.Worksheets["Settings"];

                    //Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 10, true);

                    //Closing the file stream to free all resources
                    fstream.Close();

                    dataTable.DefaultView.Sort = "[Sort ID] ASC";
                    dataTable = dataTable.DefaultView.ToTable();

                    Session["AsposeDynamicFormsdataTable"] = dataTable;
                }
                else
                {
                    dataTable = (DataTable)Session["AsposeDynamicFormsdataTable"];
                }

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }

        #endregion
    }
}