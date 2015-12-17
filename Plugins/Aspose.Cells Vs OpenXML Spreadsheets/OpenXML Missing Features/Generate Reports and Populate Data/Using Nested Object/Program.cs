// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using Aspose.Cells;

namespace Using_Nested_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Initialize WorkbookDesigner object
            WorkbookDesigner designer = new WorkbookDesigner();
            //Load the template file
            designer.Workbook = new Workbook(MyDir+"SM_NestedObjects.xlsx");
            //Instantiate the List based on the class
            System.Collections.Generic.ICollection<Individual> list = new System.Collections.Generic.List<Individual>();
            //Create an object for the Individual class
            Individual p1 = new Individual("Damian", 30);
            //Create the relevant Wife class for the Individual
            p1.Wife = new Wife("Dalya", 28);
            //Create another object for the Individual class
            Individual p2 = new Individual("Mack", 31);
            //Create the relevant Wife class for the Individual
            p2.Wife = new Wife("Maaria", 29);
            //Add the objects to the list
            list.Add(p1);
            list.Add(p2);
            //Specify the DataSource
            designer.SetDataSource("Individual", list);
            //Process the markers
            designer.Process(false);
            //Save the Excel file.
            designer.Workbook.Save(MyDir+"out_SM_NestedObjects.xlsx");
        }
    }
    class Individual
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
        internal Individual(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        private Wife m_Wife;

        public Wife Wife
        {
            get { return m_Wife; }
            set { m_Wife = value; }
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
}
