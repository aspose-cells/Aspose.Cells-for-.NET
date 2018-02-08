using System;
using System.Collections;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class CreatePdfBookmarkEntryForChartSheet 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleCreatePdfBookmarkEntryForChartSheet.xlsx");

            //Access all four worksheets
            Worksheet sheet1 = wb.Worksheets[0];
            Worksheet sheet2 = wb.Worksheets[1];
            Worksheet sheet3 = wb.Worksheets[2];
            Worksheet sheet4 = wb.Worksheets[3];

            //Create Pdf Bookmark Entry for Sheet1
            PdfBookmarkEntry ent1 = new PdfBookmarkEntry();
            ent1.Destination = sheet1.Cells["A1"];
            ent1.Text = "Bookmark-I";

            //Create Pdf Bookmark Entry for Sheet2 - Chart 
            PdfBookmarkEntry ent2 = new PdfBookmarkEntry();
            ent2.Destination = sheet2.Cells["A1"];
            ent2.Text = "Bookmark-II-Chart1";

            //Create Pdf Bookmark Entry for Sheet3 
            PdfBookmarkEntry ent3 = new PdfBookmarkEntry();
            ent3.Destination = sheet3.Cells["A1"];
            ent3.Text = "Bookmark-III";

            //Create Pdf Bookmark Entry for Sheet4 - Chart 
            PdfBookmarkEntry ent4 = new PdfBookmarkEntry();
            ent4.Destination = sheet4.Cells["A1"];
            ent4.Text = "Bookmark-IV-Chart2";

            //Arrange all Bookmark Entries
            ArrayList lst = new ArrayList();
            ent1.SubEntry = lst;
            lst.Add(ent2);
            lst.Add(ent3);
            lst.Add(ent4);

            //Create Pdf Save Options with Bookmark Entries
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.Bookmark = ent1;

            //Save the output Pdf
            wb.Save(outputDir + "outputCreatePdfBookmarkEntryForChartSheet.pdf", opts);

            Console.WriteLine("CreatePdfBookmarkEntryForChartSheet executed successfully.");
        }
    }
}
