using System.IO;

using Aspose.Cells;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.Data.Handling.Importing
{
    public class ImportingFromCustomObject
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            Age = age;
            Name = name;
        }
    }

}