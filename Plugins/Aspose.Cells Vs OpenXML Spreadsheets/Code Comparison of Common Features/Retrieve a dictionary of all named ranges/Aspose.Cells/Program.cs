using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDoc = @"E:\Aspose\Aspose Vs OpenXML\Aspose.Cells Vs OpenXML Spreadsheet v 1.1\SampleFiles\Retrieve a dictionary of all named ranges.xlsx";
            Dictionary<String, String> ranges = GetDefinedNames(strDoc);
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
