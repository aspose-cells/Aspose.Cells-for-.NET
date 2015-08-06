//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.Charts.SettingChartsAppearance
{
    public class ApplyingThemes
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate the workbook to open the file that contains a chart
            Workbook workbook = new Workbook(dataDir + "book1.xlsx");

            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[1];

            //Get the first chart in the sheet
            Chart chart = worksheet.Charts[0];

            //Specify the FilFormat's type to Solid Fill of the first series
            chart.NSeries[0].Area.FillFormat.Type = Aspose.Cells.Drawing.FillType.Solid;

            //Get the CellsColor of SolidFill
            CellsColor cc = chart.NSeries[0].Area.FillFormat.SolidFill.CellsColor;

            //Create a theme in Accent style
            cc.ThemeColor = new ThemeColor(ThemeColorType.Accent6, 0.6);

            //Apply the them to the series
            chart.NSeries[0].Area.FillFormat.SolidFill.CellsColor = cc;

            //Save the Excel file
            workbook.Save(dataDir + "output.xlsx");

        }
    }
}