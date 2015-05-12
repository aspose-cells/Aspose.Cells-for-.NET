//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Collections;

namespace AddPDFBookmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new workbook
            Workbook workbook = new Workbook();
            //Get the cells in the first(default) worksheet
            Cells cells = workbook.Worksheets[0].Cells;
            //Get the A1 cell
            Aspose.Cells.Cell p = cells["A1"];
            //Enter a value
            p.PutValue("Preface");
            //Get the A10 cell
            Aspose.Cells.Cell A = cells["A10"];
            //Enter a value.
            A.PutValue("page1");
            //Get the H15 cell
            Aspose.Cells.Cell D = cells["H15"];
            //Enter a value
            D.PutValue("page1(H15)");
            //Add a new worksheet to the workbook
            workbook.Worksheets.Add();
            //Get the cells in the second sheet
            cells = workbook.Worksheets[1].Cells;
            //Get the B10 cell in the second sheet
            Aspose.Cells.Cell B = cells["B10"];
            //Enter a value
            B.PutValue("page2");
            //Add a new worksheet to the workbook
            workbook.Worksheets.Add();
            //Get the cells in the third sheet
            cells = workbook.Worksheets[2].Cells;
            //Get the C10 cell in the third sheet
            Aspose.Cells.Cell C = cells["C10"];
            //Enter a value
            C.PutValue("page3");

            //Create a main PDF Bookmark entry object
            Aspose.Cells.Rendering.PdfBookmarkEntry pbeRoot = new Aspose.Cells.Rendering.PdfBookmarkEntry();
            //Specify its text
            pbeRoot.Text = "Sections";
            //Set the destination cell/location
            pbeRoot.Destination = p;

            //Set its sub entry array list
            pbeRoot.SubEntry = new ArrayList();

            //Create a sub PDF Bookmark entry object
            Aspose.Cells.Rendering.PdfBookmarkEntry subPbe1 = new Aspose.Cells.Rendering.PdfBookmarkEntry();
            //Specify its text
            subPbe1.Text = "Section 1";
            //Set its destination cell
            subPbe1.Destination = A;
            //Define/Create a sub Bookmark entry object of "Section A"
            Aspose.Cells.Rendering.PdfBookmarkEntry ssubPbe = new Aspose.Cells.Rendering.PdfBookmarkEntry();
            //Specify its text
            ssubPbe.Text = "Section 1.1";
            //Set its destination
            ssubPbe.Destination = D;
            //Create/Set its sub entry array list object
            subPbe1.SubEntry = new ArrayList();
            //Add the object to "Section 1"
            subPbe1.SubEntry.Add(ssubPbe);
            //Add the object to the main PDF root object
            pbeRoot.SubEntry.Add(subPbe1);

            //Create a sub PDF Bookmark entry object
            Aspose.Cells.Rendering.PdfBookmarkEntry subPbe2 = new Aspose.Cells.Rendering.PdfBookmarkEntry();
            //Specify its text
            subPbe2.Text = "Section 2";
            //Set its destination
            subPbe2.Destination = B;
            //Add the object to the main PDF root object
            pbeRoot.SubEntry.Add(subPbe2);

            //Create a sub PDF Bookmark entry object
            Aspose.Cells.Rendering.PdfBookmarkEntry subPbe3 = new Aspose.Cells.Rendering.PdfBookmarkEntry();
            //Specify its text
            subPbe3.Text = "Section 3";
            //Set its destination
            subPbe3.Destination = C;
            //Add the object to the main PDF root object
            pbeRoot.SubEntry.Add(subPbe3);

            //Create an instance of PdfSaveOptions
            Aspose.Cells.PdfSaveOptions pdfSaveOptions = new Aspose.Cells.PdfSaveOptions();

            //Set the PDF Bookmark root object
            pdfSaveOptions.Bookmark = pbeRoot;

            //Save the pdf file
            workbook.Save(dataDir+ "PDFBookmarks_test.pdf", pdfSaveOptions);
            
            
        }
    }
}