using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Vba;

namespace Aspose.Cells.Examples.CSharp.WorkbookVBAProject
{
    class CopyVBAMacroUserFormDesignerStorageToWorkbook 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create empty target workbook
            Workbook target = new Workbook();

            //Load the Excel file containing VBA-Macro Designer User Form
            Workbook templateFile = new Workbook(sourceDir + "sampleDesignerForm.xlsm");

            //Copy all template worksheets to target workboook
            foreach (Worksheet ws in templateFile.Worksheets)
            {
                if (ws.Type == SheetType.Worksheet)
                {
                    Worksheet s = target.Worksheets.Add(ws.Name);
                    s.Copy(ws);

                    //Put message in cell A2 of the target worksheet
                    s.Cells["A2"].PutValue("VBA Macro and User Form copied from template to target.");
                }
            }//foreach

            //-----------------------------------------------

            //Copy the VBA-Macro Designer UserForm from Template to Target 
            foreach (VbaModule vbaItem in templateFile.VbaProject.Modules)
            {
                if (vbaItem.Name == "ThisWorkbook")
                {
                    //Copy ThisWorkbook module code
                    target.VbaProject.Modules["ThisWorkbook"].Codes = vbaItem.Codes;

                }
                else
                {
                    //Copy other modules code and data
                    System.Diagnostics.Debug.Print(vbaItem.Name);

                    int vbaMod = 0;
                    Worksheet sheet = target.Worksheets.GetSheetByCodeName(vbaItem.Name);
                    if (sheet == null)
                    {
                        vbaMod = target.VbaProject.Modules.Add(vbaItem.Type, vbaItem.Name);
                    }
                    else
                    {
                        vbaMod = target.VbaProject.Modules.Add(sheet);
                    }

                    target.VbaProject.Modules[vbaMod].Codes = vbaItem.Codes;

                    if ((vbaItem.Type == VbaModuleType.Designer))
                    {
                        //Get the data of the user form i.e. designer storage
                        byte[] designerStorage = templateFile.VbaProject.Modules.GetDesignerStorage(vbaItem.Name);

                        //Add the designer storage to target Vba Project
                        target.VbaProject.Modules.AddDesignerStorage(vbaItem.Name, designerStorage);
                    }
                }
            }//foreach

            //Save the target workbook
            target.Save(outputDir + "outputDesignerForm.xlsm", SaveFormat.Xlsm);

            Console.WriteLine("CopyVBAMacroUserFormDesignerStorageToWorkbook executed successfully.\r\n");
        }
    }
}
