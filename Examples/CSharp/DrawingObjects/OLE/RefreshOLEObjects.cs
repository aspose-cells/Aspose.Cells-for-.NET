using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.OLE
{
    public class RefreshOLEObjects
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from your sample excel file
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet sheet = wb.Worksheets[0];

            // Set auto load property of first ole object to true
            sheet.OleObjects[0].AutoLoad = true;

            // Save the worbook in xlsx format
            wb.Save(dataDir + "RefreshOLEObjects_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

        }
    }
}
