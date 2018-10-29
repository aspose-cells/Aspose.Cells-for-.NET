using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.WorkbookSettings
{
    class SupportNamedRangeFormulasInGermanLocale
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:1
            const string name = "HasFormula";
            const string value = "=GET.CELL(48, INDIRECT(\"ZS\",FALSE))";

            Workbook wbSource = new Workbook(sourceDir + "sampleNamedRangeTest.xlsm");
            WorksheetCollection wsCol = wbSource.Worksheets;

            int nameIndex = wsCol.Names.Add(name);
            Name namedRange = wsCol.Names[nameIndex];
            namedRange.RefersTo = value;

            wbSource.Save(outputDir + "sampleOutputNamedRangeTest.xlsm");
            // ExEnd:1
            Console.WriteLine("SupportNamedRangeFormulasInGermanLocale executed successfully.\r\n");
        }
    }
}
