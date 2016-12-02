using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class UsingCellsFactory
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a Style object using CellsFactory class
            CellsFactory cf = new CellsFactory();
            Style st = cf.CreateStyle();

            // Set the Style fill color to Yellow
            st.Pattern = BackgroundType.Solid;
            st.ForegroundColor = Color.Yellow;

            // Create a workbook and set its default style using the created Style object
            Workbook wb = new Workbook();
            wb.DefaultStyle = st;

            // Save the workbook
            wb.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
