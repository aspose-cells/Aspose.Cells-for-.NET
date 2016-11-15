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
    public partial class RenameWorksheet : Form
    {
        public RenameWorksheet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // ExStart:1
                // Accesing an active worksheet directly
                Worksheet sheet = gridDesktop1.GetActiveWorksheet();

                // Renaming a worksheet
                sheet.Name = "Renamed Sheet";
                // ExEnd:1
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
