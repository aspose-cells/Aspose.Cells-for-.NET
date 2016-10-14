using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class DeterminingLicenseLoading
    {
        public static void Run()
        {
            // ExStart:DeterminingLicenseLoading
            // The path to the License File
            string licPath = @"Aspose.Cells.lic";

            // Create workbook object before setting a license
            Workbook workbook = new Workbook();

            // Check if the license is loaded or not. It will return false
            Console.WriteLine(workbook.IsLicensed);

            try
            {
                Aspose.Cells.License lic = new Aspose.Cells.License();
                lic.SetLicense(licPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Check if the license is loaded or not. Now it will return true
            Console.WriteLine(workbook.IsLicensed);
            // ExEnd:DeterminingLicenseLoading
        }
    }
}
