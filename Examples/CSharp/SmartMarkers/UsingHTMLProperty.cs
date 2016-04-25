using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.SmartMarkers
{
    public class UsingHTMLProperty
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook();
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Workbook = workbook;
            workbook.Worksheets[0].Cells["A1"].PutValue("&=$VariableArray(HTML)");
            designer.SetDataSource("VariableArray", new String[] { "Hello <b>World</b>", "Arabic", "Hindi", "Urdu", "French" });
            designer.Process();
            workbook.Save(dataDir + "output.xls");

            //ExEnd:1
        }
    }
}