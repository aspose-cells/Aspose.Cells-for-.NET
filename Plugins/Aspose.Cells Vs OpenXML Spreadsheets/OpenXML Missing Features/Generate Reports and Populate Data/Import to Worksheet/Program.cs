// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Aspose.Cells;

namespace Import_to_Worksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportFromArray();
            ImportFromArrayList();
            ImportFromCustomObject();
            ImportFromDataTable();

        }
        public static void ImportFromArray()
        {
            string MyDir = @"Files\";
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Creating an array containing names as string values
            string[] names = new string[] { "laurence chen", "roman korchagin", "kyle huang" };

            //Importing the array of names to 1st row and first column vertically
            worksheet.Cells.ImportArray(names, 0, 0, true);

            //Saving the Excel file
            workbook.Save(MyDir+"DataImport from Array.xls");
 
        }
        public static void ImportFromArrayList()
        {
            string MyDir = @"Files\";
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];
            //Instantiating an ArrayList object
            ArrayList list = new ArrayList();

            //Add few names to the list as string values
            list.Add("laurence chen");
            list.Add("roman korchagin");
            list.Add("kyle huang");
            list.Add("tommy wang");

            //Importing the contents of ArrayList to 1st row and first column vertically
            worksheet.Cells.ImportArrayList(list, 0, 0, true);

            //Saving the Excel file
            workbook.Save(MyDir + "DataImport from Array List.xls");
 
        }
        public static void ImportFromCustomObject()
        {
            string MyDir = @"Files\";
            //Instantiate a new Workbook
            Workbook book = new Workbook();
            //Clear all the worksheets
            book.Worksheets.Clear();
            //Add a new Sheet "Data";
            Worksheet sheet = book.Worksheets.Add("Data");

            //Define List
            
            List<WeeklyItem> list = new List<WeeklyItem>();
            //Add data to the list of objects
            list.Add(new WeeklyItem() { AtYarnStage = 1, InWIPStage = 2, Payment = 3, Shipment = 4, Shipment2 = 5 });
            list.Add(new WeeklyItem() { AtYarnStage = 5, InWIPStage = 9, Payment = 7, Shipment = 2, Shipment2 = 5 });
            list.Add(new WeeklyItem() { AtYarnStage = 7, InWIPStage = 3, Payment = 3, Shipment = 8, Shipment2 = 3 });

            //We pick a few columns not all to import to the worksheet
            sheet.Cells.ImportCustomObjects((System.Collections.ICollection)list,
            new string[] { "Date", "InWIPStage", "Shipment", "Payment" },
            true,
            0,
            0,
            list.Count,
            true,
            "dd/mm/yyyy",
            false);

            //Auto-fit all the columns
            book.Worksheets[0].AutoFitColumns();
            //Save the Excel file
            book.Save(MyDir+"ImportedCustomObjects.xls");
        }
        public static void ImportFromDataTable()
        {
            string MyDir = @"Files\";
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];
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
            workbook.Save(MyDir+"Import From Data Table.xls");
        }

    }
}
