using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples
{  
    public partial class Form_RenderPivotTableInGridDesktop : Form
    {
        public Form_RenderPivotTableInGridDesktop()
        {
            InitializeComponent();
        }

        private void FormRenderPivotTableInGridDesktop_Load(object sender, EventArgs e)
        {
            //Path of the sample Excel file containing Pivot Table
            string filePath = Utils.Get_SourceDirectory() + "sampleRenderPivotTableInGridDesktop.xlsx";

            //Import sample Excel file containing Pivot Table
            this.gridDesktop1.ImportExcelFile(filePath);
        }
    }
}
