using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class AddingTextBoxControlInChart
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Open the existing file.
            Workbook workbook = new Workbook(sourceDir + "sampleAddingTextBoxControlInChart.xls");
             
            // Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[0];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            // Add a new textbox to the chart.
            Aspose.Cells.Drawing.TextBox textbox0 = chart.Shapes.AddTextBoxInChart(400, 1100, 350, 2550);

            // Fill the text.
            textbox0.Text = "Sales By Region";

            // Get the textbox text frame.
            // Aspose.Cells.Drawing.MsoTextFrame textframe0 = textbox0.TextFrame;

            // Set the textbox to adjust it according to its contents.
            // textframe0.AutoSize = true;

            // Set the font color.
            textbox0.Font.Color = Color.Maroon;

            // Set the font to bold.
            textbox0.Font.IsBold = true;

            // Set the font size.
            textbox0.Font.Size = 14;

            // Set font attribute to italic.
            textbox0.Font.IsItalic = true;

            // Get the filformat of the textbox.
            Aspose.Cells.Drawing.FillFormat fillformat = textbox0.Fill;

            // Get the lineformat type of the textbox.
            Aspose.Cells.Drawing.LineFormat lineformat = textbox0.Line;
     
            // Set the line weight.
            lineformat.Weight = 2;

            // Set the dash style to solid.
            lineformat.DashStyle = Aspose.Cells.Drawing.MsoLineDashStyle.Solid;

            // Save the excel file.
            workbook.Save(outputDir + "outputAddingTextBoxControlInChart.xls");

            Console.WriteLine("AddingTextBoxControlInChart executed successfully.");
        }
    }
}
