using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using System.Data.OleDb;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ImportDataFromDataTable : Form
    {
        public ImportDataFromDataTable()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            OleDbDataAdapter adapter;
            DataTable dt = new DataTable();

            // Creating connection string to connect with database
            string conStr = @"Provider=microsoft.jet.oledb.4.0;Data Source=" + dataDir + "dbDatabase.mdb";

            // Creating Select query to fetch data from database
            string query = "SELECT * FROM Products ORDER BY ProductID";
            adapter = new OleDbDataAdapter(query, conStr);

            // Filling DataTable using an already created OleDbDataAdapter object
            adapter.Fill(dt);

            // Accessing the reference of a worksheet
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Importing data from DataTable to the worksheet. 0,0 specifies to start importing data from the cell with first row (0 index) and first column (0 index)
            sheet.ImportDataTable(dt, false, 0, 0);

            // Iterating through the number of columns contained in the DataTable
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                // Setting the column headers of the worksheet according to column names of the DataTable
                sheet.Columns[i].Header = dt.Columns[i].Caption;
            }

            // Setting the widths of the columns of the worksheet
            sheet.Columns[0].Width = 240;
            sheet.Columns[1].Width = 160;
            sheet.Columns[2].Width = 160;
            sheet.Columns[3].Width = 100;

            // Displaying the contents of the worksheet by making it active
            gridDesktop1.ActiveSheetIndex = 0;
            // ExEnd:1
        }
    }
}
