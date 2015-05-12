//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace MergeCellsInNamedRange
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

            //Instantiate a new Workbook.
            Workbook wb1 = new Workbook();

            //Get the first worksheet in the workbook.
            Worksheet worksheet1 = wb1.Worksheets[0];

            //Create a range.
            Range mrange = worksheet1.Cells.CreateRange("A18", "J18");

            //Name the range.
            mrange.Name = "Details";

            //Merge the cells of the range.
            mrange.Merge();

            //Get the range.
            Range range1 = wb1.Worksheets.GetRangeByName("Details");

            //Add a style object to the collection.
            int i = wb1.Styles.Add();

            //Define a style object.
            Style style = wb1.Styles[i];

            //Set the alignment.
            style.HorizontalAlignment = TextAlignmentType.Center;

            //Create a StyleFlag object.
            StyleFlag flag = new StyleFlag();
            //Make the relative style attribute ON.
            flag.HorizontalAlignment = true;

            //Apply the style to the range.
            range1.ApplyStyle(style, flag);

            //Input data into range.
            range1[0, 0].PutValue("Aspose");

            //Save the excel file.
            wb1.Save(dataDir + "mergingrange.xls");
        }
    }
}