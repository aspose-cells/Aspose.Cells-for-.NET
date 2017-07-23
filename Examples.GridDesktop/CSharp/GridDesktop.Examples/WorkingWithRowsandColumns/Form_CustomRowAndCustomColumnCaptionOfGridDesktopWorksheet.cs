using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples
{  
    public partial class Form_CustomRowAndCustomColumnCaptionOfGridDesktopWorksheet : Form
    {
        public class MyICustomColumnCaption : ICustomColumnCaption
        {
            //Returns the Custom Column Caption
            public string GetCaption(int column)
            {
                return "Mine " + (column + 10);
            }
        }
        public class MyICustomRowCaption : ICustomRowCaption
        {
            //Returns the Custom Row Caption
            public string GetCaption(int row)
            {
                return "R" + (row + 10).ToString();
            }
        }

        public Form_CustomRowAndCustomColumnCaptionOfGridDesktopWorksheet()
        {
            InitializeComponent();
        }

        private void FormCustomRowAndCustomColumnCaption_Load(object sender, EventArgs e)
        {
            //Access the First GridDesktop Worksheet
            Worksheet ws = this.gridDesktop1.Worksheets[0];

            //Assign the Worksheet Custom Column and Row Caption Instance
            ws.CustomColumnCaption = new MyICustomColumnCaption();
            ws.CustomRowCaption = new MyICustomRowCaption();
        }
    }
}
