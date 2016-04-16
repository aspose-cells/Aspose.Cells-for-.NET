using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.SmartMarkers
{
    public class ImageMarkers
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Get the image data.
            byte[] imageData = File.ReadAllBytes(dataDir+ @"aspose-logo.jpg");
            //Create a datatable.
            DataTable t = new DataTable("Table1");
            //Add a column to save pictures.
            DataColumn dc = t.Columns.Add("Picture");
            //Set its data type.
            dc.DataType = typeof(object);

            //Add a new new record to it.
            DataRow row = t.NewRow();
            row[0] = imageData;
            t.Rows.Add(row);

            //Add another record (having picture) to it.
            imageData = File.ReadAllBytes(dataDir+ @"image2.jpg");
            row = t.NewRow();
            row[0] = imageData;
            t.Rows.Add(row);

            //Create WorkbookDesigner object.
            WorkbookDesigner designer = new WorkbookDesigner();
            //Open the template Excel file.
            designer.Workbook = new Workbook(dataDir+ @"TestSmartMarkers.xls");
            //Set the datasource.
            designer.SetDataSource(t);
            //Process the markers.
            designer.Process();
            //Save the Excel file.
            designer.Workbook.Save(dataDir+ @"out_SmartBook.out.xls");
            //ExEnd:1

        }
    }
}