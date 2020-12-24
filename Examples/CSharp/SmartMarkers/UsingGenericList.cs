using System.IO;
using Aspose.Cells;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.CSharp.SmartMarkers
{
    public class UsingGenericList
    {

      public  class Person
        {
            int _age;
            string _name;
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;
                }
            }
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            public Person(string name, int age)
            {
                _age = age;
                _name = name;
            }
            // ExEnd:1
        }

        public class Teacher : Person
        {


            public Teacher(string name, int age) : base(name, age)
            {
                m_students = new List<Person>();
            }
            private IList<Person> m_students;

            public IList<Person> Students
            {
                get { return m_students; }
                set { m_students = value; }
            }
        }

        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook();

            // Create a designer workbook

            // Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells["A1"].PutValue("Teacher Name");
            worksheet.Cells["A2"].PutValue("&=Teacher.Name");

            worksheet.Cells["B1"].PutValue("Teacher Age");
            worksheet.Cells["B2"].PutValue("&=Teacher.Age");

            worksheet.Cells["C1"].PutValue("Student Name");
            worksheet.Cells["C2"].PutValue("&=Teacher.Students.Name");

            worksheet.Cells["D1"].PutValue("Student Age");
            worksheet.Cells["D2"].PutValue("&=Teacher.Students.Age");

            // Apply Style to A1:D1
            Range range = worksheet.Cells.CreateRange("A1:D1");
            Style style = workbook.CreateStyle();
            style.Font.IsBold = true;
            style.ForegroundColor = Color.Yellow;
            style.Pattern = BackgroundType.Solid;
            StyleFlag flag = new StyleFlag();
            flag.All = true;
            range.ApplyStyle(style, flag);

            // Initialize WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();

            // Load the template file
            designer.Workbook = workbook;

            System.Collections.Generic.List<Teacher> list = new System.Collections.Generic.List<Teacher>();

            // Create an object for the Teacher class
            Teacher h1 = new Teacher("Mark John", 30);

            // Create the relevant student objects for the Teacher object
            h1.Students = new List<Person>();
            h1.Students.Add(new Person("Chen Zhao", 14));
            h1.Students.Add(new Person("Jamima Winfrey", 18));
            h1.Students.Add(new Person("Reham Smith", 15));

            // Create another object for the Teacher class
            Teacher h2 = new Teacher("Masood Shankar", 40);

            // Create the relevant student objects for the Teacher object
            h2.Students = new List<Person>();
            h2.Students.Add(new Person("Karishma Jathool", 16));
            h2.Students.Add(new Person("Angela Rose", 13));
            h2.Students.Add(new Person("Hina Khanna", 15));

            // Add the objects to the list
            list.Add(h1);
            list.Add(h2);

            // Specify the DataSource
            designer.SetDataSource("Teacher", list);

            // Process the markers
            designer.Process();

            // Autofit columns
            worksheet.AutoFitColumns();

            // Save the Excel file.
            designer.Workbook.Save(dataDir + "output.xlsx");

            // ExEnd:1
        }
    }
}