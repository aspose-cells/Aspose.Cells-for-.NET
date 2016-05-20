// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System.IO;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        private static string MyDir = @"..\..\..\Sample Files\";
        
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
