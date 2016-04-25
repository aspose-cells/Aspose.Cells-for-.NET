using System.IO;
using Aspose.Cells;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.SmartMarkers
{
    public class UsingGenericList
    {
        
        public class Husband
        {
            private String m_Name;

            public String Name
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

            internal Husband(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            //Accepting a generic List as a Nested Object
            private List<Wife> m_Wives;

            public List<Wife> Wives
            {
                get { return m_Wives; }
                set { m_Wives = value; }
            }

        }

        public class Wife
        {
            public Wife(string name, int age)
            {
                this.m_name = name;
                this.m_age = age;
            }

            private string m_name;

            public string Name
            {
                get { return m_name; }
                set { m_name = value; }
            }
            private int m_age;

            public int Age
            {
                get { return m_age; }
                set { m_age = value; }
            }
        }

        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook();
            
            //Create a designer workbook

            //Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells["A1"].PutValue("Husband Name");
            worksheet.Cells["A2"].PutValue("&=Husband.Name");

            worksheet.Cells["B1"].PutValue("Husband Age");
            worksheet.Cells["B2"].PutValue("&=Husband.Age");

            worksheet.Cells["C1"].PutValue("Wife's Name");
            worksheet.Cells["C2"].PutValue("&=Husband.Wives.Name");

            worksheet.Cells["D1"].PutValue("Wife's Age");
            worksheet.Cells["D2"].PutValue("&=Husband.Wives.Age");

            //Apply Style to A1:D1
            Range range = worksheet.Cells.CreateRange("A1:D1");
            Style style = workbook.CreateStyle();
            style.Font.IsBold = true;
            style.ForegroundColor = Color.Yellow;
            style.Pattern = BackgroundType.Solid;
            StyleFlag flag = new StyleFlag();
            flag.All = true;
            range.ApplyStyle(style, flag);

            //Initialize WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();

            //Load the template file
            designer.Workbook = workbook;

            System.Collections.Generic.List<Husband> list = new System.Collections.Generic.List<Husband>();

            //Create an object for the Husband class
            Husband h1 = new Husband("Mark John", 30);

            //Create the relevant Wife objects for the Husband object
            h1.Wives = new List<Wife>();
            h1.Wives.Add(new Wife("Chen Zhao", 34));
            h1.Wives.Add(new Wife("Jamima Winfrey", 28));
            h1.Wives.Add(new Wife("Reham Smith", 35));

            //Create another object for the Husband class
            Husband h2 = new Husband("Masood Shankar", 40);

            //Create the relevant Wife objects for the Husband object
            h2.Wives = new List<Wife>();
            h2.Wives.Add(new Wife("Karishma Jathool", 36));
            h2.Wives.Add(new Wife("Angela Rose", 33));
            h2.Wives.Add(new Wife("Hina Khanna", 45));

            //Add the objects to the list
            list.Add(h1);
            list.Add(h2);

            //Specify the DataSource
            designer.SetDataSource("Husband", list);

            //Process the markers
            designer.Process();

            //Autofit columns
            worksheet.AutoFitColumns();

            //Save the Excel file.
            designer.Workbook.Save(dataDir + "output.xlsx");

            //ExEnd:1
        }
    }
}