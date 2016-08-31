using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class AddingRadioButtonControl
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
            Workbook excelbook = new Workbook();

            // Insert a value.
            excelbook.Worksheets[0].Cells["C2"].PutValue("Age Groups");

            // Set the font text bold.
            excelbook.Worksheets[0].Cells["C2"].GetStyle().Font.IsBold = true;

            // Add a radio button to the first sheet.
            Aspose.Cells.Drawing.RadioButton radio1 = excelbook.Worksheets[0].Shapes.AddRadioButton(3, 0, 2, 0, 30, 110);

            // Set its text string.
            radio1.Text = "20-29";

            // Set A1 cell as a linked cell for the radio button.
            radio1.LinkedCell = "A1";

            // Make the radio button 3-D.
            radio1.Shadow = true;             

            // Set the weight of the radio button.
            radio1.Line.Weight = 4;       

            // Set the dash style of the radio button.
            radio1.Line.DashStyle = MsoLineDashStyle.Solid;            

            // Add another radio button to the first sheet.
            Aspose.Cells.Drawing.RadioButton radio2 = excelbook.Worksheets[0].Shapes.AddRadioButton(6, 0, 2, 0, 30, 110);

            // Set its text string.
            radio2.Text = "30-39";

            // Set A1 cell as a linked cell for the radio button.
            radio2.LinkedCell = "A1";

            // Make the radio button 3-D.
            radio2.Shadow = true;                

            // Set the weight of the radio button.
            radio2.Line.Weight = 4;
            
            // Set the dash style of the radio button.
            radio2.Line.DashStyle = MsoLineDashStyle.Solid;            

            // Add another radio button to the first sheet.
            Aspose.Cells.Drawing.RadioButton radio3 = excelbook.Worksheets[0].Shapes.AddRadioButton(9, 0, 2, 0, 30, 110);

            // Set its text string.
            radio3.Text = "40-49";

            // Set A1 cell as a linked cell for the radio button.
            radio3.LinkedCell = "A1";

            // Make the radio button 3-D.
            radio3.Shadow = true;            

            // Set the weight of the radio button.
            radio3.Line.Weight = 4;

            // Set the dash style of the radio button.
            radio3.Line.DashStyle = MsoLineDashStyle.Solid;

            // Save the excel file.
            excelbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1

        }
    }
}
