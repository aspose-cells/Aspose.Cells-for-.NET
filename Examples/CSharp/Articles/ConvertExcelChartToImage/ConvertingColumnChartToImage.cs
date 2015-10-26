//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.ConvertExcelChartToImage
{
    public class ConvertingColumnChartToImage
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            //Create a new workbook.
            //Open the existing excel file which contains the column chart.
            Workbook workbook = new Workbook(dataDir+ "ColumnChart.xlsx");

            //Get the designer chart (first chart) in the first worksheet.
            //of the workbook.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            //Convert the chart to an image file.
            chart.ToImage(dataDir+ "ColumnChart.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            
            
        }
    }
}