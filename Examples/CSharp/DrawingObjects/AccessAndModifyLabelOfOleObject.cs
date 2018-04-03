using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class AccessAndModifyLabelOfOleObject 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            //Load the sample Excel file 
            Workbook wb = new Workbook(sourceDir + "sampleAccessAndModifyLabelOfOleObject.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first Ole Object
            Aspose.Cells.Drawing.OleObject oleObject = ws.OleObjects[0];

            //Display the Label of the Ole Object
            Console.WriteLine("Ole Object Label - Before: " + oleObject.Label);

            //Modify the Label of the Ole Object
            oleObject.Label = "Aspose APIs";

            //Save workbook to memory stream
            MemoryStream ms = new MemoryStream();
            wb.Save(ms, SaveFormat.Xlsx);

            //Set the workbook reference to null
            wb = null;

            //Load workbook from memory stream
            wb = new Workbook(ms);

            //Access first worksheet
            ws = wb.Worksheets[0];

            //Access first Ole Object
            oleObject = ws.OleObjects[0];

            //Display the Label of the Ole Object that has been modified earlier
            Console.WriteLine("Ole Object Label - After: " + oleObject.Label);

            Console.WriteLine("AccessAndModifyLabelOfOleObject executed successfully.");
        }
    }

}
