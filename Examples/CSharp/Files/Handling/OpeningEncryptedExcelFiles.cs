using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningEncryptedExcelFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate LoadOptions
            LoadOptions loadOptions6 = new LoadOptions();

            // Specify the password
            loadOptions6.Password = "1234";

            // Create a Workbook object and opening the file from its path
            Workbook wbEncrypted = new Workbook(dataDir + "encryptedBook.xls", loadOptions6);
            Console.WriteLine("Encrypted excel file opened successfully!");
            // ExEnd:1
            }
          }
        }
