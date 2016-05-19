using Aspose.Cells;
using System;
using System.Collections.Generic;

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
            string FileName = FilePath + "Retrieve a dictionary of all named ranges.xlsx";
            Dictionary<String, String> ranges = GetDefinedNames(FileName);
        }
        public static Dictionary<String, String> GetDefinedNames(String fileName)
        {
            // Given a workbook name, return a dictionary of defined names.
            // The pairs include the range name and a string representing the range.
            var returnValue = new Dictionary<String, String>();
            
            // Open a SpreadsheetDocument based on a filepath.
            Workbook workbook = new Workbook(fileName);
            
            //Getting all named ranges
            Range[] range = workbook.Worksheets.GetNamedRanges();
            
            // If there are items in Ranges, add them to the dictionary.
            if (range != null)
            {
                foreach (Range rn in range)
                    returnValue.Add(rn.Name, rn.Value.ToString());
            }
            return returnValue;
        }
    }
}
