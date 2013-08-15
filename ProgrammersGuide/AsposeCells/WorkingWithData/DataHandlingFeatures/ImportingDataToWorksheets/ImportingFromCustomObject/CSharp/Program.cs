//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Collections.Generic;

namespace ImportingFromCustomObject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook
            Workbook book = new Workbook();

            Worksheet sheet= book.Worksheets[0];

            //Define List
            List<Person> list = new List<Person>();

            list.Add(new Person("Mike", 25));
            list.Add(new Person("Steve", 30));
            list.Add(new Person("Billy", 35));



            ImportTableOptions imp = new ImportTableOptions();
            imp.InsertRows = true;

            //We pick a few columns not all to import to the worksheet
            //We pick a few columns not all to import to the worksheet
            sheet.Cells.ImportCustomObjects((System.Collections.ICollection)list,
            new string[] { "Name","Age" },
            true,
            0,
            0,
            list.Count,
            true,
            "dd/mm/yyyy",
            false);

            //Auto-fit all the columns
            book.Worksheets[0].AutoFitColumns();

            //Save the Excel file
            book.Save(dataDir + "ImportedCustomObjects.xls");

        }
    }

    class Person
    {
        // Auto-implemented properties. 
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }

}