using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.ActiveXControls;
using Aspose.Cells.Vba;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddingCustomPropertiesVisible
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook(FileFormatType.Xlsx);

            // Add simple property without any type
            workbook.ContentTypeProperties.Add("MK31", "Simple Data");

            // Add date time property with type
            workbook.ContentTypeProperties.Add("MK32", "04-Mar-2015", "DateTime");

            // Save the workbook
            workbook.Save(dataDir + "AddingCustomPropertiesVisible_out_.xlsx");
            // ExEnd:1            
        }
    }
}
