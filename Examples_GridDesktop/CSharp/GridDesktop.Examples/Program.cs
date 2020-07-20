using GridDesktop.Examples.WorkingWithCells;
using GridDesktop.Examples.WorkingWithGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GridDesktop.Examples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Uncomment the one you want to try out
            //Application.Run(new RunExamples());

            //Aspose.Cells for .NET v17.7
            //Application.Run(new Form_FindGridDesktopVersionAtRunTime());
            //Application.Run(new Form_CustomRowAndCustomColumnCaptionOfGridDesktopWorksheet());
            //Application.Run(new Form_RenderPivotTableInGridDesktop());
            Application.Run(new FilteringData());
        }
    }
}
