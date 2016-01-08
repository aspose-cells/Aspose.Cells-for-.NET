// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System.IO;
using Aspose.Cells;

namespace Work_with_Rows_n_Col
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertRow();
            InsertingMutipleRows();
            DeletingRow();
            DeletingMutipleRows();
            InsertingAColumn();
            DeletingColumn();

        }
        public static void InsertRow()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Inserting a row into the worksheet at 3rd position
            worksheet.Cells.InsertRow(2);

            //Saving the modified Excel file
            workbook.Save(MyDir + "Inserting Row.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
        public static void InsertingMutipleRows()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Inserting 10 rows into the worksheet starting from 3rd row
            worksheet.Cells.InsertRows(2, 10);
            //Saving the modified Excel file
            workbook.Save(MyDir + "Inserting Mutiple Rows.xls");

            //Closing the file stream to free all resources
            fstream.Close();
 
        }
        public static void DeletingRow()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Deleting 3rd row from the worksheet
            worksheet.Cells.DeleteRow(2);
            //Saving the modified Excel file
            workbook.Save(MyDir + "Deleting Rows.xls");

            //Closing the file stream to free all resources
            fstream.Close();
 
        }
        public static void DeletingMutipleRows()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Deleting 10 rows from the worksheet starting from 3rd row
            worksheet.Cells.DeleteRows(2, 10);
            //Saving the modified Excel file
            workbook.Save(MyDir + "Deleting Mutiple Rows.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
        public static void InsertingAColumn()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Inserting a column into the worksheet at 2nd position
            worksheet.Cells.InsertColumn(1);
            //Saving the modified Excel file
            workbook.Save(MyDir + "Inserting Column.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
        public static void DeletingColumn()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "Row and Column Operation.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];
            //Deleting a column from the worksheet at 2nd position
            worksheet.Cells.DeleteColumn(1);
            //Saving the modified Excel file
            workbook.Save(MyDir + "Deleting Column.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }

    }
}
