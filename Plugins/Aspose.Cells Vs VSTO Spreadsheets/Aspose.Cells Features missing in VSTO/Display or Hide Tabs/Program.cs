using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display_or_Hide_Tabs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            //Opening the Excel file
            Workbook workbook = new Workbook("C:\\book1.xls");

            //Hiding the tabs of the Excel file
            workbook.Settings.ShowTabs = false;

            //Adjusting the sheet tab bar width
            workbook.Settings.SheetTabBarWidth = 800;

            //Saving the modified Excel file
            workbook.Save("C:\\output.xls");
        }
    }
}
