// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System.Data;
using System.IO;

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
            string FileName = FilePath + "Image Markers.xlsx";
            
            //Get the image data.
            byte[] imageData = File.ReadAllBytes(FilePath + "Aspose.Cells.png");
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
            //imageData = File.ReadAllBytes(FilePath + "Desert.jpg");
            //row = t.NewRow();
            //row[0] = imageData;
            //t.Rows.Add(row);

            //Create WorkbookDesigner object.
            WorkbookDesigner designer = new WorkbookDesigner();
            //Open the temple Excel file.
            designer.Workbook = new Workbook(FileName);
            //Set the datasource.
            designer.SetDataSource(t);
            //Process the markers.
            designer.Process();
            //Save the Excel file.
            designer.Workbook.Save(FileName);
        }
    }
}
