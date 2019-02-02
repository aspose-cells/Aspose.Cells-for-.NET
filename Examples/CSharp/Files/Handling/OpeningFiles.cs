using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningFiles
    {
        public static void Main()
        {
            // Exstart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // 1.
            // Opening through Path
            // Creating a Workbook object and opening an Excel file using its file path
            Workbook workbook1 = new Workbook(dataDir + "Book1.xls");
            Console.WriteLine("Workbook opened using path successfully!");


            // 2.
            // Opening through Stream
            // Create a Stream object
            FileStream fstream = new FileStream(dataDir + "Book2.xls", FileMode.Open);

            // Creating a Workbook object, open the file from a Stream object
            // That contains the content of file and it should support seeking
            Workbook workbook2 = new Workbook(fstream);
            Console.WriteLine("Workbook opened using stream successfully!");
            fstream.Close();


            // 3.
            // Opening Microsoft Excel 97 - 2003 Files
            // Get the Excel file into stream
            FileStream stream = new FileStream(dataDir + "Book_Excel97_2003.xls", FileMode.Open);

            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions1 = new LoadOptions(LoadFormat.Excel97To2003);

            // Create a Workbook object and opening the file from the stream
            Workbook wbExcel97 = new Workbook(stream, loadOptions1);
            Console.WriteLine("Microsoft Excel 97 - 2003 workbook opened successfully!");


            // 4.
            // Opening Microsoft Excel 2007 Xlsx Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions2 = new LoadOptions(LoadFormat.Xlsx);

            // Create a Workbook object and opening the file from its path
            Workbook wbExcel2007 = new Workbook(dataDir + "Book_Excel2007.xlsx", loadOptions2);
            Console.WriteLine("Microsoft Excel 2007 workbook opened successfully!");


            // 5.
            // Opening SpreadsheetML Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions3 = new LoadOptions(LoadFormat.SpreadsheetML);

            // Create a Workbook object and opening the file from its path
            Workbook wbSpreadSheetML = new Workbook(dataDir + "Book3.xml", loadOptions3);
            Console.WriteLine("SpreadSheetML file opened successfully!");


            // 6.
            // Opening CSV Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions4 = new LoadOptions(LoadFormat.CSV);

            // Create a Workbook object and opening the file from its path
            Workbook wbCSV = new Workbook(dataDir + "Book_CSV.csv", loadOptions4);
            Console.WriteLine("CSV file opened successfully!");


            // 7.
            // Opening Tab Delimited Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions5 = new LoadOptions(LoadFormat.TabDelimited);

            // Create a Workbook object and opening the file from its path
            Workbook wbTabDelimited = new Workbook(dataDir + "Book1TabDelimited.txt", loadOptions5);
            Console.WriteLine("Tab delimited file opened successfully!");


            // 8.
            // Opening Encrypted Excel Files
            // Instantiate LoadOptions
            LoadOptions loadOptions6 = new LoadOptions();

            // Specify the password
            loadOptions6.Password = "1234";

            // Create a Workbook object and opening the file from its path
            Workbook wbEncrypted = new Workbook(dataDir + "encryptedBook.xls", loadOptions6);
            Console.WriteLine("Encrypted excel file opened successfully!");


            // 9.
            // Opening File with Data only
            // Load only specific sheets with data and formulas
            // Other objects, items etc. would be discarded

            // Instantiate LoadOptions specified by the LoadFormat
            LoadOptions loadOptions7 = new LoadOptions(LoadFormat.Xlsx);

            // Load only cell data, formulas & formatting
            loadOptions7.LoadFilter = new LoadFilter(LoadDataFilterOptions.CellData);

            // Create a Workbook object and opening the file from its path
            Workbook wb = new Workbook(dataDir + "Book1.xlsx", loadOptions7);


            // 10.
            // Opening Excel95/5.0 XLS Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptionsExcel95 = new LoadOptions(LoadFormat.Auto);

            // Create a Workbook object and opening the file from its path
            Workbook wbExcel95 = new Workbook(dataDir + "Excel95_5.0.xls", loadOptionsExcel95);

            Console.WriteLine("Excel95/5.0 XLS opened successfully!");
            // ExEnd:1
        }
    }
}
