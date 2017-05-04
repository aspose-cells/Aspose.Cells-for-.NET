using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.WorkbookVBAProject
{
    class CheckifVBAProjectisProtectedandLockedforViewing
    {
        public static void Run()
        {
            //ExStart:CheckifVBAProjectisProtectedandLockedforViewing

            //The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load your source Excel file.
            Workbook wb = new Workbook(dataDir + "sampleCheckifVBAProjectisProtected.xlsm");

            //Access the VBA project of the workbook.
            Aspose.Cells.Vba.VbaProject vbaProject = wb.VbaProject;

            //Whether "Lock project for viewing" is true or not.
            Console.WriteLine("Is VBA Project Locked for Viewing: " + vbaProject.IslockedForViewing);

            //ExEnd:CheckifVBAProjectisProtectedandLockedforViewing
        }
    }
}
