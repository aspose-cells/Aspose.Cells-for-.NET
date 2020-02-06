using System;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class RegexReplace
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "SampleRegexReplace.xlsx");

            ReplaceOptions replace = new ReplaceOptions();
            replace.CaseSensitive = false;
            replace.MatchEntireCellContents = false;
            // Set to true to indicate that the searched key is regex
            replace.RegexKey = true;

            workbook.Replace("\\bKIM\\b", "^^^TIM^^^", replace);
            workbook.Save(outputDir + "RegexReplace_out.xlsx");
            // ExEnd:1

            Console.WriteLine("RegexReplace executed successfully.");
        }
    }
}
