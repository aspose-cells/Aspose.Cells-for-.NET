//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Collections;

namespace Aspose.Cells.Examples.Data.Handling.Importing
{
    public class ImportingFromArrayList
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Instantiating an ArrayList object
            ArrayList list = new ArrayList();

            //Add few names to the list as string values
            list.Add("laurence chen");
            list.Add("roman korchagin");
            list.Add("kyle huang");
            list.Add("tommy wang");

            //Importing the contents of ArrayList to 1st row and first column vertically
            worksheet.Cells.ImportArrayList(list, 0, 0, true);

            //Saving the Excel file
            workbook.Save(dataDir + "DataImport.xls");
            
        }
    }
}