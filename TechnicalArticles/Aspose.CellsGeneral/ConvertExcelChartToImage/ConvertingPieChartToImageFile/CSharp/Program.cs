//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ConvertingPieChartToImageFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Create a new workbook.
            //Open the existing excel file which contains the pie chart.
            Workbook workbook = new Workbook(dataDir+ "PieChart.xls");

            //Get the designer chart (first chart) in the first worksheet.
            //of the workbook.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            //Convert the chart to an image file.
            chart.ToImage(dataDir+ "PieChart.emf", System.Drawing.Imaging.ImageFormat.Emf);
 
            
            
        }
    }
}