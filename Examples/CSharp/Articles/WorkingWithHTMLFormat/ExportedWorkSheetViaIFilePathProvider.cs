using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    // ExStart:ExportedWorkSheetViaIFilePathProvider
    public class ExportedWorkSheetViaIFilePathProvider
    {        
        public static void Run()
        {
            // because Aspose.Cells will always make the warning worksheet as active sheet in Evaluation mode.
            SetLicense();

            // Test IFilePathProvider interface
            TestFilePathProvider();

            Console.WriteLine("ExportedWorkSheetViaIFilePathProvider executed successfully.");
        }

        static void SetLicense()
        {
            string licPath = @"Aspose.Cells.lic";
            licPath = "F:/Download/Misc/Aspose/Licenses/Aspose.Total.lic";

            Aspose.Cells.License lic = new Aspose.Cells.License();
            lic.SetLicense(licPath);

            //Console.WriteLine(CellsHelper.GetVersion());
            //System.Diagnostics.Debug.WriteLine(CellsHelper.GetVersion());

            //Environment.CurrentDirectory = dirPath;

        }

        static void TestFilePathProvider()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create subdirectory for second and third worksheets
            Directory.CreateDirectory(outputDir + "OtherSheets");

            // Load sample workbook from your directory
            Workbook wb = new Workbook(sourceDir + "sampleTestFilePathProvider.xlsx");

            // Save worksheets to separate html files
            // Because of IFilePathProvider, hyperlinks will not be broken.
            for (int i = 0; i < wb.Worksheets.Count; i++)
            {
                // Set the active worksheet to current value of variable i
                wb.Worksheets.ActiveSheetIndex = i;

                // Creat html save option
                HtmlSaveOptions options = new HtmlSaveOptions();
                options.ExportActiveWorksheetOnly = true;
                options.FilePathProvider = new FilePathProvider(outputDir);

                // Sheet actual index which starts from 1 not from 0
                int sheetIndex = i + 1;

                string filePath = "";

                // Save first sheet to same directory and second and third worksheets to subdirectory
                if (i == 0)
                {
                    filePath = outputDir + "Sheet1.html";
                }
                else
                {
                    filePath = outputDir + "OtherSheets\\Sheet" + sheetIndex + "_out.html";
                }

                // Save the worksheet to html file
                wb.Save(filePath, options);
            }
        }      
    }

    // Implementation of IFilePathProvider interface
    public class FilePathProvider : IFilePathProvider
    {
        string outputFPDir;

        // Constructor
        public FilePathProvider(string outputDir)
        {
            this.outputFPDir = outputDir;
        }

        // Gets the full path of the file by worksheet name when exporting worksheet to html separately.
        // So the references among the worksheets could be exported correctly.
        public string GetFullName(string sheetName)
        {
            if ("Sheet2".Equals(sheetName))
            {
                return @"file:///"  + this.outputFPDir + "OtherSheets\\Sheet2_out.html";
            }
            else if ("Sheet3".Equals(sheetName))
            {
                return @"file:///" + this.outputFPDir + "OtherSheets\\Sheet3_out.html";
            }

            return "";
        }

    }
}
