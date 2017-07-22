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
    public partial class FormCustomRowAndCustomColumnCaption : Form
    {
        public class MyICustomColumnCaption : ICustomColumnCaption
        {
            /// <summary> 
            /// get the custom column caption. 
            /// </summary> 
            /// <param name="column">column index.</param> 
            /// <returns>return the column caption.</returns> 
            public string GetCaption(int column)
            {
                return "Mine " + (column + 10);
            }
        }
        public class MyICustomRowCaption : ICustomRowCaption
        {
            /// <summary> 
            /// get the custom row caption. 
            /// </summary> 
            /// <param name="row">row index.</param> 
            /// <returns>return the row caption.</returns> 
            public string GetCaption(int row)
            {
                return "R" + (row + 10).ToString();
            }
        }


        public FormCustomRowAndCustomColumnCaption()
        {
            InitializeComponent();
        }

        private void FormCustomRowAndCustomColumnCaption_Load(object sender, EventArgs e)
        {
            Worksheet ws = this.gridDesktop1.Worksheets[0];

            ws.CustomColumnCaption = new MyICustomColumnCaption();
            ws.CustomRowCaption = new MyICustomRowCaption();
        }
    }
}
