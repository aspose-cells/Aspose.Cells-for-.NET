using System;
using System.Web.UI.WebControls;
using System.IO;
using Aspose.Cells;
using System.Data;
using System.Web.UI;

namespace Aspose.Sitefinity.FormBuilder
{
    public partial class AsposeFormBuilder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();  // popluategrid function

            }
            catch (Exception exc)
            {
                ShowException(exc);
            }
        }


        protected void btnUpdate_OnClick(object sender, EventArgs e)
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
                            string setupSeletectedItemId = (string)Session["SetupSeletectedItemID"];

                            DataRow[] drs = dt.Select("[Field ID] = '" + setupSeletectedItemId + "'");
                            if (true)
                            {
                                if (drs.Length > 0)
                                {
                                    drs = dt.Select("[Field ID] = '" + txtFieldId.Text.Trim() + "'"); // checking field type constraint 
                                    if (drs != null)
                                    {
                                        if (drs.Length > 0)
                                        {
                                            if (setupSeletectedItemId == txtFieldId.Text.Trim())
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


                                                lbl_Msg.Visible = true;
                                                lbl_Msg.CssClass = "alertupdate";
                                                lbl_Msg.Text = "Field updated successfully";

                                                dt.AcceptChanges();

                                            }
                                            else
                                            {       // on updating field user Enter other Field ID
                                                lbl_Msg.Visible = true;
                                                lbl_Msg.CssClass = "alertdanger";
                                                lbl_Msg.Text = "Field ID already exists ";
                                                btnUpdate.Visible = true;
                                                return;

                                            }
                                        }
                                        else
                                        {                                            
                                            lbl_Msg.Visible = true;
                                            lbl_Msg.CssClass = "alertdanger";
                                            lbl_Msg.Text = "Field ID not exists ";
                                            btnUpdate.Visible = true;
                                            return;

                                        }
                                    }

                                }
                                else
                                {
                                    // new field record case 
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

                                    dr["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                                    dt.Rows.Add(dr);

                                    lbl_Msg.Visible = true;
                                    lbl_Msg.CssClass = "Success";
                                    lbl_Msg.Text = "Field added successfully";

                                }

                                Session["AsposeDynamicFormsdataTable"] = dt;

                                //Creating a file stream containing the Excel file to be opened
                                FileStream fstream = new FileStream(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

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

                                Aspose.Cells.Style objStyle = workbook.CreateStyle();
                                objStyle.Font.IsBold = true;

                                //Bold style flag options
                                StyleFlag objStyleFlag = new StyleFlag();
                                objStyleFlag.FontBold = true;
                                //Apply this style to row 1

                                Row row1 = workbook.Worksheets[0].Cells.Rows[0];
                                row1.ApplyStyle(objStyle, objStyleFlag);
                                worksheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                                //Auto-fit all the columns
                                workbook.Worksheets["Data"].AutoFitColumns();
                                workbook.Save(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"), SaveFormat.Xlsx);

                                PopulateGrid();
                                ClearFields();      // clear field function which clear all fields while update/adding record 




                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ShowException(exc);
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
                            if (true)
                            {
                                if (drs.Length > 0)
                                {
                                    if (ProcessButton.Text.Equals("Add"))
                                    {
                                        lbl_Msg.Visible = true;
                                        lbl_Msg.CssClass = "alertdanger";
                                        lbl_Msg.Text = "Field ID already exists ";
                                        return;
                                    }

                                    drs[0]["Field Type"] = ddlFieldType.SelectedValue.Trim();

                                    if (txtFieldId.Text.Trim() == "")
                                    {
                                        drs[0]["Field ID"] = "NULL";
                                    }
                                    else
                                    {
                                        drs[0]["Field ID"] = txtFieldId.Text.Trim();
                                    }
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

                                    drs[0]["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                                    lbl_Msg.Visible = true;
                                    lbl_Msg.CssClass = "alertdanger";
                                    lbl_Msg.Text = "Field deleted successfully";

                                    if (ProcessButton.Text.Equals("Update"))
                                    {
                                        lbl_Msg.Visible = true;
                                        lbl_Msg.CssClass = "alertupdate";
                                        lbl_Msg.Text = "Field updated successfully";

                                    }

                                    dt.AcceptChanges();


                                }
                                else
                                {
                                    // new field adding 
                                    DataRow dr = dt.NewRow();

                                    dr["Field Type"] = ddlFieldType.SelectedValue.Trim();
                                    if (txtFieldId.Text.Trim() == "")
                                    {
                                        dr["Field ID"] = "NULL";
                                    }
                                    else
                                    {
                                        dr["Field ID"] = txtFieldId.Text.Trim();
                                    }

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

                                    dr["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                                    dt.Rows.Add(dr);
                                }

                                UpdateSheet(dt);

                            }
                        }
                        else
                        {           // if file is empty and user add new field

                            // new field adding 
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

                            dr["Modified On"] = DateTime.Now.ToString("MM-dd-YYYY");

                            dt.Rows.Add(dr);

                            UpdateSheet(dt);

                        }
                    }
                }
                ProcessButton.Text = "Add";
            }
            catch (Exception exc)
            {
                ShowException(exc);
            }
        }

        private void UpdateSheet(DataTable dt)
        {
            Session["AsposeDynamicFormsdataTable"] = dt;

            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

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

            Aspose.Cells.Style objStyle = workbook.CreateStyle();
            objStyle.Font.IsBold = true;

            //Bold style flag options
            StyleFlag objStyleFlag = new StyleFlag();
            objStyleFlag.FontBold = true;
            //Apply this style to row 1

            Row row1 = workbook.Worksheets[0].Cells.Rows[0];
            row1.ApplyStyle(objStyle, objStyleFlag);
            worksheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

            //Auto-fit all the columns
            workbook.Worksheets["Data"].AutoFitColumns();
            workbook.Save(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"), SaveFormat.Xlsx);


            PopulateGrid();

            if (!ProcessButton.Text.Equals("Update"))
            {
                lbl_Msg.Visible = true;
                lbl_Msg.CssClass = "Success";
                lbl_Msg.Text = "Field added successfully";
            }
            ClearFields();

        }

        /// <summary>
        /// Clear Fields Function which clear all the fields while updateing/adding a new Field record
        /// </summary>

        private void ClearFields()
        {
            ProcessButton.Text = "Add";
            txtFieldId.Text = string.Empty;
            txtFieldLableText.Text = string.Empty;
            txtFieldValues.Text = string.Empty;
            chkIsDisplay.Checked = true;
            txtSortId.Text = string.Empty;
            ddlFieldType.SelectedIndex = 0;
            ProcessButton.Visible = true;
            btnUpdate.Visible = false;

        }

        /// <summary>
        /// PopulateGrid function which read data from execl file and show data in gridview
        /// </summary>

        private void PopulateGrid()
        {
            try
            {
                DataTable dataTable = null;
                if (Session["AsposeDynamicFormsdataTable"] == null)
                {

                    // Check for license and apply if exists
                    string licenseFile = Server.MapPath("~/App_Data/Aspose.Total.lic");
                    if (File.Exists(licenseFile))
                    {
                        License license = new License();
                        license.SetLicense(licenseFile);
                    }

                    //Creating a file stream containing the Excel file to be opened
                    FileStream fstream = new FileStream(Server.MapPath("~/uploads/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
            catch (Exception exc)
            {
                ShowException(exc);
            }

            btnUpdate.Visible = false;
        }


        /// <summary>
        /// Gridview functions for Updating/Deleting record
        /// </summary>


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string SetupSeletectedItemID = "";

                if (string.Equals(e.CommandName, "EditSetupValue"))     // Update Record Case
                {
                    SetupSeletectedItemID = e.CommandArgument.ToString();
                    Session["SetupSeletectedItemID"] = SetupSeletectedItemID;
                    lbl_Msg.Visible = false;
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
                                        btnUpdate.Visible = true;
                                        ProcessButton.Visible = false;
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
                                    }
                                }
                            }
                        }
                    }
                }
                else if (string.Equals(e.CommandName, "Delete"))
                {                                                   // Delete Record Case
                    SetupSeletectedItemID = e.CommandArgument.ToString();
                    if (!SetupSeletectedItemID.Equals(""))
                    {
                        if (Session["AsposeDynamicFormsdataTable"] != null)
                        {
                            DataTable dt = (DataTable)Session["AsposeDynamicFormsdataTable"];
                            if (dt != null)
                            {
                                DataTable dataTable = null;
                                if (dt.Rows.Count > 0)
                                {
                                    int selectedRow = -1;

                                    if (SetupSeletectedItemID != null || !SetupSeletectedItemID.Equals(""))
                                        selectedRow = Convert.ToInt16(SetupSeletectedItemID);

                                    //Creating a file stream containing the Excel file to be opened
                                    FileStream fstream = new FileStream(Server.MapPath("~/Uploads/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

                                    //Instantiating a Workbook object
                                    //Opening the Excel file through the file stream
                                    Workbook workbook = new Workbook(fstream);

                                    //Accessing a worksheet using its sheet name
                                    Worksheet worksheet = workbook.Worksheets["Settings"];

                                    //Closing the file stream to free all resources
                                    fstream.Close();
                                    selectedRow = selectedRow + 1;
                                    worksheet.Cells.DeleteRow(selectedRow);
                                    workbook.Save(Server.MapPath("~/uploads/AsposeDynamicFormsDataFile.xlsx"), SaveFormat.Xlsx);
                                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 10, true);
                                    Session["AsposeDynamicFormsdataTable"] = dataTable;
                                    lbl_Msg.Visible = true;
                                    lbl_Msg.CssClass = "alertdanger";
                                    lbl_Msg.Text = "Field deleted successfully";
                                    PopulateGrid();
                                    ClearFields();
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception exc)
            {
                ShowException(exc);
            }
        }

        protected void GridView1_RowCommand_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dataTable = (DataTable)Session["AsposeDynamicFormsdataTable"];
            GridView1.DataSource = dataTable;
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        public void PendingRecordsGridview_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ClearFormButton_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Msg.Visible = false;
                lbl_Msg.Text = "";
                ProcessButton.Text = "Add";
                ClearFields();
            }
            catch (Exception exc)
            {
                ShowException(exc);
            }
        }


        /// <summary>
        /// Generic Execption function which display message according to expection
        /// </summary>

        private void ShowException(Exception exc)
        {
            lbl_Msg.Visible = true;
            lbl_Msg.CssClass = "alertdanger";
            lbl_Msg.Text = exc.Message;
        }

        /// <summary>
        /// Event Handler when user click on back button 
        /// </summary>

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/View.ascx");
        }
    }
}
