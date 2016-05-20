// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using Aspose.Cells.Rendering;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/
namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Chart to Image with Image Options.tiff";
            
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

            ImageOrPrintOptions options = new ImageOrPrintOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.TiffCompression = TiffCompression.CompressionLZW;
            options.IsCellAutoFit = false;
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
            options.OnePagePerSheet = true;
            //Converting chart to image.
            chart.ToImage(FileName, options);
        }
    }
}
