using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class MovingWorksheets : Form
    {
        public MovingWorksheets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // Move the 2nd worksheet to 4th position.
            gridDesktop1.Worksheets.MoveTo(1, 3);
            // ExEnd:1
            gridDesktop1.Refresh();
        }

        private void MovingWorksheets_Load(object sender, EventArgs e)
        {
            gridDesktop1.Worksheets.Add();
            gridDesktop1.Worksheets.Add();
            gridDesktop1.Worksheets.Add();
            gridDesktop1.Worksheets.Add();
        }
    }
}
