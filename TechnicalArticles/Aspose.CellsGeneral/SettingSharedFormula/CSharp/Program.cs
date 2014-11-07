//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace SettingSharedFormulaExample
{
    public class Program
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            
            string filePath = dataDir+ "input.xlsx";

         //Instantiate a Workbook from existing file
         Workbook workbook = new Workbook(filePath);

        //Get the cells collection in the first worksheet
        Cells cells = workbook.Worksheets[0].Cells;

        //Apply the shared formula in the range i.e.., B2:B14
        cells["B2"].SetSharedFormula("=A2*0.09", 13, 1);

        //Save the excel file
        workbook.Save(dataDir+ ".out.xlsx", SaveFormat.Xlsx);
            
        }
    }
}