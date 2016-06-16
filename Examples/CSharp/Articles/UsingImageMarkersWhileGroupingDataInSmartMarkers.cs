using System;
using System.IO;
using System.Collections.Generic;

using Aspose.Cells;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    // ExStart:UsingImageMarkersWhileGroupingDataInSmartMarkers
    public class UsingImageMarkersWhileGroupingDataInSmartMarkers
    {

        class Person
        {
            // Create Name, City and Photo properties
            private string m_Name;
            private string m_City;
            private byte[] m_Photo;

            public Person(string name, string city, byte[] photo)
            {
                m_Name = name;
                m_City = city;
                m_Photo = photo;
            }

            public string Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }

            public string City
            {
                get { return m_City; }
                set { m_City = value; }
            }

            public byte[] Photo
            {
                get { return m_Photo; }
                set { m_Photo = value; }
            }

        }

        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Get the images
            byte[] photo1 = File.ReadAllBytes(dataDir + "moon.png");
            byte[] photo2 = File.ReadAllBytes(dataDir + "moon2.png");

            // Create a new workbook and access its worksheet
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the standard row height to 35
            worksheet.Cells.StandardHeight = 35;

            // Set column widhts of D, E and F
            worksheet.Cells.SetColumnWidth(3, 20);
            worksheet.Cells.SetColumnWidth(4, 20);
            worksheet.Cells.SetColumnWidth(5, 40);

            // Add the headings in columns D, E and F
            worksheet.Cells["D1"].PutValue("Name");
            Style st = worksheet.Cells["D1"].GetStyle();
            st.Font.IsBold = true;
            worksheet.Cells["D1"].SetStyle(st);

            worksheet.Cells["E1"].PutValue("City");
            worksheet.Cells["E1"].SetStyle(st);

            worksheet.Cells["F1"].PutValue("Photo");
            worksheet.Cells["F1"].SetStyle(st);

            // Add smart marker tags in columns D, E, F
            worksheet.Cells["D2"].PutValue("&=Person.Name(group:normal,skip:1)");
            worksheet.Cells["E2"].PutValue("&=Person.City");
            worksheet.Cells["F2"].PutValue("&=Person.Photo(Picture:FitToCell)");

            // Create Persons objects with photos
            List<Person> persons = new List<Person>();
            persons.Add(new Person("George", "New York", photo1));
            persons.Add(new Person("George", "New York", photo2));
            persons.Add(new Person("George", "New York", photo1));
            persons.Add(new Person("George", "New York", photo2));
            persons.Add(new Person("Johnson", "London", photo2));
            persons.Add(new Person("Johnson", "London", photo1));
            persons.Add(new Person("Johnson", "London", photo2));
            persons.Add(new Person("Simon", "Paris", photo1));
            persons.Add(new Person("Simon", "Paris", photo2));
            persons.Add(new Person("Simon", "Paris", photo1));
            persons.Add(new Person("Henry", "Sydney", photo2));
            persons.Add(new Person("Henry", "Sydney", photo1));
            persons.Add(new Person("Henry", "Sydney", photo2));

            // Create a workbook designer
            WorkbookDesigner designer = new WorkbookDesigner(workbook);

            // Set the data source and process smart marker tags
            designer.SetDataSource("Person", persons);
            designer.Process();

            // Save the workbook
            workbook.Save(dataDir + "UsingImageMarkersWhileGroupingDataInSmartMarkers.xlsx", SaveFormat.Xlsx);
                   
        }

    }
    // ExEnd:UsingImageMarkersWhileGroupingDataInSmartMarkers    
}
