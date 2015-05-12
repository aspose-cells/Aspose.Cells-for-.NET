//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace CombineMultipleWorkbooksSingleWorkbook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");


            //Define the first source
            //Open the first excel file.
            Workbook SourceBook1 = new Workbook(dataDir+ "SampleChart.xlsx");

            //Define the second source book.
            //Open the second excel file.
            Workbook SourceBook2 = new Workbook(dataDir+ "SampleImage.xlsx");

            //Combining the two workbooks
            SourceBook1.Combine(SourceBook2);

            //Save the target book file.
            SourceBook1.Save(dataDir+ "Combined.xlsx");
            
        }
    }
}