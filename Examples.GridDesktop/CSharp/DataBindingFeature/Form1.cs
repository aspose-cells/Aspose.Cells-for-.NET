using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Aspose.Cells.GridDesktop;

namespace DataBindingFeature
{
    public partial class Form1 : Form
    {
        // Declaring global variable
        OleDbDataAdapter adapter;
        OleDbCommandBuilder cb;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Creating Select query to fetch data from database
            string query = "SELECT * FROM Products ORDER BY ProductID";

            //Creating connection string to connect with database
            string conStr = @"Provider=microsoft.jet.oledb.4.0;Data Source=" + Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "dbDatabase.mdb";

            //Creating OleDbDataAdapter object that will be responsible to open/close
            //connections with database, fetch data and fill DataSet with data
            adapter = new OleDbDataAdapter(query, conStr);

            //Setting MissingSchemaAction to AddWithKey for getting necesssary primary
            //key information of the tables
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //Creating OleDbCommandBuilder object to create insert/delete SQL commmands
            //automatically that are used by OleDbDatAdapter object for updating
            //changes to the database
            cb = new OleDbCommandBuilder(adapter);

            //Creating DataSet object
            ds = new DataSet();

            //Filling DataSet with data fetched by OleDbDataAdapter object
            adapter.Fill(ds, "Products");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            //Binding the Worksheet to Products table by calling its DataBind method
            sheet.DataBind(ds.Tables["Products"], "");

            //Iterating through all columns of the Products table in DataSet
            for (int i = 0; i < ds.Tables["Products"].Columns.Count; i++)
            {
                //Setting the column header of each column to the column caption of
                //Products table
                sheet.Columns[i].Header = ds.Tables["Products"].Columns[i].Caption;
            }

            //Customizing the widths of columns of the worksheet
            sheet.Columns[0].Width = 70;
            sheet.Columns[1].Width = 120;
            sheet.Columns[2].Width = 80;

            //Iterating through each column of the worksheet
            for (int i = 0; i < sheet.ColumnsCount; i++)
            {
                //Getting the style object of each column
                Style style = sheet.Columns[i].GetStyle();

                //Setting the color of each column to Yellow
                style.Color = Color.Yellow;

                //Setting the Horizontal Alignment of each column to Centered
                style.HAlignment = HorizontalAlignmentType.Centred;

                //Setting the style of column to the updated one
                sheet.Columns[i].SetStyle(style);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Adding new row to the worksheet
            gridDesktop1.GetActiveWorksheet().AddRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Getting the index of the focused row
            int focusedRowIndex = gridDesktop1.GetActiveWorksheet().GetFocusedCell().Row;

            //Removing the focused row fro the worksheet
            gridDesktop1.GetActiveWorksheet().RemoveRow(focusedRowIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            //Updating the database according to worksheet data source
            adapter.Update((DataTable)sheet.DataSource);
        }
    }
}
