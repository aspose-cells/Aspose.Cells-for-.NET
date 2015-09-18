using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Configuration;
using Aspose.Cells;
using System.Text;
using System.Drawing;

namespace Aspose.Excel.GridViewExport
{
    public enum ExcelOutputFormat
    {
        Xlsx, Xlsb, Xls, Txt, Csv, Ods
    }

    [ProvideToolboxControl("Aspose", false)]
    [ToolboxBitmap(typeof(ExportGridViewToExcel), "icon.bmp")]
    public class ExportGridViewToExcel : GridView, INamingContainer, IPostBackDataHandler
    {
        Button ExcelExportButton;

        /// <summary>
        /// Css Class that is applied to the outer div of the export button. To apply css on button you can use .yourClass input {  }
        /// </summary>
        public string ExportButtonCssClass { get; set; }

        /// <summary>
        /// Heading that is used only in the exported output Excel file.
        /// </summary>
        public string ExportFileHeading { get; set; }

        /// <summary>
        /// If you have paging enabled then the default output is current page. To export all pages set this datasource to all rows you want to export to Excel document
        /// </summary>
        public object ExportDataSource
        {
            get { return (object)ViewState["Aspose_ExportDataSource"]; }
            set { ViewState["Aspose_ExportDataSource"] = value; }
        }

        /// <summary>
        /// Local output path e.g. "c:\\temp" Disk path on server where a copy of the export is automatically saved. Application must have write access to this path.
        /// </summary>
        public string ExportOutputPathOnServer { get; set; }

        /// <summary>
        /// Output format of the exported document. Supported formats are Xlsx, Xlsb, Xls, Txt, Csv, Ods
        /// </summary>
        public ExcelOutputFormat ExcelOutputFormat { get; set; }

        /// <summary>
        /// Export button text
        /// </summary>
        public string ExportButtonText { get; set; }

        /// <summary>
        /// Path to Aspose.Cells license file e.g. c:\\Aspose.Cells.lic
        /// </summary>
        public string LicenseFilePath { get; set; }

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            var rowCount = base.CreateChildControls(dataSource, dataBinding);
            if (ExcelExportButton == null)
                CreateExportButton();
            Controls.Add(ExcelExportButton);
            return rowCount;
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return false;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CreateExportButton();
        }

        private void CreateExportButton()
        {
            ExcelExportButton = new Button();
            ExcelExportButton.Text = string.IsNullOrEmpty(ExportButtonText) ? "Export to Excel" : ExportButtonText;
            ExcelExportButton.ID = "__aspose_export_to_excel_gridview";
            ExcelExportButton.Click += new EventHandler(ExportButton_Click);
        }

        public void RaisePostDataChangedEvent()
        {
        }

        private String CalculateWidth()
        {
            string strWidth = "auto";
            if (!this.Width.IsEmpty)
            {
                strWidth = String.Format("{0}{1}", this.Width.Value, ((this.Width.Type == UnitType.Percentage) ? "%" : "px"));
            }
            return strWidth;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<div style='width:" + CalculateWidth() + "'>");
            writer.Write("<div class='" + ExportButtonCssClass + "'>");
            ExcelExportButton.RenderControl(writer);
            ExcelExportButton.Visible = false;
            writer.Write("</div>");
            writer.Write("<div>");
            base.RenderContents(writer);
            writer.Write("</div></div>");
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            if (ExportDataSource != null)
            {
                this.AllowPaging = false;
                this.DataSource = ExportDataSource;
                this.DataBind();
            }

            this.RenderBeginTag(hw);
            this.HeaderRow.RenderControl(hw);
            foreach (GridViewRow row in this.Rows)
            {
                row.RenderControl(hw);
            }
            this.FooterRow.RenderControl(hw);
            this.RenderEndTag(hw);

            string heading = string.IsNullOrEmpty(ExportFileHeading) ? string.Empty : ExportFileHeading;

            string pageSource = sw.ToString();

            // Check for license and apply if exists
            if (File.Exists(LicenseFilePath))
            {
                License license = new License();
                license.SetLicense(LicenseFilePath);
            }

            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(pageSource)))
            {
                var loadOptions = new LoadOptions(LoadFormat.Html)
                {
                    ConvertNumericData = false
                };

                Workbook workbook = new Workbook(stream, loadOptions);

                Worksheet worksheet = workbook.Worksheets[0];

                worksheet.AutoFitColumns();
                worksheet.AutoFitRows();

                Aspose.Cells.Cells cells = worksheet.Cells;
                Range range = worksheet.Cells.MaxDisplayRange;
                int tcols = range.ColumnCount;
                int trows = range.RowCount;

                for (int i = 0; i < trows; i++)
                {
                    for (int j = 0; j < tcols; j++)
                    {
                        if (cells[i, j].Type != CellValueType.IsNull)
                        {
                            Aspose.Cells.Style style = cells[i, j].GetStyle();

                            if (i == 0)
                            {
                                style.Font.IsBold = true;
                            }

                            style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.TopBorder].Color = Color.Black;
                            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.BottomBorder].Color = Color.Black;
                            style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.LeftBorder].Color = Color.Black;
                            style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.RightBorder].Color = Color.Black;
                            cells[i, j].SetStyle(style);
                        }
                    }
                }

                worksheet.Cells.InsertColumn(0);
                worksheet.Cells.InsertRow(0);

                worksheet.Cells["B1"].HtmlString = heading;
                worksheet.Cells.InsertRow(0);
                worksheet.Cells.InsertRow(2);

                Aspose.Cells.Style style2 = worksheet.Cells["B2"].GetStyle();
                style2.Font.Size = 20;
                style2.Borders.SetStyle(CellBorderType.None);
                worksheet.Cells["B2"].SetStyle(style2);

                ExcelOutputFormat format;
                if (Enum.TryParse<ExcelOutputFormat>(ExcelOutputFormat.ToString(), out format))
                {
                    string extension = ExcelOutputFormat.ToString().ToLower();

                    if (string.IsNullOrEmpty(extension)) extension = "xls";
                    string fileNameWithExtension = System.Guid.NewGuid() + "." + extension;

                    if (!string.IsNullOrEmpty(ExportOutputPathOnServer) && Directory.Exists(ExportOutputPathOnServer))
                    {
                        try
                        {
                            workbook.Save(ExportOutputPathOnServer + "\\" + fileNameWithExtension);
                        }
                        catch (Exception) { }
                    }

                    workbook.Save(HttpContext.Current.Response, fileNameWithExtension, ContentDisposition.Inline, GetSaveFormat(ExcelOutputFormat.ToString()));
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Write("Invalid export format, must be one of Xlsx, Xlsb, Xls, Txt, Csv, Ods");
                }
            }
        }

        private XlsSaveOptions GetSaveFormat(string format)
        {
            XlsSaveOptions saveOption = new XlsSaveOptions(SaveFormat.Xlsx);

            switch (format.ToLower())
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
                default:
                    saveOption = new XlsSaveOptions(SaveFormat.Excel97To2003); break;
            }

            return saveOption;
        }
    }
}
