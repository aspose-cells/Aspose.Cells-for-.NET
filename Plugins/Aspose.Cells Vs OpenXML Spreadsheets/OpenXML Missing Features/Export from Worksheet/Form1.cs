// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
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
