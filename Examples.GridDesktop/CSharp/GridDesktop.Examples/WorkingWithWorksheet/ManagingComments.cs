using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ManagingComments : Form
    {
        public ManagingComments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddingComments
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding comment to "b2" cell
            sheet.Comments.Add("b2", "Please write your name.");

            // Adding another comment to "b4" cell using its row & column number
            sheet.Comments.Add(3, 1, "Please write your email.");
            // ExEnd:AddingComments
            MessageBox.Show("Comment has been added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingComments
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Accessing a comment added to "c3" cell (specified using its row & column number)
            Aspose.Cells.GridDesktop.Data.GridComment comment1 = sheet.Comments[3, 1];

            if (comment1 != null)
            {
                // Modifying the text of comment
                comment1.Text = "The 1st comment.";
                MessageBox.Show("Comment has been modified");
            }
            else
            {
                MessageBox.Show("Please add comment before accessing it.");
            }
            // ExEnd:AccessingComments
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:RemovingComments
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            if (sheet.Comments[3, 1] != null)
            {
                // Removing comment from "c3" cell
                sheet.Comments.Remove(3, 1);
                MessageBox.Show("Comment has been removed");
            }
            else
            {
                MessageBox.Show("Please add comment before removing it.");
            }
            // ExEnd:RemovingComments
        }
    }
}
