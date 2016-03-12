using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class SaveInExcel2007xlsbFormat
    {
        public static void Main(string[] args)
        {
        //Save in Excel2007 xlsb format
            workbook.Save(dataDir + "book1.out.xlsb", SaveFormat.Xlsb);   
            //ExEnd:1
        }
    }
  }
