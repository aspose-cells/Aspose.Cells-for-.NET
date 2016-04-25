using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.SmartMarkers

{
    public class AddCustomLabels
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate the workbook from a template file that contains Smart Markers
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");
            Workbook designer = new Workbook(dataDir + "SmartMarker_Designer.xlsx");

            //Export data from the first worksheet to fill a data table
            DataTable dt = workbook.Worksheets[0].Cells.ExportDataTable(0, 0, 11, 5, true);
            
            //Instantiate a new WorkbookDesigner
            WorkbookDesigner d = new WorkbookDesigner();

            //Specify the workbook to the designer book
            d.Workbook = workbook;

            //Set the table name
            dt.TableName = "Report";

            //Set the data source
            d.SetDataSource(dt);

            //Process the smart markers
            d.Process();

            //Save the Excel file
            workbook.Save(dataDir + "output.xlsx", SaveFormat.Xlsx);
            //ExEnd:1

        }
    }
}
