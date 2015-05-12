//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Implement1904DateSystemExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Initialize a new Workbook
            //Open an excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            //Implement 1904 date system
            workbook.Settings.Date1904 = true;

            //Save the excel file
            workbook.Save(dataDir+ "Mybook.xlsx");
 
            
            
        }
    }
}