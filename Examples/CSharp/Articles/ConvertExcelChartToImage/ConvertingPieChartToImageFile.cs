using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertExcelChartToImage
{
    public class ConvertingPieChartToImageFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a new workbook.
            // Open the existing excel file which contains the pie chart.
            Workbook workbook = new Workbook(dataDir+ "PieChart.xlsx");

            // Get the designer chart (first chart) in the first worksheet.
            // Of the workbook.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            // Convert the chart to an image file.
            chart.ToImage(dataDir+ "PieChart.out.emf", System.Drawing.Imaging.ImageFormat.Emf);
            // ExEnd:1
 
            
            
        }
    }
}
