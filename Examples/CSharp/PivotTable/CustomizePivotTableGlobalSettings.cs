using Aspose.Cells.Pivot;
using Aspose.Cells.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class CustomizePivotTableGlobalSettings
    {
        // ExStart:CustomizePivotTableGlobalSettings
        private class CustomPivotTableGlobalizationSettings : PivotGlobalizationSettings
        {
            //Gets the name of "Total" label in the PivotTable.
            //You need to override this method when the PivotTable contains two or more PivotFields in the data area.
            public override string GetTextOfTotal()
            {
                Console.WriteLine("---------GetPivotTotalName-------------");
                return "AsposeGetPivotTotalName";
            }

            //Gets the name of "Grand Total" label in the PivotTable.
            public override string GetTextOfGrandTotal()
            {
                Console.WriteLine("---------GetPivotGrandTotalName-------------");
                return "AsposeGetPivotGrandTotalName";
            }

            //Gets the name of "(Multiple Items)" label in the PivotTable.
            public override string GetTextOfMultipleItems()
            {
                Console.WriteLine("---------GetMultipleItemsName-------------");
                return "AsposeGetMultipleItemsName";
            }

            //Gets the name of "(All)" label in the PivotTable.
            public override string GetTextOfAll()
            {
                Console.WriteLine("---------GetAllName-------------");
                return "AsposeGetAllName";
            }

            //Gets the name of "Column Labels" label in the PivotTable.
            public override string GetTextOfColumnLabels()
            {
                Console.WriteLine("---------GetColumnLabelsOfPivotTable-------------");
                return "AsposeGetColumnLabelsOfPivotTable";
            }

            //Gets the name of "Row Labels" label in the PivotTable.
            public override string GetTextOfRowLabels()
            {
                Console.WriteLine("---------GetRowLabelsNameOfPivotTable-------------");
                return "AsposeGetRowLabelsNameOfPivotTable";
            }

            //Gets the name of "(blank)" label in the PivotTable.
            public override string GetTextOfEmptyData()
            {
                Console.WriteLine("---------GetEmptyDataName-------------");
                return "(blank)AsposeGetEmptyDataName";
            }

            //Gets the name of PivotFieldSubtotalType type in the PivotTable.
            public override string GetTextOfSubTotal(PivotFieldSubtotalType subTotalType)
            {
                Console.WriteLine("---------GetSubTotalName-------------");

                switch (subTotalType)
                {
                    case PivotFieldSubtotalType.Sum:
                        return "AsposeSum";//polish

                    case PivotFieldSubtotalType.Count:
                        return "AsposeCount";

                    case PivotFieldSubtotalType.Average:
                        return "AsposeAverage";

                    case PivotFieldSubtotalType.Max:
                        return "AsposeMax";

                    case PivotFieldSubtotalType.Min:
                        return "AsposeMin";

                    case PivotFieldSubtotalType.Product:
                        return "AsposeProduct";

                    case PivotFieldSubtotalType.CountNums:
                        return "AsposeCount";

                    case PivotFieldSubtotalType.Stdev:
                        return "AsposeStdDev";

                    case PivotFieldSubtotalType.Stdevp:
                        return "AsposeStdDevp";

                    case PivotFieldSubtotalType.Var:
                        return "AsposeVar";

                    case PivotFieldSubtotalType.Varp:
                        return "AsposeVarp";
                }

                return "AsposeSubTotalName";
            }
        }
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                        
            //Load your excel file
            Workbook wb = new Workbook(dataDir + "samplePivotTableGlobalizationSettings.xlsx");

            GlobalizationSettings settings = new GlobalizationSettings();
            settings.PivotSettings = new CustomPivotTableGlobalizationSettings();
            //Setting Custom Pivot Table Globalization Settings
            wb.Settings.GlobalizationSettings = settings;

            //Hide first worksheet that contains the data of the pivot table
            wb.Worksheets[0].IsVisible = false;

            //Access second worksheet
            Worksheet ws = wb.Worksheets[1];

            //Access the pivot table, refresh and calculate its data
            PivotTable pt = ws.PivotTables[0];
            pt.RefreshDataFlag = true;
            pt.RefreshData();
            pt.CalculateData();
            pt.RefreshDataFlag = false;

            //Pdf save options - save entire worksheet on a single pdf page
            PdfSaveOptions options = new PdfSaveOptions();
            options.OnePagePerSheet = true;

            //Save the output pdf 
            wb.Save(dataDir + "outputPivotTableGlobalizationSettings.pdf", options);
        }
        // ExEnd:CustomizePivotTableGlobalSettings
    }
}
