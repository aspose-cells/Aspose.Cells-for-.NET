Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningFiles
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)



            ' 1.
            ' Opening through Path
            'Creating a Workbook object and opening an Excel file using its file path
            Dim workbook1 As New Workbook(dataDir & "Book1.xls")
            Console.WriteLine("Workbook opened using path successfully!")


            ' 2.
            ' Opening through Stream
            'Create a Stream object
            Dim fstream As New FileStream(dataDir & "Book2.xls", FileMode.Open)

            'Creating a Workbook object, open the file from a Stream object
            'that contains the content of file and it should support seeking
            Dim workbook2 As New Workbook(fstream)
            Console.WriteLine("Workbook opened using stream successfully!")
            fstream.Close()


            ' 3.
            ' Opening Microsoft Excel 97 - 2003 Files
            'Get the Excel file into stream
            Dim stream As New FileStream(dataDir & "Book_Excel97_2003.xls", FileMode.Open)

            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions1 As New LoadOptions(LoadFormat.Excel97To2003)

            'Create a Workbook object and opening the file from the stream
            Dim wbExcel97 As New Workbook(stream, loadOptions1)
            Console.WriteLine("Microsoft Excel 97 - 2003 workbook opened successfully!")


            ' 4.
            ' Opening Microsoft Excel 2007 Xlsx Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions2 As New LoadOptions(LoadFormat.Xlsx)

            'Create a Workbook object and opening the file from its path
            Dim wbExcel2007 As New Workbook(dataDir & "Book_Excel2007.xlsx", loadOptions2)
            Console.WriteLine("Microsoft Excel 2007 workbook opened successfully!")


            ' 5.
            ' Opening SpreadsheetML Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions3 As New LoadOptions(LoadFormat.SpreadsheetML)

            'Create a Workbook object and opening the file from its path
            Dim wbSpreadSheetML As New Workbook(dataDir & "Book3.xml", loadOptions3)
            Console.WriteLine("SpreadSheetML file opened successfully!")


            ' 6.
            ' Opening CSV Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions4 As New LoadOptions(LoadFormat.CSV)

            'Create a Workbook object and opening the file from its path
            Dim wbCSV As New Workbook(dataDir & "Book_CSV.csv", loadOptions4)
            Console.WriteLine("CSV file opened successfully!")


            ' 7.
            ' Opening Tab Delimited Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions5 As New LoadOptions(LoadFormat.TabDelimited)

            'Create a Workbook object and opening the file from its path
            Dim wbTabDelimited As New Workbook(dataDir & "Book1TabDelimited.txt", loadOptions5)
            Console.WriteLine("Tab delimited file opened successfully!")


            ' 8.
            ' Opening Encrypted Excel Files
            'Instantiate LoadOptions
            Dim loadOptions6 As New LoadOptions()

            'Specify the password
            loadOptions6.Password = "1234"

            'Create a Workbook object and opening the file from its path
            Dim wbEncrypted As New Workbook(dataDir & "encryptedBook.xls", loadOptions6)
            Console.WriteLine("Encrypted excel file opened successfully!")


            ' 9.
            ' Opening File with Data only
            'Load only specific sheets with data and formulas
            'Other objects, items etc. would be discarded

            'Instantiate LoadOptions specified by the LoadFormat
            Dim loadOptions7 As New LoadOptions(LoadFormat.Xlsx)

            'Set the LoadDataOption
            Dim dataOption As New LoadDataOption()
            'Specify the sheet(s) in the template file to be loaded
            dataOption.SheetNames = New String() {"Sheet2"}
            dataOption.ImportFormula = True
            'Only data should be loaded.
            loadOptions7.LoadDataOnly = True
            'Specify the LoadDataOption
            loadOptions7.LoadDataOptions = dataOption

            'Create a Workbook object and opening the file from its path
            Dim wb As New Workbook(dataDir & "Book1.xlsx", loadOptions7)
            Console.WriteLine("File data imported successfully!")
        End Sub
    End Class
End Namespace