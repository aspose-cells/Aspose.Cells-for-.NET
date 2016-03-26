using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class OpeningMicrosoftExcel97-2003Files
    {
        public static void Main(string[] args)
        {
        //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
              //Get the Excel file into stream
            FileStream stream = new FileStream(dataDir + "Book_Excel97_2003.xls", FileMode.Open);

            //Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions1 = new LoadOptions(LoadFormat.Excel97To2003);

            //Create a Workbook object and opening the file from the stream
            Workbook wbExcel97 = new Workbook(stream, loadOptions1);
            Console.WriteLine("Microsoft Excel 97 - 2003 workbook opened successfully!");
            //ExEnd:1
            }
          }
      }
