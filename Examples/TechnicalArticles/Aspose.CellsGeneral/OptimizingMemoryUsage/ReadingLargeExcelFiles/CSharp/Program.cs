//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ReadingLargeExcelFilesExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Specify the LoadOptions
            LoadOptions opt = new LoadOptions();
            //Set the memory preferences
            opt.MemorySetting = MemorySetting.MemoryPreference;

            //Instantiate the Workbook
            //Load the Big Excel file having large Data set in it
            Workbook wb = new Workbook(dataDir+ "Book1.xlsx", opt);
            
        }
    }
}