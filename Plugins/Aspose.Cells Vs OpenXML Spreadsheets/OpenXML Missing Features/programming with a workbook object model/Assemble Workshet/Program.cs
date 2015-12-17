// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assemble_Workshet
{
    class Program
    {
        static void Main(string[] args)
        {
            AddingWorksheetToNewExcelFile();
            AddingWorksheetToDesignerSpreadsheet();
            AccesingWorsheetUsingSheetName();
            RemovingWorksheet();
            RemovingWorksheetUsingIndex();
        }
        public static void AddingWorksheetToNewExcelFile()
        {
            string MyDir = @"Files\";
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet";

            //Saving the Excel file
            workbook.Save(MyDir + "Adding Worksheet.xls");
        }
        public static void AddingWorksheetToDesignerSpreadsheet()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream("WorksHeet Operations.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet";

            //Saving the Excel file
            workbook.Save(MyDir + "Designer Spreadsheet.xls");

            //Closing the file stream to free all resources
            fstream.Close();
        }
        public static void AccesingWorsheetUsingSheetName()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "WorksHeet Operations.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Accessing a worksheet using its sheet name
            Worksheet worksheet = workbook.Worksheets["Sheet1"];
        }
        public static void RemovingWorksheet()
        {
            string MyDir = @"=Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "WorksHeet Operations.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Removing a worksheet using its sheet name
            workbook.Worksheets.RemoveAt("Sheet3");
            workbook.Save(MyDir + "WorksHeet Operations.xls");
        }
        public static void RemovingWorksheetUsingIndex()
        {
            string MyDir = @"Files\";
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "WorksHeet Operations.xls", FileMode.Open);

            //Instantiating a Workbook object
            //Opening the Excel file through the file stream
            Workbook workbook = new Workbook(fstream);

            //Removing a worksheet using its sheet index
            workbook.Worksheets.RemoveAt(1);
            workbook.Save(MyDir + "WorksHeet Operations.xls");
        }
    }
}
