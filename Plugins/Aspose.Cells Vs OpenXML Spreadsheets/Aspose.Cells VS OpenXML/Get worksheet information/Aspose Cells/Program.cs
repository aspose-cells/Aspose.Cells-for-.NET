// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using Aspose.Cells.Properties;
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
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Get worksheet information.xlsx";

            GetSheetInfo(FileName);
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
