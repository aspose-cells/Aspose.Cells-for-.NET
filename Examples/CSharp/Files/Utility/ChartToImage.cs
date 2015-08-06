//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Utility
{
    public class ChartToImage
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
            
            //Adding a new worksheet to the Excel object
            int sheetIndex = workbook.Worksheets.Add();
            
            //Obtaining the reference of the newly added worksheet by
            //passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];
            
            //Adding a sample value to "A1" cell
            worksheet.Cells["A1"].PutValue(50);
            //Adding a sample value to "A2" cell
            worksheet.Cells["A2"].PutValue(100);
            //Adding a sample value to "A3" cell
            worksheet.Cells["A3"].PutValue(150);
            //Adding a sample value to "B1" cell
            worksheet.Cells["B1"].PutValue(4);
            //Adding a sample value to "B2" cell
            worksheet.Cells["B2"].PutValue(20);
            //Adding a sample value to "B3" cell
            worksheet.Cells["B3"].PutValue(50);

            //Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5);
            
            //Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];
            
            //Adding Series Collection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", true);
            
            //Converting chart to image.
            chart.ToImage(dataDir + "Chart.emf", System.Drawing.Imaging.ImageFormat.Emf);

            // Display result, so that user knows the processing has finished.
            System.Console.WriteLine("Image generated successfully.");
        }
    }
}