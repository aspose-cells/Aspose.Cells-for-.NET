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
    public partial class ZoomingInOut : Form
    {
        public ZoomingInOut()
        {
            InitializeComponent();
        }

        private void ZoomingInOut_Load(object sender, EventArgs e)
        {
            // ExStart:LoadEvent
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Importing the template Excel file to GridDesktop
            gridDesktop1.ImportExcelFile(dataDir + "EmployeeSales.xlsx");

            // Set the default value of the TrackBar control
            trackBar1.Value = 100;

            // Set the custom label's text to the trackbar's value for display
            label1.Text = trackBar1.Value.ToString() + "%";
            // ExEnd:LoadEvent
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // ExStart:ZoomInOut
            // Set the Zoom factor of the active worksheet to the Trackbar's value
            gridDesktop1.Worksheets[gridDesktop1.GetActiveWorksheet().Index].Zoom = trackBar1.Value;

            // Show the percentage value of the specified Zoom
            label1.Text = trackBar1.Value.ToString() + "%";
            // ExEnd:ZoomInOut
        }
    }
}
