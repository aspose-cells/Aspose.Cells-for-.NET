using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingComboBoxControl
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Create a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            //Get the worksheet cells collection.
            Cells cells = sheet.Cells;

            //Input a value.
            cells["B3"].PutValue("Employee:");

            //Set it bold.
            cells["B3"].GetStyle().Font.IsBold = true;

            //Input some values that denote the input range
            //for the combo box.
            cells["A2"].PutValue("Emp001");
            cells["A3"].PutValue("Emp002");
            cells["A4"].PutValue("Emp003");
            cells["A5"].PutValue("Emp004");
            cells["A6"].PutValue("Emp005");
            cells["A7"].PutValue("Emp006");

            //Add a new combo box.
            Aspose.Cells.Drawing.ComboBox comboBox = sheet.Shapes.AddComboBox(2, 0, 2, 0, 22, 100);

            //Set the linked cell;
            comboBox.LinkedCell = "A1";

            //Set the input range.
            comboBox.InputRange = "A2:A7";

            //Set no. of list lines displayed in the combo
            //box's list portion.
            comboBox.DropDownLines = 5;

            //Set the combo box with 3-D shading.
            comboBox.Shadow = true;

            //AutoFit Columns
            sheet.AutoFitColumns();

            //Saves the file.
            workbook.Save(dataDir + "book1.xls");

        }
    }
}