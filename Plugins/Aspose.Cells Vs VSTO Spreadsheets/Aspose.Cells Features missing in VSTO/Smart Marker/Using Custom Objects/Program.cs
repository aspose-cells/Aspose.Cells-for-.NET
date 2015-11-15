using System.Collections.Generic;
using Aspose.Cells;

namespace Using_Custom_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Instantiate the workbookdesigner object.
            WorkbookDesigner report = new WorkbookDesigner();
            //Get the first worksheet(default sheet) in the workbook.
            Aspose.Cells.Worksheet w = report.Workbook.Worksheets[0];

            //Input some markers to the cells.
            w.Cells["A1"].PutValue("Test");
            w.Cells["A2"].PutValue("&=MyProduct.Name");
            w.Cells["B2"].PutValue("&=MyProduct.Age");

            //Instantiate the list collection based on the custom class.
            IList<MyProduct> list = new List<MyProduct>();
            //Provide values for the markers using the custom class object.
            list.Add(new MyProduct("Simon", 30));
            list.Add(new MyProduct("Johnson", 33));

            //Set the data source.
            report.SetDataSource("MyProduct", list);

            //Process the markers.
            report.Process(false);

            //Save the excel file.
            report.Workbook.Save(MyDir + "Smart Marker Customobjects.xls");
        }
    }
    //Definition of Custom class.
    public class MyProduct
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
        internal MyProduct(string name, int age)
        {
            this.m_Name = name;
            this.m_Age = age;
        }

    }
}
