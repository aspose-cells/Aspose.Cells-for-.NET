using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ExportDataToDataTable : Form
    {
        public ExportDataToDataTable()
        {
            InitializeComponent();
        }

        private void ExportDataToDataTable_Load(object sender, EventArgs e)
        {
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(dataDir + "book1.xlsx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:ExportToSpecificDataTable
            // Creating a new DataTable object
            DataTable dataTable = new DataTable();

            // Adding specific columns to the DataTable object
            dataTable.Columns.Add("ProductName", System.Type.GetType("System.String"));
            dataTable.Columns.Add("CategoryName", System.Type.GetType("System.String"));
            dataTable.Columns.Add("QuantityPerUnit", System.Type.GetType("System.String"));
            dataTable.Columns.Add("UnitsInStock", System.Type.GetType("System.Int32"));

            // Exporting the data of the first worksheet of the Grid to the specific DataTable object
            dataTable = gridDesktop1.Worksheets[0].ExportDataTable(dataTable, 0, 0, 69, 4, true);
            // ExEnd:ExportToSpecificDataTable
            MessageBox.Show("DataTable Rows Count: " + dataTable.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:ExportToNewDataTable
            // Accessing the reference of the worksheet that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            //Getting the total number of rows and columns inside the worksheet
            int totalRows = sheet.RowsCount;
            int totalCols = sheet.ColumnsCount;

            // Exporting the data of the active worksheet to a new DataTable object
            DataTable table = sheet.ExportDataTable(0, 0, totalRows, totalCols, false, true);
            // ExEnd:ExportToNewDataTable
            MessageBox.Show("DataTable Rows Count: " + table.Rows.Count);
        }
    }
}
