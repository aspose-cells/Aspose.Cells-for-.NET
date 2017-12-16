using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class AccessTextBoxName
    {
        public static void Run()
        {
            // Create an object of the Workbook class
            Workbook workbook = new Workbook();

            // Access first worksheet from the collection
            Worksheet sheet = workbook.Worksheets[0];

            // Add the TextBox to the worksheet
            int idx = sheet.TextBoxes.Add(10, 10, 10, 10);

            // Access newly created TextBox using its index & name it
            TextBox tb1 = sheet.TextBoxes[idx];
            tb1.Name = "MyTextBox";

            // Set text for the TextBox
            tb1.Text = "This is MyTextBox";

            // Access the same TextBox via its name
            TextBox tb2 = sheet.TextBoxes["MyTextBox"];

            // Display the text of the TextBox accessed via name
            Console.WriteLine(tb2.Text);

            Console.WriteLine("AccessTextBoxName executed successfully.\r\n");
        }
    }
}
