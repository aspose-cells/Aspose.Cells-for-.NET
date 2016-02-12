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

namespace Aspose.DotNetNuke.Modules.AsposeDynamicFormGeneratorExcel
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditAsposeDNNDynamicFormGenerator class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from AsposeDNNDynamicFormGeneratorModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : AsposeDNNDynamicFormGeneratorModuleBase
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
                FileStream fstream = new FileStream(Server.MapPath("~/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Docs/AsposeDynamicFormsDataFile.xlsx"), FileMode.Open, FileAccess.Read);

                //Instantiating a Workbook object
                //Opening the Excel file through the file stream
                Workbook workbook = new Workbook(fstream);

                //Accessing a worksheet using its sheet name
                Worksheet worksheet = workbook.Worksheets["Data"];

                DataTable dataTable = null;

                if (worksheet.Cells.Rows.Count <= 0)
                {
                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, 1, 1, true);
                }
                else
                {
                    dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, worksheet.Cells.Columns.Count, true);
                }

                //Closing the file stream to free all resources
                fstream.Close();

                //Instantiate a new Workbook
                Workbook book = new Workbook();
                //Clear all the worksheets
                book.Worksheets.Clear();
                //Add a new Sheet "Data";
                Worksheet sheet = book.Worksheets.Add("Data");

                // import data in to sheet
                sheet.Cells.ImportDataTable(dataTable, true, "A1");

                // Apply Hearder Row/First Row text to Bold
                Cells.Style objStyle = new Cells.Style();
                objStyle.Font.IsBold = true;

                StyleFlag objStyleFlag = new StyleFlag();
                objStyleFlag.FontBold = true;

                sheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                //Auto-fit all the columns
                book.Worksheets[0].AutoFitColumns();

                //Create unique file name
                string fileName = System.Guid.NewGuid().ToString() + "." + ExportTypeDropDown.SelectedValue;

                //Save workbook as per export type
                book.Save(this.Response, fileName, ContentDisposition.Attachment, GetSaveFormat(ExportTypeDropDown.SelectedValue));
                Response.End();
            }
            catch (Exception exc)
            {
                success_msg.Visible = false;
                error_msg.Visible = true;
                error_msg.InnerText = exc.Message;
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

    }
}