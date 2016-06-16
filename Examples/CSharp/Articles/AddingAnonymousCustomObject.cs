using System.IO;
using Aspose.Cells;
using System;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    // ExStart:1
    public class AddingAnonymousCustomObject
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

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

            // Add designer's datasource
            designer.SetDataSource("Person", list);

            // Process designer
            designer.Process(false);
            dataDir = dataDir + "result.out.xls";
            // Save the resultant file
            designer.Workbook.Save(dataDir);

            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
        }
    }
}

public class Person
{
    public String Name;
    public int Age;
    internal Person(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
// ExEnd:1
