using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells.Examples.Articles
{
    class UsingCustomXmlParts
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //The sample XML
            string booksXML = @"
<catalog>
   <book>
      <title>Complete C#</title>
      <price>44</price>
   </book>
   <book>
      <title>Complete Java</title>
      <price>76</price>
   </book>
   <book>
      <title>Complete SharePoint</title>
      <price>55</price>
   </book>
   <book>
      <title>Complete PHP</title>
      <price>63</price>
   </book>
   <book>
      <title>Complete VB.NET</title>
      <price>72</price>
   </book>
</catalog>
";
            //Create a workbook object
            Workbook workbook = new Workbook();

            //Add Custom XML Part
            workbook.ContentTypeProperties.Add("BookStore", booksXML);

            //Save the output xlsx file
            workbook.Save(dataDir + "UsingCustomXmlParts.xlsx");
            //ExEnd:1

        }
    }
}
