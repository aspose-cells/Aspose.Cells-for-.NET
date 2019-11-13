using Aspose.Cells.Rendering;
using Aspose.Cells.WebExtensions;
using System;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class ICellsDataTableDataSourceForWorkbookDesigner
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            CustomerList customers = new CustomerList();
            customers.Add(new Customer("Thomas Hardy", "120 Hanover Sq., London"));
            customers.Add(new Customer("Paolo Accorti", "Via Monte Bianco 34, Torino"));

            Workbook workbook = new Workbook(sourceDir + "SmartMarker1.xlsx");

            WorkbookDesigner designer = new WorkbookDesigner(workbook);

            designer.SetDataSource("Customer", new CustomerDataSource(customers));

            designer.Process();

            workbook.Save(outputDir + "dest.xlsx");
            // ExEnd:1

            Console.WriteLine("ICellsDataTableDataSourceForWorkbookDesigner executed successfully.");
        }
    }

    // ExStart:2
    public class CustomerDataSource : ICellsDataTable
    {
        public CustomerDataSource(CustomerList customers)
        {
            this.m_DataSource = customers;
            this.m_Properties = customers[0].GetType().GetProperties();
            this.m_Columns = new string[this.m_Properties.Length];
            this.m_PropHash = new Hashtable(this.m_Properties.Length);

            for (int i = 0; i < m_Properties.Length; i++)
            {
                this.m_Columns[i] = m_Properties[i].Name;
                this.m_PropHash.Add(m_Properties[i].Name, m_Properties[i]);
            }
            this.m_IEnumerator = this.m_DataSource.GetEnumerator();
        }

        internal string[] m_Columns;
        internal ICollection m_DataSource;
        private Hashtable m_PropHash;
        private IEnumerator m_IEnumerator;
        private System.Reflection.PropertyInfo[] m_Properties;

        public string[] Columns
        {
            get
            {
                return this.m_Columns;
            }
        }

        public int Count
        {
            get
            {
                return this.m_DataSource.Count;
            }
        }

        public void BeforeFirst()
        {
            this.m_IEnumerator = this.m_DataSource.GetEnumerator();
        }

        public object this[int index]
        {
            get
            {
                return this.m_Properties[index].GetValue(this.m_IEnumerator.Current, null);
            }
        }

        public object this[string columnName]
        {
            get
            {
                return ((System.Reflection.PropertyInfo)this.m_PropHash[columnName]).GetValue(this.m_IEnumerator.Current, null);
            }
        }

        public bool Next()
        {
            if (this.m_IEnumerator == null)
                return false;

            return this.m_IEnumerator.MoveNext();
        }
    }

    public class Customer
    {
        public Customer(string aFullName, string anAddress)
        {
            FullName = aFullName;
            Address = anAddress;
        }

        public string FullName { get; set; }

        public string Address { get; set; }
    }

    public class CustomerList : ArrayList
    {
        public new Customer this[int index]
        {
            get { return (Customer)base[index]; }
            set { base[index] = value; }
        }
    }
    // ExEnd:2
}
