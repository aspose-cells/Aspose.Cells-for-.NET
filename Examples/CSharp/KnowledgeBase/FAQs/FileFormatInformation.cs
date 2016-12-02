using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.KnowledgeBase.FAQs
{
    public class FileFormatInformation
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load File
            FileFormatInfo finfo = FileFormatUtil.DetectFileFormat(dataDir + "sample.xls");
            Console.WriteLine(finfo.FileFormatType == FileFormatType.Excel95);
            // ExEnd:1
        }
    }
}
