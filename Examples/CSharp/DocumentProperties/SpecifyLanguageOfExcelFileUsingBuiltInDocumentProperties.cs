using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.DocumentProperties
{
    class SpecifyLanguageOfExcelFileUsingBuiltInDocumentProperties
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            //Create workbook object.
            Workbook wb = new Workbook();

            //Access built-in document property collection.
            Aspose.Cells.Properties.BuiltInDocumentPropertyCollection bdpc = wb.BuiltInDocumentProperties;

            //Set the language of the Excel file.
            bdpc.Language = "German, French";

            //Save the workbook in xlsx format.
            wb.Save(outputDir + "outputSpecifyLanguageOfExcelFileUsingBuiltInDocumentProperties.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SpecifyLanguageOfExcelFileUsingBuiltInDocumentProperties executed successfully.");
        }
    }
}
