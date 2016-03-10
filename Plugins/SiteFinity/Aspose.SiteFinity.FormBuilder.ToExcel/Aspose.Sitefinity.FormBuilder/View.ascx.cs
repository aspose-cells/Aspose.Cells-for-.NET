using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Aspose.Cells;

namespace Aspose.Sitefinity.FormBuilder
{
    public partial class View : System.Web.UI.UserControl
    {
        //Default page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Load form view and data source Table, Views dropdownns
                InitForm();
            }
            catch (Exception exc) //Module failed to load
            {

            }
        }

        // Save data to excel file
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


                //Creating a file stream containing the Excel file to be opened
                FileStream fstream = new FileStream(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"),
                    FileMode.Open, FileAccess.Read);

                //Instantiating a Workbook object
                //Opening the Excel file through the file stream
                Workbook workbook = new Workbook(fstream);

                //Accessing a worksheet using its sheet name
                //Worksheet worksheet = workbook.Worksheets["Data"];
                //Worksheet worksheet1 = workbook.Worksheets["Settings"];


                Worksheet worksheet = workbook.Worksheets["Data"];
                Worksheet worksheet1 = workbook.Worksheets["Settings"];

                //Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
                DataTable dataTable = null;

                if (worksheet.Cells.Rows.Count <= 0)
                {
                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, 1, 1, true);
                }
                else
                {
                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count,
                        worksheet.Cells.Columns.Count, true);
                }

                //Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable from setting
                DataTable dataTable1 = worksheet1.Cells.ExportDataTableAsString(0, 0, worksheet1.Cells.Rows.Count, 10,
                    true);



                if (dataTable1 != null)
                {
                    if (dataTable != null)
                    {
                        if (dataTable.Columns.Count <= 1)
                        {
                            dataTable.Columns.RemoveAt(0);
                        }
                        foreach (DataRow row in dataTable1.Rows)
                        {
                            if (!row[1].ToString().Trim().Equals("Title") && !row[1].ToString().Trim().Equals("Success"))
                            {
                                foreach (string strItem in row[2].ToString().Trim().Split(';'))
                                {
                                    if (!strItem.Trim().Equals(""))
                                    {
                                        if (dataTable.Columns[strItem.Trim()] == null)
                                        {
                                            dataTable.Columns.Add(strItem.Trim());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //Closing the file stream to free all resources
                fstream.Close();

                DataRow dr = dataTable.NewRow();

                foreach (Control ctrl in myPlaceHolder.Controls)
                {
                    if (ctrl != null)
                    {
                        if (ctrl is TextBox)
                        {
                            dr[ctrl.ID] = ((TextBox)ctrl).Text.Trim();
                            continue;
                        }

                        if (ctrl is RadioButton)
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                dr[ctrl.ID] = ((RadioButton)ctrl).Text.Trim();
                                continue;
                            }
                        }

                        if (ctrl is CheckBox)
                        {
                            if (((CheckBox)ctrl).Checked)
                            {
                                dr[ctrl.ID] = ((CheckBox)ctrl).Text.Trim();
                                continue;
                            }
                        }

                        if (ctrl is DropDownList)
                        {
                            dr[ctrl.ID] = ((DropDownList)ctrl).SelectedItem.Text.Trim();
                            continue;
                        }
                    }
                }
                dataTable.Rows.Add(dr);
                workbook.Worksheets.RemoveAt("Data");
                worksheet = workbook.Worksheets.Add("Data");
                worksheet.Cells.ImportDataTable(dataTable, true, "A1");

                // Apply Hearder Row/First Row text to Bold
                Aspose.Cells.Style objStyle = workbook.CreateStyle();
                objStyle.Font.IsBold = true;

                //Bold style flag options
                StyleFlag objStyleFlag = new StyleFlag();
                objStyleFlag.FontBold = true;
                //Apply this style to row 1

                Row row1 = workbook.Worksheets[0].Cells.Rows[0];
                row1.ApplyStyle(objStyle, objStyleFlag);
                worksheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);


                worksheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                //Auto-fit all the columns
                workbook.Worksheets["Data"].AutoFitColumns();


                workbook.Save(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"), SaveFormat.Xlsx);
                error_msg.Visible = false;
                success_msg.Visible = true;
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
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
            }
        }



        #region "Private Functions"

        //Form Initiating by creating dynamic controls from Excel sheet
        private void InitForm()
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
                    FileStream fstream = new FileStream(Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx"),
                        FileMode.Open, FileAccess.Read);

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
                        string fieldType = "Text";
                        int rows = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (!row[7].ToString().Trim().ToLower().Equals("false"))
                            {
                                rows += 1;
                                fieldType = row[1].ToString();

                                switch (fieldType)
                                {
                                    case "Title":
                                        {
                                            lblTitle.Text = row[4].ToString().Trim();
                                        }
                                        break;
                                    case "Success":
                                        {
                                            success_msg.InnerText = row[4].ToString().Trim();
                                        }
                                        break;
                                    case "Text":
                                        {
                                            Label lbl = new Label();
                                            LiteralControl table = new LiteralControl("<tr><td>");
                                            lbl.ID = "lbl" + row[2].ToString();
                                            lbl.Text = row[3].ToString();
                                            lbl.Text = lbl.Text + " : ";
                                            myPlaceHolder.Controls.Add(table);
                                            myPlaceHolder.Controls.Add(lbl);
                                            table = new LiteralControl("</td>");
                                            myPlaceHolder.Controls.Add(table);


                                            TextBox textBox = new TextBox();
                                            textBox.ID = row[2].ToString().Trim();
                                            textBox.Attributes.Add("placeholder", row[4].ToString().Trim());
                                            textBox.CssClass = "myinput";
                                            table = new LiteralControl("<td>");

                                            if (myPlaceHolder.FindControl(textBox.ID) == null)
                                            {
                                                myPlaceHolder.Controls.Add(table);
                                                myPlaceHolder.Controls.Add(textBox);
                                                table = new LiteralControl("</td></tr>");
                                                myPlaceHolder.Controls.Add(table);
                                            }


                                        }
                                        break;
                                    case "MultiText":
                                        {
                                            Label lbl = new Label();
                                            lbl.ID = "lbl" + row[2].ToString().Trim();
                                            LiteralControl table = new LiteralControl("<tr><td>");

                                            lbl.Text = row[3].ToString().Trim();
                                            lbl.Text = lbl.Text + " :  ";
                                            myPlaceHolder.Controls.Add(table);
                                            myPlaceHolder.Controls.Add(lbl);
                                            table = new LiteralControl("</td>");
                                            myPlaceHolder.Controls.Add(table);


                                            TextBox textBox = new TextBox();
                                            textBox.ID = row[2].ToString().Trim();
                                            textBox.Attributes.Add("placeholder", row[4].ToString().Trim());
                                            textBox.TextMode = TextBoxMode.MultiLine;
                                            textBox.CssClass = "myinput";
                                            table = new LiteralControl("<td>");

                                            if (myPlaceHolder.FindControl(textBox.ID) == null)
                                            {
                                                myPlaceHolder.Controls.Add(table);
                                                myPlaceHolder.Controls.Add(textBox);
                                                table = new LiteralControl("</td></tr>");
                                                myPlaceHolder.Controls.Add(table);
                                            }
                                        }
                                        break;
                                    case "Radio":
                                        {
                                            Label lbl = new Label();
                                            LiteralControl table = new LiteralControl("<tr><td>");

                                            lbl.ID = "lbl" + row[2].ToString().Trim();
                                            lbl.Text = row[3].ToString().Trim();
                                            lbl.Text = lbl.Text + " :  ";
                                            myPlaceHolder.Controls.Add(table);
                                            myPlaceHolder.Controls.Add(lbl);
                                            table = new LiteralControl("</td>");
                                            myPlaceHolder.Controls.Add(table);


                                            int i = 0;
                                            table = new LiteralControl("<td>");
                                            myPlaceHolder.Controls.Add(table);

                                            foreach (string strItem in row[2].ToString().Trim().Split(';'))
                                            {
                                                if (!strItem.Equals(""))
                                                {
                                                    RadioButton radioButton = new RadioButton();
                                                    radioButton.GroupName = "RadioGroup" + rows.ToString();

                                                    if (row[4].ToString().Trim().Split(';').Length >= i)
                                                    {
                                                        radioButton.Text = row[4].ToString().Trim().Split(';')[i];
                                                        radioButton.ID = row[2].ToString().Trim().Split(';')[i];
                                                        if (i == 0)
                                                        {
                                                            radioButton.Checked = true;
                                                        }
                                                    }

                                                    if (myPlaceHolder.FindControl(radioButton.ID) == null)
                                                    {
                                                        myPlaceHolder.Controls.Add(radioButton);
                                                    }
                                                    i++;
                                                }
                                            }
                                            table = new LiteralControl("</td></tr>");
                                            myPlaceHolder.Controls.Add(table);
                                        }
                                        break;
                                    case "Check":
                                        {
                                            Label lbl = new Label();
                                            LiteralControl table = new LiteralControl("<tr><td>");

                                            lbl.ID = "lbl" + row[2].ToString().Trim();
                                            lbl.Text = row[3].ToString().Trim();
                                            lbl.Text = lbl.Text + " :  ";
                                            myPlaceHolder.Controls.Add(table);
                                            myPlaceHolder.Controls.Add(lbl);
                                            table = new LiteralControl("</td>");
                                            myPlaceHolder.Controls.Add(table);


                                            int i = 0;
                                            table = new LiteralControl("<td>");
                                            myPlaceHolder.Controls.Add(table);
                                            foreach (string strItem in row[4].ToString().Trim().Split(';'))
                                            {
                                                if (!strItem.Equals(""))
                                                {
                                                    CheckBox checkBox = new CheckBox();
                                                    checkBox.Style.Add("margin-left", "2px");

                                                    if (row[4].ToString().Trim().Split(';').Length >= i)
                                                    {
                                                        checkBox.Text = row[4].ToString().Trim().Split(';')[i];
                                                        checkBox.ID = row[2].ToString().Trim().Split(';')[i];
                                                    }

                                                    if (myPlaceHolder.FindControl(checkBox.ID) == null)
                                                    {
                                                        myPlaceHolder.Controls.Add(checkBox);
                                                    }
                                                    i++;
                                                }
                                            }
                                            table = new LiteralControl("</td></tr>");
                                            myPlaceHolder.Controls.Add(table);
                                        }
                                        break;
                                    case "DropDown":
                                        {
                                            Label lbl = new Label();
                                            lbl.ID = "lbl" + row[2].ToString().Trim();
                                            lbl.Text = row[3].ToString().Trim();
                                            lbl.Text = lbl.Text + " :  ";

                                            LiteralControl table = new LiteralControl("<tr><td>");
                                            myPlaceHolder.Controls.Add(table);
                                            myPlaceHolder.Controls.Add(lbl);
                                            table = new LiteralControl("</td>");
                                            myPlaceHolder.Controls.Add(table);

                                            DropDownList dropdownList = new DropDownList();
                                            dropdownList.ID = row[2].ToString().Trim();
                                            dropdownList.CssClass = "myinput";
                                            table = new LiteralControl("<td>");
                                            myPlaceHolder.Controls.Add(table);


                                            foreach (string strItem in row[4].ToString().Trim().Split(';'))
                                            {
                                                if (!strItem.Equals(""))
                                                {
                                                    dropdownList.Items.Add(strItem);
                                                }
                                            }
                                            if (myPlaceHolder.FindControl(dropdownList.ID) == null)
                                            {

                                                myPlaceHolder.Controls.Add(dropdownList);
                                                table = new LiteralControl("</td></tr>");
                                                myPlaceHolder.Controls.Add(table);

                                            }
                                        }
                                        break;
                                    default:

                                        break;
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

        #endregion



        protected void lnkbtnEdit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Edit.ascx");
        }


        protected void lnkbtnExport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Export.ascx");
        }
    }
}