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
    public partial class DisplayHideScrolBars : Form
    {
        public DisplayHideScrolBars()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:ShowScrollbars
            // Displaying the vertical scroll bar
            gridDesktop1.IsVerticalScrollBarVisible = true;

            // Displaying the horizontal scroll bar
            gridDesktop1.IsHorizontalScrollBarVisible = true;
            // ExEnd:ShowScrollbars
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:HideScrollbars
            // Hiding the vertical scroll bar
            gridDesktop1.IsVerticalScrollBarVisible = false;

            // Hiding the horizontal scroll bar
            gridDesktop1.IsHorizontalScrollBarVisible = false;
            // ExEnd:HideScrollbars
        }
    }
}
