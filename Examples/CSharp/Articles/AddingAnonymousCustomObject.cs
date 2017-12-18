using System.IO;
using Aspose.Cells;
using System;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddingAnonymousCustomObject
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a designer workbook
            WorkbookDesigner designer = new WorkbookDesigner();

            // Get worksheet Cells collection
            Cells cells = designer.Workbook.Worksheets[0].Cells;

            // Set Cell Values
            cells["A1"].PutValue("Name");
            cells["B1"].PutValue("Age");

            // Set markers
            cells["A2"].PutValue("&=Person.Name");
            cells["B2"].PutValue("&=Person.Age");

            // Create Array list
            ArrayList list = new ArrayList();

            // Add custom objects to the list
            list.Add(new Person("Simon", 30));
            list.Add(new Person("Johnson", 33));
            list.Add(new Person("Peter", 36));
            list.Add(new Person("Roy", 32));
            list.Add(new Person("James", 37));
            list.Add(new Person("Michael", 38));
            list.Add(new Person("George", 34));

            // Add designer's datasource
            designer.SetDataSource("Person", list);

            // Process designer
            designer.Process();

            // Save the resultant file
            designer.Workbook.Save(outputDir + "outputAddingAnonymousCustomObject.xlsx");

            Console.WriteLine("AddingAnonymousCustomObject executed successfully.\r\n");
        }
    }
}

public class Person
{
    String m_Name;
    int m_Age;

    internal Person(string name, int age)
    {
        this.m_Name = name;
        this.m_Age = age;
    }

    public String Name
    {
        get { return this.m_Name; }
    }

    public int Age
    {
        get { return this.m_Age; }
    }
}

