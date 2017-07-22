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

            //Comment or uncomment the lines to run different examples
            //Application.Run(new RunExamples());
            //Application.Run(new FormGridDesktopVersion());
            Application.Run(new FormCustomRowAndCustomColumnCaption());
        }
    }
}
