//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace AddingLabelControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Create a new Workbook.
            //Open the existing file.
            Workbook workbook = new Workbook(dataDir + "chart.xls");

            //Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[1];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            //Add a new label to the chart.
            Aspose.Cells.Drawing.Label label = chart.Shapes.AddLabelInChart(100, 100, 350, 900);

            //Set the caption of the label.
            label.Text = "A Label In Chart";

            //Set the Placement Type, the way the
            //label is attached to the cells.
            label.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating;

            //Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Azure;

            //Save the excel file.
            workbook.Save(dataDir + "chart_out.xls");
 
            
        }
    }
}