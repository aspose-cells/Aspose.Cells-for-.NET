// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Aspose.Cells.Properties;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSheetInfo("Get worksheet information.xlsx");
            Console.ReadKey();
        }

        private static void GetSheetInfo(string fileName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(fileName);

            //Loop through all Sheets in the workbook
            foreach (Worksheet Sheet in workbook.Worksheets)
            {
                //Get Name and Index of Sheet
                Console.WriteLine("Sheet Name: {0}", Sheet.Name);
                Console.WriteLine("Sheet Index: {0}", Sheet.Index);

                //Loop through all custom properties
                foreach (CustomProperty Property in Sheet.CustomProperties)
                {
                    Console.WriteLine("{0}: {1}", Property.Name, Property.Value);
                }
            }
        }
    }
}
