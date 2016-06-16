using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers

{
    public class CopyStyleWithSmartMarker
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create Students DataTable
            DataTable dtStudent = new DataTable("Student");

            // Define a field in it
            DataColumn dcName = new DataColumn("Name", typeof(string));
            dtStudent.Columns.Add(dcName);
            dtStudent.Columns.Add(new DataColumn("Age", typeof(int)));

            // Add three rows to it
            DataRow drName1 = dtStudent.NewRow();
            DataRow drName2 = dtStudent.NewRow();
            DataRow drName3 = dtStudent.NewRow();

            drName1["Name"] = "John";
            drName1["Age"] = 23;
            drName2["Name"] = "Jack";
            drName2["Age"] = 24;
            drName3["Name"] = "James";
            drName3["Age"] = 32;

            dtStudent.Rows.Add(drName1);
            dtStudent.Rows.Add(drName2);
            dtStudent.Rows.Add(drName3);
            
            string filePath = dataDir + "Template.xlsx";

            // Create a workbook from Smart Markers template file
            Workbook workbook = new Workbook(filePath);

            // Instantiate a new WorkbookDesigner
            WorkbookDesigner designer = new WorkbookDesigner();

            // Specify the Workbook
            designer.Workbook = workbook;

            // Set the Data Source
            designer.SetDataSource(dtStudent);

            // Process the smart markers
            designer.Process();

            // Save the Excel file
            workbook.Save(dataDir + "output.xlsx", SaveFormat.Xlsx);
            // ExEnd:1

        }
    }
}
