// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System.Data;
using System.IO;
using Aspose.Cells;

namespace Image_Markers
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Get the image data.
            byte[] imageData = File.ReadAllBytes(MyDir + "Thumbnail.jpg");
            //Create a datatable.
            DataTable t = new DataTable("Table1");
            //Add a column to save pictures.
            DataColumn dc = t.Columns.Add("Picture");
            //Set its data type.
            dc.DataType = typeof(object);

            //Add a new new record to it.
            DataRow row = t.NewRow();
            row[0] = imageData;
            t.Rows.Add(row);

            //Add another record (having picture) to it.
            imageData = File.ReadAllBytes(MyDir + "Desert.jpg");
            row = t.NewRow();
            row[0] = imageData;
            t.Rows.Add(row);

            //Create WorkbookDesigner object.
            WorkbookDesigner designer = new WorkbookDesigner();
            //Open the temple Excel file.
            designer.Workbook = new Workbook(MyDir + "ImageSmartBook.xls");
            //Set the datasource.
            designer.SetDataSource(t);
            //Process the markers.
            designer.Process();
            //Save the Excel file.
            designer.Workbook.Save(MyDir + "out_ImageSmartBook.xls");
        }
    }
}
