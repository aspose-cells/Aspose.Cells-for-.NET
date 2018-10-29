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
    public partial class ValidationInWorksheets : Form
    {
        public ValidationInWorksheets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddingValidation
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding values to specific cells of the worksheet
            sheet.Cells["a2"].Value = "Required";
            sheet.Cells["a4"].Value = "100";
            sheet.Cells["a6"].Value = "2006-07-21";
            sheet.Cells["a8"].Value = "101.2";

            // Adding Is Required Validation to a cell
            sheet.Validations.Add("a2", true, "");

            // Adding simple Regular Expression Validation to a cell
            sheet.Validations.Add("a4", true, @"\d+");

            // Adding complex Regular Expression Validation to a cell
            sheet.Validations.Add("a6", true, @"\d{4}-\d{2}-\d{2}");

            // Adding Custom Validation to a cell
            sheet.Validations.Add("a8", new CustomValidation());
            // ExEnd:AddingValidation
            MessageBox.Show("Validation has been added.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingValidation
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            if (sheet.Validations.Count > 0)
            {
                // Accessing the Validation object applied on "a8" cell
                Aspose.Cells.GridDesktop.Data.GridValidation validation = sheet.Validations[7, 0];

                // Editing the attributes of Validation
                validation.IsRequired = true;
                validation.RegEx = "";
                validation.CustomValidation = null;
                MessageBox.Show("Validation has been edited after accessing it.");
            }
            else
            {
                MessageBox.Show("No validations found to access.");
            }
            // ExEnd:AccessingValidation
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveValidation
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];
            if (sheet.Validations.Count > 0)
            {
                // Removing the Validation object applied on "a6" cell
                sheet.Validations.RemoveAt(1);
                MessageBox.Show("Validation has been removed.");
            }
            else
            {
                MessageBox.Show("No validations found to remove.");
            }
            // ExEnd:RemoveValidation
        }
    }

    // ExStart:ImplementingICustomInterface
    // Implementing ICustomValidation interface
    public class CustomValidation : Aspose.Cells.GridDesktop.ICustomValidation
    {
        // Implementing Validate method already defined in the interface
        public bool Validate(Worksheet worksheet, int row, int col, object value)
        {
            // Checking the cell's address
            if (row == 7 && col == 0)
            {
                //Checking the data type of cell's value
                double d = 0;
                try
                {
                    d = (double)value;
                }
                catch
                {
                    return false;
                }

                // Checking if the cell's value is greater than 100
                if (d > 100)
                    return true;
            }
            return false;
        }
    }
    // ExEnd:ImplementingICustomInterface
}
