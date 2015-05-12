//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;
using System;
using System.Drawing;

namespace UsingSparklines
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a Workbook
            //Open a template file
            Workbook book = new Workbook(dataDir + "Book1.xlsx");
            //Get the first worksheet
            Worksheet sheet = book.Worksheets[0];

            //Use the following lines if you need to read the Sparklines
            //Read the Sparklines from the template file (if it has)
            foreach (SparklineGroup g in sheet.SparklineGroupCollection)
            {
                //Display the Sparklines group information e.g type, number of sparklines items
                Console.WriteLine("sparkline group: type:" + g.Type + ", sparkline items count:" + g.SparklineCollection.Count);
                foreach (Sparkline s in g.SparklineCollection)
                {
                    //Display the individual Sparkines and the data ranges
                    Console.WriteLine("sparkline: row:" + s.Row + ", col:" + s.Column + ", dataRange:" + s.DataRange);
                }
            }


            //Add Sparklines
            //Define the CellArea D2:D10
            CellArea ca = new CellArea();
            ca.StartColumn = 4;
            ca.EndColumn = 4;
            ca.StartRow = 1;
            ca.EndRow = 7;
            //Add new Sparklines for a data range to a cell area
            int idx = sheet.SparklineGroupCollection.Add(SparklineType.Column, "Sheet1!B2:D8", false, ca);
            SparklineGroup group = sheet.SparklineGroupCollection[idx];
            //Create CellsColor
            CellsColor clr = book.CreateCellsColor();
            clr.Color = Color.Orange;
            group.SeriesColor = clr;

            //Save the excel file
            book.Save(dataDir + "Book1_out.xlsx");

        }
    }
}