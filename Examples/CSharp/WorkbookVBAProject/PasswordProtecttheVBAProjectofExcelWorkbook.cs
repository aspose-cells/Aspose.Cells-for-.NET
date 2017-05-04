using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.WorkbookVBAProject
{
    class PasswordProtecttheVBAProjectofExcelWorkbook
    {
        public static void Run()
        {
            //ExStart:PasswordProtecttheVBAProjectofExcelWorkbook

            //The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load your source Excel file.
            Workbook wb = new Workbook(dataDir + "samplePasswordProtectVBAProject.xlsm");

            //Access the VBA project of the workbook.
            Aspose.Cells.Vba.VbaProject vbaProject = wb.VbaProject;

            //Lock the VBA project for viewing with password.
            vbaProject.Protect(true, "11");

            //Save the output Excel file
            wb.Save(dataDir + "outputPasswordProtectVBAProject.xlsm");
            
            //ExEnd:PasswordProtecttheVBAProjectofExcelWorkbook
        }
    }
}
