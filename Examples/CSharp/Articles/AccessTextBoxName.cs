using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells.Examples.Articles
{
    class AccessTextBoxName
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            int idx = sheet.TextBoxes.Add(10, 10, 10, 10);

            //Create a texbox with some text and assign it some name
            Aspose.Cells.Drawing.TextBox tb1 = sheet.TextBoxes[idx];
            tb1.Name = "MyTextBox";
            tb1.Text = "This is MyTextBox";

            //Access the same textbox via its name
            Aspose.Cells.Drawing.TextBox tb2 = sheet.TextBoxes["MyTextBox"];

            //Displaying the text of the textbox accessed by its name
            Console.WriteLine(tb2.Text);
            //ExEnd:1
        }
    }
}
