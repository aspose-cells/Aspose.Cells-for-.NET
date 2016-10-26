using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ReleaseUnmanagedResources
    {
        public static void Run()
        {
            // ExStart:ReleaseUnmanagedResourcesForWorkbooks
            // Create workbook object
            Workbook wb1 = new Workbook();

            // Call Dispose method
            wb1.Dispose();

            // Call Dispose method via Using statement
            using (Workbook wb2 = new Workbook())
            {
                // Any other code goes here
            }
            // ExEnd:ReleaseUnmanagedResourcesForWorkbooks
        }
    }
}
