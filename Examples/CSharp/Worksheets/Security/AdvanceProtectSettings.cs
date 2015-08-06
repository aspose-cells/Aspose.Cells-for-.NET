//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Security
{
    public class AdvanceProtectSettings
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook excel = new Workbook(dataDir + "book1.xls");

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = excel.Worksheets[0];

            //Restricting users to delete columns of the worksheet
            worksheet.Protection.AllowDeletingColumn = false;

            //Restricting users to delete row of the worksheet
            worksheet.Protection.AllowDeletingRow = false;

            //Restricting users to edit contents of the worksheet
            worksheet.Protection.AllowEditingContent = false;

            //Restricting users to edit objects of the worksheet
            worksheet.Protection.AllowEditingObject = false;

            //Restricting users to edit scenarios of the worksheet
            worksheet.Protection.AllowEditingScenario = false;

            //Restricting users to filter
            worksheet.Protection.AllowFiltering = false;

            //Allowing users to format cells of the worksheet
            worksheet.Protection.AllowFormattingCell = true;

            //Allowing users to format rows of the worksheet
            worksheet.Protection.AllowFormattingRow = true;

            //Allowing users to insert columns in the worksheet
            worksheet.Protection.AllowFormattingColumn = true;

            //Allowing users to insert hyperlinks in the worksheet
            worksheet.Protection.AllowInsertingHyperlink = true;

            //Allowing users to insert rows in the worksheet
            worksheet.Protection.AllowInsertingRow = true;

            //Allowing users to select locked cells of the worksheet
            worksheet.Protection.AllowSelectingLockedCell = true;

            //Allowing users to select unlocked cells of the worksheet
            worksheet.Protection.AllowSelectingUnlockedCell = true;

            //Allowing users to sort
            worksheet.Protection.AllowSorting = true;

            //Allowing users to use pivot tables in the worksheet
            worksheet.Protection.AllowUsingPivotTable = true;

            //Saving the modified Excel file
            excel.Save(dataDir + "output.xls", SaveFormat.Excel97To2003);
            
        }
    }
}