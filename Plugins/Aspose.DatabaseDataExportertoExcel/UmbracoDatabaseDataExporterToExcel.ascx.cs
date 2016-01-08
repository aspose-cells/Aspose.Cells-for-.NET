using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Aspose.Cells;
using System.Collections;
using System.Configuration;

namespace Aspose.UmbracoDatabaseDataExporterToExcel
{
    public partial class UmbracoDatabaseDataExporterToExcel : System.Web.UI.UserControl
    {
        #region Page load and events

        // page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // verify page is not post back, so we can setup default page view.
                if (!Page.IsPostBack)
                {
                    // getting default DNN connection string
                    txtConString.Text = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;

                    // Load form view and data source Table, Views dropdownns
                    InitForm();
                }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }

        //Reload/Populate Tables & Views dropdownlist
        protected void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                InitForm();
                lblMessage.Text = "Tables & Views Loaded Successfully.";
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
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
                            lblMessage.Text = "There are no tables to select data.";
                            return;
                        }
                        Query = "SELECT * FROM " + ddlTables.SelectedValue + " ORDER BY 1";
                        break;
                    case "1":
                        if (ddlViews.Items.Count <= 0)
                        {
                            lblMessage.Text = "There are no views to select data.";
                            return;
                        }
                        Query = "SELECT * FROM " + ddlViews.SelectedValue;
                        break;
                    case "2":
                        if (txtCustomQuery.Text.Trim().Equals(""))
                        {
                            lblMessage.Text = "Please enter custom query.";
                            return;
                        }
                        Query = txtCustomQuery.Text.Trim();
                        break;
                }

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

                lblMessage.Text = "Data exported successfully.";

            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }

        #endregion

        #region Private methods

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