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
    public partial class RemoveWorksheet : Form
    {
        public RemoveWorksheet()
        {
            InitializeComponent();
        }

        private void RemoveWorksheet_Load(object sender, EventArgs e)
        {
            gridDesktop1.Worksheets.Add("Sheet2");
            gridDesktop1.Worksheets.Add("Sheet3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridDesktop1.Worksheets.Count > 0)
                // ExStart:RemoveUsingIndex
                // Removing a worksheet using its index
                gridDesktop1.Worksheets.Remove(0);
                // ExEnd:RemoveUsingIndex
            else
                MessageBox.Show("You have only 1 sheet left");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridDesktop1.Worksheets.Count > 0)
            {
                try
                {
                    // ExStart:RemoveUsingName
                    // Removing a worksheet using its index
                    gridDesktop1.Worksheets.RemoveAt("Sheet3");
                    // ExEnd:RemoveUsingName
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You have only 1 sheet left");
        }
    }
}
