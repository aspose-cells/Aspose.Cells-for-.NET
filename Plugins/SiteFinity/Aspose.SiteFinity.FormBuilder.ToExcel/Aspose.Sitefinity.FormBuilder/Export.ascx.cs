using System;
using System.Data;
using System.IO;
using Aspose.Cells;

namespace Aspose.Sitefinity.FormBuilder 
{
    public partial class Export : System.Web.UI.UserControl
    {
        private void ExportData(string value)
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

                // open and read file 
                FileStream fstream = new FileStream((Server.MapPath("~/Addons/Aspose.SiteFinity.FormBuilder.ToExcel/uploads/AsposeDynamicFormsDataFile.xlsx")), FileMode.Open, FileAccess.Read);

                //Instantiating a Workbook object 
                //Opening the Excel file through the file stream 
                Workbook workbook = new Workbook(fstream);

                //Accessing a worksheet using its sheet name 
                Worksheet worksheet = workbook.Worksheets["Data"];

                DataTable dataTable;

                dataTable = worksheet.Cells.Rows.Count <= 0 ? worksheet.Cells.ExportDataTableAsString(0, 0, 1, 1, true) : worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 8, true);

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
                Aspose.Cells.Style objStyle = workbook.CreateStyle();

                objStyle.Font.IsBold = true;

                StyleFlag objStyleFlag = new StyleFlag();
                objStyleFlag.FontBold = true;

                sheet.Cells.ApplyRowStyle(0, objStyle, objStyleFlag);

                //Auto-fit all the columns 
                book.Worksheets[0].AutoFitColumns();

                //Create unique file name 
                string fileName = System.Guid.NewGuid().ToString() + "." + value;

                //Save workbook as per export type 
                book.Save(this.Response, fileName, ContentDisposition.Attachment, GetSaveFormat(value));

                Response.Flush();
            }
            catch (Exception exc)
            {

            }
        }


        /// <summary>
        /// export format function 
        ///   
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>

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

        protected void btnExport_OnClick(object sender, EventArgs e)
        {
            string ddlvalue = ExportTypeDropDown.SelectedValue;
            ExportData(ddlvalue);
        }

        protected void btnback_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/View.ascx");
        }
    }
}