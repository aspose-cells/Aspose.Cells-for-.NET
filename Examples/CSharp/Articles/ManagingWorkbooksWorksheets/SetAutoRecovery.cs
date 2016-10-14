using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class SetAutoRecovery
    {
        public static void Run()
        {
            // ExStart:SetAutoRecovery
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Read AutoRecover property
            Console.WriteLine("AutoRecover: " + workbook.Settings.AutoRecover);

            // Set AutoRecover property to false
            workbook.Settings.AutoRecover = false;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");

            // Read the saved workbook again
            workbook = new Workbook(dataDir + "output_out_.xlsx");

            // Read AutoRecover property
            Console.WriteLine("AutoRecover: " + workbook.Settings.AutoRecover);
            // ExEnd:SetAutoRecovery
        }
    }
}
