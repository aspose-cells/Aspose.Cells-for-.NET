using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    // ExStart:ExportedWorkSheetViaIFilePathProvider
    public class ExportedWorkSheetViaIFilePathProvider
    {        
        // This is the directory path which contains the sample.xlsx file
        static string dirPath = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            // because Aspose.Cells will always make the warning worksheet as active sheet in Evaluation mode.
            SetLicense();

            // Check if license is set, otherwise do not proceed
            Workbook wb = new Workbook();
            if (wb.IsLicensed == false)
            {
                Console.WriteLine("You must set the license to execute this code successfully.");
                Console.ReadKey();
            }
            else
            {
                // Test IFilePathProvider interface
                TestFilePathProvider();
            }
        }

        static void SetLicense()
        {
            string licPath = @"Aspose.Cells.lic";

            Aspose.Cells.License lic = new Aspose.Cells.License();
            lic.SetLicense(licPath);

            Console.WriteLine(CellsHelper.GetVersion());
            System.Diagnostics.Debug.WriteLine(CellsHelper.GetVersion());

            Environment.CurrentDirectory = dirPath;
        }

        static void TestFilePathProvider()
        {
            // Create subdirectory for second and third worksheets
            Directory.CreateDirectory(dirPath + "OtherSheets");

            // Load sample workbook from your directory
            Workbook wb = new Workbook(dirPath + "Sample.xlsx");

            // Save worksheets to separate html files
            // Because of IFilePathProvider, hyperlinks will not be broken.
            for (int i = 0; i < wb.Worksheets.Count; i++)
            {
                // Set the active worksheet to current value of variable i
                wb.Worksheets.ActiveSheetIndex = i;

                // Creat html save option
                HtmlSaveOptions options = new HtmlSaveOptions();
                options.ExportActiveWorksheetOnly = true;
                // ExStart:hyperlinks
                // If you will comment this line, then hyperlinks will be broken
                options.FilePathProvider = new FilePathProvider();
                // ExEnd:hyperlinks
                // Sheet actual index which starts from 1 not from 0
                int sheetIndex = i + 1;

                string filePath = "";

                // Save first sheet to same directory and second and third worksheets to subdirectory
                if (i == 0)
                {
                    filePath = dirPath + "Sheet1.html";
                }
                else
                {
                    filePath = dirPath + "OtherSheets\\Sheet" + sheetIndex + "_out.html";
                }

                // Save the worksheet to html file
                wb.Save(filePath, options);
            }
        }      
       
    }
    // Implementation of IFilePathProvider interface
    public class FilePathProvider : IFilePathProvider
    {
        // Constructor
        public FilePathProvider()
        {
        }

        // Gets the full path of the file by worksheet name when exporting worksheet to html separately.
        // So the references among the worksheets could be exported correctly.
        public string GetFullName(string sheetName)
        {
            if ("Sheet2".Equals(sheetName))
            {
                return @"file:///"  + "OtherSheets\\Sheet2.html";
            }
            else if ("Sheet3".Equals(sheetName))
            {
                return @"file:///"  + "OtherSheets\\Sheet3.html";
            }

            return "";
        }

    }
    // ExEnd:ExportedWorkSheetViaIFilePathProvider
}
