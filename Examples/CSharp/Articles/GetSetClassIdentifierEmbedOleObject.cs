using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GetSetClassIdentifierEmbedOleObject
    {
        public static void Run()
        {
            // ExStart:GetSetClassIdentifierEmbedOleObject
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your sample workbook which contains embedded PowerPoint ole object
            Workbook wb = new Workbook(dataDir + "sample.xls");

            // Access its first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first ole object inside the worksheet
            OleObject oleObj = ws.OleObjects[0];

            // Convert 16-bytes array into GUID
            Guid guid = new Guid(oleObj.ClassIdentifier);

            // Print the GUID
            Console.WriteLine(guid.ToString().ToUpper());
            // ExEnd:GetSetClassIdentifierEmbedOleObject
        }
    }
}
