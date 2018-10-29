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
    public partial class Form_FindGridDesktopVersionAtRunTime : Form
    {
        public Form_FindGridDesktopVersionAtRunTime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get the version number of GridDesktop
            string version = Aspose.Cells.GridDesktop.GridDesktop.GetVersion();

            //Show the version number in message box
            MessageBox.Show("GridDesktop Version: " + version, "GridDesktop Version");
        }
    }
}
