// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/
namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Adding Formula.xlsx";
            
            //Load the template workbook
            Workbook workbook = new Workbook(FileName);

            //Print the time before formula calculation
            Console.WriteLine(DateTime.Now);

            //Set the CreateCalcChain as false
            workbook.Settings.CreateCalcChain = false;

            //Calculate the workbook formulas
            workbook.CalculateFormula();

            //Print the time after formula calculation
            Console.WriteLine(DateTime.Now);
            workbook.Save(FileName);
        }
    }
}
