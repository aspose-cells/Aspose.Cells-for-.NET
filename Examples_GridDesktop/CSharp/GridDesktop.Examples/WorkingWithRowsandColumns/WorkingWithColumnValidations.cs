using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithRowsandColumns
{
    public partial class WorkingWithColumnValidations : Form
    {
        public WorkingWithColumnValidations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddValidation
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding Is Required Validation to a column
            sheet.Columns[2].AddValidation(true, "");

            // Adding simple Regular Expression Validation to a column
            sheet.Columns[4].AddValidation(true, @"\d+");

            // Adding complex Regular Expression Validation to a column
            sheet.Columns[6].AddValidation(true, @"\d{4}-\d{2}-\d{2}");

            // Adding Custom Validation to a column
            sheet.Columns[8].AddValidation(new CustomValidation());
            // ExEnd:AddValidation
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AccessValidation
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Accessing the Validation object applied on a specific column
            //Validation validation = sheet.Columns[2].Validation;

            // Editing the attributes of Validation
            //validation.IsRequired = true;
            //validation.RegEx = "";
            //validation.CustomValidation = null;
            // ExEnd:AccessValidation
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveValidation
            // Accessing first worksheet of the Grid
            //Worksheet sheet = gridDesktop1.Worksheets[0];

            // Removing the Validation applied on a specific column
            //sheet.Columns[2].RemoveValidation();
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
