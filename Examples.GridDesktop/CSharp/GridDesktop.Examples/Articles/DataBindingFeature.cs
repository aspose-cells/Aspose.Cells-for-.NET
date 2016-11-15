using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
// ExStart:AddingNamespaceToTheTop
// Adding namespace to the top of code
using System.Data.OleDb;
// ExEnd:AddingNamespaceToTheTop

namespace GridDesktop.Examples.Articles
{
    public partial class DataBindingFeature : Form
    {
        // ExStart:DeclareGlobalVariable
        // Declaring global variable
        OleDbDataAdapter adapter;
        OleDbCommandBuilder cb;
        DataSet ds;
        // ExEnd:DeclareGlobalVariable

        public DataBindingFeature()
        {
            InitializeComponent();
        }

        // ExStart:FillDataSet
        private void DataBindingFeatures_Load(object sender, EventArgs e)
        {
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating Select query to fetch data from database
            string query = "SELECT * FROM Products ORDER BY ProductID";

            // Creating connection string to connect with database
            string conStr = @"Provider=microsoft.jet.oledb.4.0;Data Source=" + dataDir + "dbDatabase.mdb";

            // Creating OleDbDataAdapter object that will be responsible to open/close connections with database, fetch data and fill DataSet with data
            adapter = new OleDbDataAdapter(query, conStr);

            // Setting MissingSchemaAction to AddWithKey for getting necesssary primary key information of the tables
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            /*
             * Creating OleDbCommandBuilder object to create insert/delete SQL commmands
             * automatically that are used by OleDbDatAdapter object for updating
             * changes to the database
            */
            cb = new OleDbCommandBuilder(adapter);

            // Creating DataSet object
            ds = new DataSet();

            // Filling DataSet with data fetched by OleDbDataAdapter object
            adapter.Fill(ds, "Products");
        }
        // ExEnd:FillDataSet

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:BindWorksheet
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Binding the Worksheet to Products table by calling its DataBind method
            sheet.DataBind(ds.Tables["Products"], "");
            // ExEnd:BindWorksheet

            // ExStart:SettingColumnHeader
            // Iterating through all columns of the Products table in DataSet
            for (int i = 0; i < ds.Tables["Products"].Columns.Count; i++)
            {
                // Setting the column header of each column to the column caption of Products table
                sheet.Columns[i].Header = ds.Tables["Products"].Columns[i].Caption;
            }
            // ExEnd:SettingColumnHeader

            // ExStart:CustomizingStyle
            // Customizing the widths of columns of the worksheet
            sheet.Columns[0].Width = 70;
            sheet.Columns[1].Width = 120;
            sheet.Columns[2].Width = 80;
            // ExEnd:CustomizingStyle

            // ExStart:ApplyCustomStyle
            // Iterating through each column of the worksheet
            for (int i = 0; i < sheet.ColumnsCount; i++)
            {
                // Getting the style object of each column
                Style style = sheet.Columns[i].GetStyle();

                // Setting the color of each column to Yellow
                style.Color = Color.Yellow;

                // Setting the Horizontal Alignment of each column to Centered
                style.HAlignment = HorizontalAlignmentType.Centred;

                // Setting the style of column to the updated one
                sheet.Columns[i].SetStyle(style);
            }
            // ExEnd:ApplyCustomStyle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AddingRows
            // Adding new row to the worksheet
            gridDesktop1.GetActiveWorksheet().AddRow();
            // ExEnd:AddingRows
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:DeletingRows
            // Getting the index of the focused row
            int focusedRowIndex = gridDesktop1.GetActiveWorksheet().GetFocusedCell().Row;

            // Removing the focused row fro the worksheet
            gridDesktop1.GetActiveWorksheet().RemoveRow(focusedRowIndex);
            // ExEnd:DeletingRows
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:SavingChangesToDatabase
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Updating the database according to worksheet data source
            adapter.Update((DataTable)sheet.DataSource);
            // ExEnd:SavingChangesToDatabase
        }
    }
}
