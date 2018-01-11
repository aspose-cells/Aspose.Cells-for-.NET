using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.ActiveXControls;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class UpdateActiveXComboBoxControl
    {
        public static void Run()
        {
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
                // Access Shape ActiveX Control
                ActiveXControl c = shape.ActiveXControl;

                // Check if ActiveX Control is ComboBox Control
                if (c.Type == ControlType.ComboBox)
                {
                    // Type cast ActiveXControl into ComboBoxActiveXControl and change its value
                    ComboBoxActiveXControl comboBoxActiveX = (ComboBoxActiveXControl)c;
                    comboBoxActiveX.Value = "This is combo box control with updated value.";
                }
            }

            // Save the workbook
            wb.Save(outputDir + "outputUpdateActiveXComboBoxControl.xlsx");

            Console.WriteLine("UpdateActiveXComboBoxControl executed successfully.");
        }
    }
}
