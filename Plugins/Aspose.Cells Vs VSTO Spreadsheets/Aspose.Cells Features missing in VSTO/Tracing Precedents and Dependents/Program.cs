using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing_Precedents_and_Dependents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tracing Precedents
            
            //Instantiating a Workbook object
            Workbook workbook = new Workbook("C:\\book1.xls");
            Cells cells = workbook.Worksheets[0].Cells;
            Aspose.Cells.Cell cell = cells["B7"];

            //Tracing precedents of the cell B7.
            //The return array contains ranges and cells.
            ReferredAreaCollection ret = cell.GetPrecedents();

            //Printing all the precedent cells' name.
            if (ret != null)
            {
                for (int m = 0; m < ret.Count; m++)
                {
                    ReferredArea area = ret[m];
                    StringBuilder stringBuilder = new StringBuilder();
                    if (area.IsExternalLink)
                    {
                        stringBuilder.Append("[");
                        stringBuilder.Append(area.ExternalFileName);
                        stringBuilder.Append("]");
                    }
                    stringBuilder.Append(area.SheetName);
                    stringBuilder.Append("!");
                    stringBuilder.Append(CellsHelper.CellIndexToName(area.StartRow, area.StartColumn));
                    if (area.IsArea)
                    {
                        stringBuilder.Append(":");
                        stringBuilder.Append(CellsHelper.CellIndexToName(area.EndRow, area.EndColumn));
                    }


                    Console.WriteLine(stringBuilder.ToString());
                }
            }
        }
        static void Main2(string[] args)
        {
            // Tracing Dependents

            string path = @"e:\test2\Book1.xlsx";
            Workbook workbook = new Workbook(path);
            Worksheet worksheet = workbook.Worksheets[0];
            var c = worksheet.Cells["A1"];
            var dependents = c.GetDependents(true);
            foreach (var dependent in dependents)
            {
                Console.WriteLine(string.Format("{0} ---- {1} : {2}", dependent.Worksheet.Name, dependent.Name, dependent.Value));
            }
        }
    }
}
