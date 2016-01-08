// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using Aspose.Cells;

namespace Calculate_Formula_once
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Without creating formula chain.xls";

            //Load the template workbook
            Workbook workbook = new Workbook(filePath);

            //Print the time before formula calculation
            Console.WriteLine(DateTime.Now);

            //Set the CreateCalcChain as false
            workbook.Settings.CreateCalcChain = false;

            //Calculate the workbook formulas
            workbook.CalculateFormula();

            //Print the time after formula calculation
            Console.WriteLine(DateTime.Now);
            workbook.Save("Without creating formula chain.xls");
        }
    }
}
