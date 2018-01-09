using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadSpecificSheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load the workbook with the spcified worksheet only.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadFilter = new CustomLoad();

            // Creat the workbook.
            Workbook workbook = new Workbook(sourceDir + "sampleLoadSpecificSheets.xlsx", loadOptions);

            // Perform your desired task.

            // Save the workbook.
            workbook.Save(outputDir + "outputLoadSpecificSheets.xlsx");

            Console.WriteLine("LoadSpecificSheets executed successfully.");

        }

        class CustomLoad : LoadFilter
        {
            public override void StartSheet(Worksheet sheet)
            {
                if (sheet.Name == "Sheet2")
                {
                    // Load everything from worksheet "Sheet2"
                    this.LoadDataFilterOptions = LoadDataFilterOptions.All;
                }
                else
                {
                    // Load nothing
                    this.LoadDataFilterOptions = LoadDataFilterOptions.Structure;
                }
            }
        }//CustomLoad

    }
}
