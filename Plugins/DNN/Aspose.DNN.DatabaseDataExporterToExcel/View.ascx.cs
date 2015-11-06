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


namespace Aspose.DotNetNuke.Modules.AsposeDNNDataExporterExcel
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from AsposeDNNDataExporterModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------

    public partial class View : AsposeDNNDataExporterModuleBase, IActionable
    {
        #region "Event Handlers"

        //Default page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // getting default DNN connection string
                    txtConString.Text = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;

                    // Load form view and data source Table, Views dropdownns
                    InitForm();
                }

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        //Reload/Populate Tables & Views dropdownlist
        protected void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                InitForm();
                error_msg.Visible = false;
                success_msg.Visible = true;
                success_msg.InnerText = "Tables & Views Loaded Successfully.";
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }

        //Export data file as per selected export type
        protected void ProcessButton_Click(object sender, EventArgs e)
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

                String connString = txtConString.Text;
                //**STRING UPDATED**
                String Query = "SELECT * FROM " + ddlTables.SelectedValue + " ORDER BY 1";
                switch (ddlSource.SelectedValue)
                {
                    case "0":
                        if (ddlTables.Items.Count <= 0)
                        {
                            success_msg.Visible = false;
                            error_msg.Visible = true;
                            error_msg.InnerHtml = "There are no tables to select data.";
                            return;
                        }
                        Query = "SELECT * FROM " + ddlTables.SelectedValue + " ORDER BY 1";
                        break;
                    case "1":
                        if (ddlViews.Items.Count <= 0)
                        {
                            success_msg.Visible = false;
                            error_msg.Visible = true;
                            error_msg.InnerHtml = "There are no views to select data.";
                            return;
                        }
                        Query = "SELECT * FROM " + ddlViews.SelectedValue;
                        break;
                    case "2":
                        if (txtCustomQuery.Text.Trim().Equals(""))
                        {
                            success_msg.Visible = false;
                            error_msg.Visible = true;
                            error_msg.InnerHtml = "Please enter custom query.";
                            return;
                        }
                        Query = txtCustomQuery.Text.Trim();
                        break;
                }
                success_msg.Visible = false;
                error_msg.Visible = false;

                using (var cn = new SqlConnection(connString))
                {
                    //opening database connection
                    cn.Open();

                    //creating datatable, sqlCommand and sqlReader objects
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    SqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);

                    //creating leadoptions for excel file
                    LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
                    loadOptions.CheckExcelRestriction = false;

                    //Instantiate a new Workbook with Load options to prevent max cell string length of 32k error
                    Workbook book = new Workbook(Server.MapPath("~/App_Data/Sample.xlsx"), loadOptions);

                    //Clear all the worksheets
                    book.Worksheets.Clear();

                    //Add a new Sheet "Data";
                    Worksheet sheet = book.Worksheets.Add("Exported Data");

                    //Data Table import to the worksheet, inserting from A1 cell of sheet
                    sheet.Cells.ImportDataTable(dt, true, "A1");

                    // Apply Hearder Row/First Row text to Bold
                    Cells.Style objStyle = new Cells.Style();
                    objStyle.Font.IsBold = true;

                    StyleFlag objStyleFlag = new StyleFlag();
                    objStyleFlag.FontBold = true;

                    sheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                    // Fit columns width to contents
                    sheet.AutoFitColumns();

                    //Create unique file name
                    string fileName = System.Guid.NewGuid().ToString() + "." + ExportTypeDropDown.SelectedValue;

                    //Save workbook as per export type
                    book.Save(this.Response, fileName, ContentDisposition.Attachment, GetSaveFormat(ExportTypeDropDown.SelectedValue));
                    Response.End();
                }

                error_msg.Visible = false;
                success_msg.Visible = true;
                success_msg.InnerText = "Data exported successfully.";

            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }

        //Module action, on edit
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

        #endregion

        #region "Private Functions"

        //Form Initiating & Loading Tables and Views DropDownLists
        private void InitForm()
        {
            // Check for license and apply if exists
            string licenseFile = Server.MapPath("~/App_Data/Aspose.Total.lic");
            if (File.Exists(licenseFile))
            {
                License license = new License();
                license.SetLicense(licenseFile);
            }

            String connString = txtConString.Text;

            using (var cn = new SqlConnection(connString))
            {
                cn.Open();
                DataTable dt = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM information_schema.tables ORDER BY TABLE_NAME", cn);
                    SqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);
                    ddlTables.DataSource = dt;
                    ddlTables.DataTextField = "TABLE_NAME";
                    ddlTables.DataValueField = "TABLE_NAME";
                    ddlTables.DataBind();

                }
                catch (SqlException e)
                {
                    throw e;
                }

                dt = new DataTable();

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM information_schema.views ORDER BY TABLE_NAME", cn);
                    SqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);

                    ddlViews.DataSource = dt;
                    ddlViews.DataTextField = "TABLE_NAME";
                    ddlViews.DataValueField = "TABLE_NAME";
                    ddlViews.DataBind();

                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

            ddlSource.Attributes.Add("onchange", "javascript:sourceChanged();");

            ddlTables.Style["display"] = "none";
            ddlViews.Style["display"] = "none";
            txtCustomQuery.Style["display"] = "none";

            switch (ddlSource.SelectedValue)
            {
                case "0":
                    ddlTables.Style["display"] = "block";
                    break;
                case "1":
                    ddlViews.Style["display"] = "block";
                    break;
                case "2":
                    txtCustomQuery.Style["display"] = "block";
                    break;
            }

            // Create sample Excel file to use while generating exported file
            if (!File.Exists(Server.MapPath("~/App_Data/Sample.xlsx")))
            {
                File.Create(Server.MapPath("~/App_Data/Sample.xlsx"));
            }

        }

        //Get Save File Formats
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

        #endregion
    }
}