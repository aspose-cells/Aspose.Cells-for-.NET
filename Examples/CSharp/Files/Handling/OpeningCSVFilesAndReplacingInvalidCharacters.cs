using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningCSVFilesAndReplacingInvalidCharacters
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            
            var filename = sourceDir + "[20180220142533][ASPOSE_CELLS_TEST].csv";

            //Load csv file
            var workbook = new Workbook(filename, new TxtLoadOptions() { Separator = ';', LoadFilter = new LoadFilter(LoadDataFilterOptions.CellData), CheckExcelRestriction = false, ConvertNumericData = false, ConvertDateTimeData = false });

            Console.WriteLine(workbook.Worksheets[0].Name); // (20180220142533)(ASPOSE_CELLS_T
            Console.WriteLine(workbook.Worksheets[0].Name.Length); // 31
            Console.WriteLine("CSV file opened successfully!");
            // ExEnd:1
            }
          }
        }
            
