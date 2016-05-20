// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System.Data;
using System.Data.OleDb;

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
            string FileName = FilePath + "Grouping Data OLE DB.xlsx";
            //Create a connection object, specify the provider info and set the data source.
            OleDbConnection con = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=~\\..\\..\\..\\Data\\Northwind.mdb");

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
            wd.Workbook = new Workbook(FileName);

            //Set the datatable as the data source.
            wd.SetDataSource(dt);

            //Process the smart markers to fill the data into the worksheets.
            wd.Process(true);

            //Save the excel file.
            wd.Workbook.Save(FileName);
 
        }
    }
}
