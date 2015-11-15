using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Aspose.Cells;

namespace Export_frm_Worksheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {
           //Creating a file stream containing the Excel file to be opened
           FileStream fstream = new FileStream(FOD_OpenFile.FileName, FileMode.Open);

           //Instantiating a Workbook object
           //Opening the Excel file through the file stream
           Workbook workbook = new Workbook(fstream);

           //Accessing the first worksheet in the Excel file
           Worksheet worksheet = workbook.Worksheets[0];

           //Exporting the contents of 2 rows and 2 columns starting from 1st cell to DataTable
           DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0,2, 2, true);

           //Binding the DataTable with DataGrid

           dataGridView1.DataSource = dataTable;

           //Closing the file stream to free all resources
           fstream.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Select_Click(object sender, EventArgs e)
        {
            DialogResult result = FOD_OpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                LBL_SelectedFile.Text = FOD_OpenFile.FileName;
            }
        }

        private void BTN_NonStronglyExport_Click(object sender, EventArgs e)
        {
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(FOD_OpenFile.FileName, FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Exporting the contents of 2 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, 2, 2, true);

            //Binding the DataTable with DataGrid
            dataGridView2.DataSource = dataTable;

            //Closing the file stream to free all resources
            fstream.Close();
        }

    }
}
