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
    public partial class AddingCellControls : Form
    {
        public AddingCellControls()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddingButton
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Adding button to the Controls collection of the Worksheet
            Aspose.Cells.GridDesktop.Button button = sheet.Controls.AddButton(cl.Row, cl.Column, 80, 20, "Button");
            // ExEnd:AddingButton

            // ExStart:SetBackground
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Set the image.
            Image image = Image.FromFile(dataDir + @"AsposeLogo.jpg");
            button.Image = image;
            // ExEnd:SetBackground
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AddingCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Adding checkbox to the Controls collection of the Worksheet
            sheet.Controls.AddCheckBox(cl.Row, cl.Column, true);
            // ExEnd:AddingCheckbox
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AddingCombobox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Creating an array of items or values that will be added to combobox
            string[] items = new string[3];
            items[0] = "Aspose";
            items[1] = "Aspose.Grid";
            items[2] = "Aspose.Grid.Desktop";

            // Adding combobox to the Controls collection of the Worksheet
            sheet.Controls.AddComboBox(cl.Row, cl.Column, items);
            // ExEnd:AddingCombobox
        }

        // ExStart:HandlingButton
        // Implenting CellButtonClick event handler
        private void gridDesktop1_CellButtonClick(object sender, CellControlEventArgs e)
        {
            // Displaying the message when button is clicked
            MessageBox.Show("Button is clicked.");
        }
        // ExEnd:HandlingButton

        // ExStart:HandlingCheckbox
        // Implenting CellCheckedChanged event handler
        private void gridDesktop1_CellCheckedChanged(object sender, CellControlEventArgs e)
        {
            // Getting the reference of the CheckBox control whose event is triggered
            Aspose.Cells.GridDesktop.CheckBox check = (Aspose.Cells.GridDesktop.CheckBox)gridDesktop1.GetActiveWorksheet().Controls[e.Row, e.Column];

            // Displaying the message when the Checked state of CheckBox is changed
            MessageBox.Show("Current state of CheckBox is " + check.Checked);
        }
        // ExEnd:HandlingCheckbox

        // ExStart:HandlingCombobox
        // Implenting CellSelectedIndexChanged event handler
        private void gridDesktop1_CellSelectedIndexChanged(object sender, CellComboBoxEventArgs e)
        {
            // Getting the reference of the ComboBox control whose event is triggered
            Aspose.Cells.GridDesktop.ComboBox combo =
                 (Aspose.Cells.GridDesktop.ComboBox)gridDesktop1.GetActiveWorksheet().Controls[e.Row, e.Column];

            // Displaying the message when the Selected Index of ComboBox is changed
            MessageBox.Show(combo.Items[combo.SelectedIndex].ToString());
        }
        // ExEnd:HandlingCombobox
    }
}
