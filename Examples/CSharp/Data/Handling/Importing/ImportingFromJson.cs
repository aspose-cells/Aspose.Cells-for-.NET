using System.IO;

using Aspose.Cells;
using Aspose.Cells.Utility;

namespace Aspose.Cells.Examples.CSharp.Data.Handling.Importing
{
    public class ImportingFromJson
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // Read File
            string jsonInput = File.ReadAllText(dataDir + "Test.json");

            // Set Styles
            CellsFactory factory = new CellsFactory();
            Style style = factory.CreateStyle();
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.Font.Color = System.Drawing.Color.BlueViolet;
            style.Font.IsBold = true;

            // Set JsonLayoutOptions
            JsonLayoutOptions options = new JsonLayoutOptions();
            options.TitleStyle = style;
            options.ArrayAsTable = true;

            // Import JSON Data
            JSONUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

            // Save Excel file
            workbook.Save(dataDir + "ImportingFromJson.out.xlsx");
            // ExEnd:1
        }
    }
}
