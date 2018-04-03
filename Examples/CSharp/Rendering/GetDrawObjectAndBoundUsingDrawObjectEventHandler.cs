using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class GetDrawObjectAndBoundUsingDrawObjectEventHandler
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        //Implement the concrete class of DrawObjectEventHandler
        class clsDrawObjectEventHandler : DrawObjectEventHandler
        {
            public override void Draw(DrawObject drawObject, float x, float y, float width, float height)
            {
                Console.WriteLine("");

                //Print the coordinates and the value of Cell object
                if (drawObject.Type == DrawObjectEnum.Cell)
                {
                    Console.WriteLine("[X]: " + x + " [Y]: " + y + " [Width]: " + width + " [Height]: " + height + " [Cell Value]: " + drawObject.Cell.StringValue);
                }

                //Print the coordinates and the shape name of Image object
                if (drawObject.Type == DrawObjectEnum.Image)
                {
                    Console.WriteLine("[X]: " + x + " [Y]: " + y + " [Width]: " + width + " [Height]: " + height + " [Shape Name]: " + drawObject.Shape.Name);
                }

                Console.WriteLine("----------------------");
            }
        }

        public static void Run()
        {
            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleGetDrawObjectAndBoundUsingDrawObjectEventHandler.xlsx");

            //Specify Pdf save options
            PdfSaveOptions opts = new PdfSaveOptions();

            //Assign the instance of DrawObjectEventHandler class
            opts.DrawObjectEventHandler = new clsDrawObjectEventHandler();

            //Save to Pdf format with Pdf save options
            wb.Save(outputDir + "outputGetDrawObjectAndBoundUsingDrawObjectEventHandler.pdf", opts);

            Console.WriteLine("GetDrawObjectAndBoundUsingDrawObjectEventHandler executed successfully.");
        }
    }

}
