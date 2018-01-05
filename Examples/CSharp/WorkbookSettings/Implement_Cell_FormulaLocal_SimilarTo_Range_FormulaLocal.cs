using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.WorkbookSettings
{
    class Implement_Cell_FormulaLocal_SimilarTo_Range_FormulaLocal 
    {
        //Implement GlobalizationSettings class
        class GS : GlobalizationSettings
        {
            public override string GetLocalFunctionName(string standardName)
            {
                //Change the SUM function name as per your needs.
                if (standardName == "SUM")
                {
                    return "UserFormulaLocal_SUM";
                }

                //Change the AVERAGE function name as per your needs.
                if (standardName == "AVERAGE")
                {
                    return "UserFormulaLocal_AVERAGE";
                }

                return "";
            }//GetLocalFunctionName
        }//GS:GlobalizationSettings

        public static void Run()
        {
            //Create workbook
            Workbook wb = new Workbook();

            //Assign GlobalizationSettings implementation class
            wb.Settings.GlobalizationSettings = new GS();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access some cell
            Cell cell = ws.Cells["C4"];

            //Assign SUM formula and print its FormulaLocal
            cell.Formula = "SUM(A1:A2)";
            Console.WriteLine("Formula Local: " + cell.FormulaLocal);

            //Assign AVERAGE formula and print its FormulaLocal
            cell.Formula = "=AVERAGE(B1:B2, B5)";
            Console.WriteLine("Formula Local: " + cell.FormulaLocal);

            Console.WriteLine("Implement_Cell_FormulaLocal_SimilarTo_Range_FormulaLocal executed successfully.\r\n");
        }
    }
}
