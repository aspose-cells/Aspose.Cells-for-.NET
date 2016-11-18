using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class UsingFormatPainter : Form
    {
        public UsingFormatPainter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:UseOnce
            // Starting format painter to paint once
            gridDesktop1.StartFormatPainter(false);
            // ExEnd:UseOnce
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:UseAlways
            // Starting format painter to keep painting forever
            gridDesktop1.StartFormatPainter(true);
            // ExEnd:UseAlways
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:EndUse
            // Ending format painter to stop painting
            gridDesktop1.EndFormatPainter();
            // ExEnd:EndUse
        }
    }
}
