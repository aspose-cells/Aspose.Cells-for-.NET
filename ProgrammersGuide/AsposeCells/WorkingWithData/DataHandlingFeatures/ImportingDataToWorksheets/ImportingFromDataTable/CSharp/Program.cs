//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Data;
using System;

namespace ImportingFromDataTable
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

            //Instantiating a Workbook object            
            Workbook workbook = new Workbook();

            //Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Instantiating a "Products" DataTable object
            DataTable dataTable = new DataTable("Products");

            //Adding columns to the DataTable object
            dataTable.Columns.Add("Product ID", typeof(Int32));
            dataTable.Columns.Add("Product Name", typeof(string));
            dataTable.Columns.Add("Units In Stock", typeof(Int32));

            //Creating an empty row in the DataTable object
            DataRow dr = dataTable.NewRow();

            //Adding data to the row
            dr[0] = 1;
            dr[1] = "Aniseed Syrup";
            dr[2] = 15;

            //Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            //Creating another empty row in the DataTable object
            dr = dataTable.NewRow();

            //Adding data to the row
            dr[0] = 2;
            dr[1] = "Boston Crab Meat";
            dr[2] = 123;

            //Adding filled row to the DataTable object
            dataTable.Rows.Add(dr);

            //Importing the contents of DataTable to the worksheet starting from "A1" cell,
            //where true specifies that the column names of the DataTable would be added to
            //the worksheet as a header row
            worksheet.Cells.ImportDataTable(dataTable, true, "A1");


            //Saving the Excel file
            workbook.Save(dataDir + "DataImport.xls");
 
        }
    }
}