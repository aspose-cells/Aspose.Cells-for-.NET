//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace ModifyThroughSampleExcelFileExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Create a workbook.
            //Open a template file. 
            //In the book1.xls file, we have applied Ms Excel's 
            //Named style i.e., "Percent" to the range "A1:C8". 
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            //We get the Percent style and create a style object.
            Style style = workbook.Styles["Percent"];

            //Change the number format to "0.00%".
            style.Number = 11;

            //Set the font color.
            style.Font.Color = System.Drawing.Color.Red;

            //Update the style. so, the style of range "A1:C8" will be changed too.
            style.Update();

            //Save the excel file.	
            workbook.Save(dataDir+ "book2.xlsx");
            
        }
    }
}