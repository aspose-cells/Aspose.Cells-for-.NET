//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace SetExternalLinksInFormulasExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            

  
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Get first Worksheet
            Worksheet sheet =  workbook.Worksheets[0];

            //Get Cells collection
            Cells cells = sheet.Cells;

            //Set formula with external links
            cells["A1"].Formula = "=SUM('[" + dataDir + "book1.xlsx]Sheet1'!A2, '[" + dataDir + "book1.xlsx]Sheet1'!A4)";

            //Set formula with external links
            cells["A2"].Formula = "='[" + dataDir + "book1.xlsx]Sheet1'!A8";

            //Save the workbook
            workbook.Save(dataDir+ "output.xlsx");


            
            
        }
    }
}