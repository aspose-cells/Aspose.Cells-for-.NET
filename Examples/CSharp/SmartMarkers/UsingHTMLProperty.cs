using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers
{
    public class UsingHTMLProperty
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook();
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Workbook = workbook;
            workbook.Worksheets[0].Cells["A1"].PutValue("&=$VariableArray(HTML)");
            designer.SetDataSource("VariableArray", new String[] { "Hello <b>World</b>", "Arabic", "Hindi", "Urdu", "French" });
            designer.Process();
            workbook.Save(dataDir + "output.xls");

            // ExEnd:1
        }
    }
}