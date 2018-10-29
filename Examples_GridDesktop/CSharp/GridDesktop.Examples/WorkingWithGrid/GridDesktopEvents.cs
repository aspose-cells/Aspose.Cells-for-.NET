using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.WorkingWithGrid
{
    public partial class GridDesktopEvents : Form
    {
        public GridDesktopEvents()
        {
            InitializeComponent();
        }

        // ExStart:ClickEvent
        private void gridDesktop1_CellClick(object sender, Aspose.Cells.GridDesktop.CellEventArgs e)
        {
            MessageBox.Show("Cell is clicked");
        }
        // ExEnd:ClickEvent
    }
}
