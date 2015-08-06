//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class SaveEachWorksheetToDifferentPDF
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            

            //Get the Excel file path
            string filePath = dataDir+ "input.xlsx";

            //Instantiage a new workbook and open the Excel
            //File from its location
            Workbook workbook = new Workbook(filePath);

            //Get the count of the worksheets in the workbook
            int sheetCount = workbook.Worksheets.Count;

            //Make all sheets invisible except first worksheet
            for (int i = 1; i < workbook.Worksheets.Count; i++)
        {
            workbook.Worksheets[i].IsVisible = false;
}

            //Take Pdfs of each sheet
            for (int j = 0; j < workbook.Worksheets.Count; j++)
        {
             Worksheet ws = workbook.Worksheets[j];
            workbook.Save(dataDir+ "worksheet-" + ws.Name + ".pdf");

                if (j < workbook.Worksheets.Count - 1)
         {
                 workbook.Worksheets[j + 1].IsVisible = true;
                 workbook.Worksheets[j].IsVisible = false;
    }
}


            
            
        }
    }
}