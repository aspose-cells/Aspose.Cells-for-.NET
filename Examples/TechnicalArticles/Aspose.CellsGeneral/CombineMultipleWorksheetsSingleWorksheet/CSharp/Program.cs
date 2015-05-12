//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace CombineMultipleWorksheetsSingleWorksheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            string filePath = dataDir+ "SampleInput.xlsx";

            Workbook workbook = new Workbook(filePath);

            Workbook destWorkbook = new Workbook();

            Worksheet destSheet = destWorkbook.Worksheets[0];

            int TotalRowCount = 0;

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                Worksheet sourceSheet = workbook.Worksheets[i];

                Range sourceRange = sourceSheet.Cells.MaxDisplayRange;

                Range destRange = destSheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn,
                      sourceRange.RowCount, sourceRange.ColumnCount);

                destRange.Copy(sourceRange);

                TotalRowCount = sourceRange.RowCount + TotalRowCount;
            }

            destWorkbook.Save(dataDir+ "Output.xlsx");
            
            
        }
    }
}