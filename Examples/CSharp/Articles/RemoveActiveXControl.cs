using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.ActiveXControls;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RemoveActiveXControl
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook
            Workbook wb = new Workbook(sourceDir + "sampleUpdateActiveXComboBoxControl.xlsx");

            // Access first shape from first worksheet
            Shape shape = wb.Worksheets[0].Shapes[0];

            // Access ActiveX ComboBox Control and update its value
            if (shape.ActiveXControl != null)
            {
                // Remove Shape ActiveX Control
                shape.RemoveActiveXControl();
            }

            // Save the workbook
            wb.Save(outputDir + "RemoveActiveXControl_our.xlsx");
            // ExEnd:1

            Console.WriteLine("RemoveActiveXControl executed successfully.");
        }
    }
}
