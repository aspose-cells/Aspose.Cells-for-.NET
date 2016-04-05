using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveXLSFile
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Load your source workbook
            Workbook workbook = new Workbook();
            //Save in Excel2007 xlsx format
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1
        }
    }
}
