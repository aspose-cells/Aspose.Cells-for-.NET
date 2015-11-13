using System;
using System.Collections.Generic;
using System.Text;

namespace Conversion_from_xlsx_to_xls
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            Workbook workbook = new Workbook(MyDir + "Sample.xls");
            workbook.Save(MyDir + "Converted.xlsx", SaveFormat.Xlsx);
        }
    }
}
