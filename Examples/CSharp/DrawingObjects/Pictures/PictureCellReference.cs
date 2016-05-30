using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace CSharp.DrawingObjects.Pictures
{
    public class PictureCellReference
    {
        public static void Run()
        {
            try
            {
                // ExStart:1
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                // Create directory if it is not already present.
                bool IsExists = System.IO.Directory.Exists(dataDir);
                if (!IsExists)
                    System.IO.Directory.CreateDirectory(dataDir);

                // Instantiate a new Workbook
                Workbook workbook = new Workbook();
                // Get the first worksheet's cells collection
                Cells cells = workbook.Worksheets[0].Cells;

                // Add string values to the cells
                cells["A1"].PutValue("A1");
                cells["C10"].PutValue("C10");

                // Add a blank picture to the D1 cell
                Picture pic = workbook.Worksheets[0].Shapes.AddPicture(0, 3, 10, 6, null);

                // Specify the formula that refers to the source range of cells
                // Pic.Formula = "A1:C10";

                // Update the shapes selected value in the worksheet
                workbook.Worksheets[0].Shapes.UpdateSelectedValue();

                // Save the Excel file.
                workbook.Save(dataDir + "output.out.xls");
                // ExEnd:1
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
