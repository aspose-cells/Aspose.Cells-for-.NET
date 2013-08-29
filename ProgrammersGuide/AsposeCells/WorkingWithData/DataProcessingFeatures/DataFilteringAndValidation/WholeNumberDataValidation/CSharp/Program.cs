//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace WholeNumberDataValidation
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

            //Accessing the Validations collection of the worksheet
            ValidationCollection validations = workbook.Worksheets[0].Validations;

            //Creating a Validation object
            Validation validation = validations[validations.Add()];

            //Setting the validation type to whole number
            validation.Type = ValidationType.WholeNumber;

            //Setting the operator for validation to Between
            validation.Operator = OperatorType.Between;

            //Setting the minimum value for the validation
            validation.Formula1 = "10";

            //Setting the maximum value for the validation
            validation.Formula2 = "1000";

            //Applying the validation to a range of cells from A1 to B2 using the
            //CellArea structure
            CellArea area;
            area.StartRow = 0;
            area.EndRow = 1;
            area.StartColumn = 0;
            area.EndColumn = 1;

            //Adding the cell area to Validation
            validation.AreaList.Add(area);


            // Save the workbook.
            workbook.Save(dataDir + "output.xls");

            
        }
    }
}