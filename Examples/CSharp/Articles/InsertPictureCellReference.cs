//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.Articles
{
    public class InsertPictureCellReference
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate a new Workbook
            Workbook workbook = new Workbook();
            //Get the first worksheet's cells collection
            Cells cells = workbook.Worksheets[0].Cells;

            //Add string values to the cells
            cells["A1"].PutValue("A1");
            cells["C10"].PutValue("C10");

            //Add a blank picture to the D1 cell
            Picture pic = (Picture)workbook.Worksheets[0].Shapes.AddPicture(0, 3, 10, 6, null);
            //Specify the formula that refers to the source range of cells
            pic.Formula = "A1:C10";
            //Update the shapes selected value in the worksheet
            workbook.Worksheets[0].Shapes.UpdateSelectedValue();

            //Save the Excel file.
            workbook.Save(dataDir+ "referencedpicture.xlsx");
            
            
        }
    }
}