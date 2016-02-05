using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class LoadSpecificSheets
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Define a new Workbook.
            Workbook workbook;

            //Set the load data option with selected sheet(s).
            LoadDataOption dataOption = new LoadDataOption();
            dataOption.SheetNames = new string[] { "Sheet2" };

            //Load the workbook with the spcified worksheet only.
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Xlsx);
            loadOptions.LoadDataOptions = dataOption;
            loadOptions.LoadDataAndFormatting = true;

            //Creat the workbook.
            workbook = new Workbook(dataDir+ "TestData.xlsx", loadOptions);

            //Perform your desired task.

            //Save the workbook.
            workbook.Save(dataDir+ "outputFile.out.xlsx");
            
            
        }
    }
}