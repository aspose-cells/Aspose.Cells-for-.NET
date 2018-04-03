using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    class SpecifyDocumentVersionOfExcelFile 
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Create workbook object
            Workbook wb = new Workbook();

            //Access built-in document property collection
            Aspose.Cells.Properties.BuiltInDocumentPropertyCollection bdpc = wb.BuiltInDocumentProperties;

            //Set the title
            bdpc.Title = "Aspose File Format APIs";

            //Set the author
            bdpc.Author = "Aspose APIs Developers";

            //Set the document version
            bdpc.DocumentVersion = "Aspose.Cells Version - 18.3";

            //Save the workbook in xlsx format
            wb.Save(outputDir + "outputSpecifyDocumentVersionOfExcelFile.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SpecifyDocumentVersionOfExcelFile executed successfully.");
        }
    }

}
