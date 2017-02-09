using System.IO;

using Aspose.Cells;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers
{
    // ExStart:1
    // Definition of Custom class.
    public class Person
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private int m_Age;

        public int Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }
        internal Person(string name, int age)
        {
            this.m_Name = name;
            this.m_Age = age;
        }
    }
    // ExEnd:2

    public class UsingAnonymousTypes
    {
        public static void Run()
        {
            // ExStart:2
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate the workbookdesigner object.
            WorkbookDesigner report = new WorkbookDesigner();
            // Get the first worksheet(default sheet) in the workbook.
            Aspose.Cells.Worksheet sheet = report.Workbook.Worksheets[0];

            // Input some markers to the cells.
            sheet.Cells["A1"].PutValue("Name");
            sheet.Cells["B1"].PutValue("Age");
            sheet.Cells["A2"].PutValue("&=MyProduct.Name");
            sheet.Cells["B2"].PutValue("&=MyProduct.Age");

            // Instantiate the list collection based on the custom class.
            IList<Person> list = new List<Person>();
            // Provide values for the markers using the custom class object.
            list.Add(new Person("Simon", 30));
            list.Add(new Person("Johnson", 33));

            // Set the data source.
            report.SetDataSource("MyProduct", list);

            // Process the markers.
            report.Process(false);

            // Save the excel file.
            report.Workbook.Save(dataDir + "Smart Marker Customobjects.xls");
            // ExEnd:2
        }
    }
}