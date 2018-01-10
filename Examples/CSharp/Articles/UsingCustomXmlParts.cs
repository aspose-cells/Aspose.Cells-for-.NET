using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class UsingCustomXmlParts
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // The sample XML that will be injected to Workbook
            string booksXML = @"<catalog>
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
            </catalog>";
            
            // Create an instance of Workbook class
            Workbook workbook = new Workbook();

            // Add Custom XML Part to ContentTypePropertyCollection
            workbook.ContentTypeProperties.Add("BookStore", booksXML);

            // Save the resultant spreadsheet
            workbook.Save(outputDir + "outputUsingCustomXmlParts.xlsx");

            Console.WriteLine("UsingCustomXmlParts executed successfully.");
        }
    }
}
