//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace DisplayHideTabs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiating a Workbook object
            //Opening the Excel file
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            //Hiding the tabs of the Excel file
            workbook.Settings.ShowTabs = false;

            //Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");
        }
    }
}