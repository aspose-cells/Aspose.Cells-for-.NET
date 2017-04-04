using Aspose.Cells.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class CustomizePivotTableGlobalSettings
    {
        private class CustomPivotTableGlobalizationSettings : GlobalizationSettings
        {
            //Gets the name of "Total" label in the PivotTable.
            //You need to override this method when the PivotTable contains two or more PivotFields in the data area.
            public override string GetPivotTotalName()
            {
                Console.WriteLine("---------GetPivotTotalName-------------");
                return "AsposeGetPivotTotalName";
            }

            //Gets the name of "Grand Total" label in the PivotTable.
            public override string GetPivotGrandTotalName()
            {
                Console.WriteLine("---------GetPivotGrandTotalName-------------");
                return "AsposeGetPivotGrandTotalName";
            }

            //Gets the name of "(Multiple Items)" label in the PivotTable.
            public override string GetMultipleItemsName()
            {
                Console.WriteLine("---------GetMultipleItemsName-------------");
                return "AsposeGetMultipleItemsName";
            }

            //Gets the name of "(All)" label in the PivotTable.
            public override string GetAllName()
            {
                Console.WriteLine("---------GetAllName-------------");
                return "AsposeGetAllName";
            }


            //Gets the name of "Column Labels" label in the PivotTable.
            public override string GetColumnLablesName()
            {
                Console.WriteLine("---------GetColumnLablesName-------------");
                return "AsposeGetColumnLablesName";
            }

            //Gets the name of "Row Labels" label in the PivotTable.
            public override string GetRowLablesName()
            {
                Console.WriteLine("---------GetRowLablesName-------------");
                return "AsposeGetRowLablesName";
            }

            //Gets the name of "(blank)" label in the PivotTable.
            public override string GetEmptyDataName()
            {
                Console.WriteLine("---------GetEmptyDataName-------------");
                return "(blank)AsposeGetEmptyDataName";
            }

            //Gets the name of PivotFieldSubtotalType type in the PivotTable.
            public override string GetSubTotalName(PivotFieldSubtotalType subTotalType)
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
        }//End CustomPivotTableGlobalizationSettings
        public static void Run()
        {
            // ExStart:CustomizePivotTableGlobalSettings
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                        
            //Load your excel file
            Workbook wb = new Workbook(dataDir + "samplePivotTableGlobalizationSettings.xlsx");

            //Setting Custom Pivot Table Globalization Settings
            wb.Settings.GlobalizationSettings = new CustomPivotTableGlobalizationSettings();

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

            // ExEnd:CustomizePivotTableGlobalSettings
        }
    }
}
