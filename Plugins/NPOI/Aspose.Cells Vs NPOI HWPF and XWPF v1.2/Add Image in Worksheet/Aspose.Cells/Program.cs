using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            WorksheetCollection worksheets = workbook.Worksheets;
            Worksheet worksheet = worksheets.Add("My Worksheet");

            //Insert a string value to a cell
            worksheet.Cells["C2"].Value = "Image";            

            //Set the 4th row height            
            worksheet.Cells.SetRowHeight(3, 150);

            //Set the C column width            
            worksheet.Cells.SetColumnWidth(2, 50);

            //Add a picture to the C4 cell            
            int index = worksheet.Pictures.Add(3, 2, 3, 2, "../../data/aspose.png");

            //Get the picture object
            //Picture pic = worksheet.getPictures().get(index);
            Picture pic = worksheet.Pictures[index];

            //Set the placement type
            pic.Placement = PlacementType.FreeFloating;            

            workbook.Save("../../data/image.xlsx");
        }
    }
}
