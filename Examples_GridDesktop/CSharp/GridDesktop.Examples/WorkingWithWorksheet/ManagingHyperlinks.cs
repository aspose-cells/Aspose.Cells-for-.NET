using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using Aspose.Cells.GridDesktop.Data;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ManagingHyperlinks : Form
    {
        public ManagingHyperlinks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddHyperlink
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Accessing cell of the worksheet
            GridCell cell = sheet.Cells["b2"];
            GridCell cell2 = sheet.Cells["c3"];

            // Modifying the width of the column of the cell
            sheet.Columns[cell.Column].Width = 160;
            sheet.Columns[cell2.Column].Width = 160;

            // Adding a value to the cell
            cell.Value = "Aspose Home";
            cell2.Value = "Aspose Home";

            // Adding a hyperlink to the worksheet containing cell name and the hyperlink URL with which the cell will be linked
            sheet.Hyperlinks.Add("b2", "www.aspose.com");
            sheet.Hyperlinks.Add("c3", "www.aspose.com");
            // ExEnd:AddHyperlink
            MessageBox.Show("Hyperlinks have been added.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AccessHyperlink
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Accessing a hyperlink added to "c3,b2" cells (specified using its row & column number)
            Aspose.Cells.GridDesktop.Data.GridHyperlink hyperlink1 = sheet.Hyperlinks[2, 2];
            Aspose.Cells.GridDesktop.Data.GridHyperlink hyperlink2 = sheet.Hyperlinks[1, 1];

            if (hyperlink1 != null && hyperlink2 != null)
            {
                // Modifying the Url of the hyperlink
                hyperlink1.Url = "www.aspose.com";
                hyperlink2.Url = "www.aspose.com";
                MessageBox.Show("Hyperlinks are accessed and URL's are: \n" + hyperlink1.Url + "\n" + hyperlink2.Url);
            }
            else
            {
                MessageBox.Show("No hyperlinks are found in sheet. Add hyperlinks first.");
            }
            // ExEnd:AccessHyperlink
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveHyperlink
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            if (sheet.Hyperlinks.Count > 0)
            {
                // Removing hyperlink from "c3" cell
                sheet.Hyperlinks.Remove(2, 2);
                MessageBox.Show("Hyperlink in C3 cell has been removed.");
            }
            else
            {
                MessageBox.Show("No hyperlinks are found in sheet to remove. Add hyperlinks first.");
            }
            // ExEnd:RemoveHyperlink
        }
    }
}
