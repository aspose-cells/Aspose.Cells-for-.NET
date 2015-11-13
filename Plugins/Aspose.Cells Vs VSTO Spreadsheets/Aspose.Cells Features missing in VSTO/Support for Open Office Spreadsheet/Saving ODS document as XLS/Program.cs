using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
namespace Saving_ODS_document_as_XLS
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenOfficeSpreadsheet();
            SaveAsOpenOfficeSpreadsheet();
            
        }
        static void OpenOfficeSpreadsheet()
        {
             string MyDir = @"Files\";
            Workbook workbook = new Workbook(MyDir+"sample.ods");
            workbook.Save(MyDir + "Converted from ODS to XLS.xlsx",SaveFormat.Xlsx);
        }
        static void SaveAsOpenOfficeSpreadsheet()
        {
            string MyDir = @"sFiles\";
            Workbook workbook = new Workbook(MyDir + "Excel Test file.xlsx");
            workbook.Save(MyDir + "Converted from XLS to ODS.ods", SaveFormat.ODS);
        }
    }
}
