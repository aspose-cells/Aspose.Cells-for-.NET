//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
{
    public class CopyChart
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Create a workbook object
            //Open the template file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart source = workbook.Worksheets["Sheet2"].Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = source.ChartObject;

            //Copy the Chart to the Result Worksheet
            workbook.Worksheets["Sheet3"].Shapes.AddCopy(cshape, 20, 0, 2, 0);

            //Save the Worksheet
            workbook.Save(dataDir+ "Shapes.xlsx");
            
        }
    }
}