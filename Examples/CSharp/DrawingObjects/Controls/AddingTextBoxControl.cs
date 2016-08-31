using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class AddingTextBoxControl
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet in the book.
            Worksheet worksheet = workbook.Worksheets[0];

            // Add a new textbox to the collection.
            int textboxIndex = worksheet.TextBoxes.Add(2, 1, 160, 200);

            // Get the textbox object.
            Aspose.Cells.Drawing.TextBox textbox0 = worksheet.TextBoxes[textboxIndex];

            // Fill the text.
            textbox0.Text = "ASPOSE______The .NET & JAVA Component Publisher!";

            // Get the textbox text frame.
            //MsoTextFrame textframe0 = textbox0.TextFrame;

            // Set the textbox to adjust it according to its contents.
            //textframe0.AutoSize = true;

            // Set the placement.
            textbox0.Placement = PlacementType.FreeFloating;

            // Set the font color.
            textbox0.Font.Color = Color.Blue;

            // Set the font to bold.
            textbox0.Font.IsBold = true;

            // Set the font size.
            textbox0.Font.Size = 14;

            // Set font attribute to italic.
            textbox0.Font.IsItalic = true;

            // Add a hyperlink to the textbox.
            textbox0.AddHyperlink("http:// Www.aspose.com/");

            // Get the filformat of the textbox.
            Aspose.Cells.Drawing.FillFormat fillformat = textbox0.Fill;            

            // Get the lineformat type of the textbox.
            Aspose.Cells.Drawing.LineFormat lineformat = textbox0.Line;           

            // Set the line weight.
            lineformat.Weight = 6;

            // Set the dash style to squaredot.
            lineformat.DashStyle = MsoLineDashStyle.SquareDot;

            // Add another textbox.
            textboxIndex = worksheet.TextBoxes.Add(15, 4, 85, 120);

            // Get the second textbox.
            Aspose.Cells.Drawing.TextBox textbox1 = worksheet.TextBoxes[textboxIndex];

            // Input some text to it.
            textbox1.Text = "This is another simple text box";

            // Set the placement type as the textbox will move and
            // Resize with cells.
            textbox1.Placement = PlacementType.MoveAndSize;

            // Save the excel file.
            workbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1

        }
    }
}
