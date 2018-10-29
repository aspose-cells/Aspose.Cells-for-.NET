using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.Texts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ApplyingTextAlignmentToPartialTextInsideTheTextBox
    {

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:
			// Create and object of the target workbook
			var destWb = new Workbook();

			// Access first worksheet from the collection
			var _sheet = destWb.Worksheets[0];

			//Create new textbox
			TextBox _textBox = (TextBox)_sheet.Shapes.AddShape( MsoDrawingType.TextBox,1, 0, 1, 0, 200, 200);

            // Use Html string
            _textBox.HtmlText = "<Font Style=\"FONT-FAMILY: Arial;FONT-SIZE: 12pt;COLOR: #ff0000;TEXT-ALIGN: left;\">Hello</Font><Font Style=\"FONT-WEIGHT: bold;FONT-FAMILY: Arial;FONT-SIZE: 28pt;COLOR: #ff0000;TEXT-ALIGN: center;\">Hello</Font><Font Style=\"FONT-WEIGHT: bold;FONT-FAMILY: Arial;FONT-SIZE: 12pt;COLOR: #00b050;TEXT-ALIGN: right;\">Hello</Font>";

            // Save the workbook on disc
            destWb.Save(outputDir + "outputSampleTextboxPartialTextAllignment.xlsx");
            // ExEnd:
            Console.WriteLine("ApplyingTextAlignmentToPartialTextInsideTheTextBox executed successfully.\r\n");
        }
    }
}
