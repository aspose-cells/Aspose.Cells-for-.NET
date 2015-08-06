//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ImplementingNonSequencedRanges
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a Name for non sequenced range
            int index = workbook.Worksheets.Names.Add("NonSequencedRange");

            Name name = workbook.Worksheets.Names[index];

            //Creating a non sequence range of cells
            name.RefersTo = "=Sheet1!$A$1:$B$3,Sheet1!$E$5:$D$6";

            //Save the workbook
            workbook.Save(dataDir+ "Output.xlsx");
            
        }
    }
}