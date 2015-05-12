//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System;

namespace DecimalDataValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Create a workbook object.
            Workbook workbook = new Workbook();

            // Create a worksheet and get the first worksheet.
            Worksheet ExcelWorkSheet = workbook.Worksheets[0];

            // Obtain the existing Validations collection.
            ValidationCollection validations = ExcelWorkSheet.Validations;

            // Create a validation object adding to the collection list.
            Validation validation = validations[validations.Add()];

            // Set the validation type.
            validation.Type = ValidationType.Decimal;

            // Specify the operator.
            validation.Operator = OperatorType.Between;

            // Set the lower and upper limits.
            validation.Formula1 = Decimal.MinValue.ToString();
            validation.Formula2 = Decimal.MaxValue.ToString();

            // Set the error message.
            validation.ErrorMessage = "Please enter a valid integer or decimal number";

            // Specify the validation area of cells.
            CellArea area;
            area.StartRow = 0;
            area.EndRow = 9;
            area.StartColumn = 0;
            area.EndColumn = 0;

            // Add the area.
            validation.AreaList.Add(area);

            // Save the workbook.
            workbook.Save(dataDir + "output.xls");

        }
    }
}