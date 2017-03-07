using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class GetWarningsWhileLoadingExcelFile
    {
        //Implement IWarningCallback interface to catch warnings while loading workbook
        private class WarningCallback : IWarningCallback
        {
            public void Warning(WarningInfo warningInfo)
            {
                if (warningInfo.WarningType == WarningType.DuplicateDefinedName)
                {
                    Console.WriteLine("Duplicate Defined Name Warning: " + warningInfo.Description);
                }
            }
        }//WarningCallback


        public static void Run()
        {
            // ExStart:GetWarningsWhileLoadingExcelFile
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            //Create load options and set the WarningCallback property 
            //to catch warnings while loading workbook
            LoadOptions options = new LoadOptions();
            options.WarningCallback = new WarningCallback();

            //Load the source excel file
            Workbook book = new Workbook(dataDir + "sampleDuplicateDefinedName.xlsx", options);

            //Save the workbook 
            book.Save(dataDir + "outputDuplicateDefinedName.xlsx");

            // ExEnd:GetWarningsWhileLoadingExcelFile
        }
    }
}
