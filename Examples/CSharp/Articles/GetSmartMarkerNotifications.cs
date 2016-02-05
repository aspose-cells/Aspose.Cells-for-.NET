using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    class GetSmartMarkerNotifications
    {
        static void Main() {
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string outputPath = dataDir + "Output.out.xlsx";

            //Instantiate a new Workbook designer
            WorkbookDesigner designer = new WorkbookDesigner();
            /**********************************************************************
            //Get the first worksheet of the workbook
            Worksheet sheet = report.Workbook.Worksheets[0];
            
            //Set the Variable Array marker to a cell
            //You may also place this Smart Marker into a template file manually using Excel and then open this file via WorkbookDesigner
            sheet.Cells.Get("A1").PutValue("&=$VariableArray");

            //Set the data source for the marker(s)
            report.DataSource("VariableArray", new String[] { "English", "Arabic", "Hindi", "Urdu", "French" });

            //Set the CallBack property
            report.CallBack(new SmartMarkerCallBack(report.Workbook));

            //Process the markers
            report.Process(false);

            //Save the result
            report.Workbook.Save(outputPath);
            *******************************************/
            Console.WriteLine("File saved {0}", outputPath);
        }
    }

    class SmartMarkerCallBack: ISmartMarkerCallBack
    {
        Workbook workbook;

        public SmartMarkerCallBack(Workbook workbook) {
            this.workbook = workbook;
        }

        public void Process(int sheetIndex, int rowIndex, int colIndex, String tableName, String columnName) {
            Console.WriteLine("Processing Cell: " + workbook.Worksheets[sheetIndex].Name + "!" + CellsHelper.CellIndexToName(rowIndex, colIndex));
            Console.WriteLine("Processing Marker: " + tableName + "." + columnName);
        }
    }
}
