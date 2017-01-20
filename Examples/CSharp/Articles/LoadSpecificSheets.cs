using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadSpecificSheets
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Define a new Workbook.
            Workbook workbook;

            // Load the workbook with the spcified worksheet only.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadFilter = new CustomLoad();

            // Creat the workbook.
            workbook = new Workbook(dataDir+ "TestData.xlsx", loadOptions);

            // Perform your desired task.

            // Save the workbook.
            workbook.Save(dataDir+ "outputFile.out.xlsx");
            // ExEnd:1
            
        }
        // ExStart:2
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
                    this.LoadDataFilterOptions = LoadDataFilterOptions.None;
                }
            }
        }
        // ExEnd:2
    }
}
