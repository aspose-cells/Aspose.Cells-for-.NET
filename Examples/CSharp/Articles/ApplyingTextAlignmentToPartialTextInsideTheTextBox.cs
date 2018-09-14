using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.Texts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ApplyingTextAlignmentToPartialTextInsideTheTextBox
    {
        public static void Main()
        {
            //Input directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

			// Intialize an object of the Workbook class to load template file
			Workbook sourceWb = new Workbook(sourceDir + "sampleTextboxPartialTextAllignment.xlsx");

			// Access the target textbox whose text is to be aligned
			var sourceTextBox = sourceWb.Worksheets[0].Shapes[0];

			// Create and object of the target workbook
			var destWb = new Workbook();

			// Access first worksheet from the collection
			var _sheet = destWb.Worksheets[0];

			//Create new textbox
			TextBox _textBox = (TextBox)_sheet.Shapes.AddShape( MsoDrawingType.TextBox,1, 0, 1, 0, 200, 200);

			// Alternatively text box can be added using following line as well
			// TextBox _textBox = _sheet.Shapes.AddTextBox(1, 0, 1, 0, 200, 200);

			// Use Html string from a template file textbox
			_textBox.HtmlText = sourceTextBox.HtmlText;

			// Save the workbook on disc
			destWb.Save(outputDir + "outputSampleTextboxPartialTextAllignment.xlsx");

            Console.WriteLine("ApplyingTextAlignmentToPartialTextInsideTheTextBox executed successfully.\r\n");
        }
    }
}
