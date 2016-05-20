// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System.Collections.Generic;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Using Custom Objects.xlsx";
            
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
            report.Workbook.Save(FileName);
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
