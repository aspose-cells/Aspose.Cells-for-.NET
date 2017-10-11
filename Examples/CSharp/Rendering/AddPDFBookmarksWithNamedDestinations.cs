using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Rendering 
{
    public class AddPDFBookmarksWithNamedDestinations 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook wb = new Workbook(sourceDir + "samplePdfBookmarkEntry_DestinationName.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access cell C5
            Cell cell = ws.Cells["C5"];

            //Create Bookmark and Destination for this cell
            PdfBookmarkEntry bookmarkEntry = new PdfBookmarkEntry();
            bookmarkEntry.Text = "Text";
            bookmarkEntry.Destination = cell;
            bookmarkEntry.DestinationName = "AsposeCells--" + cell.Name;

            //Access cell G56
            cell = ws.Cells["G56"];

            //Create Sub-Bookmark and Destination for this cell
            PdfBookmarkEntry subbookmarkEntry1 = new PdfBookmarkEntry();
            subbookmarkEntry1.Text = "Text1";
            subbookmarkEntry1.Destination = cell;
            subbookmarkEntry1.DestinationName = "AsposeCells--" + cell.Name;

            //Access cell L4
            cell = ws.Cells["L4"];

            //Create Sub-Bookmark and Destination for this cell
            PdfBookmarkEntry subbookmarkEntry2 = new PdfBookmarkEntry();
            subbookmarkEntry2.Text = "Text2";
            subbookmarkEntry2.Destination = cell;
            subbookmarkEntry2.DestinationName = "AsposeCells--" + cell.Name;

            //Add Sub-Bookmarks in list
            ArrayList list = new ArrayList();
            list.Add(subbookmarkEntry1);
            list.Add(subbookmarkEntry2);

            //Assign Sub-Bookmarks list to Bookmark Sub-Entry
            bookmarkEntry.SubEntry = list;

            //Create PdfSaveOptions and assign Bookmark to it
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.Bookmark = bookmarkEntry;

            //Save the workbook in Pdf format with given pdf save options
            wb.Save(outputDir + "outputPdfBookmarkEntry_DestinationName.pdf", opts);

            Console.WriteLine("AddPDFBookmarksWithNamedDestinations executed successfully.\r\n");
        }
    }
}
