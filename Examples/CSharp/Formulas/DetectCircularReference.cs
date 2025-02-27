using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Formulas
{
    class DetectCircularReference
    {
        // Input directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Main()
        {
            // ExStart:1
            LoadOptions LoadOptions = new LoadOptions();
            var objWB = new Aspose.Cells.Workbook(sourceDir + "Circular Formulas.xls", LoadOptions);
            objWB.Settings.FormulaSettings.EnableIterativeCalculation = true;
            CalculationOptions copts = new CalculationOptions();
            CircularMonitor cm = new CircularMonitor();
            copts.CalculationMonitor = cm;
            objWB.CalculateFormula(copts);
            long lngCircularRef = cm.circulars.Count;

            Console.WriteLine("Circular References found - " + lngCircularRef);
            // ExEnd:1
            Console.WriteLine("DetectCircularReference executed successfully.\r\n");
        }
    }
    // ExStart:2
    public class CircularMonitor : AbstractCalculationMonitor
    {
        public ArrayList circulars = new ArrayList();
        public ArrayList Circulars { get { return circulars; } }

        public override bool OnCircular(IEnumerator circularCellsData)
        {
            CalculationCell cc = null;
            ArrayList cur = new ArrayList();
            while (circularCellsData.MoveNext())
            {
                cc = (CalculationCell)circularCellsData.Current;
                cur.Add(cc.Worksheet.Name + "!" + CellsHelper.CellIndexToName(cc.CellRow, cc.CellColumn));
            }
            circulars.Add(cur);
            return true;
        }
    }
    // ExEnd:2
}
