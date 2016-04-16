using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.SmartMarkers
{
    public class DynamicFormulas
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);


            //Instantiating a WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();

            //Open a designer spreadsheet containing smart markers
            designer.Workbook = new Workbook(designerFile);

            //Set the data source for the designer spreadsheet
            designer.SetDataSource(dataset);

            //Process the smart markers
            designer.Process();
            //ExEnd:1
            
            
        }

        public static Stream designerFile { get; set; }

        public static System.Data.SqlClient.SqlConnection dataset { get; set; }
    }
}