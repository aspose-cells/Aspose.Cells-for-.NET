//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System;
using System.Collections;

namespace Aspose.Cells.Examples.Articles
{
    public class AddingAnonymousCustomObject
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

           // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

        //Open a designer workbook
WorkbookDesigner designer = new WorkbookDesigner();

//get worksheet Cells collection
Cells cells = designer.Workbook.Worksheets[0].Cells;

//Set Cell Values
cells["A1"].PutValue("Name");
cells["B1"].PutValue("Age");

//Set markers
cells["A2"].PutValue("&=Person.Name");
cells["B2"].PutValue("&=Person.Age");

//Create Array list
ArrayList list = new ArrayList();

//add custom objects to the list
list.Add(new Person("Simon", 30));
list.Add(new Person("Johnson", 33));

//add designer's datasource
designer.SetDataSource("Person", list);

//process designer
designer.Process(false);

//save the resultant file
designer.Workbook.Save(dataDir+ "result.xls");
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