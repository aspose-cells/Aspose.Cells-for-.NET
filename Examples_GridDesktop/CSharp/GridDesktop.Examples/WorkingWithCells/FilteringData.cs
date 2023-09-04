using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using Aspose.Cells.GridDesktop.Data;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class FilteringData : Form
    {
        public FilteringData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AutoFilter
            // Enable GridDesktop's auto-filter.
            gridDesktop1.Worksheets[0].RowFilter.EnableAutoFilter = true;

            // Set the header row.
            gridDesktop1.Worksheets[0].RowFilter.StartCol = 0;
            gridDesktop1.Worksheets[0].RowFilter.EndCol = gridDesktop1.Worksheets[0].Columns.Count-1;
            gridDesktop1.Worksheets[0].RowFilter.HeaderRow = 0;
          


            gridDesktop1.Worksheets[0].RefreshFilter();
            // ExEnd:AutoFilter
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:CustomFilter

            // Set the header row.
            gridDesktop1.Worksheets[0].RowFilter.HeaderRow = 0;

            // Get the RowFilter object for the first worksheet.
            RowFilterSettings rowFilter = gridDesktop1.Worksheets[0].RowFilter;

            // Filter Rows.
            rowFilter.FilterRows(0, "Customer 1");

            gridDesktop1.Worksheets[0].RefreshFilter();
            // ExEnd:CustomFilter
        }

        private void FilteringData_Load(object sender, EventArgs e)
        {
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(dataDir + "book1.xlsx");
        }

        private void btnNotEqualFilter_Click(object sender, EventArgs e)
        {
            // ExStart:NotEqualCustomFilter
            // Get the RowFilter object for the first worksheet.
            RowFilterSettings rowFilter = gridDesktop1.Worksheets[0].RowFilter;

            // Filter Rows.
            rowFilter.CustomRows(0, GridFilterOperatorType.NotEqual, "Customer 1");

            gridDesktop1.Worksheets[0].RefreshFilter();
            // ExEnd:NotEqualCustomFilter


        }
    }
}
