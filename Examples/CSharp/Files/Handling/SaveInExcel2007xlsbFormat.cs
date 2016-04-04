using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveInExcel2007xlsbFormat
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Creating a Workbook object
            Workbook workbook = new Workbook();
        //Save in Excel2007 xlsb format
            workbook.Save(dataDir + "output.xlsb", SaveFormat.Xlsb);   
            //ExEnd:1
        }
    }
  }
