using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class ManipulatingTextBoxControls
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a new Workbook.
            //Open the existing excel file.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Get the first worksheet in the book.
            Worksheet worksheet = workbook.Worksheets[0];

            //Get the first textbox object.
            Aspose.Cells.Drawing.TextBox textbox0 = worksheet.TextBoxes[0];

            //Obtain the text in the first textbox.
            string text0 = textbox0.Text;

            //Get the second textbox object.
            Aspose.Cells.Drawing.TextBox textbox1 = worksheet.TextBoxes[1];

            //Obtain the text in the second textbox.
            string text1 = textbox1.Text;

            //Change the text of the second textbox.
            textbox1.Text = "This is an alternative text";

            //Save the excel file.
            workbook.Save(dataDir + "output.xls");

        }
    }
}