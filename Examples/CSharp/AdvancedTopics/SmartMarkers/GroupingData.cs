//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.AdvancedTopics.SmartMarkers
{
    public class GroupingData
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a connection object, specify the provider info and set the data source.
            OleDbConnection con = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\\test\\Northwind.mdb");

            //Open the connection object.
            con.Open();

            //Create a command object and specify the SQL query.
            OleDbCommand cmd = new OleDbCommand("Select * from [Order Details]", con);

            //Create a data adapter object.
            OleDbDataAdapter da = new OleDbDataAdapter();

            //Specify the command.
            da.SelectCommand = cmd;

            //Create a dataset object.
            DataSet ds = new DataSet();

            //Fill the dataset with the table records.
            da.Fill(ds, "Order Details");

            //Create a datatable with respect to dataset table.
            DataTable dt = ds.Tables["Order Details"];

            //Create WorkbookDesigner object.
            WorkbookDesigner wd = new WorkbookDesigner();

            //Open the template file (which contains smart markers).
            wd.Workbook = new Workbook(dataDir+ "TestSmartMarkers.xlsx");

            //Set the datatable as the data source.
            wd.SetDataSource(dt);

            //Process the smart markers to fill the data into the worksheets.
            wd.Process(true);

            //Save the excel file.
            wd.Workbook.Save(dataDir+ "outSmartMarker_Designer.xlsx");
            
            
        }
    }

		class OleDbCommand
    {
        private string p;
        private OleDbConnection con;

        public OleDbCommand(string p, OleDbConnection con)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.con = con;
        }
    }

    class OleDbConnection
    {
        private string p;

        public OleDbConnection(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        internal void Open()
        {
            
        }
    }

    class OleDbDataAdapter
    {
        public OleDbCommand SelectCommand { get; set; }

        internal void Fill(System.Data.DataSet ds, string p)
        {
           
        }
    }
}