using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    class AddCustomXMLPartsAndSelectThemByID
    {
        public static void Main()
        {
            // Create empty workbook.
            Workbook wb = new Workbook();

            // Some data in the form of byte array.
            // Please use correct XML and Schema instead.
            byte[] btsData = new byte[] { 1, 2, 3 };
            byte[] btsSchema = new byte[] { 1, 2, 3 };

            // Create four custom xml parts.
            wb.CustomXmlParts.Add(btsData, btsSchema);
            wb.CustomXmlParts.Add(btsData, btsSchema);
            wb.CustomXmlParts.Add(btsData, btsSchema);
            wb.CustomXmlParts.Add(btsData, btsSchema);

            // Assign ids to custom xml parts.
            wb.CustomXmlParts[0].ID = "Fruit";
            wb.CustomXmlParts[1].ID = "Color";
            wb.CustomXmlParts[2].ID = "Sport";
            wb.CustomXmlParts[3].ID = "Shape";

            // Specify search custom xml part id.
            String srchID = "Fruit";
            srchID = "Color";
            srchID = "Sport";

            // Search custom xml part by the search id.
            Aspose.Cells.Markup.CustomXmlPart cxp = wb.CustomXmlParts.SelectByID(srchID);

            // Print the found or not found message on console.
            if (cxp == null)
            {
                Console.WriteLine("Not Found: CustomXmlPart ID " + srchID);
            }
            else
            {
                Console.WriteLine("Found: CustomXmlPart ID " + srchID);
            }

            Console.WriteLine("AddCustomXMLPartsAndSelectThemByID executed successfully.");
        }

    }
}
