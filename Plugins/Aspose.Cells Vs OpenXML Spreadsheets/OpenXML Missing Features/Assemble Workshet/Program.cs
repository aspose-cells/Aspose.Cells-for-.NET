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
            AddingWorksheetToNewExcelFile();
            AddingWorksheetToDesignerSpreadsheet();
            AccesingWorsheetUsingSheetName();
            RemovingWorksheet();
            RemovingWorksheetUsingIndex();
        }
        public static void AddingWorksheetToNewExcelFile()
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet";

            //Saving the Excel file
            workbook.Save(MyDir + "WorksHeet Operations.xls");
        }
        public static void AddingWorksheetToDesignerSpreadsheet()
        {
            //Creating a file stream containing the Excel file to be opened
            FileStream fstream = new FileStream(MyDir + "WorksHeet Operations.xls", FileMode.Open);

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
