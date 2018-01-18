using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class CheckPasswordToModify
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Specify password to open inside the load options
            LoadOptions opts = new LoadOptions();
            opts.Password = "1234";

            // Open the source Excel file with load options
            Workbook workbook = new Workbook(sourceDir + "sampleCheckPasswordToModify.xlsx", opts);

            // Check if 567 is Password to modify
            bool ret = workbook.Settings.WriteProtection.ValidatePassword("567");
            Console.WriteLine("Is 567 correct Password to modify: " + ret);

            // Check if 5679 is Password to modify
            ret = workbook.Settings.WriteProtection.ValidatePassword("5678");
            Console.WriteLine("Is 5678 correct Password to modify: " + ret);

            Console.WriteLine("CheckPasswordToModify executed successfully.");
        }
    }
}
