//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ConvertingToMHTMLFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Specify the file path
            string filePath = dataDir + "Book1.xlsx";

            //Specify the HTML Saving Options
            HtmlSaveOptions sv = new HtmlSaveOptions(SaveFormat.MHtml);

            //Instantiate a workbook and open the template XLSX file
            Workbook wb = new Workbook(filePath);

            //Save the MHT file
            wb.Save(filePath + ".out.mht", sv);
        }
    }
}