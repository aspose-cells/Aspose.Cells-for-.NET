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

namespace Aspose.Cells.Examples.Articles
{
    public class ExportVisibleRowsData
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir+ "aspose-sample.xlsx";

            //Load the source workbook
            Workbook workbook = new Workbook(filePath);

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Specify export table options
            ExportTableOptions exportOptions = new ExportTableOptions();
            exportOptions.PlotVisibleRows = true;
            exportOptions.ExportColumnName = true;

            //Export the data from worksheet with export options
            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, 10, 4, exportOptions);
            
            
        }
    }
}