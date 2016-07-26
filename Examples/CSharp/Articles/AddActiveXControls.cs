using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.ActiveXControls;
using Aspose.Cells.Vba;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddActiveXControls
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook wb = new Workbook();

            // Access first worksheet
            Worksheet sheet = wb.Worksheets[0];

            // Add Toggle Button ActiveX Control inside the Shape Collection
            Shape s = sheet.Shapes.AddActiveXControl(ControlType.ToggleButton, 4, 0, 4, 0, 100, 30);

            // Access the ActiveX control object and set its linked cell property
            ActiveXControl c = s.ActiveXControl;
            c.LinkedCell = "A1";

            // Save the worbook in xlsx format
            wb.Save(dataDir + "AddActiveXControls_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:1            
        }
    }
}
