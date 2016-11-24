using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ChartRendering
    {
        public static void Run()
        {
            // ExStart:ChartRenderingCreatingChart
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();
            // Adding a new worksheet to the Workbook
            int sheetIndex = workbook.Worksheets.Add();
            // Obtaining the reference of the newly added worksheet by passing its index to WorksheetCollection
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            // Adding sample values to cells
            worksheet.Cells["A1"].PutValue(50);
            worksheet.Cells["A2"].PutValue(100);
            worksheet.Cells["A3"].PutValue(150);
            worksheet.Cells["B1"].PutValue(4);
            worksheet.Cells["B2"].PutValue(20);
            worksheet.Cells["B3"].PutValue(50);

            // Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5);
            // Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];
            // Adding Series Collection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", true);
            // ExEnd:ChartRenderingCreatingChart

            // ExStart:ChartRenderingChartToImage
            // Converting chart to image
            chart.ToImage(dataDir + "chartEMF_out.emf", System.Drawing.Imaging.ImageFormat.Emf);

            // Converting chart to Bitmap
            System.Drawing.Bitmap bitmap = chart.ToImage();
            bitmap.Save(dataDir + "chartBMP_out.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            // ExEnd:ChartRenderingChartToImage

            // ExStart:ChartRenderingChartToImageWithAdvancedOptions
            // Create an instance of ImageOrPrintOptions and set a few properties
            ImageOrPrintOptions options = new ImageOrPrintOptions()
            {
                VerticalResolution = 300,
                HorizontalResolution = 300,
                SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            };
            // Convert chart to image with additional settings
            chart.ToImage(dataDir + "chartPNG_out.png", options);
            // ExEnd:ChartRenderingChartToImageWithAdvancedOptions

            // ExStart:ChartRenderingChartToPDF
            // Converting chart to PDF
            chart.ToPdf(dataDir + "chartPDF_out.pdf");
            // ExEnd:ChartRenderingChartToPDF
        }
    }
}
