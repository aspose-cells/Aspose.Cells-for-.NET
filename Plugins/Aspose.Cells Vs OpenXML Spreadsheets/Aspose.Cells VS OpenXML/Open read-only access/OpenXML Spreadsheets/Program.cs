using DocumentFormat.OpenXml.Packaging;

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Open a spreadsheet document for read-only access.xlsx";
            OpenSpreadsheetDocumentReadonly(FileName);
        }
        public static void OpenSpreadsheetDocumentReadonly(string filepath)
        {
            // Open a SpreadsheetDocument based on a filepath.
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filepath, false))
            {
                // Attempt to add a new WorksheetPart.
                // The call to AddNewPart generates an exception because the file is read-only.
                WorksheetPart newWorksheetPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorksheetPart>();

                // The rest of the code will not be called.
            }
        }
    }
}
